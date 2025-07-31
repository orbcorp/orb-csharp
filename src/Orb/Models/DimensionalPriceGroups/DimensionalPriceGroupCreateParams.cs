using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Orb.Models.DimensionalPriceGroups;

/// <summary>
/// A dimensional price group is used to partition the result of a billable metric
/// by a set of dimensions. Prices in a price group must specify the parition used
/// to derive their usage.
///
/// For example, suppose we have a billable metric that measures the number of widgets
/// used and we want to charge differently depending on the color of the widget. We
/// can create a price group with a dimension "color" and two prices: one that charges
/// \$10 per red widget and one that charges \$20 per blue widget.
/// </summary>
public sealed record class DimensionalPriceGroupCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string BillableMetricID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billable_metric_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "billable_metric_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("billable_metric_id");
        }
        set
        {
            this.BodyProperties["billable_metric_id"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The set of keys (in order) used to disambiguate prices in the group.
    /// </summary>
    public required List<string> Dimensions
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("dimensions", out JsonElement element))
                throw new ArgumentOutOfRangeException("dimensions", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("dimensions");
        }
        set { this.BodyProperties["dimensions"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? ExternalDimensionalPriceGroupID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "external_dimensional_price_group_id",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["external_dimensional_price_group_id"] =
                JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/dimensional_price_groups")
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
