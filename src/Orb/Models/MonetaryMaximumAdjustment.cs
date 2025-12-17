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
    typeof(JsonModelConverter<MonetaryMaximumAdjustment, MonetaryMaximumAdjustmentFromRaw>)
)]
public sealed record class MonetaryMaximumAdjustment : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, MonetaryMaximumAdjustmentAdjustmentType>
            >(this.RawData, "adjustment_type");
        }
        init { JsonModel.Set(this._rawData, "adjustment_type", value); }
    }

    /// <summary>
    /// The value applied by an adjustment.
    /// </summary>
    public required string Amount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
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
    public required IReadOnlyList<MonetaryMaximumAdjustmentFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<MonetaryMaximumAdjustmentFilter>>(
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
    /// The maximum amount to charge in a given billing period for the prices this
    /// adjustment applies to.
    /// </summary>
    public required string MaximumAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "maximum_amount"); }
        init { JsonModel.Set(this._rawData, "maximum_amount", value); }
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
        _ = this.Amount;
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.MaximumAmount;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryMaximumAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryMaximumAdjustment(MonetaryMaximumAdjustment monetaryMaximumAdjustment)
        : base(monetaryMaximumAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryMaximumAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    MonetaryMaximumAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryMaximumAdjustmentFromRaw.FromRawUnchecked"/>
    public static MonetaryMaximumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryMaximumAdjustmentFromRaw : IFromRawJson<MonetaryMaximumAdjustment>
{
    /// <inheritdoc/>
    public MonetaryMaximumAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryMaximumAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonetaryMaximumAdjustmentAdjustmentTypeConverter))]
public enum MonetaryMaximumAdjustmentAdjustmentType
{
    Maximum,
}

sealed class MonetaryMaximumAdjustmentAdjustmentTypeConverter
    : JsonConverter<MonetaryMaximumAdjustmentAdjustmentType>
{
    public override MonetaryMaximumAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "maximum" => MonetaryMaximumAdjustmentAdjustmentType.Maximum,
            _ => (MonetaryMaximumAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryMaximumAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryMaximumAdjustmentAdjustmentType.Maximum => "maximum",
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
        MonetaryMaximumAdjustmentFilter,
        MonetaryMaximumAdjustmentFilterFromRaw
    >)
)]
public sealed record class MonetaryMaximumAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MonetaryMaximumAdjustmentFilterField> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, MonetaryMaximumAdjustmentFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, MonetaryMaximumAdjustmentFilterOperator>
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

    public MonetaryMaximumAdjustmentFilter() { }

    public MonetaryMaximumAdjustmentFilter(
        MonetaryMaximumAdjustmentFilter monetaryMaximumAdjustmentFilter
    )
        : base(monetaryMaximumAdjustmentFilter) { }

    public MonetaryMaximumAdjustmentFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonetaryMaximumAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryMaximumAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static MonetaryMaximumAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryMaximumAdjustmentFilterFromRaw : IFromRawJson<MonetaryMaximumAdjustmentFilter>
{
    /// <inheritdoc/>
    public MonetaryMaximumAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryMaximumAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MonetaryMaximumAdjustmentFilterFieldConverter))]
public enum MonetaryMaximumAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MonetaryMaximumAdjustmentFilterFieldConverter
    : JsonConverter<MonetaryMaximumAdjustmentFilterField>
{
    public override MonetaryMaximumAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MonetaryMaximumAdjustmentFilterField.PriceID,
            "item_id" => MonetaryMaximumAdjustmentFilterField.ItemID,
            "price_type" => MonetaryMaximumAdjustmentFilterField.PriceType,
            "currency" => MonetaryMaximumAdjustmentFilterField.Currency,
            "pricing_unit_id" => MonetaryMaximumAdjustmentFilterField.PricingUnitID,
            _ => (MonetaryMaximumAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryMaximumAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryMaximumAdjustmentFilterField.PriceID => "price_id",
                MonetaryMaximumAdjustmentFilterField.ItemID => "item_id",
                MonetaryMaximumAdjustmentFilterField.PriceType => "price_type",
                MonetaryMaximumAdjustmentFilterField.Currency => "currency",
                MonetaryMaximumAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MonetaryMaximumAdjustmentFilterOperatorConverter))]
public enum MonetaryMaximumAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class MonetaryMaximumAdjustmentFilterOperatorConverter
    : JsonConverter<MonetaryMaximumAdjustmentFilterOperator>
{
    public override MonetaryMaximumAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MonetaryMaximumAdjustmentFilterOperator.Includes,
            "excludes" => MonetaryMaximumAdjustmentFilterOperator.Excludes,
            _ => (MonetaryMaximumAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryMaximumAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryMaximumAdjustmentFilterOperator.Includes => "includes",
                MonetaryMaximumAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
