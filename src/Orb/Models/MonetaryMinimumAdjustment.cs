using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<MonetaryMinimumAdjustment>))]
public sealed record class MonetaryMinimumAdjustment
    : ModelBase,
        IFromRaw<MonetaryMinimumAdjustment>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, AdjustmentType1> AdjustmentType
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

            return JsonSerializer.Deserialize<ApiEnum<string, AdjustmentType1>>(
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
    /// The value applied by an adjustment.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
    /// </summary>
    public required List<string> AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "applies_to_price_ids",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new System::ArgumentNullException("applies_to_price_ids")
                );
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
    /// The filters that determine which prices to apply this adjustment to.
    /// </summary>
    public required List<Filter8> Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Filter8>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
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
    /// True for adjustments that apply to an entire invoice, false for adjustments
    /// that apply to only one price.
    /// </summary>
    public required bool IsInvoiceLevel
    {
        get
        {
            if (!this.Properties.TryGetValue("is_invoice_level", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'is_invoice_level' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "is_invoice_level",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
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

    /// <summary>
    /// The minimum amount to charge in a given billing period for the prices this
    /// adjustment applies to.
    /// </summary>
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
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
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

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the
    /// place of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get
        {
            if (!this.Properties.TryGetValue("replaces_adjustment_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["replaces_adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.AdjustmentType.Validate();
        _ = this.Amount;
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.ItemID;
        _ = this.MinimumAmount;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    public MonetaryMinimumAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonetaryMinimumAdjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MonetaryMinimumAdjustment FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(AdjustmentType1Converter))]
public enum AdjustmentType1
{
    Minimum,
}

sealed class AdjustmentType1Converter : JsonConverter<AdjustmentType1>
{
    public override AdjustmentType1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "minimum" => AdjustmentType1.Minimum,
            _ => (AdjustmentType1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentType1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdjustmentType1.Minimum => "minimum",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Filter8>))]
public sealed record class Filter8 : ModelBase, IFromRaw<Filter8>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Field8> Field
    {
        get
        {
            if (!this.Properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Field8>>(
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
    public required ApiEnum<string, Operator8> Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator8>>(
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

    public Filter8() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter8(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Filter8 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Field8Converter))]
public enum Field8
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Field8Converter : JsonConverter<Field8>
{
    public override Field8 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Field8.PriceID,
            "item_id" => Field8.ItemID,
            "price_type" => Field8.PriceType,
            "currency" => Field8.Currency,
            "pricing_unit_id" => Field8.PricingUnitID,
            _ => (Field8)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field8 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field8.PriceID => "price_id",
                Field8.ItemID => "item_id",
                Field8.PriceType => "price_type",
                Field8.Currency => "currency",
                Field8.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Operator8Converter))]
public enum Operator8
{
    Includes,
    Excludes,
}

sealed class Operator8Converter : JsonConverter<Operator8>
{
    public override Operator8 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Operator8.Includes,
            "excludes" => Operator8.Excludes,
            _ => (Operator8)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operator8 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator8.Includes => "includes",
                Operator8.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
