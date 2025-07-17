using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using PlanPhaseProperties = Orb.Models.Plans.PlanCreateParamsProperties.PlanPhaseProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Plans.PlanCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<PlanPhase>))]
public sealed record class PlanPhase : Orb::ModelBase, Orb::IFromRaw<PlanPhase>
{
    /// <summary>
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get
        {
            if (!this.Properties.TryGetValue("order", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("order", "Missing required argument");

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["order"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Align billing cycle day with phase start date.
    /// </summary>
    public bool? AlignBillingWithPhaseStartDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "align_billing_with_phase_start_date",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.Properties["align_billing_with_phase_start_date"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// How many terms of length `duration_unit` this phase is active for. If null,
    /// this phase is evergreen and active indefinitely
    /// </summary>
    public long? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["duration"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public PlanPhaseProperties::DurationUnit? DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<PlanPhaseProperties::DurationUnit?>(element);
        }
        set { this.Properties["duration_unit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Order;
        _ = this.AlignBillingWithPhaseStartDate;
        _ = this.Duration;
        this.DurationUnit?.Validate();
    }

    public PlanPhase() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    PlanPhase(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanPhase FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
