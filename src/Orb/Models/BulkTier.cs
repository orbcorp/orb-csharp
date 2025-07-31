using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BulkTier>))]
public sealed record class BulkTier : ModelBase, IFromRaw<BulkTier>
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "unit_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("unit_amount");
        }
        set { this.Properties["unit_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Upper bound for this tier
    /// </summary>
    public double? MaximumUnits
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_units", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["maximum_units"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.MaximumUnits;
    }

    public BulkTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkTier(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkTier FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
