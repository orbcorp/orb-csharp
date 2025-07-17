using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<NewBillingCycleConfiguration>))]
public sealed record class NewBillingCycleConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<NewBillingCycleConfiguration>
{
    /// <summary>
    /// The duration of the billing period.
    /// </summary>
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

    /// <summary>
    /// The unit of billing period duration.
    /// </summary>
    public required NewBillingCycleConfigurationProperties::DurationUnit DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration_unit",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<NewBillingCycleConfigurationProperties::DurationUnit>(
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

    public NewBillingCycleConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    NewBillingCycleConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewBillingCycleConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
