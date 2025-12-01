using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewUsageDiscount, NewUsageDiscountFromRaw>))]
public sealed record class NewUsageDiscount : ModelBase
{
    public required ApiEnum<string, NewUsageDiscountAdjustmentType> AdjustmentType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, NewUsageDiscountAdjustmentType>>(
                this.RawData,
                "adjustment_type"
            );
        }
        init { ModelBase.Set(this._rawData, "adjustment_type", value); }
    }

    public required double UsageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "usage_discount"); }
        init { ModelBase.Set(this._rawData, "usage_discount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, NewUsageDiscountAppliesToAll>? AppliesToAll
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<bool, NewUsageDiscountAppliesToAll>>(
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
    public IReadOnlyList<Filter16>? Filters
    {
        get { return ModelBase.GetNullableClass<List<Filter16>>(this.RawData, "filters"); }
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
    public ApiEnum<string, NewUsageDiscountPriceType>? PriceType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, NewUsageDiscountPriceType>>(
                this.RawData,
                "price_type"
            );
        }
        init { ModelBase.Set(this._rawData, "price_type", value); }
    }

    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.UsageDiscount;
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

    public NewUsageDiscount() { }

    public NewUsageDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewUsageDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewUsageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewUsageDiscountFromRaw : IFromRaw<NewUsageDiscount>
{
    public NewUsageDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewUsageDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewUsageDiscountAdjustmentTypeConverter))]
public enum NewUsageDiscountAdjustmentType
{
    UsageDiscount,
}

sealed class NewUsageDiscountAdjustmentTypeConverter : JsonConverter<NewUsageDiscountAdjustmentType>
{
    public override NewUsageDiscountAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_discount" => NewUsageDiscountAdjustmentType.UsageDiscount,
            _ => (NewUsageDiscountAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewUsageDiscountAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewUsageDiscountAdjustmentType.UsageDiscount => "usage_discount",
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
[JsonConverter(typeof(NewUsageDiscountAppliesToAllConverter))]
public enum NewUsageDiscountAppliesToAll
{
    True,
}

sealed class NewUsageDiscountAppliesToAllConverter : JsonConverter<NewUsageDiscountAppliesToAll>
{
    public override NewUsageDiscountAppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => NewUsageDiscountAppliesToAll.True,
            _ => (NewUsageDiscountAppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewUsageDiscountAppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewUsageDiscountAppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter16, Filter16FromRaw>))]
public sealed record class Filter16 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter16Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter16Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter16Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter16Operator>>(
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

    public Filter16() { }

    public Filter16(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter16(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter16 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter16FromRaw : IFromRaw<Filter16>
{
    public Filter16 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter16.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter16FieldConverter))]
public enum Filter16Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter16FieldConverter : JsonConverter<Filter16Field>
{
    public override Filter16Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter16Field.PriceID,
            "item_id" => Filter16Field.ItemID,
            "price_type" => Filter16Field.PriceType,
            "currency" => Filter16Field.Currency,
            "pricing_unit_id" => Filter16Field.PricingUnitID,
            _ => (Filter16Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter16Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter16Field.PriceID => "price_id",
                Filter16Field.ItemID => "item_id",
                Filter16Field.PriceType => "price_type",
                Filter16Field.Currency => "currency",
                Filter16Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter16OperatorConverter))]
public enum Filter16Operator
{
    Includes,
    Excludes,
}

sealed class Filter16OperatorConverter : JsonConverter<Filter16Operator>
{
    public override Filter16Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter16Operator.Includes,
            "excludes" => Filter16Operator.Excludes,
            _ => (Filter16Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter16Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter16Operator.Includes => "includes",
                Filter16Operator.Excludes => "excludes",
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
[JsonConverter(typeof(NewUsageDiscountPriceTypeConverter))]
public enum NewUsageDiscountPriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class NewUsageDiscountPriceTypeConverter : JsonConverter<NewUsageDiscountPriceType>
{
    public override NewUsageDiscountPriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => NewUsageDiscountPriceType.Usage,
            "fixed_in_advance" => NewUsageDiscountPriceType.FixedInAdvance,
            "fixed_in_arrears" => NewUsageDiscountPriceType.FixedInArrears,
            "fixed" => NewUsageDiscountPriceType.Fixed,
            "in_arrears" => NewUsageDiscountPriceType.InArrears,
            _ => (NewUsageDiscountPriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewUsageDiscountPriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewUsageDiscountPriceType.Usage => "usage",
                NewUsageDiscountPriceType.FixedInAdvance => "fixed_in_advance",
                NewUsageDiscountPriceType.FixedInArrears => "fixed_in_arrears",
                NewUsageDiscountPriceType.Fixed => "fixed",
                NewUsageDiscountPriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
