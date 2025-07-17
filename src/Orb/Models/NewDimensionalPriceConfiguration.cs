using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<NewDimensionalPriceConfiguration>))]
public sealed record class NewDimensionalPriceConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<NewDimensionalPriceConfiguration>
{
    /// <summary>
    /// The list of dimension values matching (in order) the dimensions of the price group
    /// </summary>
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

    /// <summary>
    /// The id of the dimensional price group to include this price in
    /// </summary>
    public string? DimensionalPriceGroupID
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "dimensional_price_group_id",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["dimensional_price_group_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The external id of the dimensional price group to include this price in
    /// </summary>
    public string? ExternalDimensionalPriceGroupID
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "external_dimensional_price_group_id",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_dimensional_price_group_id"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        foreach (var item in this.DimensionValues)
        {
            _ = item;
        }
        _ = this.DimensionalPriceGroupID;
        _ = this.ExternalDimensionalPriceGroupID;
    }

    public NewDimensionalPriceConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    NewDimensionalPriceConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewDimensionalPriceConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
