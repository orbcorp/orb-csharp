using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using PriceCreateParamsProperties = Orb.Models.Prices.PriceCreateParamsProperties;
using System = System;
using Text = System.Text;

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
public sealed record class PriceCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required PriceCreateParamsProperties::Body Body
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("body", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("body", "Missing required argument");

            return Json::JsonSerializer.Deserialize<PriceCreateParamsProperties::Body>(element)
                ?? throw new System::ArgumentNullException("body");
        }
        set { this.BodyProperties["body"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/prices")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
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
