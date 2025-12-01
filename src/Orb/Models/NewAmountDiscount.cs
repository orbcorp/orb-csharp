using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewAmountDiscount, NewAmountDiscountFromRaw>))]
public sealed record class NewAmountDiscount : ModelBase
{
    public required ApiEnum<string, NewAmountDiscountAdjustmentType> AdjustmentType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, NewAmountDiscountAdjustmentType>>(
                this.RawData,
                "adjustment_type"
            );
        }
        init { ModelBase.Set(this._rawData, "adjustment_type", value); }
    }

    public required string AmountDiscount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount_discount"); }
        init { ModelBase.Set(this._rawData, "amount_discount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, AppliesToAll>? AppliesToAll
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<bool, AppliesToAll>>(
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
    public IReadOnlyList<Filter12>? Filters
    {
        get { return ModelBase.GetNullableClass<List<Filter12>>(this.RawData, "filters"); }
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
    public ApiEnum<string, PriceType>? PriceType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, PriceType>>(
                this.RawData,
                "price_type"
            );
        }
        init { ModelBase.Set(this._rawData, "price_type", value); }
    }

    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.AmountDiscount;
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

    public NewAmountDiscount() { }

    public NewAmountDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAmountDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewAmountDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAmountDiscountFromRaw : IFromRaw<NewAmountDiscount>
{
    public NewAmountDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewAmountDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewAmountDiscountAdjustmentTypeConverter))]
public enum NewAmountDiscountAdjustmentType
{
    AmountDiscount,
}

sealed class NewAmountDiscountAdjustmentTypeConverter
    : JsonConverter<NewAmountDiscountAdjustmentType>
{
    public override NewAmountDiscountAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount_discount" => NewAmountDiscountAdjustmentType.AmountDiscount,
            _ => (NewAmountDiscountAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewAmountDiscountAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewAmountDiscountAdjustmentType.AmountDiscount => "amount_discount",
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
[JsonConverter(typeof(AppliesToAllConverter))]
public enum AppliesToAll
{
    True,
}

sealed class AppliesToAllConverter : JsonConverter<AppliesToAll>
{
    public override AppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AppliesToAll.True,
            _ => (AppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter12, Filter12FromRaw>))]
public sealed record class Filter12 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter12Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter12Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter12Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter12Operator>>(
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

    public Filter12() { }

    public Filter12(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter12(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter12 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter12FromRaw : IFromRaw<Filter12>
{
    public Filter12 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter12.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter12FieldConverter))]
public enum Filter12Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter12FieldConverter : JsonConverter<Filter12Field>
{
    public override Filter12Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter12Field.PriceID,
            "item_id" => Filter12Field.ItemID,
            "price_type" => Filter12Field.PriceType,
            "currency" => Filter12Field.Currency,
            "pricing_unit_id" => Filter12Field.PricingUnitID,
            _ => (Filter12Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter12Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter12Field.PriceID => "price_id",
                Filter12Field.ItemID => "item_id",
                Filter12Field.PriceType => "price_type",
                Filter12Field.Currency => "currency",
                Filter12Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter12OperatorConverter))]
public enum Filter12Operator
{
    Includes,
    Excludes,
}

sealed class Filter12OperatorConverter : JsonConverter<Filter12Operator>
{
    public override Filter12Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter12Operator.Includes,
            "excludes" => Filter12Operator.Excludes,
            _ => (Filter12Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter12Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter12Operator.Includes => "includes",
                Filter12Operator.Excludes => "excludes",
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
[JsonConverter(typeof(PriceTypeConverter))]
public enum PriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class PriceTypeConverter : JsonConverter<PriceType>
{
    public override PriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => PriceType.Usage,
            "fixed_in_advance" => PriceType.FixedInAdvance,
            "fixed_in_arrears" => PriceType.FixedInArrears,
            "fixed" => PriceType.Fixed,
            "in_arrears" => PriceType.InArrears,
            _ => (PriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceType.Usage => "usage",
                PriceType.FixedInAdvance => "fixed_in_advance",
                PriceType.FixedInArrears => "fixed_in_arrears",
                PriceType.Fixed => "fixed",
                PriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
