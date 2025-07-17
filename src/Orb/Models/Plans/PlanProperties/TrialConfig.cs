using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using TrialConfigProperties = Orb.Models.Plans.PlanProperties.TrialConfigProperties;

namespace Orb.Models.Plans.PlanProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TrialConfig>))]
public sealed record class TrialConfig : Orb::ModelBase, Orb::IFromRaw<TrialConfig>
{
    public required long? TrialPeriod
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "trial_period",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["trial_period"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required TrialConfigProperties::TrialPeriodUnit TrialPeriodUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period_unit", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "trial_period_unit",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<TrialConfigProperties::TrialPeriodUnit>(element)
                ?? throw new System::ArgumentNullException("trial_period_unit");
        }
        set
        {
            this.Properties["trial_period_unit"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.TrialPeriod;
        this.TrialPeriodUnit.Validate();
    }

    public TrialConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TrialConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TrialConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
