using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using ReplaceAdjustmentProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplaceAdjustmentProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ReplaceAdjustment>))]
public sealed record class ReplaceAdjustment : Orb::ModelBase, Orb::IFromRaw<ReplaceAdjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public required ReplaceAdjustmentProperties::Adjustment Adjustment
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ReplaceAdjustmentProperties::Adjustment>(
                    element
                ) ?? throw new System::ArgumentNullException("adjustment");
        }
        set { this.Properties["adjustment"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the adjustment on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesAdjustmentID
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "replaces_adjustment_id",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "replaces_adjustment_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("replaces_adjustment_id");
        }
        set
        {
            this.Properties["replaces_adjustment_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.ReplacesAdjustmentID;
    }

    public ReplaceAdjustment() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ReplaceAdjustment(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ReplaceAdjustment FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
