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
        PlanPhasePercentageDiscountAdjustment,
        PlanPhasePercentageDiscountAdjustmentFromRaw
    >)
)]
public sealed record class PlanPhasePercentageDiscountAdjustment : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<
        string,
        PlanPhasePercentageDiscountAdjustmentAdjustmentType
    > AdjustmentType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType>
            >(this.RawData, "adjustment_type");
        }
        init { ModelBase.Set(this._rawData, "adjustment_type", value); }
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
    public required IReadOnlyList<Filter22> Filters
    {
        get { return ModelBase.GetNotNullClass<List<Filter22>>(this.RawData, "filters"); }
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
    /// The plan phase in which this adjustment is active.
    /// </summary>
    public required long? PlanPhaseOrder
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { ModelBase.Set(this._rawData, "plan_phase_order", value); }
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
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.PercentageDiscount;
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhasePercentageDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhasePercentageDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete("Required properties are deprecated: applies_to_price_ids"),
        SetsRequiredMembers
    ]
    PlanPhasePercentageDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PlanPhasePercentageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhasePercentageDiscountAdjustmentFromRaw : IFromRaw<PlanPhasePercentageDiscountAdjustment>
{
    public PlanPhasePercentageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhasePercentageDiscountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanPhasePercentageDiscountAdjustmentAdjustmentTypeConverter))]
public enum PlanPhasePercentageDiscountAdjustmentAdjustmentType
{
    PercentageDiscount,
}

sealed class PlanPhasePercentageDiscountAdjustmentAdjustmentTypeConverter
    : JsonConverter<PlanPhasePercentageDiscountAdjustmentAdjustmentType>
{
    public override PlanPhasePercentageDiscountAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage_discount" =>
                PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            _ => (PlanPhasePercentageDiscountAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhasePercentageDiscountAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount =>
                    "percentage_discount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter22, Filter22FromRaw>))]
public sealed record class Filter22 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter22Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter22Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter22Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter22Operator>>(
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

    public Filter22() { }

    public Filter22(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter22(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter22 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter22FromRaw : IFromRaw<Filter22>
{
    public Filter22 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter22.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter22FieldConverter))]
public enum Filter22Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter22FieldConverter : JsonConverter<Filter22Field>
{
    public override Filter22Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter22Field.PriceID,
            "item_id" => Filter22Field.ItemID,
            "price_type" => Filter22Field.PriceType,
            "currency" => Filter22Field.Currency,
            "pricing_unit_id" => Filter22Field.PricingUnitID,
            _ => (Filter22Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter22Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter22Field.PriceID => "price_id",
                Filter22Field.ItemID => "item_id",
                Filter22Field.PriceType => "price_type",
                Filter22Field.Currency => "currency",
                Filter22Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter22OperatorConverter))]
public enum Filter22Operator
{
    Includes,
    Excludes,
}

sealed class Filter22OperatorConverter : JsonConverter<Filter22Operator>
{
    public override Filter22Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter22Operator.Includes,
            "excludes" => Filter22Operator.Excludes,
            _ => (Filter22Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter22Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter22Operator.Includes => "includes",
                Filter22Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
