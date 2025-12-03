using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Costs;

[JsonConverter(
    typeof(ModelConverter<CostListByExternalIDResponse, CostListByExternalIDResponseFromRaw>)
)]
public sealed record class CostListByExternalIDResponse : ModelBase
{
    public required IReadOnlyList<AggregatedCost> Data
    {
        get { return ModelBase.GetNotNullClass<List<AggregatedCost>>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public CostListByExternalIDResponse() { }

    public CostListByExternalIDResponse(CostListByExternalIDResponse costListByExternalIDResponse)
        : base(costListByExternalIDResponse) { }

    public CostListByExternalIDResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostListByExternalIDResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CostListByExternalIDResponseFromRaw.FromRawUnchecked"/>
    public static CostListByExternalIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CostListByExternalIDResponse(List<AggregatedCost> data)
        : this()
    {
        this.Data = data;
    }
}

class CostListByExternalIDResponseFromRaw : IFromRaw<CostListByExternalIDResponse>
{
    /// <inheritdoc/>
    public CostListByExternalIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CostListByExternalIDResponse.FromRawUnchecked(rawData);
}
