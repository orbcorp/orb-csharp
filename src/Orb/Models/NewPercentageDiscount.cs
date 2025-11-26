using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewPercentageDiscount, NewPercentageDiscountFromRaw>))]
public sealed record class NewPercentageDiscount : ModelBase
{
    public required ApiEnum<string, NewPercentageDiscountAdjustmentType> AdjustmentType
    {
        get
        {
            if (!this._rawData.TryGetValue("adjustment_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, NewPercentageDiscountAdjustmentType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["adjustment_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, NewPercentageDiscountAppliesToAll>? AppliesToAll
    {
        get
        {
            if (!this._rawData.TryGetValue("applies_to_all", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, NewPercentageDiscountAppliesToAll>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["applies_to_all"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The set of item IDs to which this adjustment applies.
    /// </summary>
    public IReadOnlyList<string>? AppliesToItemIDs
    {
        get
        {
            if (!this._rawData.TryGetValue("applies_to_item_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["applies_to_item_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The set of price IDs to which this adjustment applies.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIDs
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
    /// If set, only prices in the specified currency will have the adjustment applied.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
    /// </summary>
    public IReadOnlyList<Filter15>? Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter15>?>(
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

    /// <summary>
    /// When false, this adjustment will be applied to a single price. Otherwise,
    /// it will be applied at the invoice level, possibly to multiple prices.
    /// </summary>
    public bool? IsInvoiceLevel
    {
        get
        {
            if (!this._rawData.TryGetValue("is_invoice_level", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["is_invoice_level"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set, only prices of the specified type will have the adjustment applied.
    /// </summary>
    public ApiEnum<string, NewPercentageDiscountPriceType>? PriceType
    {
        get
        {
            if (!this._rawData.TryGetValue("price_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, NewPercentageDiscountPriceType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["price_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.PercentageDiscount;
        this.AppliesToAll?.Validate();
        _ = this.AppliesToItemIDs;
        _ = this.AppliesToPriceIDs;
        _ = this.Currency;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        this.PriceType?.Validate();
    }

    public NewPercentageDiscount() { }

    public NewPercentageDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPercentageDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewPercentageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPercentageDiscountFromRaw : IFromRaw<NewPercentageDiscount>
{
    public NewPercentageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPercentageDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewPercentageDiscountAdjustmentTypeConverter))]
public enum NewPercentageDiscountAdjustmentType
{
    PercentageDiscount,
}

sealed class NewPercentageDiscountAdjustmentTypeConverter
    : JsonConverter<NewPercentageDiscountAdjustmentType>
{
    public override NewPercentageDiscountAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage_discount" => NewPercentageDiscountAdjustmentType.PercentageDiscount,
            _ => (NewPercentageDiscountAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPercentageDiscountAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPercentageDiscountAdjustmentType.PercentageDiscount => "percentage_discount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If set, the adjustment will apply to every price on the subscription.
/// </summary>
[JsonConverter(typeof(NewPercentageDiscountAppliesToAllConverter))]
public enum NewPercentageDiscountAppliesToAll
{
    True,
}

sealed class NewPercentageDiscountAppliesToAllConverter
    : JsonConverter<NewPercentageDiscountAppliesToAll>
{
    public override NewPercentageDiscountAppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => NewPercentageDiscountAppliesToAll.True,
            _ => (NewPercentageDiscountAppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPercentageDiscountAppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPercentageDiscountAppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter15, Filter15FromRaw>))]
public sealed record class Filter15 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter15Field> Field
    {
        get
        {
            if (!this._rawData.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter15Field>>(
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
    public required ApiEnum<string, Filter15Operator> Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter15Operator>>(
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

    public Filter15() { }

    public Filter15(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter15(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter15 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter15FromRaw : IFromRaw<Filter15>
{
    public Filter15 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter15.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter15FieldConverter))]
public enum Filter15Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter15FieldConverter : JsonConverter<Filter15Field>
{
    public override Filter15Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter15Field.PriceID,
            "item_id" => Filter15Field.ItemID,
            "price_type" => Filter15Field.PriceType,
            "currency" => Filter15Field.Currency,
            "pricing_unit_id" => Filter15Field.PricingUnitID,
            _ => (Filter15Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter15Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter15Field.PriceID => "price_id",
                Filter15Field.ItemID => "item_id",
                Filter15Field.PriceType => "price_type",
                Filter15Field.Currency => "currency",
                Filter15Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter15OperatorConverter))]
public enum Filter15Operator
{
    Includes,
    Excludes,
}

sealed class Filter15OperatorConverter : JsonConverter<Filter15Operator>
{
    public override Filter15Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter15Operator.Includes,
            "excludes" => Filter15Operator.Excludes,
            _ => (Filter15Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter15Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter15Operator.Includes => "includes",
                Filter15Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If set, only prices of the specified type will have the adjustment applied.
/// </summary>
[JsonConverter(typeof(NewPercentageDiscountPriceTypeConverter))]
public enum NewPercentageDiscountPriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class NewPercentageDiscountPriceTypeConverter : JsonConverter<NewPercentageDiscountPriceType>
{
    public override NewPercentageDiscountPriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => NewPercentageDiscountPriceType.Usage,
            "fixed_in_advance" => NewPercentageDiscountPriceType.FixedInAdvance,
            "fixed_in_arrears" => NewPercentageDiscountPriceType.FixedInArrears,
            "fixed" => NewPercentageDiscountPriceType.Fixed,
            "in_arrears" => NewPercentageDiscountPriceType.InArrears,
            _ => (NewPercentageDiscountPriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPercentageDiscountPriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPercentageDiscountPriceType.Usage => "usage",
                NewPercentageDiscountPriceType.FixedInAdvance => "fixed_in_advance",
                NewPercentageDiscountPriceType.FixedInArrears => "fixed_in_arrears",
                NewPercentageDiscountPriceType.Fixed => "fixed",
                NewPercentageDiscountPriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
