using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

/// <summary>
/// This endpoint can be used to update the `external_dimensional_price_group_id`
/// and `metadata` of an existing dimensional price group. Other fields on a dimensional
/// price group are currently immutable.
/// </summary>
public sealed record class ExternalDimensionalPriceGroupIDUpdateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string ExternalDimensionalPriceGroupID;

    /// <summary>
    /// An optional user-defined ID for this dimensional price group resource, used
    /// throughout the system as an alias for this dimensional price group. Use this
    /// field to identify a dimensional price group by an existing identifier in your system.
    /// </summary>
    public string? ExternalDimensionalPriceGroupID1
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
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/dimensional_price_groups/external_dimensional_price_group_id/{0}",
                    this.ExternalDimensionalPriceGroupID
                )
        )
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
