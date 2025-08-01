using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;

[JsonConverter(typeof(ModelConverter<Percentage>))]
public sealed record class Percentage : ModelBase, IFromRaw<Percentage>
{
    public JsonElement DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("discount_type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["discount_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "percentage_discount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.PercentageDiscount;
    }

    public Percentage()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percentage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Percentage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public Percentage(double percentageDiscount)
    {
        this.PercentageDiscount = percentageDiscount;
    }
}
