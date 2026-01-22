using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// A minimal representation of an Item containing only the essential identifying information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ItemSlim, ItemSlimFromRaw>))]
public sealed record class ItemSlim : JsonModel
{
    /// <summary>
    /// The Orb-assigned unique identifier for the item.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The name of the item.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public ItemSlim() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemSlim(ItemSlim itemSlim)
        : base(itemSlim) { }
#pragma warning restore CS8618

    public ItemSlim(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemSlim(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemSlimFromRaw.FromRawUnchecked"/>
    public static ItemSlim FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemSlimFromRaw : IFromRawJson<ItemSlim>
{
    /// <inheritdoc/>
    public ItemSlim FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ItemSlim.FromRawUnchecked(rawData);
}
