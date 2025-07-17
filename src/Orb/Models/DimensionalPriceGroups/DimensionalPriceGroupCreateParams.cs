using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

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
public sealed record class DimensionalPriceGroupCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string BillableMetricID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "billable_metric_id",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "billable_metric_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("billable_metric_id");
        }
        set
        {
            this.BodyProperties["billable_metric_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The set of keys (in order) used to disambiguate prices in the group.
    /// </summary>
    public required Generic::List<string> Dimensions
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("dimensions", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "dimensions",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("dimensions");
        }
        set { this.BodyProperties["dimensions"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.BodyProperties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? ExternalDimensionalPriceGroupID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "external_dimensional_price_group_id",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["external_dimensional_price_group_id"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Generic::Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string?>?>(element);
        }
        set { this.BodyProperties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/dimensional_price_groups"
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
