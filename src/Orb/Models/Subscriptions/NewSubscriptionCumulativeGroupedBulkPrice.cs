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
        NewSubscriptionCumulativeGroupedBulkPrice,
        NewSubscriptionCumulativeGroupedBulkPriceFromRaw
    >)
)]
public sealed record class NewSubscriptionCumulativeGroupedBulkPrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewSubscriptionCumulativeGroupedBulkPriceCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                    ApiEnum<string, NewSubscriptionCumulativeGroupedBulkPriceCadence>
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
    /// Configuration for cumulative_grouped_bulk pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig CumulativeGroupedBulkConfig
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "cumulative_grouped_bulk_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'cumulative_grouped_bulk_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_grouped_bulk_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'cumulative_grouped_bulk_config' cannot be null",
                    new System::ArgumentNullException("cumulative_grouped_bulk_config")
                );
        }
        init
        {
            this._rawData["cumulative_grouped_bulk_config"] = JsonSerializer.SerializeToElement(
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
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewSubscriptionCumulativeGroupedBulkPriceModelType> ModelType
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
                    ApiEnum<string, NewSubscriptionCumulativeGroupedBulkPriceModelType>
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
    public NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig?>(
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionCumulativeGroupedBulkPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewSubscriptionCumulativeGroupedBulkPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionCumulativeGroupedBulkPriceFromRaw
    : IFromRaw<NewSubscriptionCumulativeGroupedBulkPrice>
{
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
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig,
        global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfigFromRaw
    >)
)]
public sealed record class CumulativeGroupedBulkConfig : ModelBase
{
    /// <summary>
    /// Each tier lower bound must have the same group of values.
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.DimensionValue> DimensionValues
    {
        get
        {
            if (!this._rawData.TryGetValue("dimension_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "dimension_values",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                    List<global::Orb.Models.Subscriptions.DimensionValue>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new System::ArgumentNullException("dimension_values")
                );
        }
        init
        {
            this._rawData["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Grouping key name
    /// </summary>
    public required string Group
    {
        get
        {
            if (!this._rawData.TryGetValue("group", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'group' cannot be null",
                    new System::ArgumentOutOfRangeException("group", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'group' cannot be null",
                    new System::ArgumentNullException("group")
                );
        }
        init
        {
            this._rawData["group"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.DimensionValues)
        {
            item.Validate();
        }
        _ = this.Group;
    }

    public CumulativeGroupedBulkConfig() { }

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

    public static global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedBulkConfigFromRaw
    : IFromRaw<global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig>
{
    public global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.CumulativeGroupedBulkConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a dimension value entry
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.DimensionValue,
        global::Orb.Models.Subscriptions.DimensionValueFromRaw
    >)
)]
public sealed record class DimensionValue : ModelBase
{
    /// <summary>
    /// Grouping key value
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._rawData["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this._rawData.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tier_lower_bound",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentNullException("tier_lower_bound")
                );
        }
        init
        {
            this._rawData["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unit amount for this combination
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
        _ = this.GroupingKey;
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public DimensionValue() { }

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

    public static global::Orb.Models.Subscriptions.DimensionValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionValueFromRaw : IFromRaw<global::Orb.Models.Subscriptions.DimensionValue>
{
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
public record class NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig"
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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
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
                return new NewSubscriptionCumulativeGroupedBulkPriceConversionRateConfig(json);
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
