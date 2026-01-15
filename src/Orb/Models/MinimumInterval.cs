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

[JsonConverter(typeof(JsonModelConverter<MinimumInterval, MinimumIntervalFromRaw>))]
public sealed record class MinimumInterval : JsonModel
{
    /// <summary>
    /// The price interval ids that this minimum interval applies to.
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

    /// <summary>
    /// The end date of the minimum interval.
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
    /// The filters that determine which prices this minimum interval applies to.
    /// </summary>
    public required IReadOnlyList<MinimumIntervalFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MinimumIntervalFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MinimumIntervalFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge in a given billing period for the price intervals
    /// this minimum applies to.
    /// </summary>
    public required string MinimumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    /// <summary>
    /// The start date of the minimum interval.
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
        _ = this.EndDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MinimumAmount;
        _ = this.StartDate;
    }

    public MinimumInterval() { }

    public MinimumInterval(MinimumInterval minimumInterval)
        : base(minimumInterval) { }

    public MinimumInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimumInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MinimumIntervalFromRaw.FromRawUnchecked"/>
    public static MinimumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumIntervalFromRaw : IFromRawJson<MinimumInterval>
{
    /// <inheritdoc/>
    public MinimumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MinimumInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MinimumIntervalFilter, MinimumIntervalFilterFromRaw>))]
public sealed record class MinimumIntervalFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MinimumIntervalFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimumIntervalFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MinimumIntervalFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimumIntervalFilterOperator>>(
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

    public MinimumIntervalFilter() { }

    public MinimumIntervalFilter(MinimumIntervalFilter minimumIntervalFilter)
        : base(minimumIntervalFilter) { }

    public MinimumIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimumIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MinimumIntervalFilterFromRaw.FromRawUnchecked"/>
    public static MinimumIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumIntervalFilterFromRaw : IFromRawJson<MinimumIntervalFilter>
{
    /// <inheritdoc/>
    public MinimumIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MinimumIntervalFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MinimumIntervalFilterFieldConverter))]
public enum MinimumIntervalFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MinimumIntervalFilterFieldConverter : JsonConverter<MinimumIntervalFilterField>
{
    public override MinimumIntervalFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MinimumIntervalFilterField.PriceID,
            "item_id" => MinimumIntervalFilterField.ItemID,
            "price_type" => MinimumIntervalFilterField.PriceType,
            "currency" => MinimumIntervalFilterField.Currency,
            "pricing_unit_id" => MinimumIntervalFilterField.PricingUnitID,
            _ => (MinimumIntervalFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimumIntervalFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MinimumIntervalFilterField.PriceID => "price_id",
                MinimumIntervalFilterField.ItemID => "item_id",
                MinimumIntervalFilterField.PriceType => "price_type",
                MinimumIntervalFilterField.Currency => "currency",
                MinimumIntervalFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MinimumIntervalFilterOperatorConverter))]
public enum MinimumIntervalFilterOperator
{
    Includes,
    Excludes,
}

sealed class MinimumIntervalFilterOperatorConverter : JsonConverter<MinimumIntervalFilterOperator>
{
    public override MinimumIntervalFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MinimumIntervalFilterOperator.Includes,
            "excludes" => MinimumIntervalFilterOperator.Excludes,
            _ => (MinimumIntervalFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimumIntervalFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MinimumIntervalFilterOperator.Includes => "includes",
                MinimumIntervalFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
