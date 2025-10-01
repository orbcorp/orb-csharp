using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

/// <summary>
/// This endpoint can be used to update the `external_dimensional_price_group_id`
/// and `metadata` of an existing dimensional price group. Other fields on a dimensional
/// price group are currently immutable.
/// </summary>
public sealed record class ExternalDimensionalPriceGroupIDUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

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
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["external_dimensional_price_group_id"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
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
        set
        {
            this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
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

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
