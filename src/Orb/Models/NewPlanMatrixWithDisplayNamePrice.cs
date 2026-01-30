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
        NewPlanMatrixWithDisplayNamePrice,
        NewPlanMatrixWithDisplayNamePriceFromRaw
    >)
)]
public sealed record class NewPlanMatrixWithDisplayNamePrice : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewPlanMatrixWithDisplayNamePriceCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewPlanMatrixWithDisplayNamePriceCadence>
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
    /// Configuration for matrix_with_display_name pricing
    /// </summary>
    public required NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig MatrixWithDisplayNameConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig>(
                "matrix_with_display_name_config"
            );
        }
        init { this._rawData.Set("matrix_with_display_name_config", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewPlanMatrixWithDisplayNamePriceModelType> ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewPlanMatrixWithDisplayNamePriceModelType>
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
    public NewPlanMatrixWithDisplayNamePriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewPlanMatrixWithDisplayNamePriceConversionRateConfig>(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewPlanMatrixWithDisplayNamePrice(
        NewPlanMatrixWithDisplayNamePrice newPlanMatrixWithDisplayNamePrice
    )
        : base(newPlanMatrixWithDisplayNamePrice) { }
#pragma warning restore CS8618

    public NewPlanMatrixWithDisplayNamePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanMatrixWithDisplayNamePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class NewPlanMatrixWithDisplayNamePriceFromRaw : IFromRawJson<NewPlanMatrixWithDisplayNamePrice>
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
    typeof(JsonModelConverter<
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig,
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigFromRaw
    >)
)]
public sealed record class NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig : JsonModel
{
    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string Dimension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dimension");
        }
        init { this._rawData.Set("dimension", value); }
    }

    /// <summary>
    /// Apply per unit pricing to each dimension value
    /// </summary>
    public required IReadOnlyList<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount> UnitAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount>
            >("unit_amounts");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount>
            >("unit_amounts", ImmutableArray.ToImmutableArray(value));
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig(
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig newPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig
    )
        : base(newPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig) { }
#pragma warning restore CS8618

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
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
    : IFromRawJson<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig>
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
    typeof(JsonModelConverter<
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount,
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmountFromRaw
    >)
)]
public sealed record class NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount
    : JsonModel
{
    /// <summary>
    /// The dimension value
    /// </summary>
    public required string DimensionValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dimension_value");
        }
        init { this._rawData.Set("dimension_value", value); }
    }

    /// <summary>
    /// Display name for this dimension value
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
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
        _ = this.DimensionValue;
        _ = this.DisplayName;
        _ = this.UnitAmount;
    }

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount(
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount newPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount
    )
        : base(newPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount) { }
#pragma warning restore CS8618

    public NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
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
    : IFromRawJson<NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigUnitAmount>
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
public record class NewPlanMatrixWithDisplayNamePriceConversionRateConfig : ModelBase
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

    public NewPlanMatrixWithDisplayNamePriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewPlanMatrixWithDisplayNamePriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public NewPlanMatrixWithDisplayNamePriceConversionRateConfig(JsonElement element)
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewPlanMatrixWithDisplayNamePriceConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(NewPlanMatrixWithDisplayNamePriceConversionRateConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig _ => 0,
            SharedTieredConversionRateConfig _ => 1,
            _ => -1,
        };
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
                return new NewPlanMatrixWithDisplayNamePriceConversionRateConfig(element);
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
