using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(
    typeof(ModelConverter<
        NewSubscriptionScalableMatrixWithTieredPricingPrice,
        NewSubscriptionScalableMatrixWithTieredPricingPriceFromRaw
    >)
)]
public sealed record class NewSubscriptionScalableMatrixWithTieredPricingPrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        NewSubscriptionScalableMatrixWithTieredPricingPriceCadence
    > Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewSubscriptionScalableMatrixWithTieredPricingPriceCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
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
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<
        string,
        NewSubscriptionScalableMatrixWithTieredPricingPriceModelType
    > ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewSubscriptionScalableMatrixWithTieredPricingPriceModelType>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("name", out JsonElement element))
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
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for scalable_matrix_with_tiered_pricing pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.ScalableMatrixWithTieredPricingConfig ScalableMatrixWithTieredPricingConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "scalable_matrix_with_tiered_pricing_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'scalable_matrix_with_tiered_pricing_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "scalable_matrix_with_tiered_pricing_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ScalableMatrixWithTieredPricingConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'scalable_matrix_with_tiered_pricing_config' cannot be null",
                    new System::ArgumentNullException("scalable_matrix_with_tiered_pricing_config")
                );
        }
        init
        {
            this._rawData["scalable_matrix_with_tiered_pricing_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
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
                !this._rawData.TryGetValue(
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
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.ScalableMatrixWithTieredPricingConfig.Validate();
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

    public NewSubscriptionScalableMatrixWithTieredPricingPrice() { }

    public NewSubscriptionScalableMatrixWithTieredPricingPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionScalableMatrixWithTieredPricingPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewSubscriptionScalableMatrixWithTieredPricingPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionScalableMatrixWithTieredPricingPriceFromRaw
    : IFromRaw<NewSubscriptionScalableMatrixWithTieredPricingPrice>
{
    public NewSubscriptionScalableMatrixWithTieredPricingPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewSubscriptionScalableMatrixWithTieredPricingPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewSubscriptionScalableMatrixWithTieredPricingPriceCadenceConverter))]
public enum NewSubscriptionScalableMatrixWithTieredPricingPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewSubscriptionScalableMatrixWithTieredPricingPriceCadenceConverter
    : JsonConverter<NewSubscriptionScalableMatrixWithTieredPricingPriceCadence>
{
    public override NewSubscriptionScalableMatrixWithTieredPricingPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Annual,
            "semi_annual" => NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.SemiAnnual,
            "monthly" => NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Monthly,
            "quarterly" => NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Quarterly,
            "one_time" => NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.OneTime,
            "custom" => NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Custom,
            _ => (NewSubscriptionScalableMatrixWithTieredPricingPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionScalableMatrixWithTieredPricingPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Annual => "annual",
                NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.SemiAnnual =>
                    "semi_annual",
                NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Monthly => "monthly",
                NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Quarterly => "quarterly",
                NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.OneTime => "one_time",
                NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Custom => "custom",
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
[JsonConverter(typeof(NewSubscriptionScalableMatrixWithTieredPricingPriceModelTypeConverter))]
public enum NewSubscriptionScalableMatrixWithTieredPricingPriceModelType
{
    ScalableMatrixWithTieredPricing,
}

sealed class NewSubscriptionScalableMatrixWithTieredPricingPriceModelTypeConverter
    : JsonConverter<NewSubscriptionScalableMatrixWithTieredPricingPriceModelType>
{
    public override NewSubscriptionScalableMatrixWithTieredPricingPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scalable_matrix_with_tiered_pricing" =>
                NewSubscriptionScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
            _ => (NewSubscriptionScalableMatrixWithTieredPricingPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionScalableMatrixWithTieredPricingPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing =>
                    "scalable_matrix_with_tiered_pricing",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for scalable_matrix_with_tiered_pricing pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.ScalableMatrixWithTieredPricingConfig,
        global::Orb.Models.Subscriptions.ScalableMatrixWithTieredPricingConfigFromRaw
    >)
)]
public sealed record class ScalableMatrixWithTieredPricingConfig : ModelBase
{
    /// <summary>
    /// Used for the scalable matrix first dimension
    /// </summary>
    public required string FirstDimension
    {
        get
        {
            if (!this._rawData.TryGetValue("first_dimension", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'first_dimension' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "first_dimension",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'first_dimension' cannot be null",
                    new System::ArgumentNullException("first_dimension")
                );
        }
        init
        {
            this._rawData["first_dimension"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply a scaling factor to each dimension
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.MatrixScalingFactor> MatrixScalingFactors
    {
        get
        {
            if (!this._rawData.TryGetValue("matrix_scaling_factors", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_scaling_factors' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "matrix_scaling_factors",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                    List<global::Orb.Models.Subscriptions.MatrixScalingFactor>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'matrix_scaling_factors' cannot be null",
                    new System::ArgumentNullException("matrix_scaling_factors")
                );
        }
        init
        {
            this._rawData["matrix_scaling_factors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tier pricing structure
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.Tier12> Tiers
    {
        get
        {
            if (!this._rawData.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Tier12>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._rawData["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used for the scalable matrix second dimension (optional)
    /// </summary>
    public string? SecondDimension
    {
        get
        {
            if (!this._rawData.TryGetValue("second_dimension", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["second_dimension"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FirstDimension;
        foreach (var item in this.MatrixScalingFactors)
        {
            item.Validate();
        }
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
        _ = this.SecondDimension;
    }

    public ScalableMatrixWithTieredPricingConfig() { }

    public ScalableMatrixWithTieredPricingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScalableMatrixWithTieredPricingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.ScalableMatrixWithTieredPricingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScalableMatrixWithTieredPricingConfigFromRaw
    : IFromRaw<global::Orb.Models.Subscriptions.ScalableMatrixWithTieredPricingConfig>
{
    public global::Orb.Models.Subscriptions.ScalableMatrixWithTieredPricingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Subscriptions.ScalableMatrixWithTieredPricingConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single matrix scaling factor
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.MatrixScalingFactor,
        global::Orb.Models.Subscriptions.MatrixScalingFactorFromRaw
    >)
)]
public sealed record class MatrixScalingFactor : ModelBase
{
    /// <summary>
    /// First dimension value
    /// </summary>
    public required string FirstDimensionValue
    {
        get
        {
            if (!this._rawData.TryGetValue("first_dimension_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'first_dimension_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "first_dimension_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'first_dimension_value' cannot be null",
                    new System::ArgumentNullException("first_dimension_value")
                );
        }
        init
        {
            this._rawData["first_dimension_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Scaling factor
    /// </summary>
    public required string ScalingFactor
    {
        get
        {
            if (!this._rawData.TryGetValue("scaling_factor", out JsonElement element))
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
            this._rawData["scaling_factor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Second dimension value (optional)
    /// </summary>
    public string? SecondDimensionValue
    {
        get
        {
            if (!this._rawData.TryGetValue("second_dimension_value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["second_dimension_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FirstDimensionValue;
        _ = this.ScalingFactor;
        _ = this.SecondDimensionValue;
    }

    public MatrixScalingFactor() { }

    public MatrixScalingFactor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixScalingFactor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.MatrixScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixScalingFactorFromRaw : IFromRaw<global::Orb.Models.Subscriptions.MatrixScalingFactor>
{
    public global::Orb.Models.Subscriptions.MatrixScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.MatrixScalingFactor.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tier entry with business logic
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Tier12,
        global::Orb.Models.Subscriptions.Tier12FromRaw
    >)
)]
public sealed record class Tier12 : ModelBase
{
    /// <summary>
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this._rawData.TryGetValue("tier_lower_bound", out JsonElement element))
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
        init
        {
            this._rawData["tier_lower_bound"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
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
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public Tier12() { }

    public Tier12(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier12(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier12 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Tier12FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Tier12>
{
    public global::Orb.Models.Subscriptions.Tier12 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Tier12.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfigConverter)
)]
public record class NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig"
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
                "Data did not match any variant of NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig"
            );
        }
    }
}

sealed class NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfigConverter
    : JsonConverter<NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig>
{
    public override NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig? Read(
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
                return new NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionScalableMatrixWithTieredPricingPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
