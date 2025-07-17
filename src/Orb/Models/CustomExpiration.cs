using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using CustomExpirationProperties = Orb.Models.CustomExpirationProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<CustomExpiration>))]
public sealed record class CustomExpiration : Orb::ModelBase, Orb::IFromRaw<CustomExpiration>
{
    public required long Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["duration"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required CustomExpirationProperties::DurationUnit DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration_unit",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CustomExpirationProperties::DurationUnit>(
                    element
                ) ?? throw new System::ArgumentNullException("duration_unit");
        }
        set { this.Properties["duration_unit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Duration;
        this.DurationUnit.Validate();
    }

    public CustomExpiration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    CustomExpiration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomExpiration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
