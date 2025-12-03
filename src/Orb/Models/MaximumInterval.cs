using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<MaximumInterval, MaximumIntervalFromRaw>))]
public sealed record class MaximumInterval : ModelBase
{
    /// <summary>
    /// The price interval ids that this maximum interval applies to.
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

    /// <summary>
    /// The end date of the maximum interval.
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
    /// The filters that determine which prices this maximum interval applies to.
    /// </summary>
    public required IReadOnlyList<MaximumIntervalFilter> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<List<MaximumIntervalFilter>>(this.RawData, "filters");
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// The maximum amount to charge in a given billing period for the price intervals
    /// this transform applies to.
    /// </summary>
    public required string MaximumAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "maximum_amount"); }
        init { ModelBase.Set(this._rawData, "maximum_amount", value); }
    }

    /// <summary>
    /// The start date of the maximum interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "start_date");
        }
        init { ModelBase.Set(this._rawData, "start_date", value); }
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
        _ = this.MaximumAmount;
        _ = this.StartDate;
    }

    public MaximumInterval() { }

    public MaximumInterval(MaximumInterval maximumInterval)
        : base(maximumInterval) { }

    public MaximumInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaximumInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaximumIntervalFromRaw.FromRawUnchecked"/>
    public static MaximumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaximumIntervalFromRaw : IFromRaw<MaximumInterval>
{
    /// <inheritdoc/>
    public MaximumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MaximumInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<MaximumIntervalFilter, MaximumIntervalFilterFromRaw>))]
public sealed record class MaximumIntervalFilter : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MaximumIntervalFilterField> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, MaximumIntervalFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MaximumIntervalFilterOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, MaximumIntervalFilterOperator>>(
                this.RawData,
                "operator"
            );
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public MaximumIntervalFilter() { }

    public MaximumIntervalFilter(MaximumIntervalFilter maximumIntervalFilter)
        : base(maximumIntervalFilter) { }

    public MaximumIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaximumIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaximumIntervalFilterFromRaw.FromRawUnchecked"/>
    public static MaximumIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaximumIntervalFilterFromRaw : IFromRaw<MaximumIntervalFilter>
{
    /// <inheritdoc/>
    public MaximumIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MaximumIntervalFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MaximumIntervalFilterFieldConverter))]
public enum MaximumIntervalFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MaximumIntervalFilterFieldConverter : JsonConverter<MaximumIntervalFilterField>
{
    public override MaximumIntervalFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MaximumIntervalFilterField.PriceID,
            "item_id" => MaximumIntervalFilterField.ItemID,
            "price_type" => MaximumIntervalFilterField.PriceType,
            "currency" => MaximumIntervalFilterField.Currency,
            "pricing_unit_id" => MaximumIntervalFilterField.PricingUnitID,
            _ => (MaximumIntervalFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MaximumIntervalFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MaximumIntervalFilterField.PriceID => "price_id",
                MaximumIntervalFilterField.ItemID => "item_id",
                MaximumIntervalFilterField.PriceType => "price_type",
                MaximumIntervalFilterField.Currency => "currency",
                MaximumIntervalFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MaximumIntervalFilterOperatorConverter))]
public enum MaximumIntervalFilterOperator
{
    Includes,
    Excludes,
}

sealed class MaximumIntervalFilterOperatorConverter : JsonConverter<MaximumIntervalFilterOperator>
{
    public override MaximumIntervalFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MaximumIntervalFilterOperator.Includes,
            "excludes" => MaximumIntervalFilterOperator.Excludes,
            _ => (MaximumIntervalFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MaximumIntervalFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MaximumIntervalFilterOperator.Includes => "includes",
                MaximumIntervalFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
