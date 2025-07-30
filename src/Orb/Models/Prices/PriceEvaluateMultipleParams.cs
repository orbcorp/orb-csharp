using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PriceEvaluateMultipleParamsProperties = Orb.Models.Prices.PriceEvaluateMultipleParamsProperties;
using System = System;

namespace Orb.Models.Prices;

/// <summary>
/// This endpoint is used to evaluate the output of price(s) for a given customer
/// and time range over ingested events. It enables filtering and grouping the output
/// using [computed properties](/extensibility/advanced-metrics#computed-properties),
/// supporting the following workflows:
///
/// 1. Showing detailed usage and costs to the end customer. 2. Auditing subtotals
/// on invoice line items.
///
/// For these workflows, the expressiveness of computed properties in both the filters
/// and grouping is critical. For example, if you'd like to show your customer their
/// usage grouped by hour and another property, you can do so with the following `grouping_keys`:
/// `["hour_floor_timestamp_millis(timestamp_millis)", "my_property"]`. If you'd
/// like to examine a customer's usage for a specific property value, you can do
/// so with the following `filter`: `my_property = 'foo' AND my_other_property = 'bar'`.
///
/// Prices may either reference existing prices in your Orb account or be defined
/// inline in the request body. Up to 100 prices can be evaluated in a single request.
///
/// Prices are evaluated on ingested events and the start of the time range must be
/// no more than 100 days ago. To evaluate based off a set of provided events, the
/// [evaluate preview events](/api-reference/price/evaluate-preview-events) endpoint
/// can be used instead.
///
/// Note that this is a POST endpoint rather than a GET endpoint because it employs
/// a JSON body rather than query parameters.
/// </summary>
public sealed record class PriceEvaluateMultipleParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The exclusive upper bound for event timestamps
    /// </summary>
    public required System::DateTime TimeframeEnd
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_end", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_end",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.BodyProperties["timeframe_end"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The inclusive lower bound for event timestamps
    /// </summary>
    public required System::DateTime TimeframeStart
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_start", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.BodyProperties["timeframe_start"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["customer_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The external customer ID of the customer to which this evaluation is scoped.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["external_customer_id"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// List of prices to evaluate (max 100)
    /// </summary>
    public List<PriceEvaluateMultipleParamsProperties::PriceEvaluation>? PriceEvaluations
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price_evaluations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PriceEvaluateMultipleParamsProperties::PriceEvaluation>?>(
                element
            );
        }
        set { this.BodyProperties["price_evaluations"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/prices/evaluate")
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
