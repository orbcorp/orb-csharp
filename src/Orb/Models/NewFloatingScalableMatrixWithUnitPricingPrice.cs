using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<
        NewFloatingScalableMatrixWithUnitPricingPrice,
        NewFloatingScalableMatrixWithUnitPricingPriceFromRaw
    >)
)]
public sealed record class NewFloatingScalableMatrixWithUnitPricingPrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewFloatingScalableMatrixWithUnitPricingPriceCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewFloatingScalableMatrixWithUnitPricingPriceCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<
        string,
        NewFloatingScalableMatrixWithUnitPricingPriceModelType
    > ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewFloatingScalableMatrixWithUnitPricingPriceModelType>
            >(this.RawData, "model_type");
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for scalable_matrix_with_unit_pricing pricing
    /// </summary>
    public required ScalableMatrixWithUnitPricingConfig ScalableMatrixWithUnitPricingConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<ScalableMatrixWithUnitPricingConfig>(
                this.RawData,
                "scalable_matrix_with_unit_pricing_config"
            );
        }
        init { ModelBase.Set(this._rawData, "scalable_matrix_with_unit_pricing_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.ScalableMatrixWithUnitPricingConfig.Validate();
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

    public NewFloatingScalableMatrixWithUnitPricingPrice() { }

    public NewFloatingScalableMatrixWithUnitPricingPrice(
        NewFloatingScalableMatrixWithUnitPricingPrice newFloatingScalableMatrixWithUnitPricingPrice
    )
        : base(newFloatingScalableMatrixWithUnitPricingPrice) { }

    public NewFloatingScalableMatrixWithUnitPricingPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewFloatingScalableMatrixWithUnitPricingPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewFloatingScalableMatrixWithUnitPricingPriceFromRaw.FromRawUnchecked"/>
    public static NewFloatingScalableMatrixWithUnitPricingPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewFloatingScalableMatrixWithUnitPricingPriceFromRaw
    : IFromRaw<NewFloatingScalableMatrixWithUnitPricingPrice>
{
    /// <inheritdoc/>
    public NewFloatingScalableMatrixWithUnitPricingPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewFloatingScalableMatrixWithUnitPricingPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewFloatingScalableMatrixWithUnitPricingPriceCadenceConverter))]
