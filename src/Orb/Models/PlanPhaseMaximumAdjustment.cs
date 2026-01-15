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
    typeof(JsonModelConverter<PlanPhaseMaximumAdjustment, PlanPhaseMaximumAdjustmentFromRaw>)
)]
public sealed record class PlanPhaseMaximumAdjustment : JsonModel
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

    public required ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType>
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
    public required IReadOnlyList<PlanPhaseMaximumAdjustmentFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PlanPhaseMaximumAdjustmentFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanPhaseMaximumAdjustmentFilter>>(
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
    /// The maximum amount to charge in a given billing period for the prices this
    /// adjustment applies to.
    /// </summary>
    public required string MaximumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("maximum_amount");
        }
        init { this._rawData.Set("maximum_amount", value); }
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
        _ = this.MaximumAmount;
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseMaximumAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseMaximumAdjustment(PlanPhaseMaximumAdjustment planPhaseMaximumAdjustment)
        : base(planPhaseMaximumAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseMaximumAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    PlanPhaseMaximumAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPhaseMaximumAdjustmentFromRaw.FromRawUnchecked"/>
    public static PlanPhaseMaximumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseMaximumAdjustmentFromRaw : IFromRawJson<PlanPhaseMaximumAdjustment>
{
    /// <inheritdoc/>
    public PlanPhaseMaximumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhaseMaximumAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanPhaseMaximumAdjustmentAdjustmentTypeConverter))]
public enum PlanPhaseMaximumAdjustmentAdjustmentType
{
    Maximum,
}

sealed class PlanPhaseMaximumAdjustmentAdjustmentTypeConverter
    : JsonConverter<PlanPhaseMaximumAdjustmentAdjustmentType>
{
    public override PlanPhaseMaximumAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "maximum" => PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            _ => (PlanPhaseMaximumAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseMaximumAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseMaximumAdjustmentAdjustmentType.Maximum => "maximum",
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
        PlanPhaseMaximumAdjustmentFilter,
        PlanPhaseMaximumAdjustmentFilterFromRaw
    >)
)]
public sealed record class PlanPhaseMaximumAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanPhaseMaximumAdjustmentFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanPhaseMaximumAdjustmentFilterOperator>
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

    public PlanPhaseMaximumAdjustmentFilter() { }

    public PlanPhaseMaximumAdjustmentFilter(
        PlanPhaseMaximumAdjustmentFilter planPhaseMaximumAdjustmentFilter
    )
        : base(planPhaseMaximumAdjustmentFilter) { }

    public PlanPhaseMaximumAdjustmentFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPhaseMaximumAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPhaseMaximumAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static PlanPhaseMaximumAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseMaximumAdjustmentFilterFromRaw : IFromRawJson<PlanPhaseMaximumAdjustmentFilter>
{
    /// <inheritdoc/>
    public PlanPhaseMaximumAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPhaseMaximumAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(PlanPhaseMaximumAdjustmentFilterFieldConverter))]
public enum PlanPhaseMaximumAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class PlanPhaseMaximumAdjustmentFilterFieldConverter
    : JsonConverter<PlanPhaseMaximumAdjustmentFilterField>
{
    public override PlanPhaseMaximumAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => PlanPhaseMaximumAdjustmentFilterField.PriceID,
            "item_id" => PlanPhaseMaximumAdjustmentFilterField.ItemID,
            "price_type" => PlanPhaseMaximumAdjustmentFilterField.PriceType,
            "currency" => PlanPhaseMaximumAdjustmentFilterField.Currency,
            "pricing_unit_id" => PlanPhaseMaximumAdjustmentFilterField.PricingUnitID,
            _ => (PlanPhaseMaximumAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseMaximumAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseMaximumAdjustmentFilterField.PriceID => "price_id",
                PlanPhaseMaximumAdjustmentFilterField.ItemID => "item_id",
                PlanPhaseMaximumAdjustmentFilterField.PriceType => "price_type",
                PlanPhaseMaximumAdjustmentFilterField.Currency => "currency",
                PlanPhaseMaximumAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(PlanPhaseMaximumAdjustmentFilterOperatorConverter))]
public enum PlanPhaseMaximumAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class PlanPhaseMaximumAdjustmentFilterOperatorConverter
    : JsonConverter<PlanPhaseMaximumAdjustmentFilterOperator>
{
    public override PlanPhaseMaximumAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => PlanPhaseMaximumAdjustmentFilterOperator.Includes,
            "excludes" => PlanPhaseMaximumAdjustmentFilterOperator.Excludes,
            _ => (PlanPhaseMaximumAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseMaximumAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseMaximumAdjustmentFilterOperator.Includes => "includes",
                PlanPhaseMaximumAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
