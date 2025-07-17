using AdjustmentProperties = Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Plans.PlanCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Adjustment>))]
public sealed record class Adjustment : Orb::ModelBase, Orb::IFromRaw<Adjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required AdjustmentProperties::Adjustment Adjustment1
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<AdjustmentProperties::Adjustment>(element)
                ?? throw new System::ArgumentNullException("adjustment");
        }
        set { this.Properties["adjustment"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["plan_phase_order"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        this.Adjustment1.Validate();
        _ = this.PlanPhaseOrder;
    }

    public Adjustment() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Adjustment(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Adjustment FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
