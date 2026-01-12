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

[JsonConverter(typeof(JsonModelConverter<AmountDiscount, AmountDiscountFromRaw>))]
public sealed record class AmountDiscount : JsonModel
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required string AmountDiscountValue
    {
        get { return this._rawData.GetNotNullClass<string>("amount_discount"); }
        init { this._rawData.Set("amount_discount", value); }
    }

    public required ApiEnum<string, DiscountType> DiscountType
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, DiscountType>>("discount_type");
        }
        init { this._rawData.Set("discount_type", value); }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIds
    {
        get
        {
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("applies_to_price_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "applies_to_price_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public IReadOnlyList<AmountDiscountFilter>? Filters
    {
        get
        {
            return this._rawData.GetNullableStruct<ImmutableArray<AmountDiscountFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AmountDiscountFilter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Reason
    {
        get { return this._rawData.GetNullableClass<string>("reason"); }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AmountDiscountValue;
        this.DiscountType.Validate();
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public AmountDiscount() { }

    public AmountDiscount(AmountDiscount amountDiscount)
        : base(amountDiscount) { }

    public AmountDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmountDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmountDiscountFromRaw.FromRawUnchecked"/>
    public static AmountDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmountDiscountFromRaw : IFromRawJson<AmountDiscount>
{
    /// <inheritdoc/>
    public AmountDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AmountDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DiscountTypeConverter))]
public enum DiscountType
{
    Amount,
}

sealed class DiscountTypeConverter : JsonConverter<DiscountType>
{
    public override DiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount" => DiscountType.Amount,
            _ => (DiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountType.Amount => "amount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<AmountDiscountFilter, AmountDiscountFilterFromRaw>))]
public sealed record class AmountDiscountFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, AmountDiscountFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, AmountDiscountFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, AmountDiscountFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, AmountDiscountFilterOperator>>(
                "operator"
            );
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

    public AmountDiscountFilter() { }

    public AmountDiscountFilter(AmountDiscountFilter amountDiscountFilter)
        : base(amountDiscountFilter) { }

    public AmountDiscountFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmountDiscountFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmountDiscountFilterFromRaw.FromRawUnchecked"/>
    public static AmountDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmountDiscountFilterFromRaw : IFromRawJson<AmountDiscountFilter>
{
    /// <inheritdoc/>
    public AmountDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AmountDiscountFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(AmountDiscountFilterFieldConverter))]
public enum AmountDiscountFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class AmountDiscountFilterFieldConverter : JsonConverter<AmountDiscountFilterField>
{
    public override AmountDiscountFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => AmountDiscountFilterField.PriceID,
            "item_id" => AmountDiscountFilterField.ItemID,
            "price_type" => AmountDiscountFilterField.PriceType,
            "currency" => AmountDiscountFilterField.Currency,
            "pricing_unit_id" => AmountDiscountFilterField.PricingUnitID,
            _ => (AmountDiscountFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmountDiscountFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmountDiscountFilterField.PriceID => "price_id",
                AmountDiscountFilterField.ItemID => "item_id",
                AmountDiscountFilterField.PriceType => "price_type",
                AmountDiscountFilterField.Currency => "currency",
                AmountDiscountFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(AmountDiscountFilterOperatorConverter))]
public enum AmountDiscountFilterOperator
{
    Includes,
    Excludes,
}

sealed class AmountDiscountFilterOperatorConverter : JsonConverter<AmountDiscountFilterOperator>
{
    public override AmountDiscountFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => AmountDiscountFilterOperator.Includes,
            "excludes" => AmountDiscountFilterOperator.Excludes,
            _ => (AmountDiscountFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmountDiscountFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmountDiscountFilterOperator.Includes => "includes",
                AmountDiscountFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
