using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// This endpoint allows you to enable an alert. To enable a plan-level alert for
/// a specific subscription, you must include the `subscription_id`. The `subscription_id`
/// is not required for customer or subscription level alerts.
/// </summary>
public sealed record class AlertEnableParams : Orb::ParamsBase
{
    public required string AlertConfigurationID;

    /// <summary>
    /// Used to update the status of a plan alert scoped to this subscription_id
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("subscription_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.QueryProperties["subscription_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/alerts/{0}/enable", this.AlertConfigurationID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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
