using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TierConfig>))]
public sealed record class TierConfig : Orb::ModelBase, Orb::IFromRaw<TierConfig>
{
    public required double FirstUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("first_unit", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "first_unit",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["first_unit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double? LastUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("last_unit", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "last_unit",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["last_unit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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

    public override void Validate()
    {
        _ = this.FirstUnit;
        _ = this.LastUnit;
        _ = this.UnitAmount;
    }

    public TierConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TierConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TierConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
