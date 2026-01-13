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
        NewFloatingGroupedWithProratedMinimumPrice,
        NewFloatingGroupedWithProratedMinimumPriceFromRaw
    >)
)]
public sealed record class NewFloatingGroupedWithProratedMinimumPrice : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewFloatingGroupedWithProratedMinimumPriceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewFloatingGroupedWithProratedMinimumPriceCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_prorated_minimum pricing
    /// </summary>
    public required GroupedWithProratedMinimumConfig GroupedWithProratedMinimumConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GroupedWithProratedMinimumConfig>(
                "grouped_with_prorated_minimum_config"
            );
        }
        init { this._rawData.Set("grouped_with_prorated_minimum_config", value); }
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
    public required ApiEnum<string, NewFloatingGroupedWithProratedMinimumPriceModelType> ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewFloatingGroupedWithProratedMinimumPriceModelType>
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
    public NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.GroupedWithProratedMinimumConfig.Validate();
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

    public NewFloatingGroupedWithProratedMinimumPrice() { }

    public NewFloatingGroupedWithProratedMinimumPrice(
        NewFloatingGroupedWithProratedMinimumPrice newFloatingGroupedWithProratedMinimumPrice
    )
        : base(newFloatingGroupedWithProratedMinimumPrice) { }

    public NewFloatingGroupedWithProratedMinimumPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewFloatingGroupedWithProratedMinimumPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewFloatingGroupedWithProratedMinimumPriceFromRaw.FromRawUnchecked"/>
    public static NewFloatingGroupedWithProratedMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewFloatingGroupedWithProratedMinimumPriceFromRaw
    : IFromRawJson<NewFloatingGroupedWithProratedMinimumPrice>
{
    /// <inheritdoc/>
    public NewFloatingGroupedWithProratedMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewFloatingGroupedWithProratedMinimumPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewFloatingGroupedWithProratedMinimumPriceCadenceConverter))]
public enum NewFloatingGroupedWithProratedMinimumPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewFloatingGroupedWithProratedMinimumPriceCadenceConverter
    : JsonConverter<NewFloatingGroupedWithProratedMinimumPriceCadence>
{
    public override NewFloatingGroupedWithProratedMinimumPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewFloatingGroupedWithProratedMinimumPriceCadence.Annual,
            "semi_annual" => NewFloatingGroupedWithProratedMinimumPriceCadence.SemiAnnual,
            "monthly" => NewFloatingGroupedWithProratedMinimumPriceCadence.Monthly,
            "quarterly" => NewFloatingGroupedWithProratedMinimumPriceCadence.Quarterly,
            "one_time" => NewFloatingGroupedWithProratedMinimumPriceCadence.OneTime,
            "custom" => NewFloatingGroupedWithProratedMinimumPriceCadence.Custom,
            _ => (NewFloatingGroupedWithProratedMinimumPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedWithProratedMinimumPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingGroupedWithProratedMinimumPriceCadence.Annual => "annual",
                NewFloatingGroupedWithProratedMinimumPriceCadence.SemiAnnual => "semi_annual",
                NewFloatingGroupedWithProratedMinimumPriceCadence.Monthly => "monthly",
                NewFloatingGroupedWithProratedMinimumPriceCadence.Quarterly => "quarterly",
                NewFloatingGroupedWithProratedMinimumPriceCadence.OneTime => "one_time",
                NewFloatingGroupedWithProratedMinimumPriceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_with_prorated_minimum pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        GroupedWithProratedMinimumConfig,
        GroupedWithProratedMinimumConfigFromRaw
    >)
)]
public sealed record class GroupedWithProratedMinimumConfig : JsonModel
{
    /// <summary>
    /// How to determine the groups that should each have a minimum
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The minimum amount to charge per group
    /// </summary>
    public required string Minimum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("minimum");
        }
        init { this._rawData.Set("minimum", value); }
    }

    /// <summary>
    /// The amount to charge per unit
    /// </summary>
    public required string UnitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_rate");
        }
        init { this._rawData.Set("unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.Minimum;
        _ = this.UnitRate;
    }

    public GroupedWithProratedMinimumConfig() { }

    public GroupedWithProratedMinimumConfig(
        GroupedWithProratedMinimumConfig groupedWithProratedMinimumConfig
    )
        : base(groupedWithProratedMinimumConfig) { }

    public GroupedWithProratedMinimumConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithProratedMinimumConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupedWithProratedMinimumConfigFromRaw.FromRawUnchecked"/>
    public static GroupedWithProratedMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithProratedMinimumConfigFromRaw : IFromRawJson<GroupedWithProratedMinimumConfig>
{
    /// <inheritdoc/>
    public GroupedWithProratedMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedWithProratedMinimumConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewFloatingGroupedWithProratedMinimumPriceModelTypeConverter))]
public enum NewFloatingGroupedWithProratedMinimumPriceModelType
{
    GroupedWithProratedMinimum,
}

sealed class NewFloatingGroupedWithProratedMinimumPriceModelTypeConverter
    : JsonConverter<NewFloatingGroupedWithProratedMinimumPriceModelType>
{
    public override NewFloatingGroupedWithProratedMinimumPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "grouped_with_prorated_minimum" =>
                NewFloatingGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
            _ => (NewFloatingGroupedWithProratedMinimumPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedWithProratedMinimumPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum =>
                    "grouped_with_prorated_minimum",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewFloatingGroupedWithProratedMinimumPriceConversionRateConfigConverter))]
public record class NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig : ModelBase
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

    public NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig"
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
                "Data did not match any variant of NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig(
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
                "Data did not match any variant of NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig? other
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

sealed class NewFloatingGroupedWithProratedMinimumPriceConversionRateConfigConverter
    : JsonConverter<NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig>
{
    public override NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig? Read(
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
                return new NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedWithProratedMinimumPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
