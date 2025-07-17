using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<DimensionalPriceConfiguration>))]
public sealed record class DimensionalPriceConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<DimensionalPriceConfiguration>
{
    public required Generic::List<string> DimensionValues
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension_values", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "dimension_values",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("dimension_values");
        }
        set
        {
            this.Properties["dimension_values"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required string DimensionalPriceGroupID
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "dimensional_price_group_id",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "dimensional_price_group_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("dimensional_price_group_id");
        }
        set
        {
            this.Properties["dimensional_price_group_id"] = Json::JsonSerializer.SerializeToElement(
                value
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
    [CodeAnalysis::SetsRequiredMembers]
    DimensionalPriceConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DimensionalPriceConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
