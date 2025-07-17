using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<MatrixConfig>))]
public sealed record class MatrixConfig : Orb::ModelBase, Orb::IFromRaw<MatrixConfig>
{
    /// <summary>
    /// Default per unit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("default_unit_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "default_unit_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("default_unit_amount");
        }
        set
        {
            this.Properties["default_unit_amount"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required Generic::List<string?> Dimensions
    {
        get
        {
            if (!this.Properties.TryGetValue("dimensions", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "dimensions",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string?>>(element)
                ?? throw new System::ArgumentNullException("dimensions");
        }
        set { this.Properties["dimensions"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Matrix values for specified matrix grouping keys
    /// </summary>
    public required Generic::List<MatrixValue> MatrixValues
    {
        get
        {
            if (!this.Properties.TryGetValue("matrix_values", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "matrix_values",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<MatrixValue>>(element)
                ?? throw new System::ArgumentNullException("matrix_values");
        }
        set { this.Properties["matrix_values"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.DefaultUnitAmount;
        foreach (var item in this.Dimensions)
        {
            _ = item;
        }
        foreach (var item in this.MatrixValues)
        {
            item.Validate();
        }
    }

    public MatrixConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    MatrixConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MatrixConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
