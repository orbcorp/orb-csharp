using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

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
                throw new System::ArgumentOutOfRangeException(
                    "dimension_values",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<string?>>(element)
                ?? throw new System::ArgumentNullException("dimension_values");
        }
        set { this.Properties["dimension_values"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.DimensionValues)
        {
            _ = item;
        }
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
}
