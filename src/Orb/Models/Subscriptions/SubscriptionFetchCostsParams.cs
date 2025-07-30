using System.Net.Http;
using System.Text.Json;
using SubscriptionFetchCostsParamsProperties = Orb.Models.Subscriptions.SubscriptionFetchCostsParamsProperties;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint is used to fetch a day-by-day snapshot of a subscription's costs
/// in Orb, calculated by applying pricing information to the underlying usage (see
/// the [subscription usage endpoint](fetch-subscription-usage) to fetch usage per
/// metric, in usage units rather than a currency).
///
/// The semantics of this endpoint exactly mirror those of [fetching a customer's
/// costs](fetch-customer-costs). Use this endpoint to limit your analysis of costs
/// to a specific subscription for the customer (e.g. to de-aggregate costs when a
/// customer's subscription has started and stopped on the same day).
/// </summary>
public sealed record class SubscriptionFetchCostsParams : ParamsBase
{
    public required string SubscriptionID;

    /// <summary>
    /// The currency or custom pricing unit to use.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Costs returned are exclusive of `timeframe_end`.
    /// </summary>
    public System::DateTime? TimeframeEnd
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("timeframe_end", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.QueryProperties["timeframe_end"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Costs returned are inclusive of `timeframe_start`.
    /// </summary>
    public System::DateTime? TimeframeStart
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("timeframe_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.QueryProperties["timeframe_start"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Controls whether Orb returns cumulative costs since the start of the billing
    /// period, or incremental day-by-day costs. If your customer has minimums or discounts,
    /// it's strongly recommended that you use the default cumulative behavior.
    /// </summary>
    public SubscriptionFetchCostsParamsProperties::ViewMode? ViewMode
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("view_mode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionFetchCostsParamsProperties::ViewMode?>(
                element
            );
        }
        set { this.QueryProperties["view_mode"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/costs", this.SubscriptionID)
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
