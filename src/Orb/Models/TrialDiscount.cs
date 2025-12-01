using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TrialDiscount, TrialDiscountFromRaw>))]
public sealed record class TrialDiscount : ModelBase
{
    public required ApiEnum<string, TrialDiscountDiscountType> DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, TrialDiscountDiscountType>>(
                this.RawData,
                "discount_type"
            );
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIDs
    {
        get
        {
            return ModelBase.GetNullableClass<List<string>>(this.RawData, "applies_to_price_ids");
        }
        init { ModelBase.Set(this._rawData, "applies_to_price_ids", value); }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public IReadOnlyList<Filter25>? Filters
    {
        get { return ModelBase.GetNullableClass<List<Filter25>>(this.RawData, "filters"); }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    /// <summary>
    /// Only available if discount_type is `trial`
    /// </summary>
    public string? TrialAmountDiscount
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "trial_amount_discount"); }
        init { ModelBase.Set(this._rawData, "trial_amount_discount", value); }
    }

    /// <summary>
    /// Only available if discount_type is `trial`
    /// </summary>
    public double? TrialPercentageDiscount
    {
        get
        {
            return ModelBase.GetNullableStruct<double>(this.RawData, "trial_percentage_discount");
        }
        init { ModelBase.Set(this._rawData, "trial_percentage_discount", value); }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
        _ = this.TrialAmountDiscount;
        _ = this.TrialPercentageDiscount;
    }

    public TrialDiscount() { }

    public TrialDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class TrialDiscountFromRaw : IFromRaw<TrialDiscount>
{
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

[JsonConverter(typeof(ModelConverter<Filter25, Filter25FromRaw>))]
public sealed record class Filter25 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter25Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter25Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter25Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter25Operator>>(
                this.RawData,
                "operator"
            );
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "values"); }
        init { ModelBase.Set(this._rawData, "values", value); }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public Filter25() { }

    public Filter25(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter25(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter25 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter25FromRaw : IFromRaw<Filter25>
{
    public Filter25 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter25.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter25FieldConverter))]
public enum Filter25Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter25FieldConverter : JsonConverter<Filter25Field>
{
    public override Filter25Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter25Field.PriceID,
            "item_id" => Filter25Field.ItemID,
            "price_type" => Filter25Field.PriceType,
            "currency" => Filter25Field.Currency,
            "pricing_unit_id" => Filter25Field.PricingUnitID,
            _ => (Filter25Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter25Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter25Field.PriceID => "price_id",
                Filter25Field.ItemID => "item_id",
                Filter25Field.PriceType => "price_type",
                Filter25Field.Currency => "currency",
                Filter25Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter25OperatorConverter))]
public enum Filter25Operator
{
    Includes,
    Excludes,
}

sealed class Filter25OperatorConverter : JsonConverter<Filter25Operator>
{
    public override Filter25Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter25Operator.Includes,
            "excludes" => Filter25Operator.Excludes,
            _ => (Filter25Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter25Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter25Operator.Includes => "includes",
                Filter25Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
