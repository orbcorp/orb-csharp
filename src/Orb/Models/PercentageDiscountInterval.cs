using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<PercentageDiscountInterval, PercentageDiscountIntervalFromRaw>)
)]
public sealed record class PercentageDiscountInterval : ModelBase
{
    /// <summary>
    /// The price interval ids that this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<string> AppliesToPriceIntervalIDs
    {
        get
        {
            return ModelBase.GetNotNullClass<List<string>>(
                this.RawData,
                "applies_to_price_interval_ids"
            );
        }
        init { ModelBase.Set(this._rawData, "applies_to_price_interval_ids", value); }
    }

    public required ApiEnum<string, PercentageDiscountIntervalDiscountType> DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PercentageDiscountIntervalDiscountType>
            >(this.RawData, "discount_type");
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// The end date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "end_date");
        }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The filters that determine which prices this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<PercentageDiscountIntervalFilter> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<List<PercentageDiscountIntervalFilter>>(
                this.RawData,
                "filters"
            );
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`.This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { ModelBase.Set(this._rawData, "percentage_discount", value); }
    }

    /// <summary>
    /// The start date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "start_date");
        }
        init { ModelBase.Set(this._rawData, "start_date", value); }
    }

    public override void Validate()
    {
        _ = this.AppliesToPriceIntervalIDs;
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

    public PercentageDiscountInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscountInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PercentageDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentageDiscountIntervalFromRaw : IFromRaw<PercentageDiscountInterval>
{
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
    typeof(ModelConverter<
        PercentageDiscountIntervalFilter,
        PercentageDiscountIntervalFilterFromRaw
    >)
)]
public sealed record class PercentageDiscountIntervalFilter : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, PercentageDiscountIntervalFilterField> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PercentageDiscountIntervalFilterField>
            >(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, PercentageDiscountIntervalFilterOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PercentageDiscountIntervalFilterOperator>
            >(this.RawData, "operator");
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "values"); }
        init { ModelBase.Set(this._rawData, "values", value); }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public PercentageDiscountIntervalFilter() { }

    public PercentageDiscountIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscountIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PercentageDiscountIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentageDiscountIntervalFilterFromRaw : IFromRaw<PercentageDiscountIntervalFilter>
{
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
