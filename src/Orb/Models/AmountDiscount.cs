using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AmountDiscount, AmountDiscountFromRaw>))]
public sealed record class AmountDiscount : ModelBase
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required string AmountDiscount1
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount_discount"); }
        init { ModelBase.Set(this._rawData, "amount_discount", value); }
    }

    public required ApiEnum<string, DiscountType> DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DiscountType>>(
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
    public IReadOnlyList<FilterModel>? Filters
    {
        get { return ModelBase.GetNullableClass<List<FilterModel>>(this.RawData, "filters"); }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    public override void Validate()
    {
        _ = this.AmountDiscount1;
        this.DiscountType.Validate();
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public AmountDiscount() { }

    public AmountDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmountDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AmountDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmountDiscountFromRaw : IFromRaw<AmountDiscount>
{
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

[JsonConverter(typeof(ModelConverter<FilterModel, FilterModelFromRaw>))]
public sealed record class FilterModel : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, FilterModelField> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, FilterModelField>>(
                this.RawData,
                "field"
            );
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, FilterModelOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, FilterModelOperator>>(
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

    public FilterModel() { }

    public FilterModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static FilterModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterModelFromRaw : IFromRaw<FilterModel>
{
    public FilterModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FilterModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(FilterModelFieldConverter))]
public enum FilterModelField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class FilterModelFieldConverter : JsonConverter<FilterModelField>
{
    public override FilterModelField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => FilterModelField.PriceID,
            "item_id" => FilterModelField.ItemID,
            "price_type" => FilterModelField.PriceType,
            "currency" => FilterModelField.Currency,
            "pricing_unit_id" => FilterModelField.PricingUnitID,
            _ => (FilterModelField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterModelField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FilterModelField.PriceID => "price_id",
                FilterModelField.ItemID => "item_id",
                FilterModelField.PriceType => "price_type",
                FilterModelField.Currency => "currency",
                FilterModelField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(FilterModelOperatorConverter))]
public enum FilterModelOperator
{
    Includes,
    Excludes,
}

sealed class FilterModelOperatorConverter : JsonConverter<FilterModelOperator>
{
    public override FilterModelOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => FilterModelOperator.Includes,
            "excludes" => FilterModelOperator.Excludes,
            _ => (FilterModelOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterModelOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FilterModelOperator.Includes => "includes",
                FilterModelOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
