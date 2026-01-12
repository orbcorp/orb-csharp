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

[JsonConverter(typeof(JsonModelConverter<TrialDiscount, TrialDiscountFromRaw>))]
public sealed record class TrialDiscount : JsonModel
{
    public required ApiEnum<string, TrialDiscountDiscountType> DiscountType
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, TrialDiscountDiscountType>>(
                "discount_type"
            );
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
    public IReadOnlyList<TrialDiscountFilter>? Filters
    {
        get
        {
            return this._rawData.GetNullableStruct<ImmutableArray<TrialDiscountFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TrialDiscountFilter>?>(
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

    /// <summary>
    /// Only available if discount_type is `trial`
    /// </summary>
    public string? TrialAmountDiscount
    {
        get { return this._rawData.GetNullableClass<string>("trial_amount_discount"); }
        init { this._rawData.Set("trial_amount_discount", value); }
    }

    /// <summary>
    /// Only available if discount_type is `trial`
    /// </summary>
    public double? TrialPercentageDiscount
    {
        get { return this._rawData.GetNullableStruct<double>("trial_percentage_discount"); }
        init { this._rawData.Set("trial_percentage_discount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
        _ = this.TrialAmountDiscount;
        _ = this.TrialPercentageDiscount;
    }

    public TrialDiscount() { }

    public TrialDiscount(TrialDiscount trialDiscount)
        : base(trialDiscount) { }

    public TrialDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrialDiscountFromRaw.FromRawUnchecked"/>
    public static TrialDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TrialDiscount(ApiEnum<string, TrialDiscountDiscountType> discountType)
        : this()
    {
        this.DiscountType = discountType;
    }
}

class TrialDiscountFromRaw : IFromRawJson<TrialDiscount>
{
    /// <inheritdoc/>
    public TrialDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrialDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TrialDiscountDiscountTypeConverter))]
public enum TrialDiscountDiscountType
{
    Trial,
}

sealed class TrialDiscountDiscountTypeConverter : JsonConverter<TrialDiscountDiscountType>
{
    public override TrialDiscountDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trial" => TrialDiscountDiscountType.Trial,
            _ => (TrialDiscountDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialDiscountDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrialDiscountDiscountType.Trial => "trial",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TrialDiscountFilter, TrialDiscountFilterFromRaw>))]
public sealed record class TrialDiscountFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, TrialDiscountFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, TrialDiscountFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, TrialDiscountFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, TrialDiscountFilterOperator>>(
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

    public TrialDiscountFilter() { }

    public TrialDiscountFilter(TrialDiscountFilter trialDiscountFilter)
        : base(trialDiscountFilter) { }

    public TrialDiscountFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialDiscountFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrialDiscountFilterFromRaw.FromRawUnchecked"/>
    public static TrialDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrialDiscountFilterFromRaw : IFromRawJson<TrialDiscountFilter>
{
    /// <inheritdoc/>
    public TrialDiscountFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrialDiscountFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(TrialDiscountFilterFieldConverter))]
public enum TrialDiscountFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class TrialDiscountFilterFieldConverter : JsonConverter<TrialDiscountFilterField>
{
    public override TrialDiscountFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => TrialDiscountFilterField.PriceID,
            "item_id" => TrialDiscountFilterField.ItemID,
            "price_type" => TrialDiscountFilterField.PriceType,
            "currency" => TrialDiscountFilterField.Currency,
            "pricing_unit_id" => TrialDiscountFilterField.PricingUnitID,
            _ => (TrialDiscountFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialDiscountFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrialDiscountFilterField.PriceID => "price_id",
                TrialDiscountFilterField.ItemID => "item_id",
                TrialDiscountFilterField.PriceType => "price_type",
                TrialDiscountFilterField.Currency => "currency",
                TrialDiscountFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(TrialDiscountFilterOperatorConverter))]
public enum TrialDiscountFilterOperator
{
    Includes,
    Excludes,
}

sealed class TrialDiscountFilterOperatorConverter : JsonConverter<TrialDiscountFilterOperator>
{
    public override TrialDiscountFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => TrialDiscountFilterOperator.Includes,
            "excludes" => TrialDiscountFilterOperator.Excludes,
            _ => (TrialDiscountFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialDiscountFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrialDiscountFilterOperator.Includes => "includes",
                TrialDiscountFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
