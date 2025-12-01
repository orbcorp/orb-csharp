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
    public required IReadOnlyList<Filter3> Filters
    {
        get { return ModelBase.GetNotNullClass<List<Filter3>>(this.RawData, "filters"); }
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

    public static MaximumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaximumIntervalFromRaw : IFromRaw<MaximumInterval>
{
    public MaximumInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MaximumInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Filter3, Filter3FromRaw>))]
public sealed record class Filter3 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter3Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter3Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter3Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter3Operator>>(
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

    public Filter3() { }

    public Filter3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter3FromRaw : IFromRaw<Filter3>
{
    public Filter3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter3.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter3FieldConverter))]
public enum Filter3Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter3FieldConverter : JsonConverter<Filter3Field>
{
    public override Filter3Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter3Field.PriceID,
            "item_id" => Filter3Field.ItemID,
            "price_type" => Filter3Field.PriceType,
            "currency" => Filter3Field.Currency,
            "pricing_unit_id" => Filter3Field.PricingUnitID,
            _ => (Filter3Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter3Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter3Field.PriceID => "price_id",
                Filter3Field.ItemID => "item_id",
                Filter3Field.PriceType => "price_type",
                Filter3Field.Currency => "currency",
                Filter3Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter3OperatorConverter))]
public enum Filter3Operator
{
    Includes,
    Excludes,
}

sealed class Filter3OperatorConverter : JsonConverter<Filter3Operator>
{
    public override Filter3Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter3Operator.Includes,
            "excludes" => Filter3Operator.Excludes,
            _ => (Filter3Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter3Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter3Operator.Includes => "includes",
                Filter3Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
