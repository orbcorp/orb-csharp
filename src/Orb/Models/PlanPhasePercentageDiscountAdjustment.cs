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
        PlanPhasePercentageDiscountAdjustment,
        PlanPhasePercentageDiscountAdjustmentFromRaw
    >)
)]
public sealed record class PlanPhasePercentageDiscountAdjustment : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<
        string,
        PlanPhasePercentageDiscountAdjustmentAdjustmentType
    > AdjustmentType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType>
            >(this.RawData, "adjustment_type");
        }
        init { JsonModel.Set(this._rawData, "adjustment_type", value); }
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
    public required IReadOnlyList<PlanPhasePercentageDiscountAdjustmentFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<PlanPhasePercentageDiscountAdjustmentFilter>>(
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
    /// The percentage (as a value between 0 and 1) by which to discount the price
    /// intervals this adjustment applies to in a given billing period.
    /// </summary>
    public required double PercentageDiscount
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { JsonModel.Set(this._rawData, "percentage_discount", value); }
    }

    /// <summary>
    /// The plan phase in which this adjustment is active.
    /// </summary>
    public required long? PlanPhaseOrder
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { JsonModel.Set(this._rawData, "plan_phase_order", value); }
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
        _ = this.AppliesToPriceIds;
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
    public PlanPhasePercentageDiscountAdjustment(
        PlanPhasePercentageDiscountAdjustment planPhasePercentageDiscountAdjustment
    )
        : base(planPhasePercentageDiscountAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhasePercentageDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    PlanPhasePercentageDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPhasePercentageDiscountAdjustmentFromRaw.FromRawUnchecked"/>
    public static PlanPhasePercentageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhasePercentageDiscountAdjustmentFromRaw
    : IFromRawJson<PlanPhasePercentageDiscountAdjustment>
{
    /// <inheritdoc/>
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

[JsonConverter(
    typeof(JsonModelConverter<
        PlanPhasePercentageDiscountAdjustmentFilter,
        PlanPhasePercentageDiscountAdjustmentFilterFromRaw
    >)
)]
public sealed record class PlanPhasePercentageDiscountAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField>
            >(this.RawData, "field");
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator>
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

    public PlanPhasePercentageDiscountAdjustmentFilter() { }

    public PlanPhasePercentageDiscountAdjustmentFilter(
        PlanPhasePercentageDiscountAdjustmentFilter planPhasePercentageDiscountAdjustmentFilter
    )
        : base(planPhasePercentageDiscountAdjustmentFilter) { }

    public PlanPhasePercentageDiscountAdjustmentFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPhasePercentageDiscountAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPhasePercentageDiscountAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static PlanPhasePercentageDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhasePercentageDiscountAdjustmentFilterFromRaw
    : IFromRawJson<PlanPhasePercentageDiscountAdjustmentFilter>
{
    /// <inheritdoc/>
    public PlanPhasePercentageDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhasePercentageDiscountAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(PlanPhasePercentageDiscountAdjustmentFilterFieldConverter))]
public enum PlanPhasePercentageDiscountAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class PlanPhasePercentageDiscountAdjustmentFilterFieldConverter
    : JsonConverter<PlanPhasePercentageDiscountAdjustmentFilterField>
{
    public override PlanPhasePercentageDiscountAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
            "item_id" => PlanPhasePercentageDiscountAdjustmentFilterField.ItemID,
            "price_type" => PlanPhasePercentageDiscountAdjustmentFilterField.PriceType,
            "currency" => PlanPhasePercentageDiscountAdjustmentFilterField.Currency,
            "pricing_unit_id" => PlanPhasePercentageDiscountAdjustmentFilterField.PricingUnitID,
            _ => (PlanPhasePercentageDiscountAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhasePercentageDiscountAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhasePercentageDiscountAdjustmentFilterField.PriceID => "price_id",
                PlanPhasePercentageDiscountAdjustmentFilterField.ItemID => "item_id",
                PlanPhasePercentageDiscountAdjustmentFilterField.PriceType => "price_type",
                PlanPhasePercentageDiscountAdjustmentFilterField.Currency => "currency",
                PlanPhasePercentageDiscountAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(PlanPhasePercentageDiscountAdjustmentFilterOperatorConverter))]
public enum PlanPhasePercentageDiscountAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class PlanPhasePercentageDiscountAdjustmentFilterOperatorConverter
    : JsonConverter<PlanPhasePercentageDiscountAdjustmentFilterOperator>
{
    public override PlanPhasePercentageDiscountAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
            "excludes" => PlanPhasePercentageDiscountAdjustmentFilterOperator.Excludes,
            _ => (PlanPhasePercentageDiscountAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhasePercentageDiscountAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes => "includes",
                PlanPhasePercentageDiscountAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
