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
        NewFloatingMaxGroupTieredPackagePrice,
        NewFloatingMaxGroupTieredPackagePriceFromRaw
    >)
)]
public sealed record class NewFloatingMaxGroupTieredPackagePrice : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence> Cadence
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return this._rawData.GetNotNullClass<string>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return this._rawData.GetNotNullClass<string>("item_id"); }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// Configuration for max_group_tiered_package pricing
    /// </summary>
    public required MaxGroupTieredPackageConfig MaxGroupTieredPackageConfig
    {
        get
        {
            return this._rawData.GetNotNullClass<MaxGroupTieredPackageConfig>(
                "max_group_tiered_package_config"
            );
        }
        init { this._rawData.Set("max_group_tiered_package_config", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType> ModelType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewFloatingMaxGroupTieredPackagePriceModelType>
            >("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return this._rawData.GetNullableClass<string>("billable_metric_id"); }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return this._rawData.GetNullableStruct<bool>("billed_in_advance"); }
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
        get { return this._rawData.GetNullableStruct<double>("conversion_rate"); }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewFloatingMaxGroupTieredPackagePriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return this._rawData.GetNullableClass<NewFloatingMaxGroupTieredPackagePriceConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
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
        get { return this._rawData.GetNullableClass<string>("external_price_id"); }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return this._rawData.GetNullableStruct<double>("fixed_price_quantity"); }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return this._rawData.GetNullableClass<string>("invoice_grouping_key"); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.MaxGroupTieredPackageConfig.Validate();
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

    public NewFloatingMaxGroupTieredPackagePrice() { }

    public NewFloatingMaxGroupTieredPackagePrice(
        NewFloatingMaxGroupTieredPackagePrice newFloatingMaxGroupTieredPackagePrice
    )
        : base(newFloatingMaxGroupTieredPackagePrice) { }

    public NewFloatingMaxGroupTieredPackagePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewFloatingMaxGroupTieredPackagePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewFloatingMaxGroupTieredPackagePriceFromRaw.FromRawUnchecked"/>
    public static NewFloatingMaxGroupTieredPackagePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewFloatingMaxGroupTieredPackagePriceFromRaw
    : IFromRawJson<NewFloatingMaxGroupTieredPackagePrice>
{
    /// <inheritdoc/>
    public NewFloatingMaxGroupTieredPackagePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewFloatingMaxGroupTieredPackagePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewFloatingMaxGroupTieredPackagePriceCadenceConverter))]
public enum NewFloatingMaxGroupTieredPackagePriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewFloatingMaxGroupTieredPackagePriceCadenceConverter
    : JsonConverter<NewFloatingMaxGroupTieredPackagePriceCadence>
{
    public override NewFloatingMaxGroupTieredPackagePriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewFloatingMaxGroupTieredPackagePriceCadence.Annual,
            "semi_annual" => NewFloatingMaxGroupTieredPackagePriceCadence.SemiAnnual,
            "monthly" => NewFloatingMaxGroupTieredPackagePriceCadence.Monthly,
            "quarterly" => NewFloatingMaxGroupTieredPackagePriceCadence.Quarterly,
            "one_time" => NewFloatingMaxGroupTieredPackagePriceCadence.OneTime,
            "custom" => NewFloatingMaxGroupTieredPackagePriceCadence.Custom,
            _ => (NewFloatingMaxGroupTieredPackagePriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingMaxGroupTieredPackagePriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingMaxGroupTieredPackagePriceCadence.Annual => "annual",
                NewFloatingMaxGroupTieredPackagePriceCadence.SemiAnnual => "semi_annual",
                NewFloatingMaxGroupTieredPackagePriceCadence.Monthly => "monthly",
                NewFloatingMaxGroupTieredPackagePriceCadence.Quarterly => "quarterly",
                NewFloatingMaxGroupTieredPackagePriceCadence.OneTime => "one_time",
                NewFloatingMaxGroupTieredPackagePriceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for max_group_tiered_package pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MaxGroupTieredPackageConfig, MaxGroupTieredPackageConfigFromRaw>)
)]
public sealed record class MaxGroupTieredPackageConfig : JsonModel
{
    /// <summary>
    /// The event property used to group before tiering the group with the highest value
    /// </summary>
    public required string GroupingKey
    {
        get { return this._rawData.GetNotNullClass<string>("grouping_key"); }
        init { this._rawData.Set("grouping_key", value); }
    }

