using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<DimensionalPriceConfiguration>))]
public sealed record class DimensionalPriceConfiguration
    : ModelBase,
        IFromRaw<DimensionalPriceConfiguration>
{
    public required List<string> DimensionValues
    {
        get
        {
            if (!this._properties.TryGetValue("dimension_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dimension_values",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new System::ArgumentNullException("dimension_values")
                );
        }
        init
        {
            this._properties["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string DimensionalPriceGroupID
    {
        get
        {
            if (
                !this._properties.TryGetValue("dimensional_price_group_id", out JsonElement element)
            )
                throw new OrbInvalidDataException(
                    "'dimensional_price_group_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dimensional_price_group_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimensional_price_group_id' cannot be null",
                    new System::ArgumentNullException("dimensional_price_group_id")
                );
        }
        init
        {
            this._properties["dimensional_price_group_id"] = JsonSerializer.SerializeToElement(
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

    public DimensionalPriceConfiguration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionalPriceConfiguration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static DimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
