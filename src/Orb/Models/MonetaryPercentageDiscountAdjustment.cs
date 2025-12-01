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
    typeof(ModelConverter<
        MonetaryPercentageDiscountAdjustment,
        MonetaryPercentageDiscountAdjustmentFromRaw
    >)
)]
public sealed record class MonetaryPercentageDiscountAdjustment : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<
        string,
        MonetaryPercentageDiscountAdjustmentAdjustmentType
    > AdjustmentType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType>
            >(this.RawData, "adjustment_type");
        }
        init { ModelBase.Set(this._rawData, "adjustment_type", value); }
    }

    /// <summary>
    /// The value applied by an adjustment.
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
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
    /// The filters that determine which prices to apply this adjustment to.
    /// </summary>
    public required IReadOnlyList<Filter9> Filters
    {
        get { return ModelBase.GetNotNullClass<List<Filter9>>(this.RawData, "filters"); }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// True for adjustments that apply to an entire invoice, false for adjustments
    /// that apply to only one price.
    /// </summary>
    public required bool IsInvoiceLevel
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "is_invoice_level"); }
        init { ModelBase.Set(this._rawData, "is_invoice_level", value); }
    }

    /// <summary>
    /// The percentage (as a value between 0 and 1) by which to discount the price
    /// intervals this adjustment applies to in a given billing period.
    /// </summary>
    public required double PercentageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { ModelBase.Set(this._rawData, "percentage_discount", value); }
    }

    /// <summary>
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the
    /// place of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "replaces_adjustment_id"); }
        init { ModelBase.Set(this._rawData, "replaces_adjustment_id", value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.AdjustmentType.Validate();
        _ = this.Amount;
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.PercentageDiscount;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryPercentageDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryPercentageDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete("Required properties are deprecated: applies_to_price_ids"),
        SetsRequiredMembers
    ]
    MonetaryPercentageDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MonetaryPercentageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryPercentageDiscountAdjustmentFromRaw : IFromRaw<MonetaryPercentageDiscountAdjustment>
{
    public MonetaryPercentageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryPercentageDiscountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonetaryPercentageDiscountAdjustmentAdjustmentTypeConverter))]
public enum MonetaryPercentageDiscountAdjustmentAdjustmentType
{
    PercentageDiscount,
}

sealed class MonetaryPercentageDiscountAdjustmentAdjustmentTypeConverter
    : JsonConverter<MonetaryPercentageDiscountAdjustmentAdjustmentType>
{
    public override MonetaryPercentageDiscountAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage_discount" =>
                MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            _ => (MonetaryPercentageDiscountAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryPercentageDiscountAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount =>
                    "percentage_discount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter9, Filter9FromRaw>))]
public sealed record class Filter9 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter9Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter9Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter9Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter9Operator>>(
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

    public Filter9() { }

    public Filter9(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter9(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter9 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter9FromRaw : IFromRaw<Filter9>
{
    public Filter9 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter9.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter9FieldConverter))]
public enum Filter9Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter9FieldConverter : JsonConverter<Filter9Field>
{
    public override Filter9Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter9Field.PriceID,
            "item_id" => Filter9Field.ItemID,
            "price_type" => Filter9Field.PriceType,
            "currency" => Filter9Field.Currency,
            "pricing_unit_id" => Filter9Field.PricingUnitID,
            _ => (Filter9Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter9Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter9Field.PriceID => "price_id",
                Filter9Field.ItemID => "item_id",
                Filter9Field.PriceType => "price_type",
                Filter9Field.Currency => "currency",
                Filter9Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter9OperatorConverter))]
public enum Filter9Operator
{
    Includes,
    Excludes,
}

sealed class Filter9OperatorConverter : JsonConverter<Filter9Operator>
{
    public override Filter9Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter9Operator.Includes,
            "excludes" => Filter9Operator.Excludes,
            _ => (Filter9Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter9Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter9Operator.Includes => "includes",
                Filter9Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
