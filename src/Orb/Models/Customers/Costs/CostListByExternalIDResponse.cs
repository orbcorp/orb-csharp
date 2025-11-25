using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Customers.Costs;

[JsonConverter(
    typeof(ModelConverter<CostListByExternalIDResponse, CostListByExternalIDResponseFromRaw>)
)]
public sealed record class CostListByExternalIDResponse : ModelBase
{
    public required List<AggregatedCost> Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<AggregatedCost>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public CostListByExternalIDResponse() { }

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
    public CostListByExternalIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CostListByExternalIDResponse.FromRawUnchecked(rawData);
}
