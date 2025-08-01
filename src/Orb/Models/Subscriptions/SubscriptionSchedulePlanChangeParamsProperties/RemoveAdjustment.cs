using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

[JsonConverter(typeof(ModelConverter<RemoveAdjustment>))]
public sealed record class RemoveAdjustment : ModelBase, IFromRaw<RemoveAdjustment>
{
    /// <summary>
    /// The id of the adjustment to remove on the subscription.
    /// </summary>
    public required string AdjustmentID
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("adjustment_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("adjustment_id");
        }
        set { this.Properties["adjustment_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.AdjustmentID;
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

    public RemoveAdjustment(string adjustmentID)
    {
        this.AdjustmentID = adjustmentID;
    }
}
