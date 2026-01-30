using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<
        string,
        PlanPhasePercentageDiscountAdjustmentAdjustmentType
    > AdjustmentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanPhasePercentageDiscountAdjustmentAdjustmentType>
            >("adjustment_type");
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("applies_to_price_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "applies_to_price_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this adjustment to.
    /// </summary>
    public required IReadOnlyList<PlanPhasePercentageDiscountAdjustmentFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<PlanPhasePercentageDiscountAdjustmentFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanPhasePercentageDiscountAdjustmentFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// True for adjustments that apply to an entire invoice, false for adjustments
    /// that apply to only one price.
    /// </summary>
    public required bool IsInvoiceLevel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_invoice_level");
        }
        init { this._rawData.Set("is_invoice_level", value); }
    }

    /// <summary>
    /// The percentage (as a value between 0 and 1) by which to discount the price
    /// intervals this adjustment applies to in a given billing period.
    /// </summary>
    public required double PercentageDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentage_discount");
        }
        init { this._rawData.Set("percentage_discount", value); }
    }

    /// <summary>
    /// The plan phase in which this adjustment is active.
    /// </summary>
    public required long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <summary>
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the
    /// place of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("replaces_adjustment_id");
        }
        init { this._rawData.Set("replaces_adjustment_id", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhasePercentageDiscountAdjustment(
        PlanPhasePercentageDiscountAdjustment planPhasePercentageDiscountAdjustment
    )
        : base(planPhasePercentageDiscountAdjustment) { }
#pragma warning restore CS8618

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhasePercentageDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    PlanPhasePercentageDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanPhasePercentageDiscountAdjustmentFilterOperator>
            >("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public PlanPhasePercentageDiscountAdjustmentFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanPhasePercentageDiscountAdjustmentFilter(
        PlanPhasePercentageDiscountAdjustmentFilter planPhasePercentageDiscountAdjustmentFilter
    )
        : base(planPhasePercentageDiscountAdjustmentFilter) { }
#pragma warning restore CS8618

    public PlanPhasePercentageDiscountAdjustmentFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPhasePercentageDiscountAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
