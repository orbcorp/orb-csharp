using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<Minimum, MinimumFromRaw>))]
public sealed record class Minimum : ModelBase
{
    /// <summary>
    /// List of price_ids that this minimum amount applies to. For plan/plan phase
    /// minimums, this can be a subset of prices.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIDs
    {
        get
        {
            if (!this._rawData.TryGetValue("applies_to_price_ids", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "applies_to_price_ids",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new System::ArgumentNullException("applies_to_price_ids")
                );
        }
        init
        {
            this._rawData["applies_to_price_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this minimum to.
    /// </summary>
    public required IReadOnlyList<Filter4> Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Filter4>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        init
        {
            this._rawData["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("minimum_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_amount' cannot be null",
                    new System::ArgumentNullException("minimum_amount")
                );
        }
        init
        {
            this._rawData["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MinimumAmount;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Minimum() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public Minimum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete("Required properties are deprecated: applies_to_price_ids"),
        SetsRequiredMembers
    ]
    Minimum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumFromRaw : IFromRaw<Minimum>
{
    public Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Minimum.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Filter4, Filter4FromRaw>))]
public sealed record class Filter4 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter4Field> Field
    {
        get
        {
            if (!this._rawData.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter4Field>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentNullException("field")
                );
        }
        init
        {
            this._rawData["field"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter4Operator> Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter4Operator>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentNullException("operator")
                );
        }
        init
        {
            this._rawData["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get
        {
            if (!this._rawData.TryGetValue("values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'values' cannot be null",
                    new System::ArgumentOutOfRangeException("values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'values' cannot be null",
                    new System::ArgumentNullException("values")
                );
        }
        init
        {
            this._rawData["values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public Filter4() { }

    public Filter4(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter4(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter4 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter4FromRaw : IFromRaw<Filter4>
{
    public Filter4 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter4.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter4FieldConverter))]
public enum Filter4Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter4FieldConverter : JsonConverter<Filter4Field>
{
    public override Filter4Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter4Field.PriceID,
            "item_id" => Filter4Field.ItemID,
            "price_type" => Filter4Field.PriceType,
            "currency" => Filter4Field.Currency,
            "pricing_unit_id" => Filter4Field.PricingUnitID,
            _ => (Filter4Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter4Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter4Field.PriceID => "price_id",
                Filter4Field.ItemID => "item_id",
                Filter4Field.PriceType => "price_type",
                Filter4Field.Currency => "currency",
                Filter4Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter4OperatorConverter))]
public enum Filter4Operator
{
    Includes,
    Excludes,
}

sealed class Filter4OperatorConverter : JsonConverter<Filter4Operator>
{
    public override Filter4Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter4Operator.Includes,
            "excludes" => Filter4Operator.Excludes,
            _ => (Filter4Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter4Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter4Operator.Includes => "includes",
                Filter4Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
