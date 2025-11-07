using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewAmountDiscount>))]
public sealed record class NewAmountDiscount : ModelBase, IFromRaw<NewAmountDiscount>
{
    public required ApiEnum<string, AdjustmentType4> AdjustmentType
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType4>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["adjustment_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string AmountDiscount
    {
        get
        {
            if (!this._properties.TryGetValue("amount_discount", out JsonElement element))
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
            this._properties["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, AppliesToAll>? AppliesToAll
    {
        get
        {
            if (!this._properties.TryGetValue("applies_to_all", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AppliesToAll>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["applies_to_all"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The set of item IDs to which this adjustment applies.
    /// </summary>
    public List<string>? AppliesToItemIDs
    {
        get
        {
            if (!this._properties.TryGetValue("applies_to_item_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["applies_to_item_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The set of price IDs to which this adjustment applies.
    /// </summary>
    public List<string>? AppliesToPriceIDs
    {
        get
        {
            if (!this._properties.TryGetValue("applies_to_price_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["applies_to_price_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set, only prices in the specified currency will have the adjustment applied.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
    /// </summary>
    public List<Filter12>? Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter12>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When false, this adjustment will be applied to a single price. Otherwise,
    /// it will be applied at the invoice level, possibly to multiple prices.
    /// </summary>
    public bool? IsInvoiceLevel
    {
        get
        {
            if (!this._properties.TryGetValue("is_invoice_level", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["is_invoice_level"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set, only prices of the specified type will have the adjustment applied.
    /// </summary>
    public ApiEnum<string, PriceType>? PriceType
    {
        get
        {
            if (!this._properties.TryGetValue("price_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PriceType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["price_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.AmountDiscount;
        this.AppliesToAll?.Validate();
        _ = this.AppliesToItemIDs;
        _ = this.AppliesToPriceIDs;
        _ = this.Currency;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        this.PriceType?.Validate();
    }

    public NewAmountDiscount() { }

    public NewAmountDiscount(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAmountDiscount(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewAmountDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(AdjustmentType4Converter))]
public enum AdjustmentType4
{
    AmountDiscount,
}

sealed class AdjustmentType4Converter : JsonConverter<AdjustmentType4>
{
    public override AdjustmentType4 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount_discount" => AdjustmentType4.AmountDiscount,
            _ => (AdjustmentType4)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentType4 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentType4.AmountDiscount => "amount_discount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If set, the adjustment will apply to every price on the subscription.
/// </summary>
[JsonConverter(typeof(AppliesToAllConverter))]
public enum AppliesToAll
{
    True,
}

sealed class AppliesToAllConverter : JsonConverter<AppliesToAll>
{
    public override AppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AppliesToAll.True,
            _ => (AppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter12>))]
public sealed record class Filter12 : ModelBase, IFromRaw<Filter12>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Field12> Field
    {
        get
        {
            if (!this._properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Field12>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["field"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Operator12> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator12>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("values", out JsonElement element))
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
            this._properties["values"] = JsonSerializer.SerializeToElement(
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

    public Filter12() { }

    public Filter12(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter12(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Filter12 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Field12Converter))]
public enum Field12
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Field12Converter : JsonConverter<Field12>
{
    public override Field12 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Field12.PriceID,
            "item_id" => Field12.ItemID,
            "price_type" => Field12.PriceType,
            "currency" => Field12.Currency,
            "pricing_unit_id" => Field12.PricingUnitID,
            _ => (Field12)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field12 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field12.PriceID => "price_id",
                Field12.ItemID => "item_id",
                Field12.PriceType => "price_type",
                Field12.Currency => "currency",
                Field12.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Operator12Converter))]
public enum Operator12
{
    Includes,
    Excludes,
}

sealed class Operator12Converter : JsonConverter<Operator12>
{
    public override Operator12 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Operator12.Includes,
            "excludes" => Operator12.Excludes,
            _ => (Operator12)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operator12 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator12.Includes => "includes",
                Operator12.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If set, only prices of the specified type will have the adjustment applied.
/// </summary>
[JsonConverter(typeof(PriceTypeConverter))]
public enum PriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class PriceTypeConverter : JsonConverter<PriceType>
{
    public override PriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => PriceType.Usage,
            "fixed_in_advance" => PriceType.FixedInAdvance,
            "fixed_in_arrears" => PriceType.FixedInArrears,
            "fixed" => PriceType.Fixed,
            "in_arrears" => PriceType.InArrears,
            _ => (PriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceType.Usage => "usage",
                PriceType.FixedInAdvance => "fixed_in_advance",
                PriceType.FixedInArrears => "fixed_in_arrears",
                PriceType.Fixed => "fixed",
                PriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
