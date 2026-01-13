using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<
        NewSubscriptionTieredWithMinimumPrice,
        NewSubscriptionTieredWithMinimumPriceFromRaw
    >)
)]
public sealed record class NewSubscriptionTieredWithMinimumPrice : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewSubscriptionTieredWithMinimumPriceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewSubscriptionTieredWithMinimumPriceCadence>
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
    public required ApiEnum<string, NewSubscriptionTieredWithMinimumPriceModelType> ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewSubscriptionTieredWithMinimumPriceModelType>
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
    /// Configuration for tiered_with_minimum pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.TieredWithMinimumConfig TieredWithMinimumConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Subscriptions.TieredWithMinimumConfig>(
                "tiered_with_minimum_config"
            );
        }
        init { this._rawData.Set("tiered_with_minimum_config", value); }
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
    public NewSubscriptionTieredWithMinimumPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewSubscriptionTieredWithMinimumPriceConversionRateConfig>(
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
        this.TieredWithMinimumConfig.Validate();
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

    public NewSubscriptionTieredWithMinimumPrice() { }

    public NewSubscriptionTieredWithMinimumPrice(
        NewSubscriptionTieredWithMinimumPrice newSubscriptionTieredWithMinimumPrice
    )
        : base(newSubscriptionTieredWithMinimumPrice) { }

    public NewSubscriptionTieredWithMinimumPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionTieredWithMinimumPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewSubscriptionTieredWithMinimumPriceFromRaw.FromRawUnchecked"/>
    public static NewSubscriptionTieredWithMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionTieredWithMinimumPriceFromRaw
    : IFromRawJson<NewSubscriptionTieredWithMinimumPrice>
{
    /// <inheritdoc/>
    public NewSubscriptionTieredWithMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewSubscriptionTieredWithMinimumPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewSubscriptionTieredWithMinimumPriceCadenceConverter))]
public enum NewSubscriptionTieredWithMinimumPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewSubscriptionTieredWithMinimumPriceCadenceConverter
    : JsonConverter<NewSubscriptionTieredWithMinimumPriceCadence>
{
    public override NewSubscriptionTieredWithMinimumPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewSubscriptionTieredWithMinimumPriceCadence.Annual,
            "semi_annual" => NewSubscriptionTieredWithMinimumPriceCadence.SemiAnnual,
            "monthly" => NewSubscriptionTieredWithMinimumPriceCadence.Monthly,
            "quarterly" => NewSubscriptionTieredWithMinimumPriceCadence.Quarterly,
            "one_time" => NewSubscriptionTieredWithMinimumPriceCadence.OneTime,
            "custom" => NewSubscriptionTieredWithMinimumPriceCadence.Custom,
            _ => (NewSubscriptionTieredWithMinimumPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionTieredWithMinimumPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionTieredWithMinimumPriceCadence.Annual => "annual",
                NewSubscriptionTieredWithMinimumPriceCadence.SemiAnnual => "semi_annual",
                NewSubscriptionTieredWithMinimumPriceCadence.Monthly => "monthly",
                NewSubscriptionTieredWithMinimumPriceCadence.Quarterly => "quarterly",
                NewSubscriptionTieredWithMinimumPriceCadence.OneTime => "one_time",
                NewSubscriptionTieredWithMinimumPriceCadence.Custom => "custom",
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
[JsonConverter(typeof(NewSubscriptionTieredWithMinimumPriceModelTypeConverter))]
public enum NewSubscriptionTieredWithMinimumPriceModelType
{
    TieredWithMinimum,
}

sealed class NewSubscriptionTieredWithMinimumPriceModelTypeConverter
    : JsonConverter<NewSubscriptionTieredWithMinimumPriceModelType>
{
    public override NewSubscriptionTieredWithMinimumPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tiered_with_minimum" =>
                NewSubscriptionTieredWithMinimumPriceModelType.TieredWithMinimum,
            _ => (NewSubscriptionTieredWithMinimumPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionTieredWithMinimumPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionTieredWithMinimumPriceModelType.TieredWithMinimum =>
                    "tiered_with_minimum",
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
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Subscriptions.TieredWithMinimumConfig,
        global::Orb.Models.Subscriptions.TieredWithMinimumConfigFromRaw
    >)
)]
public sealed record class TieredWithMinimumConfig : JsonModel
{
    /// <summary>
    /// Tiered pricing with a minimum amount dependent on the volume tier. Tiers
    /// are defined using exclusive lower bounds.
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier>
            >("tiers", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// If true, tiers with an accrued amount of 0 will not be included in the rating.
    /// </summary>
    public bool? HideZeroAmountTiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hide_zero_amount_tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hide_zero_amount_tiers", value);
        }
    }

    /// <summary>
    /// If true, the unit price will be prorated to the billing period
    /// </summary>
    public bool? Prorate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("prorate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prorate", value);
        }
    }

    /// <inheritdoc/>
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

    public TieredWithMinimumConfig(
        global::Orb.Models.Subscriptions.TieredWithMinimumConfig tieredWithMinimumConfig
    )
        : base(tieredWithMinimumConfig) { }

    public TieredWithMinimumConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithMinimumConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.TieredWithMinimumConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.TieredWithMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TieredWithMinimumConfig(
        IReadOnlyList<global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class TieredWithMinimumConfigFromRaw
    : IFromRawJson<global::Orb.Models.Subscriptions.TieredWithMinimumConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Subscriptions.TieredWithMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.TieredWithMinimumConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier,
        global::Orb.Models.Subscriptions.TieredWithMinimumConfigTierFromRaw
    >)
)]
public sealed record class TieredWithMinimumConfigTier : JsonModel
{
    public required string MinimumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    public required string TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
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
        _ = this.MinimumAmount;
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public TieredWithMinimumConfigTier() { }

    public TieredWithMinimumConfigTier(
        global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier tieredWithMinimumConfigTier
    )
        : base(tieredWithMinimumConfigTier) { }

    public TieredWithMinimumConfigTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithMinimumConfigTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.TieredWithMinimumConfigTierFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredWithMinimumConfigTierFromRaw
    : IFromRawJson<global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier>
{
    /// <inheritdoc/>
    public global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.TieredWithMinimumConfigTier.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewSubscriptionTieredWithMinimumPriceConversionRateConfigConverter))]
public record class NewSubscriptionTieredWithMinimumPriceConversionRateConfig : ModelBase
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

    public NewSubscriptionTieredWithMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewSubscriptionTieredWithMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewSubscriptionTieredWithMinimumPriceConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of NewSubscriptionTieredWithMinimumPriceConversionRateConfig"
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
                "Data did not match any variant of NewSubscriptionTieredWithMinimumPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewSubscriptionTieredWithMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewSubscriptionTieredWithMinimumPriceConversionRateConfig(
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
                "Data did not match any variant of NewSubscriptionTieredWithMinimumPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(NewSubscriptionTieredWithMinimumPriceConversionRateConfig? other)
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

sealed class NewSubscriptionTieredWithMinimumPriceConversionRateConfigConverter
    : JsonConverter<NewSubscriptionTieredWithMinimumPriceConversionRateConfig>
{
    public override NewSubscriptionTieredWithMinimumPriceConversionRateConfig? Read(
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
                return new NewSubscriptionTieredWithMinimumPriceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionTieredWithMinimumPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
