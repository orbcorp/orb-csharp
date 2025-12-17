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
    public required ApiEnum<string, global::Orb.Models.Subscriptions.DiscountType> DiscountType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Subscriptions.DiscountType>
            >(this.RawData, "discount_type");
        }
        init { JsonModel.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public string? AmountDiscount
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "amount_discount"); }
        init { JsonModel.Set(this._rawData, "amount_discount", value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public double? PercentageDiscount
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "percentage_discount"); }
        init { JsonModel.Set(this._rawData, "percentage_discount", value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public double? UsageDiscount
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "usage_discount"); }
        init { JsonModel.Set(this._rawData, "usage_discount", value); }
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

    public DiscountOverride(DiscountOverride discountOverride)
        : base(discountOverride) { }

    public DiscountOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public DiscountOverride(
        ApiEnum<string, global::Orb.Models.Subscriptions.DiscountType> discountType
    )
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

[JsonConverter(typeof(global::Orb.Models.Subscriptions.DiscountTypeConverter))]
public enum DiscountType
{
    Percentage,
    Usage,
    Amount,
}

sealed class DiscountTypeConverter : JsonConverter<global::Orb.Models.Subscriptions.DiscountType>
{
    public override global::Orb.Models.Subscriptions.DiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => global::Orb.Models.Subscriptions.DiscountType.Percentage,
            "usage" => global::Orb.Models.Subscriptions.DiscountType.Usage,
            "amount" => global::Orb.Models.Subscriptions.DiscountType.Amount,
            _ => (global::Orb.Models.Subscriptions.DiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.DiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.DiscountType.Percentage => "percentage",
                global::Orb.Models.Subscriptions.DiscountType.Usage => "usage",
                global::Orb.Models.Subscriptions.DiscountType.Amount => "amount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
