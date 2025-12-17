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
        PlanPhaseUsageDiscountAdjustment,
        PlanPhaseUsageDiscountAdjustmentFromRaw
    >)
)]
public sealed record class PlanPhaseUsageDiscountAdjustment : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType>
            >(this.RawData, "adjustment_type");
        }
        init { JsonModel.Set(this._rawData, "adjustment_type", value); }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIDs
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
    public required IReadOnlyList<PlanPhaseUsageDiscountAdjustmentFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<PlanPhaseUsageDiscountAdjustmentFilter>>(
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

    /// <summary>
    /// The number of usage units by which to discount the price this adjustment applies
    /// to in a given billing period.
    /// </summary>
    public required double UsageDiscount
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "usage_discount"); }
        init { JsonModel.Set(this._rawData, "usage_discount", value); }
    }

    /// <inheritdoc/>
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
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
        _ = this.UsageDiscount;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseUsageDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseUsageDiscountAdjustment(
        PlanPhaseUsageDiscountAdjustment planPhaseUsageDiscountAdjustment
    )
        : base(planPhaseUsageDiscountAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseUsageDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    PlanPhaseUsageDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPhaseUsageDiscountAdjustmentFromRaw.FromRawUnchecked"/>
    public static PlanPhaseUsageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseUsageDiscountAdjustmentFromRaw : IFromRawJson<PlanPhaseUsageDiscountAdjustment>
{
    /// <inheritdoc/>
    public PlanPhaseUsageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhaseUsageDiscountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanPhaseUsageDiscountAdjustmentAdjustmentTypeConverter))]
public enum PlanPhaseUsageDiscountAdjustmentAdjustmentType
{
    UsageDiscount,
}

sealed class PlanPhaseUsageDiscountAdjustmentAdjustmentTypeConverter
    : JsonConverter<PlanPhaseUsageDiscountAdjustmentAdjustmentType>
{
    public override PlanPhaseUsageDiscountAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_discount" => PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            _ => (PlanPhaseUsageDiscountAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseUsageDiscountAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount => "usage_discount",
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
        PlanPhaseUsageDiscountAdjustmentFilter,
        PlanPhaseUsageDiscountAdjustmentFilterFromRaw
    >)
)]
public sealed record class PlanPhaseUsageDiscountAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterField>
            >(this.RawData, "field");
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PlanPhaseUsageDiscountAdjustmentFilterOperator>
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

    public PlanPhaseUsageDiscountAdjustmentFilter() { }

    public PlanPhaseUsageDiscountAdjustmentFilter(
        PlanPhaseUsageDiscountAdjustmentFilter planPhaseUsageDiscountAdjustmentFilter
    )
        : base(planPhaseUsageDiscountAdjustmentFilter) { }

    public PlanPhaseUsageDiscountAdjustmentFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPhaseUsageDiscountAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPhaseUsageDiscountAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static PlanPhaseUsageDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseUsageDiscountAdjustmentFilterFromRaw
    : IFromRawJson<PlanPhaseUsageDiscountAdjustmentFilter>
{
    /// <inheritdoc/>
    public PlanPhaseUsageDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhaseUsageDiscountAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(PlanPhaseUsageDiscountAdjustmentFilterFieldConverter))]
public enum PlanPhaseUsageDiscountAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class PlanPhaseUsageDiscountAdjustmentFilterFieldConverter
    : JsonConverter<PlanPhaseUsageDiscountAdjustmentFilterField>
{
    public override PlanPhaseUsageDiscountAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
            "item_id" => PlanPhaseUsageDiscountAdjustmentFilterField.ItemID,
            "price_type" => PlanPhaseUsageDiscountAdjustmentFilterField.PriceType,
            "currency" => PlanPhaseUsageDiscountAdjustmentFilterField.Currency,
            "pricing_unit_id" => PlanPhaseUsageDiscountAdjustmentFilterField.PricingUnitID,
            _ => (PlanPhaseUsageDiscountAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseUsageDiscountAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseUsageDiscountAdjustmentFilterField.PriceID => "price_id",
                PlanPhaseUsageDiscountAdjustmentFilterField.ItemID => "item_id",
                PlanPhaseUsageDiscountAdjustmentFilterField.PriceType => "price_type",
                PlanPhaseUsageDiscountAdjustmentFilterField.Currency => "currency",
                PlanPhaseUsageDiscountAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(PlanPhaseUsageDiscountAdjustmentFilterOperatorConverter))]
public enum PlanPhaseUsageDiscountAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class PlanPhaseUsageDiscountAdjustmentFilterOperatorConverter
    : JsonConverter<PlanPhaseUsageDiscountAdjustmentFilterOperator>
{
    public override PlanPhaseUsageDiscountAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
            "excludes" => PlanPhaseUsageDiscountAdjustmentFilterOperator.Excludes,
            _ => (PlanPhaseUsageDiscountAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseUsageDiscountAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes => "includes",
                PlanPhaseUsageDiscountAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
