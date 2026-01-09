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
    typeof(JsonModelConverter<
        NewFloatingCumulativeGroupedBulkPrice,
        NewFloatingCumulativeGroupedBulkPriceFromRaw
    >)
)]
public sealed record class NewFloatingCumulativeGroupedBulkPrice : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewFloatingCumulativeGroupedBulkPriceCadence> Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, NewFloatingCumulativeGroupedBulkPriceCadence>
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_bulk pricing
    /// </summary>
    public required CumulativeGroupedBulkConfig CumulativeGroupedBulkConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<CumulativeGroupedBulkConfig>(
                this.RawData,
                "cumulative_grouped_bulk_config"
            );
        }
        init { JsonModel.Set(this._rawData, "cumulative_grouped_bulk_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewFloatingCumulativeGroupedBulkPriceModelType> ModelType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, NewFloatingCumulativeGroupedBulkPriceModelType>
            >(this.RawData, "model_type");
        }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewFloatingCumulativeGroupedBulkPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<NewFloatingCumulativeGroupedBulkPriceConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedBulkConfig.Validate();
        _ = this.Currency;
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

    public NewFloatingCumulativeGroupedBulkPrice() { }

    public NewFloatingCumulativeGroupedBulkPrice(
        NewFloatingCumulativeGroupedBulkPrice newFloatingCumulativeGroupedBulkPrice
    )
        : base(newFloatingCumulativeGroupedBulkPrice) { }

    public NewFloatingCumulativeGroupedBulkPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewFloatingCumulativeGroupedBulkPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewFloatingCumulativeGroupedBulkPriceFromRaw.FromRawUnchecked"/>
    public static NewFloatingCumulativeGroupedBulkPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewFloatingCumulativeGroupedBulkPriceFromRaw
    : IFromRawJson<NewFloatingCumulativeGroupedBulkPrice>
{
    /// <inheritdoc/>
    public NewFloatingCumulativeGroupedBulkPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewFloatingCumulativeGroupedBulkPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewFloatingCumulativeGroupedBulkPriceCadenceConverter))]
public enum NewFloatingCumulativeGroupedBulkPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewFloatingCumulativeGroupedBulkPriceCadenceConverter
    : JsonConverter<NewFloatingCumulativeGroupedBulkPriceCadence>
{
    public override NewFloatingCumulativeGroupedBulkPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewFloatingCumulativeGroupedBulkPriceCadence.Annual,
            "semi_annual" => NewFloatingCumulativeGroupedBulkPriceCadence.SemiAnnual,
            "monthly" => NewFloatingCumulativeGroupedBulkPriceCadence.Monthly,
            "quarterly" => NewFloatingCumulativeGroupedBulkPriceCadence.Quarterly,
            "one_time" => NewFloatingCumulativeGroupedBulkPriceCadence.OneTime,
            "custom" => NewFloatingCumulativeGroupedBulkPriceCadence.Custom,
            _ => (NewFloatingCumulativeGroupedBulkPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingCumulativeGroupedBulkPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingCumulativeGroupedBulkPriceCadence.Annual => "annual",
                NewFloatingCumulativeGroupedBulkPriceCadence.SemiAnnual => "semi_annual",
                NewFloatingCumulativeGroupedBulkPriceCadence.Monthly => "monthly",
                NewFloatingCumulativeGroupedBulkPriceCadence.Quarterly => "quarterly",
                NewFloatingCumulativeGroupedBulkPriceCadence.OneTime => "one_time",
                NewFloatingCumulativeGroupedBulkPriceCadence.Custom => "custom",
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
    typeof(JsonModelConverter<CumulativeGroupedBulkConfig, CumulativeGroupedBulkConfigFromRaw>)
)]
public sealed record class CumulativeGroupedBulkConfig : JsonModel
{
    /// <summary>
    /// Each tier lower bound must have the same group of values.
    /// </summary>
    public required IReadOnlyList<DimensionValue> DimensionValues
    {
        get
        {
            return JsonModel.GetNotNullClass<List<DimensionValue>>(
                this.RawData,
                "dimension_values"
            );
        }
        init { JsonModel.Set(this._rawData, "dimension_values", value); }
    }

    public required string Group
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "group"); }
        init { JsonModel.Set(this._rawData, "group", value); }
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

    public CumulativeGroupedBulkConfig(CumulativeGroupedBulkConfig cumulativeGroupedBulkConfig)
        : base(cumulativeGroupedBulkConfig) { }

    public CumulativeGroupedBulkConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedBulkConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CumulativeGroupedBulkConfigFromRaw.FromRawUnchecked"/>
    public static CumulativeGroupedBulkConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedBulkConfigFromRaw : IFromRawJson<CumulativeGroupedBulkConfig>
{
    /// <inheritdoc/>
    public CumulativeGroupedBulkConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CumulativeGroupedBulkConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a dimension value entry
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DimensionValue, DimensionValueFromRaw>))]
public sealed record class DimensionValue : JsonModel
{
    /// <summary>
    /// Grouping key value
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "tier_lower_bound"); }
        init { JsonModel.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <summary>
    /// Unit amount for this combination
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public DimensionValue() { }

    public DimensionValue(DimensionValue dimensionValue)
        : base(dimensionValue) { }

    public DimensionValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DimensionValueFromRaw.FromRawUnchecked"/>
    public static DimensionValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionValueFromRaw : IFromRawJson<DimensionValue>
{
    /// <inheritdoc/>
    public DimensionValue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DimensionValue.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewFloatingCumulativeGroupedBulkPriceModelTypeConverter))]
public enum NewFloatingCumulativeGroupedBulkPriceModelType
{
    CumulativeGroupedBulk,
}

sealed class NewFloatingCumulativeGroupedBulkPriceModelTypeConverter
    : JsonConverter<NewFloatingCumulativeGroupedBulkPriceModelType>
{
    public override NewFloatingCumulativeGroupedBulkPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cumulative_grouped_bulk" =>
                NewFloatingCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
            _ => (NewFloatingCumulativeGroupedBulkPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingCumulativeGroupedBulkPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk =>
                    "cumulative_grouped_bulk",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewFloatingCumulativeGroupedBulkPriceConversionRateConfigConverter))]
public record class NewFloatingCumulativeGroupedBulkPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewFloatingCumulativeGroupedBulkPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewFloatingCumulativeGroupedBulkPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewFloatingCumulativeGroupedBulkPriceConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of NewFloatingCumulativeGroupedBulkPriceConversionRateConfig"
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
                "Data did not match any variant of NewFloatingCumulativeGroupedBulkPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewFloatingCumulativeGroupedBulkPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewFloatingCumulativeGroupedBulkPriceConversionRateConfig(
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
                "Data did not match any variant of NewFloatingCumulativeGroupedBulkPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(NewFloatingCumulativeGroupedBulkPriceConversionRateConfig? other)
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

sealed class NewFloatingCumulativeGroupedBulkPriceConversionRateConfigConverter
    : JsonConverter<NewFloatingCumulativeGroupedBulkPriceConversionRateConfig>
{
    public override NewFloatingCumulativeGroupedBulkPriceConversionRateConfig? Read(
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
                return new NewFloatingCumulativeGroupedBulkPriceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingCumulativeGroupedBulkPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
