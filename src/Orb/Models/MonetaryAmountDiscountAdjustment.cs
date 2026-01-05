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
    typeof(JsonModelConverter<
        MonetaryAmountDiscountAdjustment,
        MonetaryAmountDiscountAdjustmentFromRaw
    >)
)]
public sealed record class MonetaryAmountDiscountAdjustment : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, AdjustmentType> AdjustmentType
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, AdjustmentType>>(
                this.RawData,
                "adjustment_type"
            );
        }
        init { JsonModel.Set(this._rawData, "adjustment_type", value); }
    }

    /// <summary>
    /// The value applied by an adjustment.
    /// </summary>
    public required string Amount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The amount by which to discount the prices this adjustment applies to in a
    /// given billing period.
    /// </summary>
    public required string AmountDiscount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "amount_discount"); }
        init { JsonModel.Set(this._rawData, "amount_discount", value); }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
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
    /// The filters that determine which prices to apply this adjustment to.
    /// </summary>
    public required IReadOnlyList<MonetaryAmountDiscountAdjustmentFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<MonetaryAmountDiscountAdjustmentFilter>>(
                this.RawData,
                "filters"
            );
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// True for adjustments that apply to an entire invoice, false for adjustments
    /// that apply to only one price.
    /// </summary>
    public required bool IsInvoiceLevel
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "is_invoice_level"); }
        init { JsonModel.Set(this._rawData, "is_invoice_level", value); }
    }

    /// <summary>
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reason"); }
        init { JsonModel.Set(this._rawData, "reason", value); }
    }

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the
    /// place of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "replaces_adjustment_id"); }
        init { JsonModel.Set(this._rawData, "replaces_adjustment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AdjustmentType.Validate();
        _ = this.Amount;
        _ = this.AmountDiscount;
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryAmountDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryAmountDiscountAdjustment(
        MonetaryAmountDiscountAdjustment monetaryAmountDiscountAdjustment
    )
        : base(monetaryAmountDiscountAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryAmountDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    MonetaryAmountDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryAmountDiscountAdjustmentFromRaw.FromRawUnchecked"/>
    public static MonetaryAmountDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryAmountDiscountAdjustmentFromRaw : IFromRawJson<MonetaryAmountDiscountAdjustment>
{
    /// <inheritdoc/>
    public MonetaryAmountDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryAmountDiscountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AdjustmentTypeConverter))]
public enum AdjustmentType
{
    AmountDiscount,
}

sealed class AdjustmentTypeConverter : JsonConverter<AdjustmentType>
{
    public override AdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount_discount" => AdjustmentType.AmountDiscount,
            _ => (AdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentType.AmountDiscount => "amount_discount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        MonetaryAmountDiscountAdjustmentFilter,
        MonetaryAmountDiscountAdjustmentFilterFromRaw
    >)
)]
public sealed record class MonetaryAmountDiscountAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField>
            >(this.RawData, "field");
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator>
            >(this.RawData, "operator");
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

    public MonetaryAmountDiscountAdjustmentFilter() { }

    public MonetaryAmountDiscountAdjustmentFilter(
        MonetaryAmountDiscountAdjustmentFilter monetaryAmountDiscountAdjustmentFilter
    )
        : base(monetaryAmountDiscountAdjustmentFilter) { }

    public MonetaryAmountDiscountAdjustmentFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonetaryAmountDiscountAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryAmountDiscountAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static MonetaryAmountDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryAmountDiscountAdjustmentFilterFromRaw
    : IFromRawJson<MonetaryAmountDiscountAdjustmentFilter>
{
    /// <inheritdoc/>
    public MonetaryAmountDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryAmountDiscountAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MonetaryAmountDiscountAdjustmentFilterFieldConverter))]
public enum MonetaryAmountDiscountAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MonetaryAmountDiscountAdjustmentFilterFieldConverter
    : JsonConverter<MonetaryAmountDiscountAdjustmentFilterField>
{
    public override MonetaryAmountDiscountAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MonetaryAmountDiscountAdjustmentFilterField.PriceID,
            "item_id" => MonetaryAmountDiscountAdjustmentFilterField.ItemID,
            "price_type" => MonetaryAmountDiscountAdjustmentFilterField.PriceType,
            "currency" => MonetaryAmountDiscountAdjustmentFilterField.Currency,
            "pricing_unit_id" => MonetaryAmountDiscountAdjustmentFilterField.PricingUnitID,
            _ => (MonetaryAmountDiscountAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryAmountDiscountAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryAmountDiscountAdjustmentFilterField.PriceID => "price_id",
                MonetaryAmountDiscountAdjustmentFilterField.ItemID => "item_id",
                MonetaryAmountDiscountAdjustmentFilterField.PriceType => "price_type",
                MonetaryAmountDiscountAdjustmentFilterField.Currency => "currency",
                MonetaryAmountDiscountAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MonetaryAmountDiscountAdjustmentFilterOperatorConverter))]
public enum MonetaryAmountDiscountAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class MonetaryAmountDiscountAdjustmentFilterOperatorConverter
    : JsonConverter<MonetaryAmountDiscountAdjustmentFilterOperator>
{
    public override MonetaryAmountDiscountAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
            "excludes" => MonetaryAmountDiscountAdjustmentFilterOperator.Excludes,
            _ => (MonetaryAmountDiscountAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryAmountDiscountAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryAmountDiscountAdjustmentFilterOperator.Includes => "includes",
                MonetaryAmountDiscountAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
