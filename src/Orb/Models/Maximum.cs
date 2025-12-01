using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<Maximum, MaximumFromRaw>))]
public sealed record class Maximum : ModelBase
{
    /// <summary>
    /// List of price_ids that this maximum amount applies to. For plan/plan phase
    /// maximums, this can be a subset of prices.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIDs
    {
        get
        {
            return ModelBase.GetNotNullClass<List<string>>(this.RawData, "applies_to_price_ids");
        }
        init { ModelBase.Set(this._rawData, "applies_to_price_ids", value); }
    }

    /// <summary>
    /// The filters that determine which prices to apply this maximum to.
    /// </summary>
    public required IReadOnlyList<Filter2> Filters
    {
        get { return ModelBase.GetNotNullClass<List<Filter2>>(this.RawData, "filters"); }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Maximum amount applied
    /// </summary>
    public required string MaximumAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "maximum_amount"); }
        init { ModelBase.Set(this._rawData, "maximum_amount", value); }
    }

    public override void Validate()
    {
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MaximumAmount;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Maximum() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Maximum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete("Required properties are deprecated: applies_to_price_ids"),
        SetsRequiredMembers
    ]
    Maximum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Maximum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaximumFromRaw : IFromRaw<Maximum>
{
    public Maximum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Maximum.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Filter2, Filter2FromRaw>))]
public sealed record class Filter2 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter2Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter2Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter2Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter2Operator>>(
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

    public Filter2() { }

    public Filter2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter2FromRaw : IFromRaw<Filter2>
{
    public Filter2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter2.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter2FieldConverter))]
public enum Filter2Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter2FieldConverter : JsonConverter<Filter2Field>
{
    public override Filter2Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter2Field.PriceID,
            "item_id" => Filter2Field.ItemID,
            "price_type" => Filter2Field.PriceType,
            "currency" => Filter2Field.Currency,
            "pricing_unit_id" => Filter2Field.PricingUnitID,
            _ => (Filter2Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter2Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter2Field.PriceID => "price_id",
                Filter2Field.ItemID => "item_id",
                Filter2Field.PriceType => "price_type",
                Filter2Field.Currency => "currency",
                Filter2Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter2OperatorConverter))]
public enum Filter2Operator
{
    Includes,
    Excludes,
}

sealed class Filter2OperatorConverter : JsonConverter<Filter2Operator>
{
    public override Filter2Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter2Operator.Includes,
            "excludes" => Filter2Operator.Excludes,
            _ => (Filter2Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter2Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter2Operator.Includes => "includes",
                Filter2Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
