using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewFloatingGroupedWithMeteredMinimumPrice>))]
public sealed record class NewFloatingGroupedWithMeteredMinimumPrice
    : ModelBase,
        IFromRaw<NewFloatingGroupedWithMeteredMinimumPrice>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
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
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_metered_minimum pricing
    /// </summary>
    public required GroupedWithMeteredMinimumConfig GroupedWithMeteredMinimumConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "grouped_with_metered_minimum_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'grouped_with_metered_minimum_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouped_with_metered_minimum_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<GroupedWithMeteredMinimumConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouped_with_metered_minimum_config' cannot be null",
                    new System::ArgumentNullException("grouped_with_metered_minimum_config")
                );
        }
        init
        {
            this._properties["grouped_with_metered_minimum_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType> ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewFloatingGroupedWithMeteredMinimumPriceModelType>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.GroupedWithMeteredMinimumConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
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

    public NewFloatingGroupedWithMeteredMinimumPrice() { }

    public NewFloatingGroupedWithMeteredMinimumPrice(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewFloatingGroupedWithMeteredMinimumPrice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewFloatingGroupedWithMeteredMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewFloatingGroupedWithMeteredMinimumPriceCadenceConverter))]
public enum NewFloatingGroupedWithMeteredMinimumPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewFloatingGroupedWithMeteredMinimumPriceCadenceConverter
    : JsonConverter<NewFloatingGroupedWithMeteredMinimumPriceCadence>
{
    public override NewFloatingGroupedWithMeteredMinimumPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual,
            "semi_annual" => NewFloatingGroupedWithMeteredMinimumPriceCadence.SemiAnnual,
            "monthly" => NewFloatingGroupedWithMeteredMinimumPriceCadence.Monthly,
            "quarterly" => NewFloatingGroupedWithMeteredMinimumPriceCadence.Quarterly,
            "one_time" => NewFloatingGroupedWithMeteredMinimumPriceCadence.OneTime,
            "custom" => NewFloatingGroupedWithMeteredMinimumPriceCadence.Custom,
            _ => (NewFloatingGroupedWithMeteredMinimumPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedWithMeteredMinimumPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual => "annual",
                NewFloatingGroupedWithMeteredMinimumPriceCadence.SemiAnnual => "semi_annual",
                NewFloatingGroupedWithMeteredMinimumPriceCadence.Monthly => "monthly",
                NewFloatingGroupedWithMeteredMinimumPriceCadence.Quarterly => "quarterly",
                NewFloatingGroupedWithMeteredMinimumPriceCadence.OneTime => "one_time",
                NewFloatingGroupedWithMeteredMinimumPriceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_with_metered_minimum pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<GroupedWithMeteredMinimumConfig>))]
public sealed record class GroupedWithMeteredMinimumConfig
    : ModelBase,
        IFromRaw<GroupedWithMeteredMinimumConfig>
{
    /// <summary>
    /// Used to partition the usage into groups. The minimum amount is applied to
    /// each group.
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
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
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge per group per unit
    /// </summary>
    public required string MinimumUnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("minimum_unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_unit_amount' cannot be null",
                    new System::ArgumentNullException("minimum_unit_amount")
                );
        }
        init
        {
            this._properties["minimum_unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string PricingKey
    {
        get
        {
            if (!this._properties.TryGetValue("pricing_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'pricing_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "pricing_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'pricing_key' cannot be null",
                    new System::ArgumentNullException("pricing_key")
                );
        }
        init
        {
            this._properties["pricing_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Scale the unit rates by the scaling factor.
    /// </summary>
    public required List<ScalingFactor> ScalingFactors
    {
        get
        {
            if (!this._properties.TryGetValue("scaling_factors", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'scaling_factors' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "scaling_factors",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<ScalingFactor>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'scaling_factors' cannot be null",
                    new System::ArgumentNullException("scaling_factors")
                );
        }
        init
        {
            this._properties["scaling_factors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used to determine the unit rate scaling factor
    /// </summary>
    public required string ScalingKey
    {
        get
        {
            if (!this._properties.TryGetValue("scaling_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'scaling_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "scaling_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'scaling_key' cannot be null",
                    new System::ArgumentNullException("scaling_key")
                );
        }
        init
        {
            this._properties["scaling_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply per unit pricing to each pricing value. The minimum amount is applied
    /// any unmatched usage.
    /// </summary>
    public required List<UnitAmount> UnitAmounts
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amounts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amounts' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amounts",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<UnitAmount>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'unit_amounts' cannot be null",
                    new System::ArgumentNullException("unit_amounts")
                );
        }
        init
        {
            this._properties["unit_amounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MinimumUnitAmount;
        _ = this.PricingKey;
        foreach (var item in this.ScalingFactors)
        {
            item.Validate();
        }
        _ = this.ScalingKey;
        foreach (var item in this.UnitAmounts)
        {
            item.Validate();
        }
    }

    public GroupedWithMeteredMinimumConfig() { }

    public GroupedWithMeteredMinimumConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMeteredMinimumConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMeteredMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a scaling factor
/// </summary>
[JsonConverter(typeof(ModelConverter<ScalingFactor>))]
public sealed record class ScalingFactor : ModelBase, IFromRaw<ScalingFactor>
{
    /// <summary>
    /// Scaling factor
    /// </summary>
    public required string ScalingFactor1
    {
        get
        {
            if (!this._properties.TryGetValue("scaling_factor", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'scaling_factor' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "scaling_factor",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'scaling_factor' cannot be null",
                    new System::ArgumentNullException("scaling_factor")
                );
        }
        init
        {
            this._properties["scaling_factor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Scaling value
    /// </summary>
    public required string ScalingValue
    {
        get
        {
            if (!this._properties.TryGetValue("scaling_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'scaling_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "scaling_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'scaling_value' cannot be null",
                    new System::ArgumentNullException("scaling_value")
                );
        }
        init
        {
            this._properties["scaling_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ScalingFactor1;
        _ = this.ScalingValue;
    }

    public ScalingFactor() { }

    public ScalingFactor(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScalingFactor(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a unit amount
/// </summary>
[JsonConverter(typeof(ModelConverter<UnitAmount>))]
public sealed record class UnitAmount : ModelBase, IFromRaw<UnitAmount>
{
    /// <summary>
    /// Pricing value
    /// </summary>
    public required string PricingValue
    {
        get
        {
            if (!this._properties.TryGetValue("pricing_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'pricing_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "pricing_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'pricing_value' cannot be null",
                    new System::ArgumentNullException("pricing_value")
                );
        }
        init
        {
            this._properties["pricing_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount1
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
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
        init
        {
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PricingValue;
        _ = this.UnitAmount1;
    }

    public UnitAmount() { }

    public UnitAmount(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitAmount(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static UnitAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewFloatingGroupedWithMeteredMinimumPriceModelTypeConverter))]
public enum NewFloatingGroupedWithMeteredMinimumPriceModelType
{
    GroupedWithMeteredMinimum,
}

sealed class NewFloatingGroupedWithMeteredMinimumPriceModelTypeConverter
    : JsonConverter<NewFloatingGroupedWithMeteredMinimumPriceModelType>
{
    public override NewFloatingGroupedWithMeteredMinimumPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "grouped_with_metered_minimum" =>
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            _ => (NewFloatingGroupedWithMeteredMinimumPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedWithMeteredMinimumPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum =>
                    "grouped_with_metered_minimum",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfigConverter))]
public record class NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig"
            );
        }
    }
}

sealed class NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfigConverter
    : JsonConverter<NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig>
{
    public override NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig? Read(
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedWithMeteredMinimumPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
