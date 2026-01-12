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
        MonetaryUsageDiscountAdjustment,
        MonetaryUsageDiscountAdjustmentFromRaw
    >)
)]
public sealed record class MonetaryUsageDiscountAdjustment : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType> AdjustmentType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryUsageDiscountAdjustmentAdjustmentType>
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
    public required IReadOnlyList<MonetaryUsageDiscountAdjustmentFilter> Filters
    {
        get
        {
            return this._rawData.GetNotNullStruct<
                ImmutableArray<MonetaryUsageDiscountAdjustmentFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MonetaryUsageDiscountAdjustmentFilter>>(
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

    /// <summary>
    /// The number of usage units by which to discount the price this adjustment applies
    /// to in a given billing period.
    /// </summary>
    public required double UsageDiscount
    {
        get { return this._rawData.GetNotNullStruct<double>("usage_discount"); }
        init { this._rawData.Set("usage_discount", value); }
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
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
        _ = this.UsageDiscount;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryUsageDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryUsageDiscountAdjustment(
        MonetaryUsageDiscountAdjustment monetaryUsageDiscountAdjustment
    )
        : base(monetaryUsageDiscountAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryUsageDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    MonetaryUsageDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryUsageDiscountAdjustmentFromRaw.FromRawUnchecked"/>
    public static MonetaryUsageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryUsageDiscountAdjustmentFromRaw : IFromRawJson<MonetaryUsageDiscountAdjustment>
{
    /// <inheritdoc/>
    public MonetaryUsageDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryUsageDiscountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonetaryUsageDiscountAdjustmentAdjustmentTypeConverter))]
public enum MonetaryUsageDiscountAdjustmentAdjustmentType
{
    UsageDiscount,
}

sealed class MonetaryUsageDiscountAdjustmentAdjustmentTypeConverter
    : JsonConverter<MonetaryUsageDiscountAdjustmentAdjustmentType>
{
    public override MonetaryUsageDiscountAdjustmentAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_discount" => MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            _ => (MonetaryUsageDiscountAdjustmentAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryUsageDiscountAdjustmentAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount => "usage_discount",
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
        MonetaryUsageDiscountAdjustmentFilter,
        MonetaryUsageDiscountAdjustmentFilterFromRaw
    >)
)]
public sealed record class MonetaryUsageDiscountAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryUsageDiscountAdjustmentFilterOperator>
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

    public MonetaryUsageDiscountAdjustmentFilter() { }

    public MonetaryUsageDiscountAdjustmentFilter(
        MonetaryUsageDiscountAdjustmentFilter monetaryUsageDiscountAdjustmentFilter
    )
        : base(monetaryUsageDiscountAdjustmentFilter) { }

    public MonetaryUsageDiscountAdjustmentFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonetaryUsageDiscountAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryUsageDiscountAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static MonetaryUsageDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryUsageDiscountAdjustmentFilterFromRaw
    : IFromRawJson<MonetaryUsageDiscountAdjustmentFilter>
{
    /// <inheritdoc/>
    public MonetaryUsageDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryUsageDiscountAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MonetaryUsageDiscountAdjustmentFilterFieldConverter))]
public enum MonetaryUsageDiscountAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MonetaryUsageDiscountAdjustmentFilterFieldConverter
    : JsonConverter<MonetaryUsageDiscountAdjustmentFilterField>
{
    public override MonetaryUsageDiscountAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MonetaryUsageDiscountAdjustmentFilterField.PriceID,
            "item_id" => MonetaryUsageDiscountAdjustmentFilterField.ItemID,
            "price_type" => MonetaryUsageDiscountAdjustmentFilterField.PriceType,
            "currency" => MonetaryUsageDiscountAdjustmentFilterField.Currency,
            "pricing_unit_id" => MonetaryUsageDiscountAdjustmentFilterField.PricingUnitID,
            _ => (MonetaryUsageDiscountAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryUsageDiscountAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryUsageDiscountAdjustmentFilterField.PriceID => "price_id",
                MonetaryUsageDiscountAdjustmentFilterField.ItemID => "item_id",
                MonetaryUsageDiscountAdjustmentFilterField.PriceType => "price_type",
                MonetaryUsageDiscountAdjustmentFilterField.Currency => "currency",
                MonetaryUsageDiscountAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MonetaryUsageDiscountAdjustmentFilterOperatorConverter))]
public enum MonetaryUsageDiscountAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class MonetaryUsageDiscountAdjustmentFilterOperatorConverter
    : JsonConverter<MonetaryUsageDiscountAdjustmentFilterOperator>
{
    public override MonetaryUsageDiscountAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
            "excludes" => MonetaryUsageDiscountAdjustmentFilterOperator.Excludes,
            _ => (MonetaryUsageDiscountAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryUsageDiscountAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryUsageDiscountAdjustmentFilterOperator.Includes => "includes",
                MonetaryUsageDiscountAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
