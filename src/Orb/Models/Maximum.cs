using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<Maximum, MaximumFromRaw>))]
public sealed record class Maximum : JsonModel
{
    /// <summary>
    /// List of price_ids that this maximum amount applies to. For plan/plan phase
    /// maximums, this can be a subset of prices.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIds
    {
        get
        {
            return JsonModel.GetNotNullClass<List<string>>(this.RawData, "applies_to_price_ids");
        }
        init { JsonModel.Set(this._rawData, "applies_to_price_ids", value); }
    }

    /// <summary>
    /// The filters that determine which prices to apply this maximum to.
    /// </summary>
    public required IReadOnlyList<MaximumFilter> Filters
    {
        get { return JsonModel.GetNotNullClass<List<MaximumFilter>>(this.RawData, "filters"); }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Maximum amount applied
    /// </summary>
    public required string MaximumAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "maximum_amount"); }
        init { JsonModel.Set(this._rawData, "maximum_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MaximumAmount;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Maximum() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Maximum(Maximum maximum)
        : base(maximum) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Maximum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    Maximum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaximumFromRaw.FromRawUnchecked"/>
    public static Maximum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaximumFromRaw : IFromRawJson<Maximum>
{
    /// <inheritdoc/>
    public Maximum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Maximum.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MaximumFilter, MaximumFilterFromRaw>))]
public sealed record class MaximumFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MaximumFilterField> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, MaximumFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MaximumFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, MaximumFilterOperator>>(
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

    public MaximumFilter() { }

    public MaximumFilter(MaximumFilter maximumFilter)
        : base(maximumFilter) { }

    public MaximumFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaximumFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaximumFilterFromRaw.FromRawUnchecked"/>
    public static MaximumFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaximumFilterFromRaw : IFromRawJson<MaximumFilter>
{
    /// <inheritdoc/>
    public MaximumFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MaximumFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MaximumFilterFieldConverter))]
public enum MaximumFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MaximumFilterFieldConverter : JsonConverter<MaximumFilterField>
{
    public override MaximumFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MaximumFilterField.PriceID,
            "item_id" => MaximumFilterField.ItemID,
            "price_type" => MaximumFilterField.PriceType,
            "currency" => MaximumFilterField.Currency,
            "pricing_unit_id" => MaximumFilterField.PricingUnitID,
            _ => (MaximumFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MaximumFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MaximumFilterField.PriceID => "price_id",
                MaximumFilterField.ItemID => "item_id",
                MaximumFilterField.PriceType => "price_type",
                MaximumFilterField.Currency => "currency",
                MaximumFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MaximumFilterOperatorConverter))]
public enum MaximumFilterOperator
{
    Includes,
    Excludes,
}

sealed class MaximumFilterOperatorConverter : JsonConverter<MaximumFilterOperator>
{
    public override MaximumFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MaximumFilterOperator.Includes,
            "excludes" => MaximumFilterOperator.Excludes,
            _ => (MaximumFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MaximumFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MaximumFilterOperator.Includes => "includes",
                MaximumFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
