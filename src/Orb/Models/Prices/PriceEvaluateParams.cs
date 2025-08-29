using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Orb.Models.Prices;

/// <summary>
/// [NOTE] It is recommended to use the `/v1/prices/evaluate` which offers further
/// functionality, such as multiple prices, inline price definitions, and querying
/// over preview events.
///
/// This endpoint is used to evaluate the output of a price for a given customer
/// and time range. It enables filtering and grouping the output using [computed
/// properties](/extensibility/advanced-metrics#computed-properties), supporting
/// the following workflows:
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
/// By default, the start of the time range must be no more than 100 days ago and
/// the length of the results must be no greater than 1000. Note that this is a POST
/// endpoint rather than a GET endpoint because it employs a JSON body rather than
/// query parameters.
/// </summary>
public sealed record class PriceEvaluateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string PriceID;

    /// <summary>
    /// The exclusive upper bound for event timestamps
    /// </summary>
    public required DateTime TimeframeEnd
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_end", out JsonElement element))
                throw new ArgumentOutOfRangeException("timeframe_end", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["timeframe_end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The inclusive lower bound for event timestamps
    /// </summary>
    public required DateTime TimeframeStart
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timeframe_start", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the underlying billable metric
    /// </summary>
    public string? Filter
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Properties (or [computed properties](/extensibility/advanced-metrics#computed-properties))
    /// used to group the underlying billable metric
    /// </summary>
    public List<string>? GroupingKeys
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("grouping_keys", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["grouping_keys"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/prices/{0}/evaluate", this.PriceID)
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
