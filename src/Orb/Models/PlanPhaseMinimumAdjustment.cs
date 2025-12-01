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
    typeof(ModelConverter<PlanPhaseMinimumAdjustment, PlanPhaseMinimumAdjustmentFromRaw>)
)]
public sealed record class PlanPhaseMinimumAdjustment : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PlanPhaseMinimumAdjustmentAdjustmentType>
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
    public required IReadOnlyList<Filter21> Filters
    {
        get { return ModelBase.GetNotNullClass<List<Filter21>>(this.RawData, "filters"); }
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
    /// The item ID that revenue from this minimum will be attributed to.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The minimum amount to charge in a given billing period for the prices this
    /// adjustment applies to.
    /// </summary>
    public required string MinimumAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "minimum_amount"); }
        init { ModelBase.Set(this._rawData, "minimum_amount", value); }
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
        _ = this.ItemID;
        _ = this.MinimumAmount;
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseMinimumAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseMinimumAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete("Required properties are deprecated: applies_to_price_ids"),
        SetsRequiredMembers
    ]
    PlanPhaseMinimumAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PlanPhaseMinimumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseMinimumAdjustmentFromRaw : IFromRaw<PlanPhaseMinimumAdjustment>
{
    public PlanPhaseMinimumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhaseMinimumAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanPhaseMinimumAdjustmentAdjustmentTypeConverter))]
public enum PlanPhaseMinimumAdjustmentAdjustmentType
{
    Minimum,
}

sealed class PlanPhaseMinimumAdjustmentAdjustmentTypeConverter
    : JsonConverter<PlanPhaseMinimumAdjustmentAdjustmentType>
{
    public override PlanPhaseMinimumAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "minimum" => PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            _ => (PlanPhaseMinimumAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseMinimumAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseMinimumAdjustmentAdjustmentType.Minimum => "minimum",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter21, Filter21FromRaw>))]
public sealed record class Filter21 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter21Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter21Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter21Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter21Operator>>(
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

    public Filter21() { }

    public Filter21(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter21(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter21 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter21FromRaw : IFromRaw<Filter21>
{
    public Filter21 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter21.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter21FieldConverter))]
public enum Filter21Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter21FieldConverter : JsonConverter<Filter21Field>
{
    public override Filter21Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter21Field.PriceID,
            "item_id" => Filter21Field.ItemID,
            "price_type" => Filter21Field.PriceType,
            "currency" => Filter21Field.Currency,
            "pricing_unit_id" => Filter21Field.PricingUnitID,
            _ => (Filter21Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter21Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter21Field.PriceID => "price_id",
                Filter21Field.ItemID => "item_id",
                Filter21Field.PriceType => "price_type",
                Filter21Field.Currency => "currency",
                Filter21Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter21OperatorConverter))]
public enum Filter21Operator
{
    Includes,
    Excludes,
}

sealed class Filter21OperatorConverter : JsonConverter<Filter21Operator>
{
    public override Filter21Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter21Operator.Includes,
            "excludes" => Filter21Operator.Excludes,
            _ => (Filter21Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter21Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter21Operator.Includes => "includes",
                Filter21Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
