using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

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
            if (!this.Properties.TryGetValue("dimension_values", out JsonElement element))
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
        set
        {
            this.Properties["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string DimensionalPriceGroupID
    {
        get
        {
            if (!this.Properties.TryGetValue("dimensional_price_group_id", out JsonElement element))
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
        set
        {
            this.Properties["dimensional_price_group_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.DimensionValues)
        {
            _ = item;
        }
        _ = this.DimensionalPriceGroupID;
    }

    public DimensionalPriceConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionalPriceConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DimensionalPriceConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
