using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<SubLineItemMatrixConfig>))]
public sealed record class SubLineItemMatrixConfig
    : Orb::ModelBase,
        Orb::IFromRaw<SubLineItemMatrixConfig>
{
    /// <summary>
    /// The ordered dimension values for this line item.
    /// </summary>
    public required Generic::List<string?> DimensionValues
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension_values", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "dimension_values",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string?>>(element)
                ?? throw new System::ArgumentNullException("dimension_values");
        }
        set
        {
            this.Properties["dimension_values"] = Json::JsonSerializer.SerializeToElement(value);
        }
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
    [CodeAnalysis::SetsRequiredMembers]
    SubLineItemMatrixConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubLineItemMatrixConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
