using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Amount>))]
public sealed record class Amount : Orb::ModelBase, Orb::IFromRaw<Amount>
{
    public required string AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount_discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount_discount");
        }
        set { this.Properties["amount_discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["discount_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.AmountDiscount;
    }

    public Amount()
    {
        this.DiscountType = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"amount\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Amount(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Amount FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
