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
        NewSubscriptionTieredPackageWithMinimumPrice,
        NewSubscriptionTieredPackageWithMinimumPriceFromRaw
    >)
)]
public sealed record class NewSubscriptionTieredPackageWithMinimumPrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewSubscriptionTieredPackageWithMinimumPriceCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewSubscriptionTieredPackageWithMinimumPriceCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
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
    public required ApiEnum<string, NewSubscriptionTieredPackageWithMinimumPriceModelType> ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewSubscriptionTieredPackageWithMinimumPriceModelType>
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
    /// Configuration for tiered_package_with_minimum pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfig TieredPackageWithMinimumConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfig>(
                this.RawData,
                "tiered_package_with_minimum_config"
            );
        }
        init { ModelBase.Set(this._rawData, "tiered_package_with_minimum_config", value); }
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
    public NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
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

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.TieredPackageWithMinimumConfig.Validate();
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

    public NewSubscriptionTieredPackageWithMinimumPrice() { }

    public NewSubscriptionTieredPackageWithMinimumPrice(
        NewSubscriptionTieredPackageWithMinimumPrice newSubscriptionTieredPackageWithMinimumPrice
    )
        : base(newSubscriptionTieredPackageWithMinimumPrice) { }

    public NewSubscriptionTieredPackageWithMinimumPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionTieredPackageWithMinimumPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewSubscriptionTieredPackageWithMinimumPriceFromRaw.FromRawUnchecked"/>
    public static NewSubscriptionTieredPackageWithMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionTieredPackageWithMinimumPriceFromRaw
    : IFromRaw<NewSubscriptionTieredPackageWithMinimumPrice>
{
    /// <inheritdoc/>
    public NewSubscriptionTieredPackageWithMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewSubscriptionTieredPackageWithMinimumPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewSubscriptionTieredPackageWithMinimumPriceCadenceConverter))]
public enum NewSubscriptionTieredPackageWithMinimumPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewSubscriptionTieredPackageWithMinimumPriceCadenceConverter
    : JsonConverter<NewSubscriptionTieredPackageWithMinimumPriceCadence>
{
    public override NewSubscriptionTieredPackageWithMinimumPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewSubscriptionTieredPackageWithMinimumPriceCadence.Annual,
            "semi_annual" => NewSubscriptionTieredPackageWithMinimumPriceCadence.SemiAnnual,
            "monthly" => NewSubscriptionTieredPackageWithMinimumPriceCadence.Monthly,
            "quarterly" => NewSubscriptionTieredPackageWithMinimumPriceCadence.Quarterly,
            "one_time" => NewSubscriptionTieredPackageWithMinimumPriceCadence.OneTime,
            "custom" => NewSubscriptionTieredPackageWithMinimumPriceCadence.Custom,
            _ => (NewSubscriptionTieredPackageWithMinimumPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionTieredPackageWithMinimumPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionTieredPackageWithMinimumPriceCadence.Annual => "annual",
                NewSubscriptionTieredPackageWithMinimumPriceCadence.SemiAnnual => "semi_annual",
                NewSubscriptionTieredPackageWithMinimumPriceCadence.Monthly => "monthly",
                NewSubscriptionTieredPackageWithMinimumPriceCadence.Quarterly => "quarterly",
                NewSubscriptionTieredPackageWithMinimumPriceCadence.OneTime => "one_time",
                NewSubscriptionTieredPackageWithMinimumPriceCadence.Custom => "custom",
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
[JsonConverter(typeof(NewSubscriptionTieredPackageWithMinimumPriceModelTypeConverter))]
public enum NewSubscriptionTieredPackageWithMinimumPriceModelType
{
    TieredPackageWithMinimum,
}

sealed class NewSubscriptionTieredPackageWithMinimumPriceModelTypeConverter
    : JsonConverter<NewSubscriptionTieredPackageWithMinimumPriceModelType>
{
    public override NewSubscriptionTieredPackageWithMinimumPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tiered_package_with_minimum" =>
                NewSubscriptionTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
            _ => (NewSubscriptionTieredPackageWithMinimumPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionTieredPackageWithMinimumPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum =>
                    "tiered_package_with_minimum",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for tiered_package_with_minimum pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfig,
        global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigFromRaw
    >)
)]
public sealed record class TieredPackageWithMinimumConfig : ModelBase
{
    /// <summary>
    /// Package size
    /// </summary>
    public required double PackageSize
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "package_size"); }
        init { ModelBase.Set(this._rawData, "package_size", value); }
    }

    /// <summary>
    /// Apply tiered pricing after rounding up the quantity to the package size.
    /// Tiers are defined using exclusive lower bounds.
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTier> Tiers
    {
        get
        {
            return ModelBase.GetNotNullClass<
                List<global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTier>
            >(this.RawData, "tiers");
        }
        init { ModelBase.Set(this._rawData, "tiers", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PackageSize;
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public TieredPackageWithMinimumConfig() { }

    public TieredPackageWithMinimumConfig(
        global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfig tieredPackageWithMinimumConfig
    )
        : base(tieredPackageWithMinimumConfig) { }

    public TieredPackageWithMinimumConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredPackageWithMinimumConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredPackageWithMinimumConfigFromRaw
    : IFromRaw<global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTier,
        global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTierFromRaw
    >)
)]
public sealed record class TieredPackageWithMinimumConfigTier : ModelBase
{
    /// <summary>
    /// Minimum amount
    /// </summary>
    public required string MinimumAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "minimum_amount"); }
        init { ModelBase.Set(this._rawData, "minimum_amount", value); }
    }

    /// <summary>
    /// Price per package
    /// </summary>
    public required string PerUnit
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "per_unit"); }
        init { ModelBase.Set(this._rawData, "per_unit", value); }
    }

    /// <summary>
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tier_lower_bound"); }
        init { ModelBase.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MinimumAmount;
        _ = this.PerUnit;
        _ = this.TierLowerBound;
    }

    public TieredPackageWithMinimumConfigTier() { }

    public TieredPackageWithMinimumConfigTier(
        global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTier tieredPackageWithMinimumConfigTier
    )
        : base(tieredPackageWithMinimumConfigTier) { }

    public TieredPackageWithMinimumConfigTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredPackageWithMinimumConfigTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTierFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredPackageWithMinimumConfigTierFromRaw
    : IFromRaw<global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTier>
{
    /// <inheritdoc/>
    public global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Subscriptions.TieredPackageWithMinimumConfigTier.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfigConverter))]
public record class NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig"
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
                "Data did not match any variant of NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig(
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
                "Data did not match any variant of NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfigConverter
    : JsonConverter<NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig>
{
    public override NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig? Read(
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
                return new NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionTieredPackageWithMinimumPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
