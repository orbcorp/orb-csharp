using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint is used to update the trial end date for a subscription. The new
/// trial end date must be within the time range of the current plan (i.e. the new
/// trial end date must be on or after the subscription's start date on the current
/// plan, and on or before the subscription end date).
///
/// In order to retroactively remove a trial completely, the end date can be set to
/// the transition date of the subscription to this plan (or, if this is the first
/// plan for this subscription, the subscription's start date). In order to end a
/// trial immediately, the keyword `immediate` can be provided as the trial end date.
///
/// By default, Orb will shift only the trial end date (and price intervals that start
/// or end on the previous trial end date), and leave all other future price intervals
/// untouched. If the `shift` parameter is set to `true`, Orb will shift all subsequent
/// price and adjustment intervals by the same amount as the trial end date shift
/// (so, e.g., if a plan change is scheduled or an add-on price was added, that change
/// will be pushed back by the same amount of time the trial is extended).
/// </summary>
public sealed record class SubscriptionUpdateTrialParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// The new date that the trial should end, or the literal string `immediate`
    /// to end the trial immediately.
    /// </summary>
    public required TrialEndDate TrialEndDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("trial_end_date", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "trial_end_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<TrialEndDate>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("trial_end_date");
        }
        set
        {
            this.BodyProperties["trial_end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, shifts subsequent price and adjustment intervals (preserving their
    /// durations, but adjusting their absolute dates).
    /// </summary>
    public bool? Shift
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("shift", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["shift"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/update_trial", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
