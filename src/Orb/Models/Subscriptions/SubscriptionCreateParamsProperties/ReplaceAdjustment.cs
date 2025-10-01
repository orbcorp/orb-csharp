using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplaceAdjustmentProperties;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<ReplaceAdjustment>))]
public sealed record class ReplaceAdjustment : ModelBase, IFromRaw<ReplaceAdjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
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
    /// The id of the adjustment on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesAdjustmentID
    {
        get
        {
            if (!this.Properties.TryGetValue("replaces_adjustment_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'replaces_adjustment_id' cannot be null",
                    new ArgumentOutOfRangeException(
                        "replaces_adjustment_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'replaces_adjustment_id' cannot be null",
                    new ArgumentNullException("replaces_adjustment_id")
                );
        }
        set
        {
            this.Properties["replaces_adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
    [SetsRequiredMembers]
    ReplaceAdjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ReplaceAdjustment FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
