using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AmountDiscount>))]
public sealed record class AmountDiscount : ModelBase, IFromRaw<AmountDiscount>
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required string AmountDiscount1
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out JsonElement element))
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
        set
        {
            this.Properties["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DiscountType> DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
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
        set
        {
            this.Properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public List<string>? AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["applies_to_price_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public List<FilterModel>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<FilterModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmountDiscount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AmountDiscount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
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

[JsonConverter(typeof(ModelConverter<FilterModel>))]
public sealed record class FilterModel : ModelBase, IFromRaw<FilterModel>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, FieldModel> Field
    {
        get
        {
            if (!this.Properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, FieldModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["field"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, OperatorModel> Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, OperatorModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required List<string> Values
    {
        get
        {
            if (!this.Properties.TryGetValue("values", out JsonElement element))
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
        set
        {
            this.Properties["values"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FilterModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(FieldModelConverter))]
public enum FieldModel
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class FieldModelConverter : JsonConverter<FieldModel>
{
    public override FieldModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => FieldModel.PriceID,
            "item_id" => FieldModel.ItemID,
            "price_type" => FieldModel.PriceType,
            "currency" => FieldModel.Currency,
            "pricing_unit_id" => FieldModel.PricingUnitID,
            _ => (FieldModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FieldModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FieldModel.PriceID => "price_id",
                FieldModel.ItemID => "item_id",
                FieldModel.PriceType => "price_type",
                FieldModel.Currency => "currency",
                FieldModel.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(OperatorModelConverter))]
public enum OperatorModel
{
    Includes,
    Excludes,
}

sealed class OperatorModelConverter : JsonConverter<OperatorModel>
{
    public override OperatorModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => OperatorModel.Includes,
            "excludes" => OperatorModel.Excludes,
            _ => (OperatorModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OperatorModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OperatorModel.Includes => "includes",
                OperatorModel.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
