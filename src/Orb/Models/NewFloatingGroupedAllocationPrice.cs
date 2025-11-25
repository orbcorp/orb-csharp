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
        NewFloatingGroupedAllocationPrice,
        NewFloatingGroupedAllocationPriceFromRaw
    >)
)]
public sealed record class NewFloatingGroupedAllocationPrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewFloatingGroupedAllocationPriceCadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewFloatingGroupedAllocationPriceCadence>
            >(element, ModelBase.SerializerOptions);
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
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
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
    /// Configuration for grouped_allocation pricing
    /// </summary>
    public required GroupedAllocationConfig GroupedAllocationConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("grouped_allocation_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouped_allocation_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouped_allocation_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<GroupedAllocationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouped_allocation_config' cannot be null",
                    new System::ArgumentNullException("grouped_allocation_config")
                );
        }
        init
        {
            this._rawData["grouped_allocation_config"] = JsonSerializer.SerializeToElement(
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
    public required ApiEnum<string, NewFloatingGroupedAllocationPriceModelType> ModelType
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
                ApiEnum<string, NewFloatingGroupedAllocationPriceModelType>
            >(element, ModelBase.SerializerOptions);
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
    public NewFloatingGroupedAllocationPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewFloatingGroupedAllocationPriceConversionRateConfig?>(
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
    public Dictionary<string, string?>? Metadata
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

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.GroupedAllocationConfig.Validate();
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

    public NewFloatingGroupedAllocationPrice() { }

    public NewFloatingGroupedAllocationPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewFloatingGroupedAllocationPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewFloatingGroupedAllocationPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewFloatingGroupedAllocationPriceFromRaw : IFromRaw<NewFloatingGroupedAllocationPrice>
{
    public NewFloatingGroupedAllocationPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewFloatingGroupedAllocationPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewFloatingGroupedAllocationPriceCadenceConverter))]
public enum NewFloatingGroupedAllocationPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewFloatingGroupedAllocationPriceCadenceConverter
    : JsonConverter<NewFloatingGroupedAllocationPriceCadence>
{
    public override NewFloatingGroupedAllocationPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewFloatingGroupedAllocationPriceCadence.Annual,
            "semi_annual" => NewFloatingGroupedAllocationPriceCadence.SemiAnnual,
            "monthly" => NewFloatingGroupedAllocationPriceCadence.Monthly,
            "quarterly" => NewFloatingGroupedAllocationPriceCadence.Quarterly,
            "one_time" => NewFloatingGroupedAllocationPriceCadence.OneTime,
            "custom" => NewFloatingGroupedAllocationPriceCadence.Custom,
            _ => (NewFloatingGroupedAllocationPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedAllocationPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingGroupedAllocationPriceCadence.Annual => "annual",
                NewFloatingGroupedAllocationPriceCadence.SemiAnnual => "semi_annual",
                NewFloatingGroupedAllocationPriceCadence.Monthly => "monthly",
                NewFloatingGroupedAllocationPriceCadence.Quarterly => "quarterly",
                NewFloatingGroupedAllocationPriceCadence.OneTime => "one_time",
                NewFloatingGroupedAllocationPriceCadence.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<GroupedAllocationConfig, GroupedAllocationConfigFromRaw>))]
public sealed record class GroupedAllocationConfig : ModelBase
{
    /// <summary>
    /// Usage allocation per group
    /// </summary>
    public required string Allocation
    {
        get
        {
            if (!this._rawData.TryGetValue("allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'allocation' cannot be null",
                    new System::ArgumentNullException("allocation")
                );
        }
        init
        {
            this._rawData["allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// How to determine the groups that should each be allocated some quantity
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
    /// Unit rate for post-allocation
    /// </summary>
    public required string OverageUnitRate
    {
        get
        {
            if (!this._rawData.TryGetValue("overage_unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'overage_unit_rate' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "overage_unit_rate",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'overage_unit_rate' cannot be null",
                    new System::ArgumentNullException("overage_unit_rate")
                );
        }
        init
        {
            this._rawData["overage_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Allocation;
        _ = this.GroupingKey;
        _ = this.OverageUnitRate;
    }

    public GroupedAllocationConfig() { }

    public GroupedAllocationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedAllocationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static GroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedAllocationConfigFromRaw : IFromRaw<GroupedAllocationConfig>
{
    public GroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedAllocationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewFloatingGroupedAllocationPriceModelTypeConverter))]
public enum NewFloatingGroupedAllocationPriceModelType
{
    GroupedAllocation,
}

sealed class NewFloatingGroupedAllocationPriceModelTypeConverter
    : JsonConverter<NewFloatingGroupedAllocationPriceModelType>
{
    public override NewFloatingGroupedAllocationPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "grouped_allocation" => NewFloatingGroupedAllocationPriceModelType.GroupedAllocation,
            _ => (NewFloatingGroupedAllocationPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedAllocationPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewFloatingGroupedAllocationPriceModelType.GroupedAllocation =>
                    "grouped_allocation",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewFloatingGroupedAllocationPriceConversionRateConfigConverter))]
public record class NewFloatingGroupedAllocationPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewFloatingGroupedAllocationPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewFloatingGroupedAllocationPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewFloatingGroupedAllocationPriceConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of NewFloatingGroupedAllocationPriceConversionRateConfig"
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
                "Data did not match any variant of NewFloatingGroupedAllocationPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewFloatingGroupedAllocationPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewFloatingGroupedAllocationPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewFloatingGroupedAllocationPriceConversionRateConfig"
            );
        }
    }
}

sealed class NewFloatingGroupedAllocationPriceConversionRateConfigConverter
    : JsonConverter<NewFloatingGroupedAllocationPriceConversionRateConfig>
{
    public override NewFloatingGroupedAllocationPriceConversionRateConfig? Read(
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
                return new NewFloatingGroupedAllocationPriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewFloatingGroupedAllocationPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
