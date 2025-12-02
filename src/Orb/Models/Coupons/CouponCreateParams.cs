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
            return ModelBase.GetNotNullClass<global::Orb.Models.Coupons.Discount>(
                this.RawBodyData,
                "discount"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "discount", value); }
    }

    /// <summary>
    /// This string can be used to redeem this coupon for a given subscription.
    /// </summary>
    public required string RedemptionCode
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "redemption_code"); }
        init { ModelBase.Set(this._rawBodyData, "redemption_code", value); }
    }

    /// <summary>
    /// This allows for a coupon's discount to apply for a limited time (determined
    /// in months); a `null` value here means "unlimited time".
    /// </summary>
    public long? DurationInMonths
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "duration_in_months"); }
        init { ModelBase.Set(this._rawBodyData, "duration_in_months", value); }
    }

    /// <summary>
    /// The maximum number of redemptions allowed for this coupon before it is exhausted;`null`
    /// here means "unlimited".
    /// </summary>
    public long? MaxRedemptions
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "max_redemptions"); }
        init { ModelBase.Set(this._rawBodyData, "max_redemptions", value); }
    }

    public CouponCreateParams() { }

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

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement DiscountType
    {
        get { return Match(percentage: (x) => x.DiscountType, amount: (x) => x.DiscountType); }
    }

    public Discount(Percentage value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Discount(Amount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Discount(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out Percentage? value)
    {
        value = this.Value as Percentage;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out Amount? value)
    {
        value = this.Value as Amount;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
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
                    var deserialized = JsonSerializer.Deserialize<Percentage>(json, options);
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
                    var deserialized = JsonSerializer.Deserialize<Amount>(json, options);
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
                return new global::Orb.Models.Coupons.Discount(json);
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

[JsonConverter(typeof(ModelConverter<Percentage, PercentageFromRaw>))]
public sealed record class Percentage : ModelBase
{
    public JsonElement DiscountType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "discount_type"); }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    public required double PercentageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { ModelBase.Set(this._rawData, "percentage_discount", value); }
    }

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

class PercentageFromRaw : IFromRaw<Percentage>
{
    public Percentage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Percentage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Amount, AmountFromRaw>))]
public sealed record class Amount : ModelBase
{
    public required string AmountDiscount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount_discount"); }
        init { ModelBase.Set(this._rawData, "amount_discount", value); }
    }

    public JsonElement DiscountType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "discount_type"); }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

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

class AmountFromRaw : IFromRaw<Amount>
{
    public Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Amount.FromRawUnchecked(rawData);
}
