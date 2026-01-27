using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Costs;

[JsonConverter(typeof(JsonModelConverter<CostListResponse, CostListResponseFromRaw>))]
public sealed record class CostListResponse : JsonModel
{
    public required IReadOnlyList<AggregatedCost> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AggregatedCost>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AggregatedCost>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public CostListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostListResponse(CostListResponse costListResponse)
        : base(costListResponse) { }
#pragma warning restore CS8618

    public CostListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CostListResponseFromRaw.FromRawUnchecked"/>
    public static CostListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CostListResponse(IReadOnlyList<AggregatedCost> data)
        : this()
    {
        this.Data = data;
    }
}

class CostListResponseFromRaw : IFromRawJson<CostListResponse>
{
    /// <inheritdoc/>
    public CostListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CostListResponse.FromRawUnchecked(rawData);
}
