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
    typeof(ModelConverter<PlanPhaseMaximumAdjustment, PlanPhaseMaximumAdjustmentFromRaw>)
)]
public sealed record class PlanPhaseMaximumAdjustment : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            if (!this._rawData.TryGetValue("adjustment_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                    ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment_type' cannot be null",
                    new System::ArgumentNullException("adjustment_type")
                );
        }
        init
        {
            this._rawData["adjustment_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIDs
    {
        get
        {
            if (!this._rawData.TryGetValue("applies_to_price_ids", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "applies_to_price_ids",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new System::ArgumentNullException("applies_to_price_ids")
                );
        }
        init
        {
            this._rawData["applies_to_price_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this adjustment to.
    /// </summary>
    public required IReadOnlyList<Filter20> Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Filter20>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        init
        {
            this._rawData["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("is_invoice_level", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'is_invoice_level' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "is_invoice_level",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["is_invoice_level"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum amount to charge in a given billing period for the prices this
    /// adjustment applies to.
    /// </summary>
    public required string MaximumAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("maximum_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "maximum_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_amount' cannot be null",
                    new System::ArgumentNullException("maximum_amount")
                );
        }
        init
        {
            this._rawData["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The plan phase in which this adjustment is active.
    /// </summary>
    public required long? PlanPhaseOrder
    {
        get
        {
            if (!this._rawData.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
    {
        get
        {
            if (!this._rawData.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the
    /// place of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get
        {
            if (!this._rawData.TryGetValue("replaces_adjustment_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["replaces_adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        _ = this.MaximumAmount;
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseMaximumAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanPhaseMaximumAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete("Required properties are deprecated: applies_to_price_ids"),
        SetsRequiredMembers
    ]
    PlanPhaseMaximumAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PlanPhaseMaximumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseMaximumAdjustmentFromRaw : IFromRaw<PlanPhaseMaximumAdjustment>
{
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

[JsonConverter(typeof(ModelConverter<Filter20, Filter20FromRaw>))]
public sealed record class Filter20 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter20Field> Field
    {
        get
        {
            if (!this._rawData.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter20Field>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentNullException("field")
                );
        }
        init
        {
            this._rawData["field"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter20Operator> Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter20Operator>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentNullException("operator")
                );
        }
        init
        {
            this._rawData["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get
        {
            if (!this._rawData.TryGetValue("values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'values' cannot be null",
                    new System::ArgumentOutOfRangeException("values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'values' cannot be null",
                    new System::ArgumentNullException("values")
                );
        }
        init
        {
            this._rawData["values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public Filter20() { }

    public Filter20(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter20(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter20 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter20FromRaw : IFromRaw<Filter20>
{
    public Filter20 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter20.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter20FieldConverter))]
public enum Filter20Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter20FieldConverter : JsonConverter<Filter20Field>
{
    public override Filter20Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter20Field.PriceID,
            "item_id" => Filter20Field.ItemID,
            "price_type" => Filter20Field.PriceType,
            "currency" => Filter20Field.Currency,
            "pricing_unit_id" => Filter20Field.PricingUnitID,
            _ => (Filter20Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter20Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter20Field.PriceID => "price_id",
                Filter20Field.ItemID => "item_id",
                Filter20Field.PriceType => "price_type",
                Filter20Field.Currency => "currency",
                Filter20Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter20OperatorConverter))]
public enum Filter20Operator
{
    Includes,
    Excludes,
}

sealed class Filter20OperatorConverter : JsonConverter<Filter20Operator>
{
    public override Filter20Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter20Operator.Includes,
            "excludes" => Filter20Operator.Excludes,
            _ => (Filter20Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter20Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter20Operator.Includes => "includes",
                Filter20Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
