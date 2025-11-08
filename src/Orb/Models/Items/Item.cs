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
            if (!this._properties.TryGetValue("id", out JsonElement element))
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
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time at which the item was created.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_connections", out JsonElement element))
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
            this._properties["external_connections"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
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
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time at which the item was archived. If null, the item is not archived.
    /// </summary>
    public System::DateTime? ArchivedAt
    {
        get
        {
            if (!this._properties.TryGetValue("archived_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["archived_at"] = JsonSerializer.SerializeToElement(
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

    public Item(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
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
    public required ApiEnum<string, ExternalConnectionNameModel> ExternalConnectionName
    {
        get
        {
            if (!this._properties.TryGetValue("external_connection_name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'external_connection_name' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "external_connection_name",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ExternalConnectionNameModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["external_connection_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_entity_id", out JsonElement element))
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
            this._properties["external_entity_id"] = JsonSerializer.SerializeToElement(
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

    public ExternalConnectionModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ExternalConnectionModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The name of the external system this item is connected to.
/// </summary>
[JsonConverter(typeof(ExternalConnectionNameModelConverter))]
public enum ExternalConnectionNameModel
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

sealed class ExternalConnectionNameModelConverter : JsonConverter<ExternalConnectionNameModel>
{
    public override ExternalConnectionNameModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => ExternalConnectionNameModel.Stripe,
            "quickbooks" => ExternalConnectionNameModel.Quickbooks,
            "bill.com" => ExternalConnectionNameModel.BillCom,
            "netsuite" => ExternalConnectionNameModel.Netsuite,
            "taxjar" => ExternalConnectionNameModel.Taxjar,
            "avalara" => ExternalConnectionNameModel.Avalara,
            "anrok" => ExternalConnectionNameModel.Anrok,
            "numeral" => ExternalConnectionNameModel.Numeral,
            _ => (ExternalConnectionNameModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalConnectionNameModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalConnectionNameModel.Stripe => "stripe",
                ExternalConnectionNameModel.Quickbooks => "quickbooks",
                ExternalConnectionNameModel.BillCom => "bill.com",
                ExternalConnectionNameModel.Netsuite => "netsuite",
                ExternalConnectionNameModel.Taxjar => "taxjar",
                ExternalConnectionNameModel.Avalara => "avalara",
                ExternalConnectionNameModel.Anrok => "anrok",
                ExternalConnectionNameModel.Numeral => "numeral",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
