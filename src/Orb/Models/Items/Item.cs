using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    /// <summary>
    /// The Orb-assigned unique identifier for the item.
    /// </summary>
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The time at which the item was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// A list of external connections for this item, used to sync with external invoicing
    /// and tax systems.
    /// </summary>
    public required IReadOnlyList<ItemExternalConnection> ExternalConnections
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<ItemExternalConnection>>(
                "external_connections"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ItemExternalConnection>>(
                "external_connections",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get { return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata"); }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The name of the item.
    /// </summary>
    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The time at which the item was archived. If null, the item is not archived.
    /// </summary>
    public System::DateTimeOffset? ArchivedAt
    {
        get { return this._rawData.GetNullableStruct<System::DateTimeOffset>("archived_at"); }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <inheritdoc/>
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

    public Item(Item item)
        : base(item) { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a connection between an Item and an external system for invoicing
/// or tax calculation purposes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ItemExternalConnection, ItemExternalConnectionFromRaw>))]
public sealed record class ItemExternalConnection : JsonModel
{
    /// <summary>
    /// The name of the external system this item is connected to.
    /// </summary>
    public required ApiEnum<
        string,
        ItemExternalConnectionExternalConnectionName
    > ExternalConnectionName
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ItemExternalConnectionExternalConnectionName>
            >("external_connection_name");
        }
        init { this._rawData.Set("external_connection_name", value); }
    }

    /// <summary>
    /// The identifier of this item in the external system.
    /// </summary>
    public required string ExternalEntityID
    {
        get { return this._rawData.GetNotNullClass<string>("external_entity_id"); }
        init { this._rawData.Set("external_entity_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ExternalConnectionName.Validate();
        _ = this.ExternalEntityID;
    }

    public ItemExternalConnection() { }

    public ItemExternalConnection(ItemExternalConnection itemExternalConnection)
        : base(itemExternalConnection) { }

    public ItemExternalConnection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemExternalConnection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemExternalConnectionFromRaw.FromRawUnchecked"/>
    public static ItemExternalConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemExternalConnectionFromRaw : IFromRawJson<ItemExternalConnection>
{
    /// <inheritdoc/>
    public ItemExternalConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ItemExternalConnection.FromRawUnchecked(rawData);
}

/// <summary>
/// The name of the external system this item is connected to.
/// </summary>
[JsonConverter(typeof(ItemExternalConnectionExternalConnectionNameConverter))]
public enum ItemExternalConnectionExternalConnectionName
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

sealed class ItemExternalConnectionExternalConnectionNameConverter
    : JsonConverter<ItemExternalConnectionExternalConnectionName>
{
    public override ItemExternalConnectionExternalConnectionName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => ItemExternalConnectionExternalConnectionName.Stripe,
            "quickbooks" => ItemExternalConnectionExternalConnectionName.Quickbooks,
            "bill.com" => ItemExternalConnectionExternalConnectionName.BillCom,
            "netsuite" => ItemExternalConnectionExternalConnectionName.Netsuite,
            "taxjar" => ItemExternalConnectionExternalConnectionName.Taxjar,
            "avalara" => ItemExternalConnectionExternalConnectionName.Avalara,
            "anrok" => ItemExternalConnectionExternalConnectionName.Anrok,
            "numeral" => ItemExternalConnectionExternalConnectionName.Numeral,
            _ => (ItemExternalConnectionExternalConnectionName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ItemExternalConnectionExternalConnectionName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ItemExternalConnectionExternalConnectionName.Stripe => "stripe",
                ItemExternalConnectionExternalConnectionName.Quickbooks => "quickbooks",
                ItemExternalConnectionExternalConnectionName.BillCom => "bill.com",
                ItemExternalConnectionExternalConnectionName.Netsuite => "netsuite",
                ItemExternalConnectionExternalConnectionName.Taxjar => "taxjar",
                ItemExternalConnectionExternalConnectionName.Avalara => "avalara",
                ItemExternalConnectionExternalConnectionName.Anrok => "anrok",
                ItemExternalConnectionExternalConnectionName.Numeral => "numeral",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
