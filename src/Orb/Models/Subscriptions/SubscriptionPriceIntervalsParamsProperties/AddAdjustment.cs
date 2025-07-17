using AddAdjustmentProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties;

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
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `start_date`. This `start_date` is treated
    /// as inclusive for in-advance prices, and exclusive for in-arrears prices.
    /// </summary>
    public required AddAdjustmentProperties::StartDate StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<AddAdjustmentProperties::StartDate>(element)
                ?? throw new System::ArgumentNullException("start_date");
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription. The adjustment will apply to
    /// invoice dates that overlap with this `end_date`.This `end_date` is treated as
    /// exclusive for in-advance prices, and inclusive for in-arrears prices.
    /// </summary>
    public AddAdjustmentProperties::EndDate? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<AddAdjustmentProperties::EndDate?>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Adjustment.Validate();
        this.StartDate.Validate();
        this.EndDate?.Validate();
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
