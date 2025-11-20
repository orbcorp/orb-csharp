using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Items;

/// <summary>
/// The Item resource represents a sellable product or good. Items are associated
/// with all line items, billable metrics, and prices and are used for defining external
/// sync behavior for invoices and tax calculation purposes.
/// </summary>
[JsonConverter(typeof(ModelConverter<Item>))]
public sealed record class Item : ModelBase, IFromRaw<Item>
{
    /// <summary>
    /// The Orb-assigned unique identifier for the item.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time at which the item was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of external connections for this item, used to sync with external invoicing
    /// and tax systems.
    /// </summary>
    public required List<ExternalConnectionModel> ExternalConnections
    {
        get
        {
            if (!this._rawData.TryGetValue("external_connections", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'external_connections' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "external_connections",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<ExternalConnectionModel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'external_connections' cannot be null",
                    new System::ArgumentNullException("external_connections")
                );
        }
        init
        {
            this._rawData["external_connections"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time at which the item was archived. If null, the item is not archived.
    /// </summary>
    public System::DateTimeOffset? ArchivedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("archived_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["archived_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        foreach (var item in this.ExternalConnections)
        {
            item.Validate();
        }
        _ = this.Metadata;
        _ = this.Name;
        _ = this.ArchivedAt;
    }

    public Item() { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// Represents a connection between an Item and an external system for invoicing
/// or tax calculation purposes.
/// </summary>
[JsonConverter(typeof(ModelConverter<ExternalConnectionModel>))]
public sealed record class ExternalConnectionModel : ModelBase, IFromRaw<ExternalConnectionModel>
{
    /// <summary>
    /// The name of the external system this item is connected to.
    /// </summary>
    public required ApiEnum<
        string,
        ExternalConnectionModelExternalConnectionName
    > ExternalConnectionName
    {
        get
        {
            if (!this._rawData.TryGetValue("external_connection_name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'external_connection_name' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "external_connection_name",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ExternalConnectionModelExternalConnectionName>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_connection_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("external_entity_id", out JsonElement element))
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
        init
        {
            this._rawData["external_entity_id"] = JsonSerializer.SerializeToElement(
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

    public ExternalConnectionModel() { }

    public ExternalConnectionModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ExternalConnectionModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// The name of the external system this item is connected to.
/// </summary>
[JsonConverter(typeof(ExternalConnectionModelExternalConnectionNameConverter))]
public enum ExternalConnectionModelExternalConnectionName
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

sealed class ExternalConnectionModelExternalConnectionNameConverter
    : JsonConverter<ExternalConnectionModelExternalConnectionName>
{
    public override ExternalConnectionModelExternalConnectionName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => ExternalConnectionModelExternalConnectionName.Stripe,
            "quickbooks" => ExternalConnectionModelExternalConnectionName.Quickbooks,
            "bill.com" => ExternalConnectionModelExternalConnectionName.BillCom,
            "netsuite" => ExternalConnectionModelExternalConnectionName.Netsuite,
            "taxjar" => ExternalConnectionModelExternalConnectionName.Taxjar,
            "avalara" => ExternalConnectionModelExternalConnectionName.Avalara,
            "anrok" => ExternalConnectionModelExternalConnectionName.Anrok,
            "numeral" => ExternalConnectionModelExternalConnectionName.Numeral,
            _ => (ExternalConnectionModelExternalConnectionName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalConnectionModelExternalConnectionName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalConnectionModelExternalConnectionName.Stripe => "stripe",
                ExternalConnectionModelExternalConnectionName.Quickbooks => "quickbooks",
                ExternalConnectionModelExternalConnectionName.BillCom => "bill.com",
                ExternalConnectionModelExternalConnectionName.Netsuite => "netsuite",
                ExternalConnectionModelExternalConnectionName.Taxjar => "taxjar",
                ExternalConnectionModelExternalConnectionName.Avalara => "avalara",
                ExternalConnectionModelExternalConnectionName.Anrok => "anrok",
                ExternalConnectionModelExternalConnectionName.Numeral => "numeral",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
