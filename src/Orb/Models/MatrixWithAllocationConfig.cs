using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<MatrixWithAllocationConfig>))]
public sealed record class MatrixWithAllocationConfig
    : ModelBase,
        IFromRaw<MatrixWithAllocationConfig>
{
    /// <summary>
    /// Allocation to be used to calculate the price
    /// </summary>
    public required double Allocation
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "allocation",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["allocation"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Default per unit rate for any usage not bucketed into a specified matrix_value
    /// </summary>
    public required string DefaultUnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("default_unit_amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "default_unit_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("default_unit_amount");
        }
        set { this.Properties["default_unit_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// One or two event property values to evaluate matrix groups by
    /// </summary>
    public required List<string?> Dimensions
    {
        get
        {
            if (!this.Properties.TryGetValue("dimensions", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "dimensions",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<string?>>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("dimensions");
        }
        set { this.Properties["dimensions"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Matrix values for specified matrix grouping keys
    /// </summary>
    public required List<MatrixValue> MatrixValues
    {
        get
        {
            if (!this.Properties.TryGetValue("matrix_values", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "matrix_values",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<MatrixValue>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("matrix_values");
        }
        set { this.Properties["matrix_values"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Allocation;
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

    public MatrixWithAllocationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithAllocationConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MatrixWithAllocationConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
