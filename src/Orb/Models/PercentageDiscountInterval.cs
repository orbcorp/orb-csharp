using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<PercentageDiscountInterval, PercentageDiscountIntervalFromRaw>)
)]
public sealed record class PercentageDiscountInterval : ModelBase
{
    /// <summary>
    /// The price interval ids that this discount interval applies to.
    /// </summary>
    public required List<string> AppliesToPriceIntervalIDs
    {
        get
        {
            if (
                !this._rawData.TryGetValue("applies_to_price_interval_ids", out JsonElement element)
            )
                throw new OrbInvalidDataException(
                    "'applies_to_price_interval_ids' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "applies_to_price_interval_ids",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'applies_to_price_interval_ids' cannot be null",
                    new System::ArgumentNullException("applies_to_price_interval_ids")
                );
        }
        init
        {
            this._rawData["applies_to_price_interval_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, PercentageDiscountIntervalDiscountType> DiscountType
    {
        get
        {
            if (!this._rawData.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, PercentageDiscountIntervalDiscountType>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            if (!this._rawData.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices this discount interval applies to.
    /// </summary>
    public required List<Filter18> Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Filter18>>(element, ModelBase.SerializerOptions)
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
    /// Only available if discount_type is `percentage`.This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscount
    {
        get
        {
            if (!this._rawData.TryGetValue("percentage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percentage_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percentage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            if (!this._rawData.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "start_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AppliesToPriceIntervalIDs;
        this.DiscountType.Validate();
        _ = this.EndDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.PercentageDiscount;
        _ = this.StartDate;
    }

    public PercentageDiscountInterval() { }

    public PercentageDiscountInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscountInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PercentageDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentageDiscountIntervalFromRaw : IFromRaw<PercentageDiscountInterval>
{
    public PercentageDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PercentageDiscountInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PercentageDiscountIntervalDiscountTypeConverter))]
public enum PercentageDiscountIntervalDiscountType
{
    Percentage,
}

sealed class PercentageDiscountIntervalDiscountTypeConverter
    : JsonConverter<PercentageDiscountIntervalDiscountType>
{
    public override PercentageDiscountIntervalDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => PercentageDiscountIntervalDiscountType.Percentage,
            _ => (PercentageDiscountIntervalDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentageDiscountIntervalDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentageDiscountIntervalDiscountType.Percentage => "percentage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter18, Filter18FromRaw>))]
public sealed record class Filter18 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter18Field> Field
    {
        get
        {
            if (!this._rawData.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter18Field>>(
                element,
                ModelBase.SerializerOptions
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
    public required ApiEnum<string, Filter18Operator> Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter18Operator>>(
                element,
                ModelBase.SerializerOptions
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
    public required List<string> Values
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

    public Filter18() { }

    public Filter18(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter18(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter18 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter18FromRaw : IFromRaw<Filter18>
{
    public Filter18 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter18.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter18FieldConverter))]
public enum Filter18Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter18FieldConverter : JsonConverter<Filter18Field>
{
    public override Filter18Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter18Field.PriceID,
            "item_id" => Filter18Field.ItemID,
            "price_type" => Filter18Field.PriceType,
            "currency" => Filter18Field.Currency,
            "pricing_unit_id" => Filter18Field.PricingUnitID,
            _ => (Filter18Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter18Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter18Field.PriceID => "price_id",
                Filter18Field.ItemID => "item_id",
                Filter18Field.PriceType => "price_type",
                Filter18Field.Currency => "currency",
                Filter18Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter18OperatorConverter))]
public enum Filter18Operator
{
    Includes,
    Excludes,
}

sealed class Filter18OperatorConverter : JsonConverter<Filter18Operator>
{
    public override Filter18Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter18Operator.Includes,
            "excludes" => Filter18Operator.Excludes,
            _ => (Filter18Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter18Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter18Operator.Includes => "includes",
                Filter18Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
