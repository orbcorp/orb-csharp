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
[JsonConverter(typeof(JsonModelConverter<Coupon, CouponFromRaw>))]
public sealed record class Coupon : JsonModel
{
    /// <summary>
    /// Also referred to as coupon_id in this documentation.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// An archived coupon can no longer be redeemed. Active coupons will have a value
    /// of null for `archived_at`; this field will be non-null for archived coupons.
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "archived_at");
        }
        init { JsonModel.Set(this._rawData, "archived_at", value); }
    }

    public required CouponDiscount Discount
    {
        get { return JsonModel.GetNotNullClass<CouponDiscount>(this.RawData, "discount"); }
        init { JsonModel.Set(this._rawData, "discount", value); }
    }

    /// <summary>
    /// This allows for a coupon's discount to apply for a limited time (determined
    /// in months); a `null` value here means "unlimited time".
    /// </summary>
    public required long? DurationInMonths
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "duration_in_months"); }
        init { JsonModel.Set(this._rawData, "duration_in_months", value); }
    }

    /// <summary>
    /// The maximum number of redemptions allowed for this coupon before it is exhausted;
    /// `null` here means "unlimited".
    /// </summary>
    public required long? MaxRedemptions
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "max_redemptions"); }
        init { JsonModel.Set(this._rawData, "max_redemptions", value); }
    }

    /// <summary>
    /// This string can be used to redeem this coupon for a given subscription.
    /// </summary>
    public required string RedemptionCode
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "redemption_code"); }
        init { JsonModel.Set(this._rawData, "redemption_code", value); }
    }

    /// <summary>
    /// The number of times this coupon has been redeemed.
    /// </summary>
    public required long TimesRedeemed
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "times_redeemed"); }
        init { JsonModel.Set(this._rawData, "times_redeemed", value); }
    }

    /// <inheritdoc/>
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

    public Coupon(Coupon coupon)
        : base(coupon) { }

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

    /// <inheritdoc cref="CouponFromRaw.FromRawUnchecked"/>
    public static Coupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponFromRaw : IFromRawJson<Coupon>
{
    /// <inheritdoc/>
    public Coupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Coupon.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CouponDiscountConverter))]
public record class CouponDiscount : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? Reason
    {
        get { return Match<string?>(percentage: (x) => x.Reason, amount: (x) => x.Reason); }
    }

    public CouponDiscount(PercentageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CouponDiscount(AmountDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CouponDiscount(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercentage(out var value)) {
    ///     // `value` is of type `PercentageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = this.Value as PercentageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AmountDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAmount(out var value)) {
    ///     // `value` is of type `AmountDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = this.Value as AmountDiscount;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (PercentageDiscount value) => {...},
    ///     (AmountDiscount value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (PercentageDiscount value) => {...},
    ///     (AmountDiscount value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of CouponDiscount");
        }
        this.Switch((percentage) => percentage.Validate(), (amount) => amount.Validate());
    }

    public virtual bool Equals(CouponDiscount? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class CouponDiscountConverter : JsonConverter<CouponDiscount>
{
    public override CouponDiscount? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? discountType;
        try
        {
            discountType = element.GetProperty("discount_type").GetString();
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
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscount>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new CouponDiscount(element);
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
