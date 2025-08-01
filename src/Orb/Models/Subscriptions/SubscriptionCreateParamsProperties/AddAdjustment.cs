using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AddAdjustmentProperties = Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.AddAdjustmentProperties;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<AddAdjustment>))]
public sealed record class AddAdjustment : ModelBase, IFromRaw<AddAdjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required AddAdjustmentProperties::Adjustment Adjustment
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out JsonElement element))
                throw new ArgumentOutOfRangeException("adjustment", "Missing required argument");

            return JsonSerializer.Deserialize<AddAdjustmentProperties::Adjustment>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("adjustment");
        }
        set { this.Properties["adjustment"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription.
    /// </summary>
    public DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["end_date"] = JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. If null, the adjustment
    /// will start when the phase or subscription starts.
    /// </summary>
    public DateTime? StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["start_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.EndDate;
        _ = this.PlanPhaseOrder;
        _ = this.StartDate;
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

    public AddAdjustment(AddAdjustmentProperties::Adjustment adjustment)
    {
        this.Adjustment = adjustment;
    }
}
