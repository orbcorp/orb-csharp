using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewFloatingTieredWithMinimumPrice>))]
public sealed record class NewFloatingTieredWithMinimumPrice
    : ModelBase,
        IFromRaw<NewFloatingTieredWithMinimumPrice>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, Cadence21> Cadence
    {
        get
        {
            if (!this.Properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Cadence21>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
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
    /// The id of the item the price will be associated with.
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
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, ModelType20> ModelType
    {
        get
        {
            if (!this.Properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ModelType20>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for tiered_with_minimum pricing
    /// </summary>
    public required TieredWithMinimumConfig TieredWithMinimumConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("tiered_with_minimum_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiered_with_minimum_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tiered_with_minimum_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TieredWithMinimumConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiered_with_minimum_config' cannot be null",
                    new System::ArgumentNullException("tiered_with_minimum_config")
                );
        }
        set
        {
            this.Properties["tiered_with_minimum_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this.Properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this.Properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue("billing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ConversionRateConfig20? ConversionRateConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ConversionRateConfig20?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this.Properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.TieredWithMinimumConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public NewFloatingTieredWithMinimumPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewFloatingTieredWithMinimumPrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewFloatingTieredWithMinimumPrice FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(Cadence21Converter))]
public enum Cadence21
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence21Converter : JsonConverter<Cadence21>
{
    public override Cadence21 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => Cadence21.Annual,
            "semi_annual" => Cadence21.SemiAnnual,
            "monthly" => Cadence21.Monthly,
            "quarterly" => Cadence21.Quarterly,
            "one_time" => Cadence21.OneTime,
            "custom" => Cadence21.Custom,
            _ => (Cadence21)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Cadence21 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cadence21.Annual => "annual",
                Cadence21.SemiAnnual => "semi_annual",
                Cadence21.Monthly => "monthly",
                Cadence21.Quarterly => "quarterly",
                Cadence21.OneTime => "one_time",
                Cadence21.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(ModelType20Converter))]
public enum ModelType20
{
    TieredWithMinimum,
}

sealed class ModelType20Converter : JsonConverter<ModelType20>
{
    public override ModelType20 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tiered_with_minimum" => ModelType20.TieredWithMinimum,
            _ => (ModelType20)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelType20 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelType20.TieredWithMinimum => "tiered_with_minimum",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for tiered_with_minimum pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<TieredWithMinimumConfig>))]
public sealed record class TieredWithMinimumConfig : ModelBase, IFromRaw<TieredWithMinimumConfig>
{
    /// <summary>
    /// Tiered pricing with a minimum amount dependent on the volume tier. Tiers are
    /// defined using exclusive lower bounds.
    /// </summary>
    public required List<Tier6> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Tier6>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        set
        {
            this.Properties["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, tiers with an accrued amount of 0 will not be included in the rating.
    /// </summary>
    public bool? HideZeroAmountTiers
    {
        get
        {
            if (!this.Properties.TryGetValue("hide_zero_amount_tiers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["hide_zero_amount_tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, the unit price will be prorated to the billing period
    /// </summary>
    public bool? Prorate
    {
        get
        {
            if (!this.Properties.TryGetValue("prorate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["prorate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
        _ = this.HideZeroAmountTiers;
        _ = this.Prorate;
    }

    public TieredWithMinimumConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithMinimumConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredWithMinimumConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TieredWithMinimumConfig(List<Tier6> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

/// <summary>
/// Configuration for a single tier
/// </summary>
[JsonConverter(typeof(ModelConverter<Tier6>))]
public sealed record class Tier6 : ModelBase, IFromRaw<Tier6>
{
    /// <summary>
    /// Minimum amount
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
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this.Properties.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tier_lower_bound",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentNullException("tier_lower_bound")
                );
        }
        set
        {
            this.Properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        set
        {
            this.Properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.MinimumAmount;
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public Tier6() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier6(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Tier6 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ConversionRateConfig20Converter))]
public record class ConversionRateConfig20
{
    public object Value { get; private init; }

    public ConversionRateConfig20(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig20(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig20(UnknownVariant value)
    {
        Value = value;
    }

    public static ConversionRateConfig20 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig20"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig20"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig20"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig20Converter : JsonConverter<ConversionRateConfig20>
{
    public override ConversionRateConfig20? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ConversionRateConfig20(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ConversionRateConfig20(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversionRateConfig20 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
