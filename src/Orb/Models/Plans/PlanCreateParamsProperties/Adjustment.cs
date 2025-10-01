using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using AdjustmentProperties = Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties;

namespace Orb.Models.Plans.PlanCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<Adjustment>))]
public sealed record class Adjustment : ModelBase, IFromRaw<Adjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required AdjustmentProperties::Adjustment Adjustment1
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new ArgumentOutOfRangeException("adjustment", "Missing required argument")
                );

            return JsonSerializer.Deserialize<AdjustmentProperties::Adjustment>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new ArgumentNullException("adjustment")
                );
        }
        set
        {
            this.Properties["adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        set
        {
            this.Properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    [SetsRequiredMembers]
    public Adjustment(AdjustmentProperties::Adjustment adjustment1)
        : this()
    {
        this.Adjustment1 = adjustment1;
    }
}
