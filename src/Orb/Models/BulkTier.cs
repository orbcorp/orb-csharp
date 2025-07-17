using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<BulkTier>))]
public sealed record class BulkTier : Orb::ModelBase, Orb::IFromRaw<BulkTier>
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "unit_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("unit_amount");
        }
        set { this.Properties["unit_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Upper bound for this tier
    /// </summary>
    public double? MaximumUnits
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_units", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["maximum_units"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.MaximumUnits;
    }

    public BulkTier() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BulkTier(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkTier FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
