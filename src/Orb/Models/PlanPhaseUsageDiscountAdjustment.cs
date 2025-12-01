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
        PlanPhaseUsageDiscountAdjustment,
        PlanPhaseUsageDiscountAdjustmentFromRaw
    >)
)]
public sealed record class PlanPhaseUsageDiscountAdjustment : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType>
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
    public required IReadOnlyList<Filter23> Filters
    {
        get { return ModelBase.GetNotNullClass<List<Filter23>>(this.RawData, "filters"); }
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

    /// <summary>
    /// The number of usage units by which to discount the price this adjustment applies
    /// to in a given billing period.
    /// </summary>
    public required double UsageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "usage_discount"); }
        init { ModelBase.Set(this._rawData, "usage_discount", value); }
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
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
        _ = this.UsageDiscount;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseUsageDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseUsageDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete("Required properties are deprecated: applies_to_price_ids"),
        SetsRequiredMembers
    ]
    PlanPhaseUsageDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PlanPhaseUsageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseUsageDiscountAdjustmentFromRaw : IFromRaw<PlanPhaseUsageDiscountAdjustment>
{
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

[JsonConverter(typeof(ModelConverter<Filter23, Filter23FromRaw>))]
public sealed record class Filter23 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter23Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter23Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter23Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter23Operator>>(
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

    public Filter23() { }

    public Filter23(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter23(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter23 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter23FromRaw : IFromRaw<Filter23>
{
    public Filter23 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter23.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter23FieldConverter))]
public enum Filter23Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter23FieldConverter : JsonConverter<Filter23Field>
{
    public override Filter23Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter23Field.PriceID,
            "item_id" => Filter23Field.ItemID,
            "price_type" => Filter23Field.PriceType,
            "currency" => Filter23Field.Currency,
            "pricing_unit_id" => Filter23Field.PricingUnitID,
            _ => (Filter23Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter23Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter23Field.PriceID => "price_id",
                Filter23Field.ItemID => "item_id",
                Filter23Field.PriceType => "price_type",
                Filter23Field.Currency => "currency",
                Filter23Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter23OperatorConverter))]
public enum Filter23Operator
{
    Includes,
    Excludes,
}

sealed class Filter23OperatorConverter : JsonConverter<Filter23Operator>
{
    public override Filter23Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter23Operator.Includes,
            "excludes" => Filter23Operator.Excludes,
            _ => (Filter23Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter23Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter23Operator.Includes => "includes",
                Filter23Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
