using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Coupons;

/// <summary>
/// A coupon represents a reusable discount configuration that can be applied either
/// as a fixed or percentage amount to an invoice or subscription. Coupons are activated
/// using a redemption code, which applies the discount to a subscription or invoice.
/// The duration of a coupon determines how long it remains available for use by end users.
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
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An archived coupon can no longer be redeemed. Active coupons will have a value
    /// of null for `archived_at`; this field will be non-null for archived coupons.
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("archived_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["archived_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CouponDiscount Discount
    {
        get
        {
            if (!this._rawData.TryGetValue("discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new System::ArgumentOutOfRangeException("discount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CouponDiscount>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new System::ArgumentNullException("discount")
                );
        }
        init
        {
            this._rawData["discount"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("duration_in_months", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["duration_in_months"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("max_redemptions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["max_redemptions"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("redemption_code", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'redemption_code' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "redemption_code",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'redemption_code' cannot be null",
                    new System::ArgumentNullException("redemption_code")
                );
        }
        init
        {
            this._rawData["redemption_code"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("times_redeemed", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'times_redeemed' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "times_redeemed",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["times_redeemed"] = JsonSerializer.SerializeToElement(
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

    public Coupon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Coupon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Coupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

[JsonConverter(typeof(CouponDiscountConverter))]
public record class CouponDiscount
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? Reason
    {
        get { return Match<string?>(percentage: (x) => x.Reason, amount: (x) => x.Reason); }
    }

    public CouponDiscount(PercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public CouponDiscount(AmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public CouponDiscount(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = this.Value as PercentageDiscount;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = this.Value as AmountDiscount;
        return value != null;
    }

    public void Switch(
        System::Action<PercentageDiscount> percentage,
        System::Action<AmountDiscount> amount
    )
    {
        switch (this.Value)
        {
            case PercentageDiscount value:
                percentage(value);
                break;
            case AmountDiscount value:
                amount(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of CouponDiscount"
                );
        }
    }

    public T Match<T>(
        System::Func<PercentageDiscount, T> percentage,
        System::Func<AmountDiscount, T> amount
    )
    {
        return this.Value switch
        {
            PercentageDiscount value => percentage(value),
            AmountDiscount value => amount(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of CouponDiscount"
            ),
        };
    }

    public static implicit operator CouponDiscount(PercentageDiscount value) => new(value);

    public static implicit operator CouponDiscount(AmountDiscount value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of CouponDiscount");
        }
    }
}

sealed class CouponDiscountConverter : JsonConverter<CouponDiscount>
{
    public override CouponDiscount? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? discountType;
        try
        {
            discountType = json.GetProperty("discount_type").GetString();
        }
        catch
        {
            discountType = null;
        }

        switch (discountType)
        {
            case "percentage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new CouponDiscount(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponDiscount value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
