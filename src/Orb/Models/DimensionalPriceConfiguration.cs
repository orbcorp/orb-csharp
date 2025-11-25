using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<DimensionalPriceConfiguration, DimensionalPriceConfigurationFromRaw>)
)]
public sealed record class DimensionalPriceConfiguration : ModelBase
{
    public required List<string> DimensionValues
    {
        get
        {
            if (!this._rawData.TryGetValue("dimension_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new ArgumentOutOfRangeException("dimension_values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new ArgumentNullException("dimension_values")
                );
        }
        init
        {
            this._rawData["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string DimensionalPriceGroupID
    {
        get
        {
            if (!this._rawData.TryGetValue("dimensional_price_group_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimensional_price_group_id' cannot be null",
                    new ArgumentOutOfRangeException(
                        "dimensional_price_group_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimensional_price_group_id' cannot be null",
                    new ArgumentNullException("dimensional_price_group_id")
                );
        }
        init
        {
            this._rawData["dimensional_price_group_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.DimensionalPriceGroupID;
    }

    public DimensionalPriceConfiguration() { }

    public DimensionalPriceConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionalPriceConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionalPriceConfigurationFromRaw : IFromRaw<DimensionalPriceConfiguration>
{
    public DimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DimensionalPriceConfiguration.FromRawUnchecked(rawData);
}
