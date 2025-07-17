using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<RemoveAdjustment>))]
public sealed record class RemoveAdjustment : Orb::ModelBase, Orb::IFromRaw<RemoveAdjustment>
{
    /// <summary>
    /// The id of the adjustment to remove on the subscription.
    /// </summary>
    public required string AdjustmentID
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("adjustment_id");
        }
        set { this.Properties["adjustment_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.AdjustmentID;
    }

    public RemoveAdjustment() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    RemoveAdjustment(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RemoveAdjustment FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
