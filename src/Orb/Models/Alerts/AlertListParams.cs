using System.Net.Http;
using System.Text.Json;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// This endpoint returns a list of alerts within Orb.
///
/// The request must specify one of `customer_id`, `external_customer_id`, or `subscription_id`.
///
/// If querying by subscripion_id, the endpoint will return the subscription level
/// alerts as well as the plan level alerts associated with the subscription.
///
/// The list of alerts is ordered starting from the most recently created alert.
/// This endpoint follows Orb's [standardized pagination format](/api-reference/pagination).
/// </summary>
public sealed record class AlertListParams : ParamsBase
{
    public System::DateTime? CreatedAtGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.QueryProperties["created_at[gt]"] = JsonSerializer.SerializeToElement(value); }
    }

    public System::DateTime? CreatedAtGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.QueryProperties["created_at[gte]"] = JsonSerializer.SerializeToElement(value); }
    }

    public System::DateTime? CreatedAtLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.QueryProperties["created_at[lt]"] = JsonSerializer.SerializeToElement(value); }
    }

    public System::DateTime? CreatedAtLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.QueryProperties["created_at[lte]"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Fetch alerts scoped to this customer_id
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["customer_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Fetch alerts scoped to this external_customer_id
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.QueryProperties["external_customer_id"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Fetch alerts scoped to this subscription_id
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("subscription_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["subscription_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/alerts")
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
