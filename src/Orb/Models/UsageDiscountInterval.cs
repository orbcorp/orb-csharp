using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<UsageDiscountInterval, UsageDiscountIntervalFromRaw>))]
public sealed record class UsageDiscountInterval : JsonModel
{
    /// <summary>
    /// The price interval ids that this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<string> AppliesToPriceIntervalIDs
    {
        get
        {
            return JsonModel.GetNotNullClass<List<string>>(
                this.RawData,
                "applies_to_price_interval_ids"
            );
        }
        init { JsonModel.Set(this._rawData, "applies_to_price_interval_ids", value); }
    }

    public required ApiEnum<string, UsageDiscountIntervalDiscountType> DiscountType
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, UsageDiscountIntervalDiscountType>>(
                this.RawData,
                "discount_type"
            );
        }
        init { JsonModel.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// The end date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "end_date");
        }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The filters that determine which prices this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<UsageDiscountIntervalFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<UsageDiscountIntervalFilter>>(
                this.RawData,
                "filters"
            );
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// The start date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "start_date");
        }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public required double UsageDiscount
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "usage_discount"); }
        init { JsonModel.Set(this._rawData, "usage_discount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppliesToPriceIntervalIDs;
        this.DiscountType.Validate();
        _ = this.EndDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.StartDate;
        _ = this.UsageDiscount;
    }

    public UsageDiscountInterval() { }

    public UsageDiscountInterval(UsageDiscountInterval usageDiscountInterval)
        : base(usageDiscountInterval) { }

    public UsageDiscountInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageDiscountInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageDiscountIntervalFromRaw.FromRawUnchecked"/>
    public static UsageDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageDiscountIntervalFromRaw : IFromRawJson<UsageDiscountInterval>
{
    /// <inheritdoc/>
    public UsageDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageDiscountInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UsageDiscountIntervalDiscountTypeConverter))]
public enum UsageDiscountIntervalDiscountType
{
    Usage,
}

sealed class UsageDiscountIntervalDiscountTypeConverter
    : JsonConverter<UsageDiscountIntervalDiscountType>
{
    public override UsageDiscountIntervalDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => UsageDiscountIntervalDiscountType.Usage,
            _ => (UsageDiscountIntervalDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsageDiscountIntervalDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UsageDiscountIntervalDiscountType.Usage => "usage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<UsageDiscountIntervalFilter, UsageDiscountIntervalFilterFromRaw>)
)]
public sealed record class UsageDiscountIntervalFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, UsageDiscountIntervalFilterField> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, UsageDiscountIntervalFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, UsageDiscountIntervalFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, UsageDiscountIntervalFilterOperator>>(
                this.RawData,
                "operator"
            );
        }
        init { JsonModel.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "values"); }
        init { JsonModel.Set(this._rawData, "values", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public UsageDiscountIntervalFilter() { }

    public UsageDiscountIntervalFilter(UsageDiscountIntervalFilter usageDiscountIntervalFilter)
        : base(usageDiscountIntervalFilter) { }

    public UsageDiscountIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageDiscountIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageDiscountIntervalFilterFromRaw.FromRawUnchecked"/>
    public static UsageDiscountIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageDiscountIntervalFilterFromRaw : IFromRawJson<UsageDiscountIntervalFilter>
{
    /// <inheritdoc/>
    public UsageDiscountIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageDiscountIntervalFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(UsageDiscountIntervalFilterFieldConverter))]
public enum UsageDiscountIntervalFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class UsageDiscountIntervalFilterFieldConverter
    : JsonConverter<UsageDiscountIntervalFilterField>
{
    public override UsageDiscountIntervalFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => UsageDiscountIntervalFilterField.PriceID,
            "item_id" => UsageDiscountIntervalFilterField.ItemID,
            "price_type" => UsageDiscountIntervalFilterField.PriceType,
            "currency" => UsageDiscountIntervalFilterField.Currency,
            "pricing_unit_id" => UsageDiscountIntervalFilterField.PricingUnitID,
            _ => (UsageDiscountIntervalFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsageDiscountIntervalFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UsageDiscountIntervalFilterField.PriceID => "price_id",
                UsageDiscountIntervalFilterField.ItemID => "item_id",
                UsageDiscountIntervalFilterField.PriceType => "price_type",
                UsageDiscountIntervalFilterField.Currency => "currency",
                UsageDiscountIntervalFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(UsageDiscountIntervalFilterOperatorConverter))]
public enum UsageDiscountIntervalFilterOperator
{
    Includes,
    Excludes,
}

sealed class UsageDiscountIntervalFilterOperatorConverter
    : JsonConverter<UsageDiscountIntervalFilterOperator>
{
    public override UsageDiscountIntervalFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => UsageDiscountIntervalFilterOperator.Includes,
            "excludes" => UsageDiscountIntervalFilterOperator.Excludes,
            _ => (UsageDiscountIntervalFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsageDiscountIntervalFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UsageDiscountIntervalFilterOperator.Includes => "includes",
                UsageDiscountIntervalFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
