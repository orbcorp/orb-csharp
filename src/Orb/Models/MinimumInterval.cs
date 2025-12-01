using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<MinimumInterval, MinimumIntervalFromRaw>))]
public sealed record class MinimumInterval : ModelBase
{
    /// <summary>
    /// The price interval ids that this minimum interval applies to.
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
    /// The end date of the minimum interval.
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
    /// The filters that determine which prices this minimum interval applies to.
    /// </summary>
    public required IReadOnlyList<Filter5> Filters
    {
        get { return ModelBase.GetNotNullClass<List<Filter5>>(this.RawData, "filters"); }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// The minimum amount to charge in a given billing period for the price intervals
    /// this minimum applies to.
    /// </summary>
    public required string MinimumAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "minimum_amount"); }
        init { ModelBase.Set(this._rawData, "minimum_amount", value); }
    }

    /// <summary>
    /// The start date of the minimum interval.
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
        _ = this.EndDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MinimumAmount;
        _ = this.StartDate;
    }

    public MinimumInterval() { }

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

    public static MinimumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumIntervalFromRaw : IFromRaw<MinimumInterval>
{
    public MinimumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MinimumInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Filter5, Filter5FromRaw>))]
public sealed record class Filter5 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter5Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter5Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter5Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter5Operator>>(
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

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public Filter5() { }

    public Filter5(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter5(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter5 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter5FromRaw : IFromRaw<Filter5>
{
    public Filter5 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter5.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter5FieldConverter))]
public enum Filter5Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter5FieldConverter : JsonConverter<Filter5Field>
{
    public override Filter5Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter5Field.PriceID,
            "item_id" => Filter5Field.ItemID,
            "price_type" => Filter5Field.PriceType,
            "currency" => Filter5Field.Currency,
            "pricing_unit_id" => Filter5Field.PricingUnitID,
            _ => (Filter5Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter5Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter5Field.PriceID => "price_id",
                Filter5Field.ItemID => "item_id",
                Filter5Field.PriceType => "price_type",
                Filter5Field.Currency => "currency",
                Filter5Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter5OperatorConverter))]
public enum Filter5Operator
{
    Includes,
    Excludes,
}

sealed class Filter5OperatorConverter : JsonConverter<Filter5Operator>
{
    public override Filter5Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter5Operator.Includes,
            "excludes" => Filter5Operator.Excludes,
            _ => (Filter5Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter5Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter5Operator.Includes => "includes",
                Filter5Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
