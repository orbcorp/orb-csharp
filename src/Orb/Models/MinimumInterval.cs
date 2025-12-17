using System.Collections.Frozen;
using System.Collections.Generic;
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

    /// <summary>
    /// The end date of the minimum interval.
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
    /// The filters that determine which prices this minimum interval applies to.
    /// </summary>
    public required IReadOnlyList<MinimumIntervalFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<MinimumIntervalFilter>>(this.RawData, "filters");
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// The minimum amount to charge in a given billing period for the price intervals
    /// this minimum applies to.
    /// </summary>
    public required string MinimumAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "minimum_amount"); }
        init { JsonModel.Set(this._rawData, "minimum_amount", value); }
    }

    /// <summary>
    /// The start date of the minimum interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "start_date");
        }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppliesToPriceIntervalIDs;
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimumInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
            return JsonModel.GetNotNullClass<ApiEnum<string, MinimumIntervalFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MinimumIntervalFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, MinimumIntervalFilterOperator>>(
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

    public MinimumIntervalFilter() { }

    public MinimumIntervalFilter(MinimumIntervalFilter minimumIntervalFilter)
        : base(minimumIntervalFilter) { }

    public MinimumIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimumIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
