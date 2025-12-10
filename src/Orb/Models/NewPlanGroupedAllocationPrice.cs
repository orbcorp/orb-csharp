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
    typeof(ModelConverter<NewPlanGroupedAllocationPrice, NewPlanGroupedAllocationPriceFromRaw>)
)]
public sealed record class NewPlanGroupedAllocationPrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewPlanGroupedAllocationPriceCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, NewPlanGroupedAllocationPriceCadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_allocation pricing
    /// </summary>
    public required NewPlanGroupedAllocationPriceGroupedAllocationConfig GroupedAllocationConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<NewPlanGroupedAllocationPriceGroupedAllocationConfig>(
                this.RawData,
                "grouped_allocation_config"
            );
        }
        init { ModelBase.Set(this._rawData, "grouped_allocation_config", value); }
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
    public required ApiEnum<string, NewPlanGroupedAllocationPriceModelType> ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewPlanGroupedAllocationPriceModelType>
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
    public NewPlanGroupedAllocationPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<NewPlanGroupedAllocationPriceConversionRateConfig>(
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
        this.GroupedAllocationConfig.Validate();
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

    public NewPlanGroupedAllocationPrice() { }

    public NewPlanGroupedAllocationPrice(
        NewPlanGroupedAllocationPrice newPlanGroupedAllocationPrice
    )
        : base(newPlanGroupedAllocationPrice) { }

    public NewPlanGroupedAllocationPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanGroupedAllocationPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanGroupedAllocationPriceFromRaw.FromRawUnchecked"/>
    public static NewPlanGroupedAllocationPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanGroupedAllocationPriceFromRaw : IFromRaw<NewPlanGroupedAllocationPrice>
{
    /// <inheritdoc/>
    public NewPlanGroupedAllocationPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPlanGroupedAllocationPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewPlanGroupedAllocationPriceCadenceConverter))]
public enum NewPlanGroupedAllocationPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewPlanGroupedAllocationPriceCadenceConverter
    : JsonConverter<NewPlanGroupedAllocationPriceCadence>
{
    public override NewPlanGroupedAllocationPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewPlanGroupedAllocationPriceCadence.Annual,
            "semi_annual" => NewPlanGroupedAllocationPriceCadence.SemiAnnual,
            "monthly" => NewPlanGroupedAllocationPriceCadence.Monthly,
            "quarterly" => NewPlanGroupedAllocationPriceCadence.Quarterly,
            "one_time" => NewPlanGroupedAllocationPriceCadence.OneTime,
            "custom" => NewPlanGroupedAllocationPriceCadence.Custom,
            _ => (NewPlanGroupedAllocationPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedAllocationPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanGroupedAllocationPriceCadence.Annual => "annual",
                NewPlanGroupedAllocationPriceCadence.SemiAnnual => "semi_annual",
                NewPlanGroupedAllocationPriceCadence.Monthly => "monthly",
                NewPlanGroupedAllocationPriceCadence.Quarterly => "quarterly",
                NewPlanGroupedAllocationPriceCadence.OneTime => "one_time",
                NewPlanGroupedAllocationPriceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_allocation pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        NewPlanGroupedAllocationPriceGroupedAllocationConfig,
        NewPlanGroupedAllocationPriceGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class NewPlanGroupedAllocationPriceGroupedAllocationConfig : ModelBase
{
    /// <summary>
    /// Usage allocation per group
    /// </summary>
    public required string Allocation
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "allocation"); }
        init { ModelBase.Set(this._rawData, "allocation", value); }
    }

    /// <summary>
    /// How to determine the groups that should each be allocated some quantity
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// Unit rate for post-allocation
    /// </summary>
    public required string OverageUnitRate
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "overage_unit_rate"); }
        init { ModelBase.Set(this._rawData, "overage_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Allocation;
        _ = this.GroupingKey;
        _ = this.OverageUnitRate;
    }

    public NewPlanGroupedAllocationPriceGroupedAllocationConfig() { }

    public NewPlanGroupedAllocationPriceGroupedAllocationConfig(
        NewPlanGroupedAllocationPriceGroupedAllocationConfig newPlanGroupedAllocationPriceGroupedAllocationConfig
    )
        : base(newPlanGroupedAllocationPriceGroupedAllocationConfig) { }

    public NewPlanGroupedAllocationPriceGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanGroupedAllocationPriceGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanGroupedAllocationPriceGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static NewPlanGroupedAllocationPriceGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanGroupedAllocationPriceGroupedAllocationConfigFromRaw
    : IFromRaw<NewPlanGroupedAllocationPriceGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public NewPlanGroupedAllocationPriceGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPlanGroupedAllocationPriceGroupedAllocationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewPlanGroupedAllocationPriceModelTypeConverter))]
public enum NewPlanGroupedAllocationPriceModelType
{
    GroupedAllocation,
}

sealed class NewPlanGroupedAllocationPriceModelTypeConverter
    : JsonConverter<NewPlanGroupedAllocationPriceModelType>
{
    public override NewPlanGroupedAllocationPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "grouped_allocation" => NewPlanGroupedAllocationPriceModelType.GroupedAllocation,
            _ => (NewPlanGroupedAllocationPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedAllocationPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanGroupedAllocationPriceModelType.GroupedAllocation => "grouped_allocation",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewPlanGroupedAllocationPriceConversionRateConfigConverter))]
public record class NewPlanGroupedAllocationPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewPlanGroupedAllocationPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewPlanGroupedAllocationPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewPlanGroupedAllocationPriceConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of NewPlanGroupedAllocationPriceConversionRateConfig"
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
                "Data did not match any variant of NewPlanGroupedAllocationPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewPlanGroupedAllocationPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewPlanGroupedAllocationPriceConversionRateConfig(
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
                "Data did not match any variant of NewPlanGroupedAllocationPriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(NewPlanGroupedAllocationPriceConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class NewPlanGroupedAllocationPriceConversionRateConfigConverter
    : JsonConverter<NewPlanGroupedAllocationPriceConversionRateConfig>
{
    public override NewPlanGroupedAllocationPriceConversionRateConfig? Read(
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
                return new NewPlanGroupedAllocationPriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedAllocationPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
