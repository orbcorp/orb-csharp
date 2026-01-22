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

[JsonConverter(typeof(JsonModelConverter<MaximumInterval, MaximumIntervalFromRaw>))]
public sealed record class MaximumInterval : JsonModel
{
    /// <summary>
    /// The price interval ids that this maximum interval applies to.
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
    /// The end date of the maximum interval.
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
    /// The filters that determine which prices this maximum interval applies to.
    /// </summary>
    public required IReadOnlyList<MaximumIntervalFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MaximumIntervalFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MaximumIntervalFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The maximum amount to charge in a given billing period for the price intervals
    /// this transform applies to.
    /// </summary>
    public required string MaximumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("maximum_amount");
        }
        init { this._rawData.Set("maximum_amount", value); }
    }

    /// <summary>
    /// The start date of the maximum interval.
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
        _ = this.MaximumAmount;
        _ = this.StartDate;
    }

    public MaximumInterval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MaximumInterval(MaximumInterval maximumInterval)
        : base(maximumInterval) { }
#pragma warning restore CS8618

    public MaximumInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaximumInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaximumIntervalFromRaw.FromRawUnchecked"/>
    public static MaximumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaximumIntervalFromRaw : IFromRawJson<MaximumInterval>
{
    /// <inheritdoc/>
    public MaximumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MaximumInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MaximumIntervalFilter, MaximumIntervalFilterFromRaw>))]
public sealed record class MaximumIntervalFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MaximumIntervalFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MaximumIntervalFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MaximumIntervalFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MaximumIntervalFilterOperator>>(
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

    public MaximumIntervalFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MaximumIntervalFilter(MaximumIntervalFilter maximumIntervalFilter)
        : base(maximumIntervalFilter) { }
#pragma warning restore CS8618

    public MaximumIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaximumIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class MaximumIntervalFilterFromRaw : IFromRawJson<MaximumIntervalFilter>
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
