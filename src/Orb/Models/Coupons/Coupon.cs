using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using CouponProperties = Orb.Models.Coupons.CouponProperties;

namespace Orb.Models.Coupons;

/// <summary>
/// A coupon represents a reusable discount configuration that can be applied either
/// as a fixed or percentage amount to an invoice or subscription. Coupons are activated
/// using a redemption code, which applies the discount to a subscription or invoice.
/// The duration of a coupon determines how long it remains available for use by
/// end users.
/// </summary>
[JsonConverter(typeof(ModelConverter<Coupon>))]
public sealed record class Coupon : ModelBase, IFromRaw<Coupon>
{
    /// <summary>
    /// Also referred to as coupon_id in this documentation.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An archived coupon can no longer be redeemed. Active coupons will have a
    /// value of null for `archived_at`; this field will be non-null for archived coupons.
    /// </summary>
    public required DateTime? ArchivedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("archived_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["archived_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CouponProperties::Discount Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new ArgumentOutOfRangeException("discount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CouponProperties::Discount>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new ArgumentNullException("discount")
                );
        }
        set
        {
            this.Properties["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This allows for a coupon's discount to apply for a limited time (determined
    /// in months); a `null` value here means "unlimited time".
    /// </summary>
    public required long? DurationInMonths
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_in_months", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration_in_months"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("max_redemptions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["max_redemptions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This string can be used to redeem this coupon for a given subscription.
    /// </summary>
    public required string RedemptionCode
    {
        get
        {
            if (!this.Properties.TryGetValue("redemption_code", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'redemption_code' cannot be null",
                    new ArgumentOutOfRangeException("redemption_code", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'redemption_code' cannot be null",
                    new ArgumentNullException("redemption_code")
                );
        }
        set
        {
            this.Properties["redemption_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of times this coupon has been redeemed.
    /// </summary>
    public required long TimesRedeemed
    {
        get
        {
            if (!this.Properties.TryGetValue("times_redeemed", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'times_redeemed' cannot be null",
                    new ArgumentOutOfRangeException("times_redeemed", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["times_redeemed"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
    [SetsRequiredMembers]
    Coupon(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Coupon FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
