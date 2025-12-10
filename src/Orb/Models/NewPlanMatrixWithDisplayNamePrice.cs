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
        NewPlanMatrixWithDisplayNamePrice,
        NewPlanMatrixWithDisplayNamePriceFromRaw
    >)
)]
public sealed record class NewPlanMatrixWithDisplayNamePrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewPlanMatrixWithDisplayNamePriceCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewPlanMatrixWithDisplayNamePriceCadence>
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
    /// Configuration for matrix_with_display_name pricing
    /// </summary>
    public required NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig MatrixWithDisplayNameConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig>(
                this.RawData,
                "matrix_with_display_name_config"
            );
        }
        init { ModelBase.Set(this._rawData, "matrix_with_display_name_config", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewPlanMatrixWithDisplayNamePriceModelType> ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewPlanMatrixWithDisplayNamePriceModelType>
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
    public NewPlanMatrixWithDisplayNamePriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<NewPlanMatrixWithDisplayNamePriceConversionRateConfig>(
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
        this.MatrixWithDisplayNameConfig.Validate();
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

    public NewPlanMatrixWithDisplayNamePrice() { }

    public NewPlanMatrixWithDisplayNamePrice(
        NewPlanMatrixWithDisplayNamePrice newPlanMatrixWithDisplayNamePrice
    )
        : base(newPlanMatrixWithDisplayNamePrice) { }

    public NewPlanMatrixWithDisplayNamePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanMatrixWithDisplayNamePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanMatrixWithDisplayNamePriceFromRaw.FromRawUnchecked"/>
    public static NewPlanMatrixWithDisplayNamePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanMatrixWithDisplayNamePriceFromRaw : IFromRaw<NewPlanMatrixWithDisplayNamePrice>
{
    /// <inheritdoc/>
    public NewPlanMatrixWithDisplayNamePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPlanMatrixWithDisplayNamePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewPlanMatrixWithDisplayNamePriceCadenceConverter))]
public enum NewPlanMatrixWithDisplayNamePriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewPlanMatrixWithDisplayNamePriceCadenceConverter
    : JsonConverter<NewPlanMatrixWithDisplayNamePriceCadence>
{
    public override NewPlanMatrixWithDisplayNamePriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewPlanMatrixWithDisplayNamePriceCadence.Annual,
            "semi_annual" => NewPlanMatrixWithDisplayNamePriceCadence.SemiAnnual,
            "monthly" => NewPlanMatrixWithDisplayNamePriceCadence.Monthly,
            "quarterly" => NewPlanMatrixWithDisplayNamePriceCadence.Quarterly,
            "one_time" => NewPlanMatrixWithDisplayNamePriceCadence.OneTime,
            "custom" => NewPlanMatrixWithDisplayNamePriceCadence.Custom,
            _ => (NewPlanMatrixWithDisplayNamePriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanMatrixWithDisplayNamePriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanMatrixWithDisplayNamePriceCadence.Annual => "annual",
                NewPlanMatrixWithDisplayNamePriceCadence.SemiAnnual => "semi_annual",
                NewPlanMatrixWithDisplayNamePriceCadence.Monthly => "monthly",
                NewPlanMatrixWithDisplayNamePriceCadence.Quarterly => "quarterly",
                NewPlanMatrixWithDisplayNamePriceCadence.OneTime => "one_time",
                NewPlanMatrixWithDisplayNamePriceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for matrix_with_display_name pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig,
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigFromRaw
    >)
)]
public sealed record class NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig : ModelBase
{
    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string Dimension
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "dimension"); }
        init { ModelBase.Set(this._rawData, "dimension", value); }
    }

    /// <summary>
    /// Apply per unit pricing to each dimension value
    /// </summary>
    public required IReadOnlyList<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount> UnitAmounts
    {
        get
        {
            return ModelBase.GetNotNullClass<
                List<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount>
            >(this.RawData, "unit_amounts");
        }
        init { ModelBase.Set(this._rawData, "unit_amounts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Dimension;
        foreach (var item in this.UnitAmounts)
        {
            item.Validate();
        }
    }

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig() { }

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig(
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig newPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig
    )
        : base(newPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig) { }

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigFromRaw.FromRawUnchecked"/>
    public static NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigFromRaw
    : IFromRaw<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig>
{
    /// <inheritdoc/>
    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a unit amount item
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount,
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmountFromRaw
    >)
)]
public sealed record class NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount
    : ModelBase
{
    /// <summary>
    /// The dimension value
    /// </summary>
    public required string DimensionValue
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "dimension_value"); }
        init { ModelBase.Set(this._rawData, "dimension_value", value); }
    }

    /// <summary>
    /// Display name for this dimension value
    /// </summary>
    public required string DisplayName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "display_name"); }
        init { ModelBase.Set(this._rawData, "display_name", value); }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValue;
        _ = this.DisplayName;
        _ = this.UnitAmount;
    }

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount() { }

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount(
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount newPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount
    )
        : base(newPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount) { }

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmountFromRaw.FromRawUnchecked"/>
    public static NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmountFromRaw
    : IFromRaw<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount>
{
    /// <inheritdoc/>
    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewPlanMatrixWithDisplayNamePriceModelTypeConverter))]
public enum NewPlanMatrixWithDisplayNamePriceModelType
{
    MatrixWithDisplayName,
}

sealed class NewPlanMatrixWithDisplayNamePriceModelTypeConverter
    : JsonConverter<NewPlanMatrixWithDisplayNamePriceModelType>
{
    public override NewPlanMatrixWithDisplayNamePriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "matrix_with_display_name" =>
                NewPlanMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
            _ => (NewPlanMatrixWithDisplayNamePriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanMatrixWithDisplayNamePriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName =>
                    "matrix_with_display_name",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewPlanMatrixWithDisplayNamePriceConversionRateConfigConverter))]
public record class NewPlanMatrixWithDisplayNamePriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewPlanMatrixWithDisplayNamePriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewPlanMatrixWithDisplayNamePriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewPlanMatrixWithDisplayNamePriceConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of NewPlanMatrixWithDisplayNamePriceConversionRateConfig"
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
                "Data did not match any variant of NewPlanMatrixWithDisplayNamePriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewPlanMatrixWithDisplayNamePriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewPlanMatrixWithDisplayNamePriceConversionRateConfig(
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
                "Data did not match any variant of NewPlanMatrixWithDisplayNamePriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(NewPlanMatrixWithDisplayNamePriceConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class NewPlanMatrixWithDisplayNamePriceConversionRateConfigConverter
    : JsonConverter<NewPlanMatrixWithDisplayNamePriceConversionRateConfig>
{
    public override NewPlanMatrixWithDisplayNamePriceConversionRateConfig? Read(
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
                return new NewPlanMatrixWithDisplayNamePriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanMatrixWithDisplayNamePriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
