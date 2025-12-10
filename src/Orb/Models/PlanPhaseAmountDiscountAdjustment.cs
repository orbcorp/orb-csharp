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
        PlanPhaseAmountDiscountAdjustment,
        PlanPhaseAmountDiscountAdjustmentFromRaw
    >)
)]
public sealed record class PlanPhaseAmountDiscountAdjustment : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType>
            >(this.RawData, "adjustment_type");
        }
        init { ModelBase.Set(this._rawData, "adjustment_type", value); }
    }

    /// <summary>
    /// The amount by which to discount the prices this adjustment applies to in a
    /// given billing period.
    /// </summary>
    public required string AmountDiscount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount_discount"); }
        init { ModelBase.Set(this._rawData, "amount_discount", value); }
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
    public required IReadOnlyList<PlanPhaseAmountDiscountAdjustmentFilter> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<List<PlanPhaseAmountDiscountAdjustmentFilter>>(
                this.RawData,
                "filters"
            );
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AdjustmentType.Validate();
        _ = this.AmountDiscount;
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseAmountDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseAmountDiscountAdjustment(
        PlanPhaseAmountDiscountAdjustment planPhaseAmountDiscountAdjustment
    )
        : base(planPhaseAmountDiscountAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseAmountDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    PlanPhaseAmountDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPhaseAmountDiscountAdjustmentFromRaw.FromRawUnchecked"/>
    public static PlanPhaseAmountDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseAmountDiscountAdjustmentFromRaw : IFromRaw<PlanPhaseAmountDiscountAdjustment>
{
    /// <inheritdoc/>
    public PlanPhaseAmountDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhaseAmountDiscountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanPhaseAmountDiscountAdjustmentAdjustmentTypeConverter))]
public enum PlanPhaseAmountDiscountAdjustmentAdjustmentType
{
    AmountDiscount,
}

sealed class PlanPhaseAmountDiscountAdjustmentAdjustmentTypeConverter
    : JsonConverter<PlanPhaseAmountDiscountAdjustmentAdjustmentType>
{
    public override PlanPhaseAmountDiscountAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount_discount" => PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            _ => (PlanPhaseAmountDiscountAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseAmountDiscountAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount => "amount_discount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(ModelConverter<
        PlanPhaseAmountDiscountAdjustmentFilter,
        PlanPhaseAmountDiscountAdjustmentFilterFromRaw
    >)
)]
public sealed record class PlanPhaseAmountDiscountAdjustmentFilter : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterField>
            >(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PlanPhaseAmountDiscountAdjustmentFilterOperator>
            >(this.RawData, "operator");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public PlanPhaseAmountDiscountAdjustmentFilter() { }

    public PlanPhaseAmountDiscountAdjustmentFilter(
        PlanPhaseAmountDiscountAdjustmentFilter planPhaseAmountDiscountAdjustmentFilter
    )
        : base(planPhaseAmountDiscountAdjustmentFilter) { }

    public PlanPhaseAmountDiscountAdjustmentFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPhaseAmountDiscountAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPhaseAmountDiscountAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static PlanPhaseAmountDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseAmountDiscountAdjustmentFilterFromRaw
    : IFromRaw<PlanPhaseAmountDiscountAdjustmentFilter>
{
    /// <inheritdoc/>
    public PlanPhaseAmountDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhaseAmountDiscountAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(PlanPhaseAmountDiscountAdjustmentFilterFieldConverter))]
public enum PlanPhaseAmountDiscountAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class PlanPhaseAmountDiscountAdjustmentFilterFieldConverter
    : JsonConverter<PlanPhaseAmountDiscountAdjustmentFilterField>
{
    public override PlanPhaseAmountDiscountAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
            "item_id" => PlanPhaseAmountDiscountAdjustmentFilterField.ItemID,
            "price_type" => PlanPhaseAmountDiscountAdjustmentFilterField.PriceType,
            "currency" => PlanPhaseAmountDiscountAdjustmentFilterField.Currency,
            "pricing_unit_id" => PlanPhaseAmountDiscountAdjustmentFilterField.PricingUnitID,
            _ => (PlanPhaseAmountDiscountAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseAmountDiscountAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseAmountDiscountAdjustmentFilterField.PriceID => "price_id",
                PlanPhaseAmountDiscountAdjustmentFilterField.ItemID => "item_id",
                PlanPhaseAmountDiscountAdjustmentFilterField.PriceType => "price_type",
                PlanPhaseAmountDiscountAdjustmentFilterField.Currency => "currency",
                PlanPhaseAmountDiscountAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(PlanPhaseAmountDiscountAdjustmentFilterOperatorConverter))]
public enum PlanPhaseAmountDiscountAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class PlanPhaseAmountDiscountAdjustmentFilterOperatorConverter
    : JsonConverter<PlanPhaseAmountDiscountAdjustmentFilterOperator>
{
    public override PlanPhaseAmountDiscountAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
            "excludes" => PlanPhaseAmountDiscountAdjustmentFilterOperator.Excludes,
            _ => (PlanPhaseAmountDiscountAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseAmountDiscountAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes => "includes",
                PlanPhaseAmountDiscountAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
