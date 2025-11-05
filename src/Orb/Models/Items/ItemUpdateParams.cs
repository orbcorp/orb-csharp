using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Items;

/// <summary>
/// This endpoint can be used to update properties on the Item.
/// </summary>
public sealed record class ItemUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ItemID;

    public List<ExternalConnection>? ExternalConnections
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_connections", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ExternalConnection>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["external_connections"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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

    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/items/{0}", this.ItemID)
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

/// <summary>
/// Represents a connection between an Item and an external system for invoicing or
/// tax calculation purposes.
/// </summary>
[JsonConverter(typeof(ModelConverter<ExternalConnection>))]
public sealed record class ExternalConnection : ModelBase, IFromRaw<ExternalConnection>
{
    /// <summary>
    /// The name of the external system this item is connected to.
    /// </summary>
    public required ApiEnum<string, ExternalConnectionName> ExternalConnectionName
    {
        get
        {
            if (!this.Properties.TryGetValue("external_connection_name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'external_connection_name' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "external_connection_name",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ExternalConnectionName>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["external_connection_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The identifier of this item in the external system.
    /// </summary>
    public required string ExternalEntityID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_entity_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'external_entity_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "external_entity_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'external_entity_id' cannot be null",
                    new System::ArgumentNullException("external_entity_id")
                );
        }
        set
        {
            this.Properties["external_entity_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ExternalConnectionName.Validate();
        _ = this.ExternalEntityID;
    }

    public ExternalConnection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnection(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ExternalConnection FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// The name of the external system this item is connected to.
/// </summary>
[JsonConverter(typeof(ExternalConnectionNameConverter))]
public enum ExternalConnectionName
{
    Stripe,
    Quickbooks,
    BillCom,
    Netsuite,
    Taxjar,
    Avalara,
    Anrok,
    Numeral,
}

sealed class ExternalConnectionNameConverter : JsonConverter<ExternalConnectionName>
{
    public override ExternalConnectionName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => ExternalConnectionName.Stripe,
            "quickbooks" => ExternalConnectionName.Quickbooks,
            "bill.com" => ExternalConnectionName.BillCom,
            "netsuite" => ExternalConnectionName.Netsuite,
            "taxjar" => ExternalConnectionName.Taxjar,
            "avalara" => ExternalConnectionName.Avalara,
            "anrok" => ExternalConnectionName.Anrok,
            "numeral" => ExternalConnectionName.Numeral,
            _ => (ExternalConnectionName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalConnectionName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalConnectionName.Stripe => "stripe",
                ExternalConnectionName.Quickbooks => "quickbooks",
                ExternalConnectionName.BillCom => "bill.com",
                ExternalConnectionName.Netsuite => "netsuite",
                ExternalConnectionName.Taxjar => "taxjar",
                ExternalConnectionName.Avalara => "avalara",
                ExternalConnectionName.Anrok => "anrok",
                ExternalConnectionName.Numeral => "numeral",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
