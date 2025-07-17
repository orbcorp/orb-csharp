using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// Apply a subscription change to perform the intended action. If a positive amount
/// is passed with a request to this endpoint, any eligible invoices that were created
/// will be issued immediately if they only contain in-advance fees.
/// </summary>
public sealed record class SubscriptionChangeApplyParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionChangeID;

    /// <summary>
    /// Description to apply to the balance transaction representing this credit.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["description"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Amount already collected to apply to the customer's balance.
    /// </summary>
    public string? PreviouslyCollectedAmount
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "previously_collected_amount",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["previously_collected_amount"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscription_changes/{0}/apply", this.SubscriptionChangeID)
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
