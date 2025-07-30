using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewDimensionalPriceConfiguration>))]
public sealed record class NewDimensionalPriceConfiguration
    : ModelBase,
        IFromRaw<NewDimensionalPriceConfiguration>
{
    /// <summary>
    /// The list of dimension values matching (in order) the dimensions of the price group
    /// </summary>
    public required List<string> DimensionValues
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension_values", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "dimension_values",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<string>>(element)
                ?? throw new System::ArgumentNullException("dimension_values");
        }
        set { this.Properties["dimension_values"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the dimensional price group to include this price in
    /// </summary>
    public string? DimensionalPriceGroupID
    {
        get
        {
            if (!this.Properties.TryGetValue("dimensional_price_group_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["dimensional_price_group_id"] = JsonSerializer.SerializeToElement(
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
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_dimensional_price_group_id"] =
                JsonSerializer.SerializeToElement(value);
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
    [SetsRequiredMembers]
    NewDimensionalPriceConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewDimensionalPriceConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
