using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(JsonModelConverter<DiscountOverride, DiscountOverrideFromRaw>))]
public sealed record class DiscountOverride : JsonModel
{
    public required ApiEnum<string, DiscountType> DiscountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DiscountType>>("discount_type");
        }
        init { this._rawData.Set("discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public string? AmountDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("amount_discount");
        }
        init { this._rawData.Set("amount_discount", value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public double? PercentageDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentage_discount");
        }
        init { this._rawData.Set("percentage_discount", value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public double? UsageDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("usage_discount");
        }
        init { this._rawData.Set("usage_discount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.AmountDiscount;
        _ = this.PercentageDiscount;
        _ = this.UsageDiscount;
    }

    public DiscountOverride() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiscountOverride(DiscountOverride discountOverride)
        : base(discountOverride) { }
#pragma warning restore CS8618

    public DiscountOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountOverrideFromRaw.FromRawUnchecked"/>
    public static DiscountOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DiscountOverride(ApiEnum<string, DiscountType> discountType)
        : this()
    {
        this.DiscountType = discountType;
    }
}

class DiscountOverrideFromRaw : IFromRawJson<DiscountOverride>
{
    /// <inheritdoc/>
    public DiscountOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DiscountOverride.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DiscountTypeConverter))]
public enum DiscountType
{
    Percentage,
    Usage,
    Amount,
}

sealed class DiscountTypeConverter : JsonConverter<DiscountType>
{
    public override DiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => DiscountType.Percentage,
            "usage" => DiscountType.Usage,
            "amount" => DiscountType.Amount,
            _ => (DiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountType.Percentage => "percentage",
                DiscountType.Usage => "usage",
                DiscountType.Amount => "amount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
