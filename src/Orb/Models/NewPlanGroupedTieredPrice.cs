using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewPlanGroupedTieredPrice, NewPlanGroupedTieredPriceFromRaw>))]
public sealed record class NewPlanGroupedTieredPrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewPlanGroupedTieredPriceCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, NewPlanGroupedTieredPriceCadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_tiered pricing
    /// </summary>
    public required NewPlanGroupedTieredPriceGroupedTieredConfig GroupedTieredConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<NewPlanGroupedTieredPriceGroupedTieredConfig>(
                this.RawData,
                "grouped_tiered_config"
            );
        }
        init { ModelBase.Set(this._rawData, "grouped_tiered_config", value); }
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
    public required ApiEnum<string, NewPlanGroupedTieredPriceModelType> ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, NewPlanGroupedTieredPriceModelType>>(
                this.RawData,
                "model_type"
            );
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
    public NewPlanGroupedTieredPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<NewPlanGroupedTieredPriceConversionRateConfig>(
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

    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedTieredConfig.Validate();
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

    public NewPlanGroupedTieredPrice() { }

    public NewPlanGroupedTieredPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanGroupedTieredPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewPlanGroupedTieredPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanGroupedTieredPriceFromRaw : IFromRaw<NewPlanGroupedTieredPrice>
{
    public NewPlanGroupedTieredPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPlanGroupedTieredPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewPlanGroupedTieredPriceCadenceConverter))]
public enum NewPlanGroupedTieredPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewPlanGroupedTieredPriceCadenceConverter
    : JsonConverter<NewPlanGroupedTieredPriceCadence>
{
    public override NewPlanGroupedTieredPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewPlanGroupedTieredPriceCadence.Annual,
            "semi_annual" => NewPlanGroupedTieredPriceCadence.SemiAnnual,
            "monthly" => NewPlanGroupedTieredPriceCadence.Monthly,
            "quarterly" => NewPlanGroupedTieredPriceCadence.Quarterly,
            "one_time" => NewPlanGroupedTieredPriceCadence.OneTime,
            "custom" => NewPlanGroupedTieredPriceCadence.Custom,
            _ => (NewPlanGroupedTieredPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedTieredPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanGroupedTieredPriceCadence.Annual => "annual",
                NewPlanGroupedTieredPriceCadence.SemiAnnual => "semi_annual",
                NewPlanGroupedTieredPriceCadence.Monthly => "monthly",
                NewPlanGroupedTieredPriceCadence.Quarterly => "quarterly",
                NewPlanGroupedTieredPriceCadence.OneTime => "one_time",
                NewPlanGroupedTieredPriceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_tiered pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        NewPlanGroupedTieredPriceGroupedTieredConfig,
        NewPlanGroupedTieredPriceGroupedTieredConfigFromRaw
    >)
)]
public sealed record class NewPlanGroupedTieredPriceGroupedTieredConfig : ModelBase
{
    /// <summary>
    /// The billable metric property used to group before tiering
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// Apply tiered pricing to each segment generated after grouping with the provided key
    /// </summary>
    public required IReadOnlyList<Tier10> Tiers
    {
        get { return ModelBase.GetNotNullClass<List<Tier10>>(this.RawData, "tiers"); }
        init { ModelBase.Set(this._rawData, "tiers", value); }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public NewPlanGroupedTieredPriceGroupedTieredConfig() { }

    public NewPlanGroupedTieredPriceGroupedTieredConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanGroupedTieredPriceGroupedTieredConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewPlanGroupedTieredPriceGroupedTieredConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanGroupedTieredPriceGroupedTieredConfigFromRaw
    : IFromRaw<NewPlanGroupedTieredPriceGroupedTieredConfig>
{
    public NewPlanGroupedTieredPriceGroupedTieredConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPlanGroupedTieredPriceGroupedTieredConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tier
/// </summary>
[JsonConverter(typeof(ModelConverter<Tier10, Tier10FromRaw>))]
public sealed record class Tier10 : ModelBase
{
    /// <summary>
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tier_lower_bound"); }
        init { ModelBase.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public Tier10() { }

    public Tier10(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier10(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Tier10 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Tier10FromRaw : IFromRaw<Tier10>
{
    public Tier10 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tier10.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewPlanGroupedTieredPriceModelTypeConverter))]
public enum NewPlanGroupedTieredPriceModelType
{
    GroupedTiered,
}

sealed class NewPlanGroupedTieredPriceModelTypeConverter
    : JsonConverter<NewPlanGroupedTieredPriceModelType>
{
    public override NewPlanGroupedTieredPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "grouped_tiered" => NewPlanGroupedTieredPriceModelType.GroupedTiered,
            _ => (NewPlanGroupedTieredPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedTieredPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPlanGroupedTieredPriceModelType.GroupedTiered => "grouped_tiered",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewPlanGroupedTieredPriceConversionRateConfigConverter))]
public record class NewPlanGroupedTieredPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewPlanGroupedTieredPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewPlanGroupedTieredPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewPlanGroupedTieredPriceConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of NewPlanGroupedTieredPriceConversionRateConfig"
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
                "Data did not match any variant of NewPlanGroupedTieredPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewPlanGroupedTieredPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewPlanGroupedTieredPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewPlanGroupedTieredPriceConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(NewPlanGroupedTieredPriceConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class NewPlanGroupedTieredPriceConversionRateConfigConverter
    : JsonConverter<NewPlanGroupedTieredPriceConversionRateConfig>
{
    public override NewPlanGroupedTieredPriceConversionRateConfig? Read(
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
                return new NewPlanGroupedTieredPriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPlanGroupedTieredPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
