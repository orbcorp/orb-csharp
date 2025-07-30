using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;

[JsonConverter(typeof(ModelConverter<FixedFeeQuantityTransition1>))]
public sealed record class FixedFeeQuantityTransition1
    : ModelBase,
        IFromRaw<FixedFeeQuantityTransition1>
{
    /// <summary>
    /// The date that the fixed fee quantity transition should take effect.
    /// </summary>
    public required System::DateTime EffectiveDate
    {
        get
        {
            if (!this.Properties.TryGetValue("effective_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "effective_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["effective_date"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The quantity of the fixed fee quantity transition.
    /// </summary>
    public required long Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransition1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FixedFeeQuantityTransition1 FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
