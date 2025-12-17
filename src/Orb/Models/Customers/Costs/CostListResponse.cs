using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<List<AggregatedCost>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
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

    public CostListResponse(CostListResponse costListResponse)
        : base(costListResponse) { }

    public CostListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public CostListResponse(List<AggregatedCost> data)
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
