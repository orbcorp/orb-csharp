using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PriceEvaluatePreviewEventsParamsProperties = Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties;
using System = System;

namespace Orb.Models.Prices;

/// <summary>
/// This endpoint evaluates prices on preview events instead of actual usage, making
/// it ideal for building price calculators and cost estimation tools. You can filter
/// and group results using [computed properties](/extensibility/advanced-metrics#computed-properties)
/// to analyze pricing across different dimensions.
///
/// Prices may either reference existing prices in your Orb account or be defined
/// inline in the request body. The endpoint has the following limitations: 1. Up
/// to 100 prices can be evaluated in a single request. 2. Up to 500 preview events
/// can be provided in a single request.
///
/// A top-level customer_id is required to evaluate the preview events. Additionally,
/// all events without a customer_id will have the top-level customer_id added.
///
/// Note that this is a POST endpoint rather than a GET endpoint because it employs
/// a JSON body rather than query parameters.
/// </summary>
public sealed record class PriceEvaluatePreviewEventsParams : ParamsBase
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
    /// List of preview events to use instead of actual usage data
    /// </summary>
    public List<PriceEvaluatePreviewEventsParamsProperties::Event>? Events
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("events", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PriceEvaluatePreviewEventsParamsProperties::Event>?>(
                element
            );
        }
        set { this.BodyProperties["events"] = JsonSerializer.SerializeToElement(value); }
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
    public List<PriceEvaluatePreviewEventsParamsProperties::PriceEvaluation>? PriceEvaluations
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price_evaluations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PriceEvaluatePreviewEventsParamsProperties::PriceEvaluation>?>(
                element
            );
        }
        set { this.BodyProperties["price_evaluations"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/prices/evaluate_preview_events"
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
