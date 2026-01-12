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

[JsonConverter(typeof(JsonModelConverter<UsageDiscountInterval, UsageDiscountIntervalFromRaw>))]
public sealed record class UsageDiscountInterval : JsonModel
{
    /// <summary>
    /// The price interval ids that this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<string> AppliesToPriceIntervalIds
    {
        get
        {
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

    public required ApiEnum<string, UsageDiscountIntervalDiscountType> DiscountType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UsageDiscountIntervalDiscountType>
            >("discount_type");
        }
        init { this._rawData.Set("discount_type", value); }
    }

    /// <summary>
    /// The end date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get { return this._rawData.GetNullableStruct<System::DateTimeOffset>("end_date"); }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// The filters that determine which prices this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<UsageDiscountIntervalFilter> Filters
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<UsageDiscountIntervalFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<UsageDiscountIntervalFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The start date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get { return this._rawData.GetNotNullStruct<System::DateTimeOffset>("start_date"); }
        init { this._rawData.Set("start_date", value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public required double UsageDiscount
    {
        get { return this._rawData.GetNotNullStruct<double>("usage_discount"); }
        init { this._rawData.Set("usage_discount", value); }
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
        _ = this.StartDate;
        _ = this.UsageDiscount;
    }

    public UsageDiscountInterval() { }

    public UsageDiscountInterval(UsageDiscountInterval usageDiscountInterval)
        : base(usageDiscountInterval) { }

    public UsageDiscountInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageDiscountInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
            return this._rawData.GetNotNullClass<ApiEnum<string, UsageDiscountIntervalFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, UsageDiscountIntervalFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UsageDiscountIntervalFilterOperator>
            >("operator");
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

    public UsageDiscountIntervalFilter() { }

    public UsageDiscountIntervalFilter(UsageDiscountIntervalFilter usageDiscountIntervalFilter)
        : base(usageDiscountIntervalFilter) { }

    public UsageDiscountIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageDiscountIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
