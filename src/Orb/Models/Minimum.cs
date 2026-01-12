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

[JsonConverter(typeof(JsonModelConverter<Minimum, MinimumFromRaw>))]
public sealed record class Minimum : JsonModel
{
    /// <summary>
    /// List of price_ids that this minimum amount applies to. For plan/plan phase
    /// minimums, this can be a subset of prices.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("applies_to_price_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "applies_to_price_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this minimum to.
    /// </summary>
    public required IReadOnlyList<MinimumFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MinimumFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MinimumFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Minimum amount applied
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MinimumAmount;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Minimum() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Minimum(Minimum minimum)
        : base(minimum) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Minimum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    Minimum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MinimumFromRaw.FromRawUnchecked"/>
    public static Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumFromRaw : IFromRawJson<Minimum>
{
    /// <inheritdoc/>
    public Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Minimum.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MinimumFilter, MinimumFilterFromRaw>))]
public sealed record class MinimumFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MinimumFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimumFilterField>>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MinimumFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimumFilterOperator>>(
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

    public MinimumFilter() { }

    public MinimumFilter(MinimumFilter minimumFilter)
        : base(minimumFilter) { }

    public MinimumFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimumFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MinimumFilterFromRaw.FromRawUnchecked"/>
    public static MinimumFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumFilterFromRaw : IFromRawJson<MinimumFilter>
{
    /// <inheritdoc/>
    public MinimumFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MinimumFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MinimumFilterFieldConverter))]
public enum MinimumFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MinimumFilterFieldConverter : JsonConverter<MinimumFilterField>
{
    public override MinimumFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MinimumFilterField.PriceID,
            "item_id" => MinimumFilterField.ItemID,
            "price_type" => MinimumFilterField.PriceType,
            "currency" => MinimumFilterField.Currency,
            "pricing_unit_id" => MinimumFilterField.PricingUnitID,
            _ => (MinimumFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimumFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MinimumFilterField.PriceID => "price_id",
                MinimumFilterField.ItemID => "item_id",
                MinimumFilterField.PriceType => "price_type",
                MinimumFilterField.Currency => "currency",
                MinimumFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MinimumFilterOperatorConverter))]
public enum MinimumFilterOperator
{
    Includes,
    Excludes,
}

sealed class MinimumFilterOperatorConverter : JsonConverter<MinimumFilterOperator>
{
    public override MinimumFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MinimumFilterOperator.Includes,
            "excludes" => MinimumFilterOperator.Excludes,
            _ => (MinimumFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimumFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MinimumFilterOperator.Includes => "includes",
                MinimumFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
