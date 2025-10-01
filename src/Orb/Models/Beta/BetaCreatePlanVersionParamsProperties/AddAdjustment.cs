using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddAdjustmentProperties;

namespace Orb.Models.Beta.BetaCreatePlanVersionParamsProperties;

[JsonConverter(typeof(ModelConverter<AddAdjustment>))]
public sealed record class AddAdjustment : ModelBase, IFromRaw<AddAdjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required Adjustment Adjustment
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new ArgumentOutOfRangeException("adjustment", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Adjustment>(element, ModelBase.SerializerOptions)
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
        this.Adjustment.Validate();
        _ = this.PlanPhaseOrder;
    }

    public AddAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddAdjustment FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AddAdjustment(Adjustment adjustment)
        : this()
    {
        this.Adjustment = adjustment;
    }
}
