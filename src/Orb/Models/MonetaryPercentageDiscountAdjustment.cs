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
        MonetaryPercentageDiscountAdjustment,
        MonetaryPercentageDiscountAdjustmentFromRaw
    >)
)]
public sealed record class MonetaryPercentageDiscountAdjustment : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<
        string,
        MonetaryPercentageDiscountAdjustmentAdjustmentType
    > AdjustmentType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType>
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
    public required IReadOnlyList<MonetaryPercentageDiscountAdjustmentFilter> Filters
    {
        get
        {
            return this._rawData.GetNotNullStruct<
                ImmutableArray<MonetaryPercentageDiscountAdjustmentFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MonetaryPercentageDiscountAdjustmentFilter>>(
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
    /// The percentage (as a value between 0 and 1) by which to discount the price
    /// intervals this adjustment applies to in a given billing period.
    /// </summary>
    public required double PercentageDiscount
    {
        get { return this._rawData.GetNotNullStruct<double>("percentage_discount"); }
        init { this._rawData.Set("percentage_discount", value); }
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
        _ = this.PercentageDiscount;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryPercentageDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryPercentageDiscountAdjustment(
        MonetaryPercentageDiscountAdjustment monetaryPercentageDiscountAdjustment
    )
        : base(monetaryPercentageDiscountAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryPercentageDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    MonetaryPercentageDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryPercentageDiscountAdjustmentFromRaw.FromRawUnchecked"/>
    public static MonetaryPercentageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryPercentageDiscountAdjustmentFromRaw
    : IFromRawJson<MonetaryPercentageDiscountAdjustment>
{
    /// <inheritdoc/>
    public MonetaryPercentageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryPercentageDiscountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonetaryPercentageDiscountAdjustmentAdjustmentTypeConverter))]
public enum MonetaryPercentageDiscountAdjustmentAdjustmentType
{
    PercentageDiscount,
}

sealed class MonetaryPercentageDiscountAdjustmentAdjustmentTypeConverter
    : JsonConverter<MonetaryPercentageDiscountAdjustmentAdjustmentType>
{
    public override MonetaryPercentageDiscountAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage_discount" =>
                MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            _ => (MonetaryPercentageDiscountAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryPercentageDiscountAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount =>
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
        MonetaryPercentageDiscountAdjustmentFilter,
        MonetaryPercentageDiscountAdjustmentFilterFromRaw
    >)
)]
public sealed record class MonetaryPercentageDiscountAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryPercentageDiscountAdjustmentFilterOperator>
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

    public MonetaryPercentageDiscountAdjustmentFilter() { }

    public MonetaryPercentageDiscountAdjustmentFilter(
        MonetaryPercentageDiscountAdjustmentFilter monetaryPercentageDiscountAdjustmentFilter
    )
        : base(monetaryPercentageDiscountAdjustmentFilter) { }

    public MonetaryPercentageDiscountAdjustmentFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonetaryPercentageDiscountAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryPercentageDiscountAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static MonetaryPercentageDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryPercentageDiscountAdjustmentFilterFromRaw
    : IFromRawJson<MonetaryPercentageDiscountAdjustmentFilter>
{
    /// <inheritdoc/>
    public MonetaryPercentageDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryPercentageDiscountAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MonetaryPercentageDiscountAdjustmentFilterFieldConverter))]
public enum MonetaryPercentageDiscountAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MonetaryPercentageDiscountAdjustmentFilterFieldConverter
    : JsonConverter<MonetaryPercentageDiscountAdjustmentFilterField>
{
    public override MonetaryPercentageDiscountAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
            "item_id" => MonetaryPercentageDiscountAdjustmentFilterField.ItemID,
            "price_type" => MonetaryPercentageDiscountAdjustmentFilterField.PriceType,
            "currency" => MonetaryPercentageDiscountAdjustmentFilterField.Currency,
            "pricing_unit_id" => MonetaryPercentageDiscountAdjustmentFilterField.PricingUnitID,
            _ => (MonetaryPercentageDiscountAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryPercentageDiscountAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryPercentageDiscountAdjustmentFilterField.PriceID => "price_id",
                MonetaryPercentageDiscountAdjustmentFilterField.ItemID => "item_id",
                MonetaryPercentageDiscountAdjustmentFilterField.PriceType => "price_type",
                MonetaryPercentageDiscountAdjustmentFilterField.Currency => "currency",
                MonetaryPercentageDiscountAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MonetaryPercentageDiscountAdjustmentFilterOperatorConverter))]
public enum MonetaryPercentageDiscountAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class MonetaryPercentageDiscountAdjustmentFilterOperatorConverter
    : JsonConverter<MonetaryPercentageDiscountAdjustmentFilterOperator>
{
    public override MonetaryPercentageDiscountAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
            "excludes" => MonetaryPercentageDiscountAdjustmentFilterOperator.Excludes,
            _ => (MonetaryPercentageDiscountAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryPercentageDiscountAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryPercentageDiscountAdjustmentFilterOperator.Includes => "includes",
                MonetaryPercentageDiscountAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
