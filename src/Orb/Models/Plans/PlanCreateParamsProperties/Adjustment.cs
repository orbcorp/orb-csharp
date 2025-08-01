using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AdjustmentProperties = Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties;

namespace Orb.Models.Plans.PlanCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<Adjustment>))]
public sealed record class Adjustment : ModelBase, IFromRaw<Adjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required AdjustmentProperties::Adjustment1 Adjustment1
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out JsonElement element))
                throw new ArgumentOutOfRangeException("adjustment", "Missing required argument");

            return JsonSerializer.Deserialize<AdjustmentProperties::Adjustment1>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("adjustment");
        }
        set { this.Properties["adjustment"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["plan_phase_order"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Adjustment1.Validate();
        _ = this.PlanPhaseOrder;
    }

    public Adjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Adjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Adjustment FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public Adjustment(AdjustmentProperties::Adjustment1 adjustment1)
    {
        this.Adjustment1 = adjustment1;
    }
}
