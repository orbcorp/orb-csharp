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
        NewSubscriptionMatrixWithDisplayNamePrice,
        NewSubscriptionMatrixWithDisplayNamePriceFromRaw
    >)
)]
public sealed record class NewSubscriptionMatrixWithDisplayNamePrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewSubscriptionMatrixWithDisplayNamePriceCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                    ApiEnum<string, NewSubscriptionMatrixWithDisplayNamePriceCadence>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentNullException("cadence")
                );
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for matrix_with_display_name pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.MatrixWithDisplayNameConfig MatrixWithDisplayNameConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "matrix_with_display_name_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'matrix_with_display_name_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "matrix_with_display_name_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.MatrixWithDisplayNameConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'matrix_with_display_name_config' cannot be null",
                    new System::ArgumentNullException("matrix_with_display_name_config")
                );
        }
        init
        {
            this._rawData["matrix_with_display_name_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewSubscriptionMatrixWithDisplayNamePriceModelType> ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                    ApiEnum<string, NewSubscriptionMatrixWithDisplayNamePriceModelType>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._rawData.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._rawData.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (!this._rawData.TryGetValue("billing_cycle_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._rawData.TryGetValue("invoicing_cycle_configuration", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public NewSubscriptionMatrixWithDisplayNamePrice() { }

    public NewSubscriptionMatrixWithDisplayNamePrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionMatrixWithDisplayNamePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewSubscriptionMatrixWithDisplayNamePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionMatrixWithDisplayNamePriceFromRaw
    : IFromRaw<NewSubscriptionMatrixWithDisplayNamePrice>
{
    public NewSubscriptionMatrixWithDisplayNamePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewSubscriptionMatrixWithDisplayNamePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewSubscriptionMatrixWithDisplayNamePriceCadenceConverter))]
public enum NewSubscriptionMatrixWithDisplayNamePriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewSubscriptionMatrixWithDisplayNamePriceCadenceConverter
    : JsonConverter<NewSubscriptionMatrixWithDisplayNamePriceCadence>
{
    public override NewSubscriptionMatrixWithDisplayNamePriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewSubscriptionMatrixWithDisplayNamePriceCadence.Annual,
            "semi_annual" => NewSubscriptionMatrixWithDisplayNamePriceCadence.SemiAnnual,
            "monthly" => NewSubscriptionMatrixWithDisplayNamePriceCadence.Monthly,
            "quarterly" => NewSubscriptionMatrixWithDisplayNamePriceCadence.Quarterly,
            "one_time" => NewSubscriptionMatrixWithDisplayNamePriceCadence.OneTime,
            "custom" => NewSubscriptionMatrixWithDisplayNamePriceCadence.Custom,
            _ => (NewSubscriptionMatrixWithDisplayNamePriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionMatrixWithDisplayNamePriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionMatrixWithDisplayNamePriceCadence.Annual => "annual",
                NewSubscriptionMatrixWithDisplayNamePriceCadence.SemiAnnual => "semi_annual",
                NewSubscriptionMatrixWithDisplayNamePriceCadence.Monthly => "monthly",
                NewSubscriptionMatrixWithDisplayNamePriceCadence.Quarterly => "quarterly",
                NewSubscriptionMatrixWithDisplayNamePriceCadence.OneTime => "one_time",
                NewSubscriptionMatrixWithDisplayNamePriceCadence.Custom => "custom",
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
        global::Orb.Models.Subscriptions.MatrixWithDisplayNameConfig,
        global::Orb.Models.Subscriptions.MatrixWithDisplayNameConfigFromRaw
    >)
)]
public sealed record class MatrixWithDisplayNameConfig : ModelBase
{
    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string Dimension
    {
        get
        {
            if (!this._rawData.TryGetValue("dimension", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dimension",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension' cannot be null",
                    new System::ArgumentNullException("dimension")
                );
        }
        init
        {
            this._rawData["dimension"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply per unit pricing to each dimension value
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.UnitAmountModel> UnitAmounts
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amounts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amounts' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amounts",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                    List<global::Orb.Models.Subscriptions.UnitAmountModel>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amounts' cannot be null",
                    new System::ArgumentNullException("unit_amounts")
                );
        }
        init
        {
            this._rawData["unit_amounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Dimension;
        foreach (var item in this.UnitAmounts)
        {
            item.Validate();
        }
    }

    public MatrixWithDisplayNameConfig() { }

    public MatrixWithDisplayNameConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixWithDisplayNameConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.MatrixWithDisplayNameConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixWithDisplayNameConfigFromRaw
    : IFromRaw<global::Orb.Models.Subscriptions.MatrixWithDisplayNameConfig>
{
    public global::Orb.Models.Subscriptions.MatrixWithDisplayNameConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.MatrixWithDisplayNameConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a unit amount item
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.UnitAmountModel,
        global::Orb.Models.Subscriptions.UnitAmountModelFromRaw
    >)
)]
public sealed record class UnitAmountModel : ModelBase
{
    /// <summary>
    /// The dimension value
    /// </summary>
    public required string DimensionValue
    {
        get
        {
            if (!this._rawData.TryGetValue("dimension_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dimension_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension_value' cannot be null",
                    new System::ArgumentNullException("dimension_value")
                );
        }
        init
        {
            this._rawData["dimension_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Display name for this dimension value
    /// </summary>
    public required string DisplayName
    {
        get
        {
            if (!this._rawData.TryGetValue("display_name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'display_name' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "display_name",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'display_name' cannot be null",
                    new System::ArgumentNullException("display_name")
                );
        }
        init
        {
            this._rawData["display_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.DimensionValue;
        _ = this.DisplayName;
        _ = this.UnitAmount;
    }

    public UnitAmountModel() { }

    public UnitAmountModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitAmountModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.UnitAmountModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnitAmountModelFromRaw : IFromRaw<global::Orb.Models.Subscriptions.UnitAmountModel>
{
    public global::Orb.Models.Subscriptions.UnitAmountModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.UnitAmountModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewSubscriptionMatrixWithDisplayNamePriceModelTypeConverter))]
public enum NewSubscriptionMatrixWithDisplayNamePriceModelType
{
    MatrixWithDisplayName,
}

sealed class NewSubscriptionMatrixWithDisplayNamePriceModelTypeConverter
    : JsonConverter<NewSubscriptionMatrixWithDisplayNamePriceModelType>
{
    public override NewSubscriptionMatrixWithDisplayNamePriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "matrix_with_display_name" =>
                NewSubscriptionMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
            _ => (NewSubscriptionMatrixWithDisplayNamePriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionMatrixWithDisplayNamePriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName =>
                    "matrix_with_display_name",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfigConverter))]
public record class NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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
                    "Data did not match any variant of NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig"
                );
        }
    }

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
                "Data did not match any variant of NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfigConverter
    : JsonConverter<NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig>
{
    public override NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig? Read(
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
                return new NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionMatrixWithDisplayNamePriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
