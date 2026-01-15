using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<
        NewPlanScalableMatrixWithTieredPricingPrice,
        NewPlanScalableMatrixWithTieredPricingPriceFromRaw
    >)
)]
public sealed record class NewPlanScalableMatrixWithTieredPricingPrice : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewPlanScalableMatrixWithTieredPricingPriceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewPlanScalableMatrixWithTieredPricingPriceCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewPlanScalableMatrixWithTieredPricingPriceModelType> ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewPlanScalableMatrixWithTieredPricingPriceModelType>
            >("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for scalable_matrix_with_tiered_pricing pricing
    /// </summary>
    public required NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig ScalableMatrixWithTieredPricingConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig>(
                "scalable_matrix_with_tiered_pricing_config"
            );
        }
        init { this._rawData.Set("scalable_matrix_with_tiered_pricing_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
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

    public NewPlanScalableMatrixWithTieredPricingPrice() { }

    public NewPlanScalableMatrixWithTieredPricingPrice(
        NewPlanScalableMatrixWithTieredPricingPrice newPlanScalableMatrixWithTieredPricingPrice
    )
        : base(newPlanScalableMatrixWithTieredPricingPrice) { }

    public NewPlanScalableMatrixWithTieredPricingPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanScalableMatrixWithTieredPricingPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanScalableMatrixWithTieredPricingPriceFromRaw.FromRawUnchecked"/>
    public static NewPlanScalableMatrixWithTieredPricingPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanScalableMatrixWithTieredPricingPriceFromRaw
    : IFromRawJson<NewPlanScalableMatrixWithTieredPricingPrice>
{
    /// <inheritdoc/>
    public NewPlanScalableMatrixWithTieredPricingPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPlanScalableMatrixWithTieredPricingPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewPlanScalableMatrixWithTieredPricingPriceCadenceConverter))]
public enum NewPlanScalableMatrixWithTieredPricingPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewPlanScalableMatrixWithTieredPricingPriceCadenceConverter
    : JsonConverter<NewPlanScalableMatrixWithTieredPricingPriceCadence>
{
    public override NewPlanScalableMatrixWithTieredPricingPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewPlanScalableMatrixWithTieredPricingPriceCadence.Annual,
            "semi_annual" => NewPlanScalableMatrixWithTieredPricingPriceCadence.SemiAnnual,
            "monthly" => NewPlanScalableMatrixWithTieredPricingPriceCadence.Monthly,
            "quarterly" => NewPlanScalableMatrixWithTieredPricingPriceCadence.Quarterly,
            "one_time" => NewPlanScalableMatrixWithTieredPricingPriceCadence.OneTime,
            "custom" => NewPlanScalableMatrixWithTieredPricingPriceCadence.Custom,
            _ => (NewPlanScalableMatrixWithTieredPricingPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanScalableMatrixWithTieredPricingPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanScalableMatrixWithTieredPricingPriceCadence.Annual => "annual",
                NewPlanScalableMatrixWithTieredPricingPriceCadence.SemiAnnual => "semi_annual",
                NewPlanScalableMatrixWithTieredPricingPriceCadence.Monthly => "monthly",
                NewPlanScalableMatrixWithTieredPricingPriceCadence.Quarterly => "quarterly",
                NewPlanScalableMatrixWithTieredPricingPriceCadence.OneTime => "one_time",
                NewPlanScalableMatrixWithTieredPricingPriceCadence.Custom => "custom",
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
[JsonConverter(typeof(NewPlanScalableMatrixWithTieredPricingPriceModelTypeConverter))]
public enum NewPlanScalableMatrixWithTieredPricingPriceModelType
{
    ScalableMatrixWithTieredPricing,
}

sealed class NewPlanScalableMatrixWithTieredPricingPriceModelTypeConverter
    : JsonConverter<NewPlanScalableMatrixWithTieredPricingPriceModelType>
{
    public override NewPlanScalableMatrixWithTieredPricingPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scalable_matrix_with_tiered_pricing" =>
                NewPlanScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
            _ => (NewPlanScalableMatrixWithTieredPricingPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanScalableMatrixWithTieredPricingPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing =>
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
    typeof(JsonModelConverter<
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig,
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigFromRaw
    >)
)]
public sealed record class NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig
    : JsonModel
{
    /// <summary>
    /// Used for the scalable matrix first dimension
    /// </summary>
    public required string FirstDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_dimension");
        }
        init { this._rawData.Set("first_dimension", value); }
    }

    /// <summary>
    /// Apply a scaling factor to each dimension
    /// </summary>
    public required IReadOnlyList<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor> MatrixScalingFactors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor>
            >("matrix_scaling_factors");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor>
            >("matrix_scaling_factors", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required IReadOnlyList<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier>
            >("tiers", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Used for the scalable matrix second dimension (optional)
    /// </summary>
    public string? SecondDimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("second_dimension");
        }
        init { this._rawData.Set("second_dimension", value); }
    }

    /// <inheritdoc/>
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

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig() { }

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig(
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig newPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig
    )
        : base(newPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig) { }

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigFromRaw.FromRawUnchecked"/>
    public static NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigFromRaw
    : IFromRawJson<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig>
{
    /// <inheritdoc/>
    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single matrix scaling factor
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor,
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactorFromRaw
    >)
)]
public sealed record class NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor
    : JsonModel
{
    public required string FirstDimensionValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_dimension_value");
        }
        init { this._rawData.Set("first_dimension_value", value); }
    }

    public required string ScalingFactor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("scaling_factor");
        }
        init { this._rawData.Set("scaling_factor", value); }
    }

    public string? SecondDimensionValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("second_dimension_value");
        }
        init { this._rawData.Set("second_dimension_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstDimensionValue;
        _ = this.ScalingFactor;
        _ = this.SecondDimensionValue;
    }

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor()
    { }

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor(
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor newPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor
    )
        : base(
            newPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor
        ) { }

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactorFromRaw.FromRawUnchecked"/>
    public static NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactorFromRaw
    : IFromRawJson<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor>
{
    /// <inheritdoc/>
    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigMatrixScalingFactor.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single tier entry with business logic
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier,
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTierFromRaw
    >)
)]
public sealed record class NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier
    : JsonModel
{
    public required string TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier()
    { }

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier(
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier newPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier
    )
        : base(newPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier)
    { }

    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTierFromRaw.FromRawUnchecked"/>
    public static NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTierFromRaw
    : IFromRawJson<NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier>
{
    /// <inheritdoc/>
    public NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        NewPlanScalableMatrixWithTieredPricingPriceScalableMatrixWithTieredPricingConfigTier.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfigConverter))]
public record class NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfigConverter
    : JsonConverter<NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig>
{
    public override NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
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
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanScalableMatrixWithTieredPricingPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
