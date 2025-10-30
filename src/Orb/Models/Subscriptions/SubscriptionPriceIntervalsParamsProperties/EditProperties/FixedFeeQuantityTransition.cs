using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;

[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties.FixedFeeQuantityTransition>)
)]
public sealed record class FixedFeeQuantityTransition
    : ModelBase,
        IFromRaw<global::Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties.FixedFeeQuantityTransition>
{
    /// <summary>
    /// The date that the fixed fee quantity transition should take effect.
    /// </summary>
    public required DateTime EffectiveDate
    {
        get
        {
            if (!this.Properties.TryGetValue("effective_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'effective_date' cannot be null",
                    new ArgumentOutOfRangeException("effective_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["effective_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The quantity of the fixed fee quantity transition.
    /// </summary>
    public required long Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransition(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties.FixedFeeQuantityTransition FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
