using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewMinimum>))]
public sealed record class NewMinimum : ModelBase, IFromRaw<NewMinimum>
{
    public required ApiEnum<string, AdjustmentType6> AdjustmentType
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType6>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["adjustment_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The item ID that revenue from this minimum will be attributed to.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        set
        {
            this.Properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_amount' cannot be null",
                    new System::ArgumentNullException("minimum_amount")
                );
        }
        set
        {
            this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, AppliesToAll1>? AppliesToAll
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_all", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AppliesToAll1>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["applies_to_all"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("applies_to_item_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["applies_to_item_ids"] = JsonSerializer.SerializeToElement(
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
    /// If set, only prices in the specified currency will have the adjustment applied.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
    /// </summary>
    public List<Filter14>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter14>?>(
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

    /// <summary>
    /// When false, this adjustment will be applied to a single price. Otherwise,
    /// it will be applied at the invoice level, possibly to multiple prices.
    /// </summary>
    public bool? IsInvoiceLevel
    {
        get
        {
            if (!this.Properties.TryGetValue("is_invoice_level", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_invoice_level"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set, only prices of the specified type will have the adjustment applied.
    /// </summary>
    public ApiEnum<string, PriceType1>? PriceType
    {
        get
        {
            if (!this.Properties.TryGetValue("price_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PriceType1>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["price_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.ItemID;
        _ = this.MinimumAmount;
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

    public NewMinimum() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewMinimum(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewMinimum FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(AdjustmentType6Converter))]
public enum AdjustmentType6
{
    Minimum,
}

sealed class AdjustmentType6Converter : JsonConverter<AdjustmentType6>
{
    public override AdjustmentType6 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "minimum" => AdjustmentType6.Minimum,
            _ => (AdjustmentType6)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentType6 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentType6.Minimum => "minimum",
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
[JsonConverter(typeof(AppliesToAll1Converter))]
public enum AppliesToAll1
{
    True,
}

sealed class AppliesToAll1Converter : JsonConverter<AppliesToAll1>
{
    public override AppliesToAll1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AppliesToAll1.True,
            _ => (AppliesToAll1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliesToAll1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AppliesToAll1.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter14>))]
public sealed record class Filter14 : ModelBase, IFromRaw<Filter14>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Field14> Field
    {
        get
        {
            if (!this.Properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Field14>>(
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
    public required ApiEnum<string, Operator14> Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator14>>(
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

    public Filter14() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter14(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Filter14 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Field14Converter))]
public enum Field14
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Field14Converter : JsonConverter<Field14>
{
    public override Field14 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Field14.PriceID,
            "item_id" => Field14.ItemID,
            "price_type" => Field14.PriceType,
            "currency" => Field14.Currency,
            "pricing_unit_id" => Field14.PricingUnitID,
            _ => (Field14)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field14 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field14.PriceID => "price_id",
                Field14.ItemID => "item_id",
                Field14.PriceType => "price_type",
                Field14.Currency => "currency",
                Field14.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Operator14Converter))]
public enum Operator14
{
    Includes,
    Excludes,
}

sealed class Operator14Converter : JsonConverter<Operator14>
{
    public override Operator14 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Operator14.Includes,
            "excludes" => Operator14.Excludes,
            _ => (Operator14)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operator14 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator14.Includes => "includes",
                Operator14.Excludes => "excludes",
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
[JsonConverter(typeof(PriceType1Converter))]
public enum PriceType1
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class PriceType1Converter : JsonConverter<PriceType1>
{
    public override PriceType1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => PriceType1.Usage,
            "fixed_in_advance" => PriceType1.FixedInAdvance,
            "fixed_in_arrears" => PriceType1.FixedInArrears,
            "fixed" => PriceType1.Fixed,
            "in_arrears" => PriceType1.InArrears,
            _ => (PriceType1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceType1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceType1.Usage => "usage",
                PriceType1.FixedInAdvance => "fixed_in_advance",
                PriceType1.FixedInArrears => "fixed_in_arrears",
                PriceType1.Fixed => "fixed",
                PriceType1.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
