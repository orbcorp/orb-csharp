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
        get
        {
            if (!this._rawData.TryGetValue("amount_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "amount_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_discount' cannot be null",
                    new System::ArgumentNullException("amount_discount")
                );
        }
        init
        {
            this._rawData["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DiscountType> DiscountType
    {
        get
        {
            if (!this._rawData.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIDs
    {
        get
        {
            if (!this._rawData.TryGetValue("applies_to_price_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
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
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public IReadOnlyList<FilterModel>? Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<FilterModel>?>(
                element,
                ModelBase.SerializerOptions
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

    public string? Reason
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
            if (!this._rawData.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, FilterModelField>>(
                element,
                ModelBase.SerializerOptions
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
    public required ApiEnum<string, FilterModelOperator> Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, FilterModelOperator>>(
                element,
                ModelBase.SerializerOptions
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
