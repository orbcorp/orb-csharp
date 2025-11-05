using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewMaximum>))]
public sealed record class NewMaximum : ModelBase, IFromRaw<NewMaximum>
{
    public required ApiEnum<string, AdjustmentType5> AdjustmentType
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

            return JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType5>>(
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

    public required string MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "maximum_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_amount' cannot be null",
                    new System::ArgumentNullException("maximum_amount")
                );
        }
        set
        {
            this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, AppliesToAllModel>? AppliesToAll
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_all", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AppliesToAllModel>?>(
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
    public List<Filter13>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter13>?>(
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
    public ApiEnum<string, PriceTypeModel>? PriceType
    {
        get
        {
            if (!this.Properties.TryGetValue("price_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PriceTypeModel>?>(
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
        _ = this.MaximumAmount;
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

    public NewMaximum() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewMaximum(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewMaximum FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(AdjustmentType5Converter))]
public enum AdjustmentType5
{
    Maximum,
}

sealed class AdjustmentType5Converter : JsonConverter<AdjustmentType5>
{
    public override AdjustmentType5 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "maximum" => AdjustmentType5.Maximum,
            _ => (AdjustmentType5)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentType5 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentType5.Maximum => "maximum",
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
[JsonConverter(typeof(AppliesToAllModelConverter))]
public enum AppliesToAllModel
{
    True,
}

sealed class AppliesToAllModelConverter : JsonConverter<AppliesToAllModel>
{
    public override AppliesToAllModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AppliesToAllModel.True,
            _ => (AppliesToAllModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliesToAllModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AppliesToAllModel.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter13>))]
public sealed record class Filter13 : ModelBase, IFromRaw<Filter13>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Field13> Field
    {
        get
        {
            if (!this.Properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Field13>>(
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
    public required ApiEnum<string, Operator13> Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator13>>(
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

    public Filter13() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter13(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Filter13 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Field13Converter))]
public enum Field13
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Field13Converter : JsonConverter<Field13>
{
    public override Field13 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Field13.PriceID,
            "item_id" => Field13.ItemID,
            "price_type" => Field13.PriceType,
            "currency" => Field13.Currency,
            "pricing_unit_id" => Field13.PricingUnitID,
            _ => (Field13)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field13 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field13.PriceID => "price_id",
                Field13.ItemID => "item_id",
                Field13.PriceType => "price_type",
                Field13.Currency => "currency",
                Field13.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Operator13Converter))]
public enum Operator13
{
    Includes,
    Excludes,
}

sealed class Operator13Converter : JsonConverter<Operator13>
{
    public override Operator13 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Operator13.Includes,
            "excludes" => Operator13.Excludes,
            _ => (Operator13)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operator13 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator13.Includes => "includes",
                Operator13.Excludes => "excludes",
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
[JsonConverter(typeof(PriceTypeModelConverter))]
public enum PriceTypeModel
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class PriceTypeModelConverter : JsonConverter<PriceTypeModel>
{
    public override PriceTypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => PriceTypeModel.Usage,
            "fixed_in_advance" => PriceTypeModel.FixedInAdvance,
            "fixed_in_arrears" => PriceTypeModel.FixedInArrears,
            "fixed" => PriceTypeModel.Fixed,
            "in_arrears" => PriceTypeModel.InArrears,
            _ => (PriceTypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceTypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceTypeModel.Usage => "usage",
                PriceTypeModel.FixedInAdvance => "fixed_in_advance",
                PriceTypeModel.FixedInArrears => "fixed_in_arrears",
                PriceTypeModel.Fixed => "fixed",
                PriceTypeModel.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
