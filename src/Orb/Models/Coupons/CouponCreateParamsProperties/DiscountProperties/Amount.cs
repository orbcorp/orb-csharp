using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

[JsonConverter(typeof(ModelConverter<Amount>))]
public sealed record class Amount : ModelBase, IFromRaw<Amount>
{
    public required string AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "amount_discount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("amount_discount");
        }
        set { this.Properties["amount_discount"] = JsonSerializer.SerializeToElement(value); }
    }

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

    public override void Validate()
    {
        _ = this.AmountDiscount;
    }

    public Amount()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Amount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Amount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public Amount(string amountDiscount)
    {
        this.AmountDiscount = amountDiscount;
    }
}
