using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties;

[JsonConverter(typeof(ModelConverter<RemoveAdjustment>))]
public sealed record class RemoveAdjustment : ModelBase, IFromRaw<RemoveAdjustment>
{
    /// <summary>
    /// The id of the adjustment to remove from on the plan.
    /// </summary>
    public required string AdjustmentID
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_id' cannot be null",
                    new ArgumentOutOfRangeException("adjustment_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment_id' cannot be null",
                    new ArgumentNullException("adjustment_id")
                );
        }
        set
        {
            this.Properties["adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The phase to remove this adjustment from.
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
        _ = this.AdjustmentID;
        _ = this.PlanPhaseOrder;
    }

    public RemoveAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveAdjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RemoveAdjustment FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public RemoveAdjustment(string adjustmentID)
        : this()
    {
        this.AdjustmentID = adjustmentID;
    }
}
