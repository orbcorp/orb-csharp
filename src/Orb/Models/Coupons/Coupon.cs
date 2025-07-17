using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using CouponProperties = Orb.Models.Coupons.CouponProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Coupons;

/// <summary>
/// A coupon represents a reusable discount configuration that can be applied either
/// as a fixed or percentage amount to an invoice or subscription. Coupons are activated
/// using a redemption code, which applies the discount to a subscription or invoice.
/// The duration of a coupon determines how long it remains available for use by
/// end users.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Coupon>))]
public sealed record class Coupon : Orb::ModelBase, Orb::IFromRaw<Coupon>
{
    /// <summary>
    /// Also referred to as coupon_id in this documentation.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An archived coupon can no longer be redeemed. Active coupons will have a value
    /// of null for `archived_at`; this field will be non-null for archived coupons.
    /// </summary>
    public required System::DateTime? ArchivedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("archived_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "archived_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["archived_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required CouponProperties::Discount Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CouponProperties::Discount>(element)
                ?? throw new System::ArgumentNullException("discount");
        }
        set { this.Properties["discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// This allows for a coupon's discount to apply for a limited time (determined
    /// in months); a `null` value here means "unlimited time".
    /// </summary>
    public required long? DurationInMonths
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_in_months", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration_in_months",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["duration_in_months"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The maximum number of redemptions allowed for this coupon before it is exhausted;
    /// `null` here means "unlimited".
    /// </summary>
    public required long? MaxRedemptions
    {
        get
        {
            if (!this.Properties.TryGetValue("max_redemptions", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "max_redemptions",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["max_redemptions"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// This string can be used to redeem this coupon for a given subscription.
    /// </summary>
    public required string RedemptionCode
    {
        get
        {
            if (!this.Properties.TryGetValue("redemption_code", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "redemption_code",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("redemption_code");
        }
        set { this.Properties["redemption_code"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of times this coupon has been redeemed.
    /// </summary>
    public required long TimesRedeemed
    {
        get
        {
            if (!this.Properties.TryGetValue("times_redeemed", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "times_redeemed",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["times_redeemed"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        this.Discount.Validate();
        _ = this.DurationInMonths;
        _ = this.MaxRedemptions;
        _ = this.RedemptionCode;
        _ = this.TimesRedeemed;
    }

    public Coupon() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Coupon(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Coupon FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
