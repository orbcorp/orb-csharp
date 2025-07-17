using BillingCycleConfigurationProperties = Orb.Models.BillingCycleConfigurationProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<BillingCycleConfiguration>))]
public sealed record class BillingCycleConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<BillingCycleConfiguration>
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

    public required BillingCycleConfigurationProperties::DurationUnit DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration_unit",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BillingCycleConfigurationProperties::DurationUnit>(
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

    public BillingCycleConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BillingCycleConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BillingCycleConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
