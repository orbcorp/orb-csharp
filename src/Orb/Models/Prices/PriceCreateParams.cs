using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PriceCreateParamsProperties = Orb.Models.Prices.PriceCreateParamsProperties;
using System = System;

namespace Orb.Models.Prices;

/// <summary>
/// This endpoint is used to create a [price](/product-catalog/price-configuration).
/// A price created using this endpoint is always an add-on, meaning that it's not
/// associated with a specific plan and can instead be individually added to subscriptions,
/// including subscriptions on different plans.
///
/// An `external_price_id` can be optionally specified as an alias to allow ergonomic
/// interaction with prices in the Orb API.
///
/// See the [Price resource](/product-catalog/price-configuration) for the specification
/// of different price model configurations possible in this endpoint.
/// </summary>
public sealed record class PriceCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required PriceCreateParamsProperties::Body Body
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("body", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("body", "Missing required argument");

            return JsonSerializer.Deserialize<PriceCreateParamsProperties::Body>(element)
                ?? throw new System::ArgumentNullException("body");
        }
        set { this.BodyProperties["body"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/prices")
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
