using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.MatrixWithAllocationConfigProperties;

/// <summary>
/// Configuration for a single matrix value
/// </summary>
[JsonConverter(typeof(ModelConverter<MatrixValue>))]
public sealed record class MatrixValue : ModelBase, IFromRaw<MatrixValue>
{
    /// <summary>
    /// One or two matrix keys to filter usage to this Matrix value by. For example,
    /// ["region", "tier"] could be used to filter cloud usage by a cloud region and
    /// an instance tier.
    /// </summary>
    public required List<string?> DimensionValues
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension_values", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "dimension_values",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<string?>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("dimension_values");
        }
        set
        {
            this.Properties["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unit price for the specified dimension_values
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("unit_amount", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("unit_amount");
        }
        set
        {
            this.Properties["unit_amount"] = JsonSerializer.SerializeToElement(
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
        _ = this.UnitAmount;
    }

    public MatrixValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixValue(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MatrixValue FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
