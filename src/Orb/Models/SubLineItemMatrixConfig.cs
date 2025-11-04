using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubLineItemMatrixConfig>))]
public sealed record class SubLineItemMatrixConfig : ModelBase, IFromRaw<SubLineItemMatrixConfig>
{
    /// <summary>
    /// The ordered dimension values for this line item.
    /// </summary>
    public required List<string?> DimensionValues
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new ArgumentOutOfRangeException("dimension_values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string?>>(element, ModelBase.SerializerOptions)
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

    public override void Validate()
    {
        _ = this.DimensionValues;
    }

    public SubLineItemMatrixConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubLineItemMatrixConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubLineItemMatrixConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SubLineItemMatrixConfig(List<string?> dimensionValues)
        : this()
    {
        this.DimensionValues = dimensionValues;
    }
}
