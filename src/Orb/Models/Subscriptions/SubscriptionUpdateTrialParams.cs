using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using SubscriptionUpdateTrialParamsProperties = Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties;
using System = System;
using Text = System.Text;

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
public sealed record class SubscriptionUpdateTrialParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// The new date that the trial should end, or the literal string `immediate` to
    /// end the trial immediately.
    /// </summary>
    public required SubscriptionUpdateTrialParamsProperties::TrialEndDate TrialEndDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("trial_end_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "trial_end_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<SubscriptionUpdateTrialParamsProperties::TrialEndDate>(
                    element
                ) ?? throw new System::ArgumentNullException("trial_end_date");
        }
        set
        {
            this.BodyProperties["trial_end_date"] = Json::JsonSerializer.SerializeToElement(value);
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
            if (!this.BodyProperties.TryGetValue("shift", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.BodyProperties["shift"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/update_trial", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new Http::StringContent(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
