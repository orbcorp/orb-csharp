using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using PercentageProperties = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties.PercentageProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Percentage>))]
public sealed record class Percentage : Orb::ModelBase, Orb::IFromRaw<Percentage>
{
    public required PercentageProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<PercentageProperties::DiscountType>(element)
                ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "percentage_discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set
        {
            this.Properties["percentage_discount"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
    }

    public Percentage() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Percentage(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Percentage FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
