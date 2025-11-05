using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<NewSubscriptionCumulativeGroupedBulkPrice>))]
public sealed record class NewSubscriptionCumulativeGroupedBulkPrice
    : ModelBase,
        IFromRaw<NewSubscriptionCumulativeGroupedBulkPrice>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence25> Cadence
    {
        get
        {
            if (!this.Properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence25>
            >(element, ModelBase.SerializerOptions);
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
    /// Configuration for cumulative_grouped_bulk pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig CumulativeGroupedBulkConfig
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "cumulative_grouped_bulk_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'cumulative_grouped_bulk_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_grouped_bulk_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'cumulative_grouped_bulk_config' cannot be null",
                    new System::ArgumentNullException("cumulative_grouped_bulk_config")
                );
        }
        set
        {
            this.Properties["cumulative_grouped_bulk_config"] = JsonSerializer.SerializeToElement(
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
    public required ApiEnum<string, global::Orb.Models.Subscriptions.ModelType25> ModelType
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

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.ModelType25>
            >(element, ModelBase.SerializerOptions);
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
    public global::Orb.Models.Subscriptions.ConversionRateConfig25? ConversionRateConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig25?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this.Properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedBulkConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public NewSubscriptionCumulativeGroupedBulkPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionCumulativeGroupedBulkPrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewSubscriptionCumulativeGroupedBulkPrice FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence25Converter))]
public enum Cadence25
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence25Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence25>
{
    public override global::Orb.Models.Subscriptions.Cadence25 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence25.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence25.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence25.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence25.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence25.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence25.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence25)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence25 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence25.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence25.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence25.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence25.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence25.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence25.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for cumulative_grouped_bulk pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig>)
)]
public sealed record class CumulativeGroupedBulkConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig>
{
    /// <summary>
    /// Each tier lower bound must have the same group of values.
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.DimensionValue> DimensionValues
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dimension_values",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                    List<global::Orb.Models.Subscriptions.DimensionValue>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new System::ArgumentNullException("dimension_values")
                );
        }
        set
        {
            this.Properties["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Grouping key name
    /// </summary>
    public required string Group
    {
        get
        {
            if (!this.Properties.TryGetValue("group", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'group' cannot be null",
                    new System::ArgumentOutOfRangeException("group", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'group' cannot be null",
                    new System::ArgumentNullException("group")
                );
        }
        set
        {
            this.Properties["group"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.DimensionValues)
        {
            item.Validate();
        }
        _ = this.Group;
    }

    public CumulativeGroupedBulkConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedBulkConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// Configuration for a dimension value entry
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.DimensionValue>))]
public sealed record class DimensionValue
    : ModelBase,
        IFromRaw<global::Orb.Models.Subscriptions.DimensionValue>
{
    /// <summary>
    /// Grouping key value
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        set
        {
            this.Properties["grouping_key"] = JsonSerializer.SerializeToElement(
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
    /// Unit amount for this combination
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
        _ = this.GroupingKey;
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public DimensionValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionValue(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.DimensionValue FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.ModelType25Converter))]
public enum ModelType25
{
    CumulativeGroupedBulk,
}

sealed class ModelType25Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType25>
{
    public override global::Orb.Models.Subscriptions.ModelType25 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cumulative_grouped_bulk" => global::Orb
                .Models
                .Subscriptions
                .ModelType25
                .CumulativeGroupedBulk,
            _ => (global::Orb.Models.Subscriptions.ModelType25)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.ModelType25 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.ModelType25.CumulativeGroupedBulk =>
                    "cumulative_grouped_bulk",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig25Converter))]
public record class ConversionRateConfig25
{
    public object Value { get; private init; }

    public ConversionRateConfig25(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig25(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig25(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig25 CreateUnknownVariant(
        JsonElement value
    )
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
                    "Data did not match any variant of ConversionRateConfig25"
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
                "Data did not match any variant of ConversionRateConfig25"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig25"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig25Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig25>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig25? Read(
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig25(
                            deserialized
                        );
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig25(
                            deserialized
                        );
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
        global::Orb.Models.Subscriptions.ConversionRateConfig25 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
