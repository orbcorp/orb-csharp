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
        MonetaryAmountDiscountAdjustment,
        MonetaryAmountDiscountAdjustmentFromRaw
    >)
)]
public sealed record class MonetaryAmountDiscountAdjustment : JsonModel
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

    public required ApiEnum<string, AdjustmentType> AdjustmentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AdjustmentType>>(
                "adjustment_type"
            );
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    /// <summary>
    /// The value applied by an adjustment.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The amount by which to discount the prices this adjustment applies to in a
    /// given billing period.
    /// </summary>
    public required string AmountDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount_discount");
        }
        init { this._rawData.Set("amount_discount", value); }
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
    public required IReadOnlyList<MonetaryAmountDiscountAdjustmentFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<MonetaryAmountDiscountAdjustmentFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MonetaryAmountDiscountAdjustmentFilter>>(
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
        _ = this.Amount;
        _ = this.AmountDiscount;
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryAmountDiscountAdjustment() { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryAmountDiscountAdjustment(
        MonetaryAmountDiscountAdjustment monetaryAmountDiscountAdjustment
    )
        : base(monetaryAmountDiscountAdjustment) { }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public MonetaryAmountDiscountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    MonetaryAmountDiscountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryAmountDiscountAdjustmentFromRaw.FromRawUnchecked"/>
    public static MonetaryAmountDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryAmountDiscountAdjustmentFromRaw : IFromRawJson<MonetaryAmountDiscountAdjustment>
{
    /// <inheritdoc/>
    public MonetaryAmountDiscountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryAmountDiscountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AdjustmentTypeConverter))]
public enum AdjustmentType
{
    AmountDiscount,
}

sealed class AdjustmentTypeConverter : JsonConverter<AdjustmentType>
{
    public override AdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount_discount" => AdjustmentType.AmountDiscount,
            _ => (AdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentType.AmountDiscount => "amount_discount",
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
        MonetaryAmountDiscountAdjustmentFilter,
        MonetaryAmountDiscountAdjustmentFilterFromRaw
    >)
)]
public sealed record class MonetaryAmountDiscountAdjustmentFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonetaryAmountDiscountAdjustmentFilterOperator>
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

    public MonetaryAmountDiscountAdjustmentFilter() { }

    public MonetaryAmountDiscountAdjustmentFilter(
        MonetaryAmountDiscountAdjustmentFilter monetaryAmountDiscountAdjustmentFilter
    )
        : base(monetaryAmountDiscountAdjustmentFilter) { }

    public MonetaryAmountDiscountAdjustmentFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonetaryAmountDiscountAdjustmentFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonetaryAmountDiscountAdjustmentFilterFromRaw.FromRawUnchecked"/>
    public static MonetaryAmountDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonetaryAmountDiscountAdjustmentFilterFromRaw
    : IFromRawJson<MonetaryAmountDiscountAdjustmentFilter>
{
    /// <inheritdoc/>
    public MonetaryAmountDiscountAdjustmentFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonetaryAmountDiscountAdjustmentFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(MonetaryAmountDiscountAdjustmentFilterFieldConverter))]
public enum MonetaryAmountDiscountAdjustmentFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class MonetaryAmountDiscountAdjustmentFilterFieldConverter
    : JsonConverter<MonetaryAmountDiscountAdjustmentFilterField>
{
    public override MonetaryAmountDiscountAdjustmentFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => MonetaryAmountDiscountAdjustmentFilterField.PriceID,
            "item_id" => MonetaryAmountDiscountAdjustmentFilterField.ItemID,
            "price_type" => MonetaryAmountDiscountAdjustmentFilterField.PriceType,
            "currency" => MonetaryAmountDiscountAdjustmentFilterField.Currency,
            "pricing_unit_id" => MonetaryAmountDiscountAdjustmentFilterField.PricingUnitID,
            _ => (MonetaryAmountDiscountAdjustmentFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryAmountDiscountAdjustmentFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryAmountDiscountAdjustmentFilterField.PriceID => "price_id",
                MonetaryAmountDiscountAdjustmentFilterField.ItemID => "item_id",
                MonetaryAmountDiscountAdjustmentFilterField.PriceType => "price_type",
                MonetaryAmountDiscountAdjustmentFilterField.Currency => "currency",
                MonetaryAmountDiscountAdjustmentFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(MonetaryAmountDiscountAdjustmentFilterOperatorConverter))]
public enum MonetaryAmountDiscountAdjustmentFilterOperator
{
    Includes,
    Excludes,
}

sealed class MonetaryAmountDiscountAdjustmentFilterOperatorConverter
    : JsonConverter<MonetaryAmountDiscountAdjustmentFilterOperator>
{
    public override MonetaryAmountDiscountAdjustmentFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
            "excludes" => MonetaryAmountDiscountAdjustmentFilterOperator.Excludes,
            _ => (MonetaryAmountDiscountAdjustmentFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonetaryAmountDiscountAdjustmentFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonetaryAmountDiscountAdjustmentFilterOperator.Includes => "includes",
                MonetaryAmountDiscountAdjustmentFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