    public required string PackageSize
    {
        get { return this._rawData.GetNotNullClass<string>("package_size"); }
        init { this._rawData.Set("package_size", value); }
    }

    /// <summary>
    /// Apply tiered pricing to the largest group after grouping with the provided key.
    /// </summary>
    public required IReadOnlyList<MaxGroupTieredPackageConfigTier> Tiers
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<MaxGroupTieredPackageConfigTier>>(
                "tiers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<MaxGroupTieredPackageConfigTier>>(
                "tiers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.PackageSize;
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public MaxGroupTieredPackageConfig() { }

    public MaxGroupTieredPackageConfig(MaxGroupTieredPackageConfig maxGroupTieredPackageConfig)
        : base(maxGroupTieredPackageConfig) { }

    public MaxGroupTieredPackageConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaxGroupTieredPackageConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaxGroupTieredPackageConfigFromRaw.FromRawUnchecked"/>
    public static MaxGroupTieredPackageConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaxGroupTieredPackageConfigFromRaw : IFromRawJson<MaxGroupTieredPackageConfig>
{
    /// <inheritdoc/>
    public MaxGroupTieredPackageConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MaxGroupTieredPackageConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MaxGroupTieredPackageConfigTier,
        MaxGroupTieredPackageConfigTierFromRaw
    >)
)]
public sealed record class MaxGroupTieredPackageConfigTier : JsonModel
{
    public required string TierLowerBound
    {
        get { return this._rawData.GetNotNullClass<string>("tier_lower_bound"); }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount
    {
        get { return this._rawData.GetNotNullClass<string>("unit_amount"); }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public MaxGroupTieredPackageConfigTier() { }

    public MaxGroupTieredPackageConfigTier(
        MaxGroupTieredPackageConfigTier maxGroupTieredPackageConfigTier
    )
        : base(maxGroupTieredPackageConfigTier) { }

    public MaxGroupTieredPackageConfigTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaxGroupTieredPackageConfigTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaxGroupTieredPackageConfigTierFromRaw.FromRawUnchecked"/>
    public static MaxGroupTieredPackageConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaxGroupTieredPackageConfigTierFromRaw : IFromRawJson<MaxGroupTieredPackageConfigTier>
{
    /// <inheritdoc/>
    public MaxGroupTieredPackageConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MaxGroupTieredPackageConfigTier.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewFloatingMaxGroupTieredPackagePriceModelTypeConverter))]
public enum NewFloatingMaxGroupTieredPackagePriceModelType
{
    MaxGroupTieredPackage,
}

sealed class NewFloatingMaxGroupTieredPackagePriceModelTypeConverter
    : JsonConverter<NewFloatingMaxGroupTieredPackagePriceModelType>
{
    public override NewFloatingMaxGroupTieredPackagePriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "max_group_tiered_package" =>
                NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
            _ => (NewFloatingMaxGroupTieredPackagePriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingMaxGroupTieredPackagePriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage =>
                    "max_group_tiered_package",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewFloatingMaxGroupTieredPackagePriceConversionRateConfigConverter))]
public record class NewFloatingMaxGroupTieredPackagePriceConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewFloatingMaxGroupTieredPackagePriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewFloatingMaxGroupTieredPackagePriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewFloatingMaxGroupTieredPackagePriceConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of NewFloatingMaxGroupTieredPackagePriceConversionRateConfig"
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
                "Data did not match any variant of NewFloatingMaxGroupTieredPackagePriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewFloatingMaxGroupTieredPackagePriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewFloatingMaxGroupTieredPackagePriceConversionRateConfig(
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
                "Data did not match any variant of NewFloatingMaxGroupTieredPackagePriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(NewFloatingMaxGroupTieredPackagePriceConversionRateConfig? other)
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

sealed class NewFloatingMaxGroupTieredPackagePriceConversionRateConfigConverter
    : JsonConverter<NewFloatingMaxGroupTieredPackagePriceConversionRateConfig>
{
    public override NewFloatingMaxGroupTieredPackagePriceConversionRateConfig? Read(
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
                return new NewFloatingMaxGroupTieredPackagePriceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingMaxGroupTieredPackagePriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
