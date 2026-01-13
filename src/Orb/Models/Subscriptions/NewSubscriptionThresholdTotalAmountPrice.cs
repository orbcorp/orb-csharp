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
        NewSubscriptionThresholdTotalAmountPrice,
        NewSubscriptionThresholdTotalAmountPriceFromRaw
    >)
)]
public sealed record class NewSubscriptionThresholdTotalAmountPrice : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewSubscriptionThresholdTotalAmountPriceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewSubscriptionThresholdTotalAmountPriceCadence>
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
    public required ApiEnum<string, NewSubscriptionThresholdTotalAmountPriceModelType> ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewSubscriptionThresholdTotalAmountPriceModelType>
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
    /// Configuration for threshold_total_amount pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.ThresholdTotalAmountConfig ThresholdTotalAmountConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Subscriptions.ThresholdTotalAmountConfig>(
                "threshold_total_amount_config"
            );
        }
        init { this._rawData.Set("threshold_total_amount_config", value); }
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
    public NewSubscriptionThresholdTotalAmountPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewSubscriptionThresholdTotalAmountPriceConversionRateConfig>(
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
        this.ThresholdTotalAmountConfig.Validate();
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

    public NewSubscriptionThresholdTotalAmountPrice() { }

    public NewSubscriptionThresholdTotalAmountPrice(
        NewSubscriptionThresholdTotalAmountPrice newSubscriptionThresholdTotalAmountPrice
    )
        : base(newSubscriptionThresholdTotalAmountPrice) { }

    public NewSubscriptionThresholdTotalAmountPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionThresholdTotalAmountPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewSubscriptionThresholdTotalAmountPriceFromRaw.FromRawUnchecked"/>
    public static NewSubscriptionThresholdTotalAmountPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionThresholdTotalAmountPriceFromRaw
    : IFromRawJson<NewSubscriptionThresholdTotalAmountPrice>
{
    /// <inheritdoc/>
    public NewSubscriptionThresholdTotalAmountPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewSubscriptionThresholdTotalAmountPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewSubscriptionThresholdTotalAmountPriceCadenceConverter))]
public enum NewSubscriptionThresholdTotalAmountPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewSubscriptionThresholdTotalAmountPriceCadenceConverter
    : JsonConverter<NewSubscriptionThresholdTotalAmountPriceCadence>
{
    public override NewSubscriptionThresholdTotalAmountPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewSubscriptionThresholdTotalAmountPriceCadence.Annual,
            "semi_annual" => NewSubscriptionThresholdTotalAmountPriceCadence.SemiAnnual,
            "monthly" => NewSubscriptionThresholdTotalAmountPriceCadence.Monthly,
            "quarterly" => NewSubscriptionThresholdTotalAmountPriceCadence.Quarterly,
            "one_time" => NewSubscriptionThresholdTotalAmountPriceCadence.OneTime,
            "custom" => NewSubscriptionThresholdTotalAmountPriceCadence.Custom,
            _ => (NewSubscriptionThresholdTotalAmountPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionThresholdTotalAmountPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionThresholdTotalAmountPriceCadence.Annual => "annual",
                NewSubscriptionThresholdTotalAmountPriceCadence.SemiAnnual => "semi_annual",
                NewSubscriptionThresholdTotalAmountPriceCadence.Monthly => "monthly",
                NewSubscriptionThresholdTotalAmountPriceCadence.Quarterly => "quarterly",
                NewSubscriptionThresholdTotalAmountPriceCadence.OneTime => "one_time",
                NewSubscriptionThresholdTotalAmountPriceCadence.Custom => "custom",
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
[JsonConverter(typeof(NewSubscriptionThresholdTotalAmountPriceModelTypeConverter))]
public enum NewSubscriptionThresholdTotalAmountPriceModelType
{
    ThresholdTotalAmount,
}

sealed class NewSubscriptionThresholdTotalAmountPriceModelTypeConverter
    : JsonConverter<NewSubscriptionThresholdTotalAmountPriceModelType>
{
    public override NewSubscriptionThresholdTotalAmountPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "threshold_total_amount" =>
                NewSubscriptionThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
            _ => (NewSubscriptionThresholdTotalAmountPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionThresholdTotalAmountPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionThresholdTotalAmountPriceModelType.ThresholdTotalAmount =>
                    "threshold_total_amount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for threshold_total_amount pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Subscriptions.ThresholdTotalAmountConfig,
        global::Orb.Models.Subscriptions.ThresholdTotalAmountConfigFromRaw
    >)
)]
public sealed record class ThresholdTotalAmountConfig : JsonModel
{
    /// <summary>
    /// When the quantity consumed passes a provided threshold, the configured total
    /// will be charged
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.ConsumptionTable> ConsumptionTable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::Orb.Models.Subscriptions.ConsumptionTable>
            >("consumption_table");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::Orb.Models.Subscriptions.ConsumptionTable>>(
                "consumption_table",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("prorate");
        }
        init { this._rawData.Set("prorate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ConsumptionTable)
        {
            item.Validate();
        }
        _ = this.Prorate;
    }

    public ThresholdTotalAmountConfig() { }

    public ThresholdTotalAmountConfig(
        global::Orb.Models.Subscriptions.ThresholdTotalAmountConfig thresholdTotalAmountConfig
    )
        : base(thresholdTotalAmountConfig) { }

    public ThresholdTotalAmountConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdTotalAmountConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.ThresholdTotalAmountConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.ThresholdTotalAmountConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ThresholdTotalAmountConfig(
        List<global::Orb.Models.Subscriptions.ConsumptionTable> consumptionTable
    )
        : this()
    {
        this.ConsumptionTable = consumptionTable;
    }
}

class ThresholdTotalAmountConfigFromRaw
    : IFromRawJson<global::Orb.Models.Subscriptions.ThresholdTotalAmountConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Subscriptions.ThresholdTotalAmountConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.ThresholdTotalAmountConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single threshold
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Subscriptions.ConsumptionTable,
        global::Orb.Models.Subscriptions.ConsumptionTableFromRaw
    >)
)]
public sealed record class ConsumptionTable : JsonModel
{
    public required string Threshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("threshold");
        }
        init { this._rawData.Set("threshold", value); }
    }

    /// <summary>
    /// Total amount for this threshold
    /// </summary>
    public required string TotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("total_amount");
        }
        init { this._rawData.Set("total_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Threshold;
        _ = this.TotalAmount;
    }

    public ConsumptionTable() { }

    public ConsumptionTable(global::Orb.Models.Subscriptions.ConsumptionTable consumptionTable)
        : base(consumptionTable) { }

    public ConsumptionTable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumptionTable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.ConsumptionTableFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.ConsumptionTable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConsumptionTableFromRaw : IFromRawJson<global::Orb.Models.Subscriptions.ConsumptionTable>
{
    /// <inheritdoc/>
    public global::Orb.Models.Subscriptions.ConsumptionTable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.ConsumptionTable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewSubscriptionThresholdTotalAmountPriceConversionRateConfigConverter))]
public record class NewSubscriptionThresholdTotalAmountPriceConversionRateConfig : ModelBase
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

    public NewSubscriptionThresholdTotalAmountPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewSubscriptionThresholdTotalAmountPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewSubscriptionThresholdTotalAmountPriceConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of NewSubscriptionThresholdTotalAmountPriceConversionRateConfig"
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
                "Data did not match any variant of NewSubscriptionThresholdTotalAmountPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewSubscriptionThresholdTotalAmountPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewSubscriptionThresholdTotalAmountPriceConversionRateConfig(
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
                "Data did not match any variant of NewSubscriptionThresholdTotalAmountPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(NewSubscriptionThresholdTotalAmountPriceConversionRateConfig? other)
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

sealed class NewSubscriptionThresholdTotalAmountPriceConversionRateConfigConverter
    : JsonConverter<NewSubscriptionThresholdTotalAmountPriceConversionRateConfig>
{
    public override NewSubscriptionThresholdTotalAmountPriceConversionRateConfig? Read(
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
                return new NewSubscriptionThresholdTotalAmountPriceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionThresholdTotalAmountPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
