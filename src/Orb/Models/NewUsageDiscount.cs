using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewUsageDiscount>))]
public sealed record class NewUsageDiscount : ModelBase, IFromRaw<NewUsageDiscount>
{
    public required ApiEnum<string, AdjustmentType8> AdjustmentType
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

            return JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType8>>(
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

    public required double UsageDiscount
    {
        get
        {
            if (!this._properties.TryGetValue("usage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'usage_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "usage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["usage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, AppliesToAll3>? AppliesToAll
    {
        get
        {
            if (!this._properties.TryGetValue("applies_to_all", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AppliesToAll3>?>(
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
    public List<Filter16>? Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter16>?>(
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
    public ApiEnum<string, PriceType3>? PriceType
    {
        get
        {
            if (!this._properties.TryGetValue("price_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PriceType3>?>(
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
        _ = this.UsageDiscount;
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

    public NewUsageDiscount() { }

    public NewUsageDiscount(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewUsageDiscount(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewUsageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(AdjustmentType8Converter))]
public enum AdjustmentType8
{
    UsageDiscount,
}

sealed class AdjustmentType8Converter : JsonConverter<AdjustmentType8>
{
    public override AdjustmentType8 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_discount" => AdjustmentType8.UsageDiscount,
            _ => (AdjustmentType8)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentType8 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentType8.UsageDiscount => "usage_discount",
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
[JsonConverter(typeof(AppliesToAll3Converter))]
public enum AppliesToAll3
{
    True,
}

sealed class AppliesToAll3Converter : JsonConverter<AppliesToAll3>
{
    public override AppliesToAll3 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AppliesToAll3.True,
            _ => (AppliesToAll3)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliesToAll3 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AppliesToAll3.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter16>))]
public sealed record class Filter16 : ModelBase, IFromRaw<Filter16>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Field16> Field
    {
        get
        {
            if (!this._properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Field16>>(
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
    public required ApiEnum<string, Operator16> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator16>>(
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

    public Filter16() { }

    public Filter16(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter16(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Filter16 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Field16Converter))]
public enum Field16
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Field16Converter : JsonConverter<Field16>
{
    public override Field16 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Field16.PriceID,
            "item_id" => Field16.ItemID,
            "price_type" => Field16.PriceType,
            "currency" => Field16.Currency,
            "pricing_unit_id" => Field16.PricingUnitID,
            _ => (Field16)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field16 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field16.PriceID => "price_id",
                Field16.ItemID => "item_id",
                Field16.PriceType => "price_type",
                Field16.Currency => "currency",
                Field16.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Operator16Converter))]
public enum Operator16
{
    Includes,
    Excludes,
}

sealed class Operator16Converter : JsonConverter<Operator16>
{
    public override Operator16 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Operator16.Includes,
            "excludes" => Operator16.Excludes,
            _ => (Operator16)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operator16 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator16.Includes => "includes",
                Operator16.Excludes => "excludes",
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
[JsonConverter(typeof(PriceType3Converter))]
public enum PriceType3
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class PriceType3Converter : JsonConverter<PriceType3>
{
    public override PriceType3 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => PriceType3.Usage,
            "fixed_in_advance" => PriceType3.FixedInAdvance,
            "fixed_in_arrears" => PriceType3.FixedInArrears,
            "fixed" => PriceType3.Fixed,
            "in_arrears" => PriceType3.InArrears,
            _ => (PriceType3)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceType3 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceType3.Usage => "usage",
                PriceType3.FixedInAdvance => "fixed_in_advance",
                PriceType3.FixedInArrears => "fixed_in_arrears",
                PriceType3.Fixed => "fixed",
                PriceType3.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
