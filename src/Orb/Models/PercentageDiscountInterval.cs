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

[JsonConverter(
    typeof(JsonModelConverter<PercentageDiscountInterval, PercentageDiscountIntervalFromRaw>)
)]
public sealed record class PercentageDiscountInterval : JsonModel
{
    /// <summary>
    /// The price interval ids that this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<string> AppliesToPriceIntervalIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "applies_to_price_interval_ids"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "applies_to_price_interval_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, PercentageDiscountIntervalDiscountType> DiscountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PercentageDiscountIntervalDiscountType>
            >("discount_type");
        }
        init { this._rawData.Set("discount_type", value); }
    }

    /// <summary>
    /// The end date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// The filters that determine which prices this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<PercentageDiscountIntervalFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PercentageDiscountIntervalFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PercentageDiscountIntervalFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`.This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentage_discount");
        }
        init { this._rawData.Set("percentage_discount", value); }
    }

    /// <summary>
    /// The start date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("start_date");
        }
        init { this._rawData.Set("start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppliesToPriceIntervalIds;
        this.DiscountType.Validate();
        _ = this.EndDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.PercentageDiscount;
        _ = this.StartDate;
    }

    public PercentageDiscountInterval() { }

    public PercentageDiscountInterval(PercentageDiscountInterval percentageDiscountInterval)
        : base(percentageDiscountInterval) { }

    public PercentageDiscountInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscountInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PercentageDiscountIntervalFromRaw.FromRawUnchecked"/>
    public static PercentageDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentageDiscountIntervalFromRaw : IFromRawJson<PercentageDiscountInterval>
{
    /// <inheritdoc/>
    public PercentageDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PercentageDiscountInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PercentageDiscountIntervalDiscountTypeConverter))]
public enum PercentageDiscountIntervalDiscountType
{
    Percentage,
}

sealed class PercentageDiscountIntervalDiscountTypeConverter
    : JsonConverter<PercentageDiscountIntervalDiscountType>
{
    public override PercentageDiscountIntervalDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => PercentageDiscountIntervalDiscountType.Percentage,
            _ => (PercentageDiscountIntervalDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentageDiscountIntervalDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentageDiscountIntervalDiscountType.Percentage => "percentage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PercentageDiscountIntervalFilter,
        PercentageDiscountIntervalFilterFromRaw
    >)
)]
public sealed record class PercentageDiscountIntervalFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, PercentageDiscountIntervalFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PercentageDiscountIntervalFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, PercentageDiscountIntervalFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PercentageDiscountIntervalFilterOperator>
            >("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values");
        }
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

    public PercentageDiscountIntervalFilter() { }

    public PercentageDiscountIntervalFilter(
        PercentageDiscountIntervalFilter percentageDiscountIntervalFilter
    )
        : base(percentageDiscountIntervalFilter) { }

    public PercentageDiscountIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscountIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PercentageDiscountIntervalFilterFromRaw.FromRawUnchecked"/>
    public static PercentageDiscountIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentageDiscountIntervalFilterFromRaw : IFromRawJson<PercentageDiscountIntervalFilter>
{
    /// <inheritdoc/>
    public PercentageDiscountIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PercentageDiscountIntervalFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(PercentageDiscountIntervalFilterFieldConverter))]
public enum PercentageDiscountIntervalFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class PercentageDiscountIntervalFilterFieldConverter
    : JsonConverter<PercentageDiscountIntervalFilterField>
{
    public override PercentageDiscountIntervalFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => PercentageDiscountIntervalFilterField.PriceID,
            "item_id" => PercentageDiscountIntervalFilterField.ItemID,
            "price_type" => PercentageDiscountIntervalFilterField.PriceType,
            "currency" => PercentageDiscountIntervalFilterField.Currency,
            "pricing_unit_id" => PercentageDiscountIntervalFilterField.PricingUnitID,
            _ => (PercentageDiscountIntervalFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentageDiscountIntervalFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentageDiscountIntervalFilterField.PriceID => "price_id",
                PercentageDiscountIntervalFilterField.ItemID => "item_id",
                PercentageDiscountIntervalFilterField.PriceType => "price_type",
                PercentageDiscountIntervalFilterField.Currency => "currency",
                PercentageDiscountIntervalFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(PercentageDiscountIntervalFilterOperatorConverter))]
public enum PercentageDiscountIntervalFilterOperator
{
    Includes,
    Excludes,
}

sealed class PercentageDiscountIntervalFilterOperatorConverter
    : JsonConverter<PercentageDiscountIntervalFilterOperator>
{
    public override PercentageDiscountIntervalFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => PercentageDiscountIntervalFilterOperator.Includes,
            "excludes" => PercentageDiscountIntervalFilterOperator.Excludes,
            _ => (PercentageDiscountIntervalFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentageDiscountIntervalFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentageDiscountIntervalFilterOperator.Includes => "includes",
                PercentageDiscountIntervalFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