public enum NewFloatingScalableMatrixWithUnitPricingPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewFloatingScalableMatrixWithUnitPricingPriceCadenceConverter
    : JsonConverter<NewFloatingScalableMatrixWithUnitPricingPriceCadence>
{
    public override NewFloatingScalableMatrixWithUnitPricingPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewFloatingScalableMatrixWithUnitPricingPriceCadence.Annual,
            "semi_annual" => NewFloatingScalableMatrixWithUnitPricingPriceCadence.SemiAnnual,
            "monthly" => NewFloatingScalableMatrixWithUnitPricingPriceCadence.Monthly,
            "quarterly" => NewFloatingScalableMatrixWithUnitPricingPriceCadence.Quarterly,
            "one_time" => NewFloatingScalableMatrixWithUnitPricingPriceCadence.OneTime,
            "custom" => NewFloatingScalableMatrixWithUnitPricingPriceCadence.Custom,
            _ => (NewFloatingScalableMatrixWithUnitPricingPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingScalableMatrixWithUnitPricingPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingScalableMatrixWithUnitPricingPriceCadence.Annual => "annual",
                NewFloatingScalableMatrixWithUnitPricingPriceCadence.SemiAnnual => "semi_annual",
                NewFloatingScalableMatrixWithUnitPricingPriceCadence.Monthly => "monthly",
                NewFloatingScalableMatrixWithUnitPricingPriceCadence.Quarterly => "quarterly",
                NewFloatingScalableMatrixWithUnitPricingPriceCadence.OneTime => "one_time",
                NewFloatingScalableMatrixWithUnitPricingPriceCadence.Custom => "custom",
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
[JsonConverter(typeof(NewFloatingScalableMatrixWithUnitPricingPriceModelTypeConverter))]
public enum NewFloatingScalableMatrixWithUnitPricingPriceModelType
{
    ScalableMatrixWithUnitPricing,
}

sealed class NewFloatingScalableMatrixWithUnitPricingPriceModelTypeConverter
    : JsonConverter<NewFloatingScalableMatrixWithUnitPricingPriceModelType>
{
    public override NewFloatingScalableMatrixWithUnitPricingPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scalable_matrix_with_unit_pricing" =>
                NewFloatingScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
            _ => (NewFloatingScalableMatrixWithUnitPricingPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingScalableMatrixWithUnitPricingPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing =>
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
    typeof(ModelConverter<
        ScalableMatrixWithUnitPricingConfig,
        ScalableMatrixWithUnitPricingConfigFromRaw
    >)
)]
public sealed record class ScalableMatrixWithUnitPricingConfig : ModelBase
{
    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string FirstDimension
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "first_dimension"); }
        init { ModelBase.Set(this._rawData, "first_dimension", value); }
    }

    /// <summary>
    /// Apply a scaling factor to each dimension
    /// </summary>
    public required IReadOnlyList<ScalableMatrixWithUnitPricingConfigMatrixScalingFactor> MatrixScalingFactors
    {
        get
        {
            return ModelBase.GetNotNullClass<
                List<ScalableMatrixWithUnitPricingConfigMatrixScalingFactor>
            >(this.RawData, "matrix_scaling_factors");
        }
        init { ModelBase.Set(this._rawData, "matrix_scaling_factors", value); }
    }

    /// <summary>
    /// The final unit price to rate against the output of the matrix
    /// </summary>
    public required string UnitPrice
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_price"); }
        init { ModelBase.Set(this._rawData, "unit_price", value); }
    }

    /// <summary>
    /// If true, the unit price will be prorated to the billing period
    /// </summary>
    public bool? Prorate
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "prorate"); }
        init { ModelBase.Set(this._rawData, "prorate", value); }
    }

    /// <summary>
    /// Used to determine the unit rate (optional)
    /// </summary>
    public string? SecondDimension
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "second_dimension"); }
        init { ModelBase.Set(this._rawData, "second_dimension", value); }
    }

    /// <inheritdoc/>
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

    public ScalableMatrixWithUnitPricingConfig() { }

    public ScalableMatrixWithUnitPricingConfig(
        ScalableMatrixWithUnitPricingConfig scalableMatrixWithUnitPricingConfig
    )
        : base(scalableMatrixWithUnitPricingConfig) { }

    public ScalableMatrixWithUnitPricingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScalableMatrixWithUnitPricingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScalableMatrixWithUnitPricingConfigFromRaw.FromRawUnchecked"/>
    public static ScalableMatrixWithUnitPricingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScalableMatrixWithUnitPricingConfigFromRaw : IFromRaw<ScalableMatrixWithUnitPricingConfig>
{
    /// <inheritdoc/>
    public ScalableMatrixWithUnitPricingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScalableMatrixWithUnitPricingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single matrix scaling factor
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        ScalableMatrixWithUnitPricingConfigMatrixScalingFactor,
        ScalableMatrixWithUnitPricingConfigMatrixScalingFactorFromRaw
    >)
)]
public sealed record class ScalableMatrixWithUnitPricingConfigMatrixScalingFactor : ModelBase
{
    /// <summary>
    /// First dimension value
    /// </summary>
    public required string FirstDimensionValue
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "first_dimension_value"); }
        init { ModelBase.Set(this._rawData, "first_dimension_value", value); }
    }

    /// <summary>
    /// Scaling factor
    /// </summary>
    public required string ScalingFactor
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "scaling_factor"); }
        init { ModelBase.Set(this._rawData, "scaling_factor", value); }
    }

    /// <summary>
    /// Second dimension value (optional)
    /// </summary>
    public string? SecondDimensionValue
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "second_dimension_value"); }
        init { ModelBase.Set(this._rawData, "second_dimension_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstDimensionValue;
        _ = this.ScalingFactor;
        _ = this.SecondDimensionValue;
    }

    public ScalableMatrixWithUnitPricingConfigMatrixScalingFactor() { }

    public ScalableMatrixWithUnitPricingConfigMatrixScalingFactor(
        ScalableMatrixWithUnitPricingConfigMatrixScalingFactor scalableMatrixWithUnitPricingConfigMatrixScalingFactor
    )
        : base(scalableMatrixWithUnitPricingConfigMatrixScalingFactor) { }

    public ScalableMatrixWithUnitPricingConfigMatrixScalingFactor(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScalableMatrixWithUnitPricingConfigMatrixScalingFactor(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScalableMatrixWithUnitPricingConfigMatrixScalingFactorFromRaw.FromRawUnchecked"/>
    public static ScalableMatrixWithUnitPricingConfigMatrixScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScalableMatrixWithUnitPricingConfigMatrixScalingFactorFromRaw
    : IFromRaw<ScalableMatrixWithUnitPricingConfigMatrixScalingFactor>
{
    /// <inheritdoc/>
    public ScalableMatrixWithUnitPricingConfigMatrixScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScalableMatrixWithUnitPricingConfigMatrixScalingFactor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfigConverter))]
public record class NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig"
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
                "Data did not match any variant of NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig(
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfigConverter
    : JsonConverter<NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig>
{
    public override NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig? Read(
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
                return new NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingScalableMatrixWithUnitPricingPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
