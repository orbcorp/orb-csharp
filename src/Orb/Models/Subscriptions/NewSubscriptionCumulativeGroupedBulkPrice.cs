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
        NewSubscriptionCumulativeGroupedBulkPrice,
        NewSubscriptionCumulativeGroupedBulkPriceFromRaw
    >)
)]
public sealed record class NewSubscriptionCumulativeGroupedBulkPrice : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewSubscriptionCumulativeGroupedBulkPriceCadence> Cadence
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewSubscriptionCumulativeGroupedBulkPriceCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_bulk pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig CumulativeGroupedBulkConfig
    {
        get
        {
            return this._rawData.GetNotNullClass<global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig>(
                "cumulative_grouped_bulk_config"
            );
        }
        init { this._rawData.Set("cumulative_grouped_bulk_config", value); }
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
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewSubscriptionCumulativeGroupedBulkPriceModelType> ModelType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewSubscriptionCumulativeGroupedBulkPriceModelType>
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
    public NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return this._rawData.GetNullableClass<NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig>(
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
        get { return this._rawData.GetNullableClass<string>("currency"); }
        init { this._rawData.Set("currency", value); }
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

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return this._rawData.GetNullableClass<string>("reference_id"); }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
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

    public NewSubscriptionCumulativeGroupedBulkPrice(
        NewSubscriptionCumulativeGroupedBulkPrice newSubscriptionCumulativeGroupedBulkPrice
    )
        : base(newSubscriptionCumulativeGroupedBulkPrice) { }

    public NewSubscriptionCumulativeGroupedBulkPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionCumulativeGroupedBulkPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewSubscriptionCumulativeGroupedBulkPriceFromRaw.FromRawUnchecked"/>
    public static NewSubscriptionCumulativeGroupedBulkPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionCumulativeGroupedBulkPriceFromRaw
    : IFromRawJson<NewSubscriptionCumulativeGroupedBulkPrice>
{
    /// <inheritdoc/>
    public NewSubscriptionCumulativeGroupedBulkPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewSubscriptionCumulativeGroupedBulkPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewSubscriptionCumulativeGroupedBulkPriceCadenceConverter))]
public enum NewSubscriptionCumulativeGroupedBulkPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewSubscriptionCumulativeGroupedBulkPriceCadenceConverter
    : JsonConverter<NewSubscriptionCumulativeGroupedBulkPriceCadence>
{
    public override NewSubscriptionCumulativeGroupedBulkPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewSubscriptionCumulativeGroupedBulkPriceCadence.Annual,
            "semi_annual" => NewSubscriptionCumulativeGroupedBulkPriceCadence.SemiAnnual,
            "monthly" => NewSubscriptionCumulativeGroupedBulkPriceCadence.Monthly,
            "quarterly" => NewSubscriptionCumulativeGroupedBulkPriceCadence.Quarterly,
            "one_time" => NewSubscriptionCumulativeGroupedBulkPriceCadence.OneTime,
            "custom" => NewSubscriptionCumulativeGroupedBulkPriceCadence.Custom,
            _ => (NewSubscriptionCumulativeGroupedBulkPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionCumulativeGroupedBulkPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionCumulativeGroupedBulkPriceCadence.Annual => "annual",
                NewSubscriptionCumulativeGroupedBulkPriceCadence.SemiAnnual => "semi_annual",
                NewSubscriptionCumulativeGroupedBulkPriceCadence.Monthly => "monthly",
                NewSubscriptionCumulativeGroupedBulkPriceCadence.Quarterly => "quarterly",
                NewSubscriptionCumulativeGroupedBulkPriceCadence.OneTime => "one_time",
                NewSubscriptionCumulativeGroupedBulkPriceCadence.Custom => "custom",
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
    typeof(JsonModelConverter<
        global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig,
        global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfigFromRaw
    >)
)]
public sealed record class CumulativeGroupedBulkConfig : JsonModel
{
    /// <summary>
    /// Each tier lower bound must have the same group of values.
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.DimensionValue> DimensionValues
    {
        get
        {
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::Orb.Models.Subscriptions.DimensionValue>
            >("dimension_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::Orb.Models.Subscriptions.DimensionValue>>(
                "dimension_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Group
    {
        get { return this._rawData.GetNotNullClass<string>("group"); }
        init { this._rawData.Set("group", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.DimensionValues)
        {
            item.Validate();
        }
        _ = this.Group;
    }

    public CumulativeGroupedBulkConfig() { }

    public CumulativeGroupedBulkConfig(
        global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig cumulativeGroupedBulkConfig
    )
        : base(cumulativeGroupedBulkConfig) { }

    public CumulativeGroupedBulkConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedBulkConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedBulkConfigFromRaw
    : IFromRawJson<global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a dimension value entry
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Subscriptions.DimensionValue,
        global::Orb.Models.Subscriptions.DimensionValueFromRaw
    >)
)]
public sealed record class DimensionValue : JsonModel
{
    /// <summary>
    /// Grouping key value
    /// </summary>
    public required string GroupingKey
    {
        get { return this._rawData.GetNotNullClass<string>("grouping_key"); }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get { return this._rawData.GetNotNullClass<string>("tier_lower_bound"); }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <summary>
    /// Unit amount for this combination
    /// </summary>
    public required string UnitAmount
    {
        get { return this._rawData.GetNotNullClass<string>("unit_amount"); }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public DimensionValue() { }

    public DimensionValue(global::Orb.Models.Subscriptions.DimensionValue dimensionValue)
        : base(dimensionValue) { }

    public DimensionValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.DimensionValueFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.DimensionValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionValueFromRaw : IFromRawJson<global::Orb.Models.Subscriptions.DimensionValue>
{
    /// <inheritdoc/>
    public global::Orb.Models.Subscriptions.DimensionValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.DimensionValue.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewSubscriptionCumulativeGroupedBulkPriceModelTypeConverter))]
public enum NewSubscriptionCumulativeGroupedBulkPriceModelType
{
    CumulativeGroupedBulk,
}

sealed class NewSubscriptionCumulativeGroupedBulkPriceModelTypeConverter
    : JsonConverter<NewSubscriptionCumulativeGroupedBulkPriceModelType>
{
    public override NewSubscriptionCumulativeGroupedBulkPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cumulative_grouped_bulk" =>
                NewSubscriptionCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
            _ => (NewSubscriptionCumulativeGroupedBulkPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionCumulativeGroupedBulkPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk =>
                    "cumulative_grouped_bulk",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfigConverter))]
public record class NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig"
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
                "Data did not match any variant of NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(
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
                "Data did not match any variant of NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig? other)
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

sealed class NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfigConverter
    : JsonConverter<NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig>
{
    public override NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig? Read(
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
                return new NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
