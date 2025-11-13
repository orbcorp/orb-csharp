using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewPlanScalableMatrixWithUnitPricingPrice>))]
public sealed record class NewPlanScalableMatrixWithUnitPricingPrice
    : ModelBase,
        IFromRaw<NewPlanScalableMatrixWithUnitPricingPrice>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceCadence>
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
    public required ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType> ModelType
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
                ApiEnum<string, NewPlanScalableMatrixWithUnitPricingPriceModelType>
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
    /// Configuration for scalable_matrix_with_unit_pricing pricing
    /// </summary>
    public required NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig ScalableMatrixWithUnitPricingConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "scalable_matrix_with_unit_pricing_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'scalable_matrix_with_unit_pricing_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "scalable_matrix_with_unit_pricing_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'scalable_matrix_with_unit_pricing_config' cannot be null",
                    new System::ArgumentNullException("scalable_matrix_with_unit_pricing_config")
                );
        }
        init
        {
            this._properties["scalable_matrix_with_unit_pricing_config"] =
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
    public NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
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

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
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
        this.ScalableMatrixWithUnitPricingConfig.Validate();
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

    public NewPlanScalableMatrixWithUnitPricingPrice() { }

    public NewPlanScalableMatrixWithUnitPricingPrice(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanScalableMatrixWithUnitPricingPrice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewPlanScalableMatrixWithUnitPricingPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewPlanScalableMatrixWithUnitPricingPriceCadenceConverter))]
public enum NewPlanScalableMatrixWithUnitPricingPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewPlanScalableMatrixWithUnitPricingPriceCadenceConverter
    : JsonConverter<NewPlanScalableMatrixWithUnitPricingPriceCadence>
{
    public override NewPlanScalableMatrixWithUnitPricingPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
            "semi_annual" => NewPlanScalableMatrixWithUnitPricingPriceCadence.SemiAnnual,
            "monthly" => NewPlanScalableMatrixWithUnitPricingPriceCadence.Monthly,
            "quarterly" => NewPlanScalableMatrixWithUnitPricingPriceCadence.Quarterly,
            "one_time" => NewPlanScalableMatrixWithUnitPricingPriceCadence.OneTime,
            "custom" => NewPlanScalableMatrixWithUnitPricingPriceCadence.Custom,
            _ => (NewPlanScalableMatrixWithUnitPricingPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanScalableMatrixWithUnitPricingPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual => "annual",
                NewPlanScalableMatrixWithUnitPricingPriceCadence.SemiAnnual => "semi_annual",
                NewPlanScalableMatrixWithUnitPricingPriceCadence.Monthly => "monthly",
                NewPlanScalableMatrixWithUnitPricingPriceCadence.Quarterly => "quarterly",
                NewPlanScalableMatrixWithUnitPricingPriceCadence.OneTime => "one_time",
                NewPlanScalableMatrixWithUnitPricingPriceCadence.Custom => "custom",
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
[JsonConverter(typeof(NewPlanScalableMatrixWithUnitPricingPriceModelTypeConverter))]
public enum NewPlanScalableMatrixWithUnitPricingPriceModelType
{
    ScalableMatrixWithUnitPricing,
}

sealed class NewPlanScalableMatrixWithUnitPricingPriceModelTypeConverter
    : JsonConverter<NewPlanScalableMatrixWithUnitPricingPriceModelType>
{
    public override NewPlanScalableMatrixWithUnitPricingPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scalable_matrix_with_unit_pricing" =>
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            _ => (NewPlanScalableMatrixWithUnitPricingPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanScalableMatrixWithUnitPricingPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing =>
                    "scalable_matrix_with_unit_pricing",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for scalable_matrix_with_unit_pricing pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig>)
)]
public sealed record class NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig
    : ModelBase,
        IFromRaw<NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig>
{
    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string FirstDimension
    {
        get
        {
            if (!this._properties.TryGetValue("first_dimension", out JsonElement element))
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
            this._properties["first_dimension"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply a scaling factor to each dimension
    /// </summary>
    public required List<MatrixScalingFactor2> MatrixScalingFactors
    {
        get
        {
            if (!this._properties.TryGetValue("matrix_scaling_factors", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_scaling_factors' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "matrix_scaling_factors",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<MatrixScalingFactor2>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'matrix_scaling_factors' cannot be null",
                    new System::ArgumentNullException("matrix_scaling_factors")
                );
        }
        init
        {
            this._properties["matrix_scaling_factors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The final unit price to rate against the output of the matrix
    /// </summary>
    public required string UnitPrice
    {
        get
        {
            if (!this._properties.TryGetValue("unit_price", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_price' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_price",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_price' cannot be null",
                    new System::ArgumentNullException("unit_price")
                );
        }
        init
        {
            this._properties["unit_price"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("prorate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["prorate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used to determine the unit rate (optional)
    /// </summary>
    public string? SecondDimension
    {
        get
        {
            if (!this._properties.TryGetValue("second_dimension", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["second_dimension"] = JsonSerializer.SerializeToElement(
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
        _ = this.UnitPrice;
        _ = this.Prorate;
        _ = this.SecondDimension;
    }

    public NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig() { }

    public NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewPlanScalableMatrixWithUnitPricingPriceScalableMatrixWithUnitPricingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single matrix scaling factor
/// </summary>
[JsonConverter(typeof(ModelConverter<MatrixScalingFactor2>))]
public sealed record class MatrixScalingFactor2 : ModelBase, IFromRaw<MatrixScalingFactor2>
{
    /// <summary>
    /// First dimension value
    /// </summary>
    public required string FirstDimensionValue
    {
        get
        {
            if (!this._properties.TryGetValue("first_dimension_value", out JsonElement element))
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
            this._properties["first_dimension_value"] = JsonSerializer.SerializeToElement(
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
    /// Second dimension value (optional)
    /// </summary>
    public string? SecondDimensionValue
    {
        get
        {
            if (!this._properties.TryGetValue("second_dimension_value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["second_dimension_value"] = JsonSerializer.SerializeToElement(
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

    public MatrixScalingFactor2() { }

    public MatrixScalingFactor2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixScalingFactor2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MatrixScalingFactor2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfigConverter))]
public record class NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig
{
    public object Value { get; private init; }

    public NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    )
    {
        Value = value;
    }

    public NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    )
    {
        Value = value;
    }

    NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig(UnknownVariant value)
    {
        Value = value;
    }

    public static NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
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
                    "Data did not match any variant of NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig"
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
                "Data did not match any variant of NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfigConverter
    : JsonConverter<NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig>
{
    public override NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig? Read(
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
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'SharedUnitConversionRateConfig'",
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
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'SharedTieredConversionRateConfig'",
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
        NewPlanScalableMatrixWithUnitPricingPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
