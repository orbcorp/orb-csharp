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
[JsonConverter(typeof(ModelConverter<ItemSlim, ItemSlimFromRaw>))]
public sealed record class ItemSlim : ModelBase
{
    /// <summary>
    /// The Orb-assigned unique identifier for the item.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The name of the item.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public ItemSlim() { }

    public ItemSlim(ItemSlim itemSlim)
        : base(itemSlim) { }

    public ItemSlim(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemSlim(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemSlimFromRaw.FromRawUnchecked"/>
    public static ItemSlim FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemSlimFromRaw : IFromRaw<ItemSlim>
{
    /// <inheritdoc/>
    public ItemSlim FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ItemSlim.FromRawUnchecked(rawData);
}
