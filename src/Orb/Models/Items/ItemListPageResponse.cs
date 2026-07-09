using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Items;

[JsonConverter(typeof(JsonModelConverter<ItemListPageResponse, ItemListPageResponseFromRaw>))]
public sealed record class ItemListPageResponse : JsonModel
{
    public required IReadOnlyList<Item> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationMetadata>("pagination_metadata");
        }
        init { this._rawData.Set("pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public ItemListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemListPageResponse(ItemListPageResponse itemListPageResponse)
        : base(itemListPageResponse) { }
#pragma warning restore CS8618

    public ItemListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemListPageResponseFromRaw.FromRawUnchecked"/>
    public static ItemListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemListPageResponseFromRaw : IFromRawJson<ItemListPageResponse>
{
    /// <inheritdoc/>
    public ItemListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ItemListPageResponse.FromRawUnchecked(rawData);
}
