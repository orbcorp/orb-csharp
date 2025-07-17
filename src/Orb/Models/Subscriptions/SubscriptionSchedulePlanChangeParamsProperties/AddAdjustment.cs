using AddAdjustmentProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddAdjustmentProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<AddAdjustment>))]
public sealed record class AddAdjustment : Orb::ModelBase, Orb::IFromRaw<AddAdjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required AddAdjustmentProperties::Adjustment Adjustment
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<AddAdjustmentProperties::Adjustment>(element)
                ?? throw new System::ArgumentNullException("adjustment");
        }
        set { this.Properties["adjustment"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription.
    /// </summary>
    public System::DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. If null, the adjustment will
    /// start when the phase or subscription starts.
    /// </summary>
    public System::DateTime? StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    AddAdjustment(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddAdjustment FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
