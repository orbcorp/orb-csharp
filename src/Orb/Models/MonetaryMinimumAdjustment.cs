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
    typeof(JsonModelConverter<MonetaryMinimumAdjustment, MonetaryMinimumAdjustmentFromRaw>)
)]
public sealed record class MonetaryMinimumAdjustment : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType>
            >("adjustment_type");
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    /// <summary>
    /// The value applied by an adjustment.
    /// </summary>
    public required string Amount
    {
        get { return this._rawData.GetNotNullClass<string>("amount"); }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIds
    {
        get
        {
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
    public required IReadOnlyList<MonetaryMinimumAdjustmentFilter> Filters
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<MonetaryMinimumAdjustmentFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<MonetaryMinimumAdjustmentFilter>>(
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
        get { return this._rawData.GetNotNullStruct<bool>("is_invoice_level"); }
        init { this._rawData.Set("is_invoice_level", value); }
    }

    /// <summary>
    /// The item ID that revenue from this minimum will be attributed to.
    /// </summary>
    public required string ItemID
    {
        get { return this._rawData.GetNotNullClass<string>("item_id"); }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The minimum amount to charge in a given billing period for the prices this
    /// adjustment applies to.
    /// </summary>
    public required string MinimumAmount
    {
        get { return this._rawData.GetNotNullClass<string>("minimum_amount"); }
        init { this._rawData.Set("minimum_amount", value); }
    }

    /// <summary>
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
    {
        get { return this._rawData.GetNullableClass<string>("reason"); }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the
    /// place of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get { return this._rawData.GetNullableClass<string>("replaces_adjustment_id"); }
        init { this._rawData.Set("replaces_adjustment_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AdjustmentType.Validate();
        _ = this.Amount;
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.ItemID;
        _ = this.MinimumAmount;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryMinimumAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryMinimumAdjustment(MonetaryMinimumAdjustment monetaryMinimumAdjustment)
        : base(monetaryMinimumAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryMinimumAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    MonetaryMinimumAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryMinimumAdjustmentFromRaw.FromRawUnchecked"/>
    public static MonetaryMinimumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryMinimumAdjustmentFromRaw : IFromRawJson<MonetaryMinimumAdjustment>
{
    /// <inheritdoc/>
    public MonetaryMinimumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryMinimumAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonetaryMinimumAdjustmentAdjustmentTypeConverter))]
public enum MonetaryMinimumAdjustmentAdjustmentType
{
    Minimum,
}

sealed class MonetaryMinimumAdjustmentAdjustmentTypeConverter
    : JsonConverter<MonetaryMinimumAdjustmentAdjustmentType>
{
    public override MonetaryMinimumAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "minimum" => MonetaryMinimumAdjustmentAdjustmentType.Minimum,
            _ => (MonetaryMinimumAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryMinimumAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryMinimumAdjustmentAdjustmentType.Minimum => "minimum",
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
        MonetaryMinimumAdjustmentFilter,
        MonetaryMinimumAdjustmentFilterFromRaw
    >)
)]
public sealed record class MonetaryMinimumAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MonetaryMinimumAdjustmentFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryMinimumAdjustmentFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryMinimumAdjustmentFilterOperator>
            >("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values"); }
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

    public MonetaryMinimumAdjustmentFilter() { }

    public MonetaryMinimumAdjustmentFilter(
        MonetaryMinimumAdjustmentFilter monetaryMinimumAdjustmentFilter
    )
        : base(monetaryMinimumAdjustmentFilter) { }

    public MonetaryMinimumAdjustmentFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonetaryMinimumAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryMinimumAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static MonetaryMinimumAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryMinimumAdjustmentFilterFromRaw : IFromRawJson<MonetaryMinimumAdjustmentFilter>
{
    /// <inheritdoc/>
    public MonetaryMinimumAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryMinimumAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MonetaryMinimumAdjustmentFilterFieldConverter))]
public enum MonetaryMinimumAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MonetaryMinimumAdjustmentFilterFieldConverter
    : JsonConverter<MonetaryMinimumAdjustmentFilterField>
{
    public override MonetaryMinimumAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MonetaryMinimumAdjustmentFilterField.PriceID,
            "item_id" => MonetaryMinimumAdjustmentFilterField.ItemID,
            "price_type" => MonetaryMinimumAdjustmentFilterField.PriceType,
            "currency" => MonetaryMinimumAdjustmentFilterField.Currency,
            "pricing_unit_id" => MonetaryMinimumAdjustmentFilterField.PricingUnitID,
            _ => (MonetaryMinimumAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryMinimumAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryMinimumAdjustmentFilterField.PriceID => "price_id",
                MonetaryMinimumAdjustmentFilterField.ItemID => "item_id",
                MonetaryMinimumAdjustmentFilterField.PriceType => "price_type",
                MonetaryMinimumAdjustmentFilterField.Currency => "currency",
                MonetaryMinimumAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MonetaryMinimumAdjustmentFilterOperatorConverter))]
public enum MonetaryMinimumAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class MonetaryMinimumAdjustmentFilterOperatorConverter
    : JsonConverter<MonetaryMinimumAdjustmentFilterOperator>
{
    public override MonetaryMinimumAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MonetaryMinimumAdjustmentFilterOperator.Includes,
            "excludes" => MonetaryMinimumAdjustmentFilterOperator.Excludes,
            _ => (MonetaryMinimumAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryMinimumAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryMinimumAdjustmentFilterOperator.Includes => "includes",
                MonetaryMinimumAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
