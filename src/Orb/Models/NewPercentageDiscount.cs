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
            return ModelBase.GetNotNullClass<ApiEnum<string, NewPercentageDiscountAdjustmentType>>(
                this.RawData,
                "adjustment_type"
            );
        }
        init { ModelBase.Set(this._rawData, "adjustment_type", value); }
    }

    public required double PercentageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { ModelBase.Set(this._rawData, "percentage_discount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, NewPercentageDiscountAppliesToAll>? AppliesToAll
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<bool, NewPercentageDiscountAppliesToAll>>(
                this.RawData,
                "applies_to_all"
            );
        }
        init { ModelBase.Set(this._rawData, "applies_to_all", value); }
    }

    /// <summary>
    /// The set of item IDs to which this adjustment applies.
    /// </summary>
    public IReadOnlyList<string>? AppliesToItemIDs
    {
        get
        {
            return ModelBase.GetNullableClass<List<string>>(this.RawData, "applies_to_item_ids");
        }
        init { ModelBase.Set(this._rawData, "applies_to_item_ids", value); }
    }

    /// <summary>
    /// The set of price IDs to which this adjustment applies.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIDs
    {
        get
        {
            return ModelBase.GetNullableClass<List<string>>(this.RawData, "applies_to_price_ids");
        }
        init { ModelBase.Set(this._rawData, "applies_to_price_ids", value); }
    }

    /// <summary>
    /// If set, only prices in the specified currency will have the adjustment applied.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
    /// </summary>
    public IReadOnlyList<Filter15>? Filters
    {
        get { return ModelBase.GetNullableClass<List<Filter15>>(this.RawData, "filters"); }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// When false, this adjustment will be applied to a single price. Otherwise,
    /// it will be applied at the invoice level, possibly to multiple prices.
    /// </summary>
    public bool? IsInvoiceLevel
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "is_invoice_level"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "is_invoice_level", value);
        }
    }

    /// <summary>
    /// If set, only prices of the specified type will have the adjustment applied.
    /// </summary>
    public ApiEnum<string, NewPercentageDiscountPriceType>? PriceType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, NewPercentageDiscountPriceType>>(
                this.RawData,
                "price_type"
            );
        }
        init { ModelBase.Set(this._rawData, "price_type", value); }
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
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter15Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter15Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter15Operator>>(
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
