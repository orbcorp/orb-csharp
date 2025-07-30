using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using ItemUpdateParamsProperties = Orb.Models.Items.ItemUpdateParamsProperties;

namespace Orb.Models.Items;

/// <summary>
/// This endpoint can be used to update properties on the Item.
/// </summary>
public sealed record class ItemUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ItemID;

    public List<ItemUpdateParamsProperties::ExternalConnection>? ExternalConnections
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_connections", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ItemUpdateParamsProperties::ExternalConnection>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["external_connections"] = JsonSerializer.SerializeToElement(value);
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

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(element);
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/items/{0}", this.ItemID)
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
