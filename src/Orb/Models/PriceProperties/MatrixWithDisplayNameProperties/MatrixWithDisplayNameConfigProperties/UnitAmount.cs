using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.PriceProperties.MatrixWithDisplayNameProperties.MatrixWithDisplayNameConfigProperties;

/// <summary>
/// Configuration for a unit amount item
/// </summary>
[JsonConverter(typeof(ModelConverter<UnitAmount>))]
public sealed record class UnitAmount : ModelBase, IFromRaw<UnitAmount>
{
    /// <summary>
    /// The dimension value
    /// </summary>
    public required string DimensionValue
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension_value", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "dimension_value",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("dimension_value");
        }
        set
        {
            this.Properties["dimension_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Display name for this dimension value
    /// </summary>
    public required string DisplayName
    {
        get
        {
            if (!this.Properties.TryGetValue("display_name", out JsonElement element))
                throw new ArgumentOutOfRangeException("display_name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("display_name");
        }
        set
        {
            this.Properties["display_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount1
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
        _ = this.DimensionValue;
        _ = this.DisplayName;
        _ = this.UnitAmount1;
    }

    public UnitAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitAmount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnitAmount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
