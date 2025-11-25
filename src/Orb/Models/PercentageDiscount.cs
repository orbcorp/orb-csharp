using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<PercentageDiscount, PercentageDiscountFromRaw>))]
public sealed record class PercentageDiscount : ModelBase
{
    public required ApiEnum<string, PercentageDiscountDiscountType> DiscountType
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

            return JsonSerializer.Deserialize<ApiEnum<string, PercentageDiscountDiscountType>>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscount1
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
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public List<string>? AppliesToPriceIDs
    {
        get
        {
            if (!this._rawData.TryGetValue("applies_to_price_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
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
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public List<Filter17>? Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter17>?>(
                element,
                ModelBase.SerializerOptions
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

    public string? Reason
    {
        get
        {
            if (!this._rawData.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.PercentageDiscount1;
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public PercentageDiscount() { }

    public PercentageDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PercentageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentageDiscountFromRaw : IFromRaw<PercentageDiscount>
{
    public PercentageDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PercentageDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PercentageDiscountDiscountTypeConverter))]
public enum PercentageDiscountDiscountType
{
    Percentage,
}

sealed class PercentageDiscountDiscountTypeConverter : JsonConverter<PercentageDiscountDiscountType>
{
    public override PercentageDiscountDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => PercentageDiscountDiscountType.Percentage,
            _ => (PercentageDiscountDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PercentageDiscountDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PercentageDiscountDiscountType.Percentage => "percentage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter17, Filter17FromRaw>))]
public sealed record class Filter17 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter17Field> Field
    {
        get
        {
            if (!this._rawData.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter17Field>>(
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
    public required ApiEnum<string, Filter17Operator> Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter17Operator>>(
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

    public Filter17() { }

    public Filter17(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter17(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter17 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter17FromRaw : IFromRaw<Filter17>
{
    public Filter17 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter17.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter17FieldConverter))]
public enum Filter17Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter17FieldConverter : JsonConverter<Filter17Field>
{
    public override Filter17Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter17Field.PriceID,
            "item_id" => Filter17Field.ItemID,
            "price_type" => Filter17Field.PriceType,
            "currency" => Filter17Field.Currency,
            "pricing_unit_id" => Filter17Field.PricingUnitID,
            _ => (Filter17Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter17Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter17Field.PriceID => "price_id",
                Filter17Field.ItemID => "item_id",
                Filter17Field.PriceType => "price_type",
                Filter17Field.Currency => "currency",
                Filter17Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter17OperatorConverter))]
public enum Filter17Operator
{
    Includes,
    Excludes,
}

sealed class Filter17OperatorConverter : JsonConverter<Filter17Operator>
{
    public override Filter17Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter17Operator.Includes,
            "excludes" => Filter17Operator.Excludes,
            _ => (Filter17Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter17Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter17Operator.Includes => "includes",
                Filter17Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
