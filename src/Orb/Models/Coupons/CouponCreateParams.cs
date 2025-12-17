using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Coupons;

/// <summary>
/// This endpoint allows the creation of coupons, which can then be redeemed at subscription
/// creation or plan change.
/// </summary>
public sealed record class CouponCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required global::Orb.Models.Coupons.Discount Discount
    {
        get
        {
            return JsonModel.GetNotNullClass<global::Orb.Models.Coupons.Discount>(
                this.RawBodyData,
                "discount"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "discount", value); }
    }

    /// <summary>
    /// This string can be used to redeem this coupon for a given subscription.
    /// </summary>
    public required string RedemptionCode
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "redemption_code"); }
        init { JsonModel.Set(this._rawBodyData, "redemption_code", value); }
    }

    /// <summary>
    /// This allows for a coupon's discount to apply for a limited time (determined
    /// in months); a `null` value here means "unlimited time".
    /// </summary>
    public long? DurationInMonths
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "duration_in_months"); }
        init { JsonModel.Set(this._rawBodyData, "duration_in_months", value); }
    }

    /// <summary>
    /// The maximum number of redemptions allowed for this coupon before it is exhausted;`null`
    /// here means "unlimited".
    /// </summary>
    public long? MaxRedemptions
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "max_redemptions"); }
        init { JsonModel.Set(this._rawBodyData, "max_redemptions", value); }
    }

    public CouponCreateParams() { }

    public CouponCreateParams(CouponCreateParams couponCreateParams)
        : base(couponCreateParams)
    {
        this._rawBodyData = [.. couponCreateParams._rawBodyData];
    }

    public CouponCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CouponCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/coupons")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(DiscountConverter))]
public record class Discount
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement DiscountType
    {
        get { return Match(percentage: (x) => x.DiscountType, amount: (x) => x.DiscountType); }
    }

    public Discount(Percentage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Discount(Amount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Discount(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Percentage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercentage(out var value)) {
    ///     // `value` is of type `Percentage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercentage([NotNullWhen(true)] out Percentage? value)
    {
        value = this.Value as Percentage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Amount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAmount(out var value)) {
    ///     // `value` is of type `Amount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAmount([NotNullWhen(true)] out Amount? value)
    {
        value = this.Value as Amount;
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
    ///     (Percentage value) => {...},
    ///     (Amount value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<Percentage> percentage, System::Action<Amount> amount)
    {
        switch (this.Value)
        {
            case Percentage value:
                percentage(value);
                break;
            case Amount value:
                amount(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Discount");
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
    ///     (Percentage value) => {...},
    ///     (Amount value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<Percentage, T> percentage, System::Func<Amount, T> amount)
    {
        return this.Value switch
        {
            Percentage value => percentage(value),
            Amount value => amount(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Discount"),
        };
    }

    public static implicit operator global::Orb.Models.Coupons.Discount(Percentage value) =>
        new(value);

    public static implicit operator global::Orb.Models.Coupons.Discount(Amount value) => new(value);

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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
        this.Switch((percentage) => percentage.Validate(), (amount) => amount.Validate());
    }

    public virtual bool Equals(global::Orb.Models.Coupons.Discount? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class DiscountConverter : JsonConverter<global::Orb.Models.Coupons.Discount>
{
    public override global::Orb.Models.Coupons.Discount? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Percentage>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Amount>(element, options);
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
                return new global::Orb.Models.Coupons.Discount(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Coupons.Discount value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Percentage, PercentageFromRaw>))]
public sealed record class Percentage : JsonModel
{
    public JsonElement DiscountType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "discount_type"); }
        init { JsonModel.Set(this._rawData, "discount_type", value); }
    }

    public required double PercentageDiscount
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { JsonModel.Set(this._rawData, "percentage_discount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.DiscountType,
                JsonSerializer.Deserialize<JsonElement>("\"percentage\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.PercentageDiscount;
    }

    public Percentage()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
    }

    public Percentage(Percentage percentage)
        : base(percentage) { }

    public Percentage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percentage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PercentageFromRaw.FromRawUnchecked"/>
    public static Percentage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Percentage(double percentageDiscount)
        : this()
    {
        this.PercentageDiscount = percentageDiscount;
    }
}

class PercentageFromRaw : IFromRawJson<Percentage>
{
    /// <inheritdoc/>
    public Percentage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Percentage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Amount, AmountFromRaw>))]
public sealed record class Amount : JsonModel
{
    public required string AmountDiscount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "amount_discount"); }
        init { JsonModel.Set(this._rawData, "amount_discount", value); }
    }

    public JsonElement DiscountType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "discount_type"); }
        init { JsonModel.Set(this._rawData, "discount_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AmountDiscount;
        if (
            !JsonElement.DeepEquals(
                this.DiscountType,
                JsonSerializer.Deserialize<JsonElement>("\"amount\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
    }

    public Amount()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\"");
    }

    public Amount(Amount amount)
        : base(amount) { }

    public Amount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Amount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmountFromRaw.FromRawUnchecked"/>
    public static Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Amount(string amountDiscount)
        : this()
    {
        this.AmountDiscount = amountDiscount;
    }
}

class AmountFromRaw : IFromRawJson<Amount>
{
    /// <inheritdoc/>
    public Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Amount.FromRawUnchecked(rawData);
}
