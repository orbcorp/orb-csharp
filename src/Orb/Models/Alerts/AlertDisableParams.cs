using System.Net.Http;
using System.Text.Json;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// This endpoint allows you to disable an alert. To disable a plan-level alert for
/// a specific subscription, you must include the `subscription_id`. The `subscription_id`
/// is not required for customer or subscription level alerts.
/// </summary>
public sealed record class AlertDisableParams : ParamsBase
{
    public required string AlertConfigurationID;

    /// <summary>
    /// Used to update the status of a plan alert scoped to this subscription_id
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("subscription_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["subscription_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/alerts/{0}/disable", this.AlertConfigurationID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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
