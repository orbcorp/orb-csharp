using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<PercentageDiscount, PercentageDiscountFromRaw>))]
public sealed record class PercentageDiscount : JsonModel
{
    public required ApiEnum<string, PercentageDiscountDiscountType> DiscountType
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, PercentageDiscountDiscountType>>(
                "discount_type"
            );
        }
        init { this._rawData.Set("discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscountValue
    {
        get { return this._rawData.GetNotNullStruct<double>("percentage_discount"); }
        init { this._rawData.Set("percentage_discount", value); }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIds
    {
        get
        {
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("applies_to_price_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "applies_to_price_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public IReadOnlyList<PercentageDiscountFilter>? Filters
    {
        get
        {
            return this._rawData.GetNullableStruct<ImmutableArray<PercentageDiscountFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PercentageDiscountFilter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Reason
    {
        get { return this._rawData.GetNullableClass<string>("reason"); }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.PercentageDiscountValue;
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public PercentageDiscount() { }

    public PercentageDiscount(PercentageDiscount percentageDiscount)
        : base(percentageDiscount) { }

    public PercentageDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PercentageDiscountFromRaw.FromRawUnchecked"/>
    public static PercentageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentageDiscountFromRaw : IFromRawJson<PercentageDiscount>
{
    /// <inheritdoc/>
    public PercentageDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PercentageDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PercentageDiscountDiscountTypeConverter))]
public enum PercentageDiscountDiscountType
{
    Percentage,
}

sealed class PercentageDiscountDiscountTypeConverter : JsonConverter<PercentageDiscountDiscountType>
{
    public override PercentageDiscountDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => PercentageDiscountDiscountType.Percentage,
            _ => (PercentageDiscountDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentageDiscountDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentageDiscountDiscountType.Percentage => "percentage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<PercentageDiscountFilter, PercentageDiscountFilterFromRaw>)
)]
public sealed record class PercentageDiscountFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, PercentageDiscountFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, PercentageDiscountFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, PercentageDiscountFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, PercentageDiscountFilterOperator>>(
                "operator"
            );
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values"); }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public PercentageDiscountFilter() { }

    public PercentageDiscountFilter(PercentageDiscountFilter percentageDiscountFilter)
        : base(percentageDiscountFilter) { }

    public PercentageDiscountFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscountFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PercentageDiscountFilterFromRaw.FromRawUnchecked"/>
    public static PercentageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentageDiscountFilterFromRaw : IFromRawJson<PercentageDiscountFilter>
{
    /// <inheritdoc/>
    public PercentageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PercentageDiscountFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(PercentageDiscountFilterFieldConverter))]
public enum PercentageDiscountFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class PercentageDiscountFilterFieldConverter : JsonConverter<PercentageDiscountFilterField>
{
    public override PercentageDiscountFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => PercentageDiscountFilterField.PriceID,
            "item_id" => PercentageDiscountFilterField.ItemID,
            "price_type" => PercentageDiscountFilterField.PriceType,
            "currency" => PercentageDiscountFilterField.Currency,
            "pricing_unit_id" => PercentageDiscountFilterField.PricingUnitID,
            _ => (PercentageDiscountFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentageDiscountFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentageDiscountFilterField.PriceID => "price_id",
                PercentageDiscountFilterField.ItemID => "item_id",
                PercentageDiscountFilterField.PriceType => "price_type",
                PercentageDiscountFilterField.Currency => "currency",
                PercentageDiscountFilterField.PricingUnitID => "pricing_unit_id",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(PercentageDiscountFilterOperatorConverter))]
public enum PercentageDiscountFilterOperator
{
    Includes,
    Excludes,
}

sealed class PercentageDiscountFilterOperatorConverter
    : JsonConverter<PercentageDiscountFilterOperator>
{
    public override PercentageDiscountFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => PercentageDiscountFilterOperator.Includes,
            "excludes" => PercentageDiscountFilterOperator.Excludes,
            _ => (PercentageDiscountFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentageDiscountFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentageDiscountFilterOperator.Includes => "includes",
                PercentageDiscountFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
