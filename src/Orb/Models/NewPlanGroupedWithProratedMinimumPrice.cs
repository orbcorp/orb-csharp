using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewPlanGroupedWithProratedMinimumPrice>))]
public sealed record class NewPlanGroupedWithProratedMinimumPrice
    : ModelBase,
        IFromRaw<NewPlanGroupedWithProratedMinimumPrice>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewPlanGroupedWithProratedMinimumPriceCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewPlanGroupedWithProratedMinimumPriceCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_prorated_minimum pricing
    /// </summary>
    public required NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig GroupedWithProratedMinimumConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "grouped_with_prorated_minimum_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'grouped_with_prorated_minimum_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouped_with_prorated_minimum_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouped_with_prorated_minimum_config' cannot be null",
                    new System::ArgumentNullException("grouped_with_prorated_minimum_config")
                );
        }
        init
        {
            this._properties["grouped_with_prorated_minimum_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
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
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public required ApiEnum<string, NewPlanGroupedWithProratedMinimumPriceModelType> ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewPlanGroupedWithProratedMinimumPriceModelType>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
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
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewPlanGroupedWithProratedMinimumPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewPlanGroupedWithProratedMinimumPriceConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
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
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithProratedMinimumConfig.Validate();
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

    public NewPlanGroupedWithProratedMinimumPrice() { }

    public NewPlanGroupedWithProratedMinimumPrice(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanGroupedWithProratedMinimumPrice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewPlanGroupedWithProratedMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewPlanGroupedWithProratedMinimumPriceCadenceConverter))]
public enum NewPlanGroupedWithProratedMinimumPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewPlanGroupedWithProratedMinimumPriceCadenceConverter
    : JsonConverter<NewPlanGroupedWithProratedMinimumPriceCadence>
{
    public override NewPlanGroupedWithProratedMinimumPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewPlanGroupedWithProratedMinimumPriceCadence.Annual,
            "semi_annual" => NewPlanGroupedWithProratedMinimumPriceCadence.SemiAnnual,
            "monthly" => NewPlanGroupedWithProratedMinimumPriceCadence.Monthly,
            "quarterly" => NewPlanGroupedWithProratedMinimumPriceCadence.Quarterly,
            "one_time" => NewPlanGroupedWithProratedMinimumPriceCadence.OneTime,
            "custom" => NewPlanGroupedWithProratedMinimumPriceCadence.Custom,
            _ => (NewPlanGroupedWithProratedMinimumPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedWithProratedMinimumPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanGroupedWithProratedMinimumPriceCadence.Annual => "annual",
                NewPlanGroupedWithProratedMinimumPriceCadence.SemiAnnual => "semi_annual",
                NewPlanGroupedWithProratedMinimumPriceCadence.Monthly => "monthly",
                NewPlanGroupedWithProratedMinimumPriceCadence.Quarterly => "quarterly",
                NewPlanGroupedWithProratedMinimumPriceCadence.OneTime => "one_time",
                NewPlanGroupedWithProratedMinimumPriceCadence.Custom => "custom",
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
    typeof(ModelConverter<NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig>)
)]
public sealed record class NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig
    : ModelBase,
        IFromRaw<NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig>
{
    /// <summary>
    /// How to determine the groups that should each have a minimum
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
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
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge per group
    /// </summary>
    public required string Minimum
    {
        get
        {
            if (!this._properties.TryGetValue("minimum", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum' cannot be null",
                    new System::ArgumentOutOfRangeException("minimum", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum' cannot be null",
                    new System::ArgumentNullException("minimum")
                );
        }
        init
        {
            this._properties["minimum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount to charge per unit
    /// </summary>
    public required string UnitRate
    {
        get
        {
            if (!this._properties.TryGetValue("unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_rate' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_rate",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_rate' cannot be null",
                    new System::ArgumentNullException("unit_rate")
                );
        }
        init
        {
            this._properties["unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.Minimum;
        _ = this.UnitRate;
    }

    public NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig() { }

    public NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewPlanGroupedWithProratedMinimumPriceGroupedWithProratedMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewPlanGroupedWithProratedMinimumPriceModelTypeConverter))]
public enum NewPlanGroupedWithProratedMinimumPriceModelType
{
    GroupedWithProratedMinimum,
}

sealed class NewPlanGroupedWithProratedMinimumPriceModelTypeConverter
    : JsonConverter<NewPlanGroupedWithProratedMinimumPriceModelType>
{
    public override NewPlanGroupedWithProratedMinimumPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "grouped_with_prorated_minimum" =>
                NewPlanGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
            _ => (NewPlanGroupedWithProratedMinimumPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedWithProratedMinimumPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum =>
                    "grouped_with_prorated_minimum",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewPlanGroupedWithProratedMinimumPriceConversionRateConfigConverter))]
public record class NewPlanGroupedWithProratedMinimumPriceConversionRateConfig
{
    public object Value { get; private init; }

    public NewPlanGroupedWithProratedMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    )
    {
        Value = value;
    }

    public NewPlanGroupedWithProratedMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    )
    {
        Value = value;
    }

    NewPlanGroupedWithProratedMinimumPriceConversionRateConfig(UnknownVariant value)
    {
        Value = value;
    }

    public static NewPlanGroupedWithProratedMinimumPriceConversionRateConfig CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
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
                    "Data did not match any variant of NewPlanGroupedWithProratedMinimumPriceConversionRateConfig"
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
                "Data did not match any variant of NewPlanGroupedWithProratedMinimumPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewPlanGroupedWithProratedMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewPlanGroupedWithProratedMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewPlanGroupedWithProratedMinimumPriceConversionRateConfig"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class NewPlanGroupedWithProratedMinimumPriceConversionRateConfigConverter
    : JsonConverter<NewPlanGroupedWithProratedMinimumPriceConversionRateConfig>
{
    public override NewPlanGroupedWithProratedMinimumPriceConversionRateConfig? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new NewPlanGroupedWithProratedMinimumPriceConversionRateConfig(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'SharedUnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new NewPlanGroupedWithProratedMinimumPriceConversionRateConfig(
                            deserialized
                        );
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'SharedTieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedWithProratedMinimumPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
