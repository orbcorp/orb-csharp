using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Plans.PlanCreateParamsProperties.PlanPhaseProperties;

namespace Orb.Models.Plans.PlanCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<PlanPhase>))]
public sealed record class PlanPhase : ModelBase, IFromRaw<PlanPhase>
{
    /// <summary>
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get
        {
            if (!this.Properties.TryGetValue("order", out JsonElement element))
                throw new ArgumentOutOfRangeException("order", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["align_billing_with_phase_start_date"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
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
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, DurationUnit>? DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["duration_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
    [SetsRequiredMembers]
    PlanPhase(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanPhase FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PlanPhase(long order)
        : this()
    {
        this.Order = order;
    }
}
