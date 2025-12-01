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
        NewSubscriptionGroupedWithMeteredMinimumPrice,
        NewSubscriptionGroupedWithMeteredMinimumPriceFromRaw
    >)
)]
public sealed record class NewSubscriptionGroupedWithMeteredMinimumPrice : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, NewSubscriptionGroupedWithMeteredMinimumPriceCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewSubscriptionGroupedWithMeteredMinimumPriceCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_metered_minimum pricing
    /// </summary>
    public required global::Orb.Models.Subscriptions.GroupedWithMeteredMinimumConfig GroupedWithMeteredMinimumConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Subscriptions.GroupedWithMeteredMinimumConfig>(
                this.RawData,
                "grouped_with_metered_minimum_config"
            );
        }
        init { ModelBase.Set(this._rawData, "grouped_with_metered_minimum_config", value); }
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
    public required ApiEnum<
        string,
        NewSubscriptionGroupedWithMeteredMinimumPriceModelType
    > ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewSubscriptionGroupedWithMeteredMinimumPriceModelType>
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
    public NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig>(
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
        this.GroupedWithMeteredMinimumConfig.Validate();
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

    public NewSubscriptionGroupedWithMeteredMinimumPrice() { }

    public NewSubscriptionGroupedWithMeteredMinimumPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscriptionGroupedWithMeteredMinimumPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewSubscriptionGroupedWithMeteredMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionGroupedWithMeteredMinimumPriceFromRaw
    : IFromRaw<NewSubscriptionGroupedWithMeteredMinimumPrice>
{
    public NewSubscriptionGroupedWithMeteredMinimumPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewSubscriptionGroupedWithMeteredMinimumPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(NewSubscriptionGroupedWithMeteredMinimumPriceCadenceConverter))]
public enum NewSubscriptionGroupedWithMeteredMinimumPriceCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class NewSubscriptionGroupedWithMeteredMinimumPriceCadenceConverter
    : JsonConverter<NewSubscriptionGroupedWithMeteredMinimumPriceCadence>
{
    public override NewSubscriptionGroupedWithMeteredMinimumPriceCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
            "semi_annual" => NewSubscriptionGroupedWithMeteredMinimumPriceCadence.SemiAnnual,
            "monthly" => NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Monthly,
            "quarterly" => NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Quarterly,
            "one_time" => NewSubscriptionGroupedWithMeteredMinimumPriceCadence.OneTime,
            "custom" => NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Custom,
            _ => (NewSubscriptionGroupedWithMeteredMinimumPriceCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionGroupedWithMeteredMinimumPriceCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual => "annual",
                NewSubscriptionGroupedWithMeteredMinimumPriceCadence.SemiAnnual => "semi_annual",
                NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Monthly => "monthly",
                NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Quarterly => "quarterly",
                NewSubscriptionGroupedWithMeteredMinimumPriceCadence.OneTime => "one_time",
                NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_with_metered_minimum pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.GroupedWithMeteredMinimumConfig,
        global::Orb.Models.Subscriptions.GroupedWithMeteredMinimumConfigFromRaw
    >)
)]
public sealed record class GroupedWithMeteredMinimumConfig : ModelBase
{
    /// <summary>
    /// Used to partition the usage into groups. The minimum amount is applied to
    /// each group.
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The minimum amount to charge per group per unit
    /// </summary>
    public required string MinimumUnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "minimum_unit_amount"); }
        init { ModelBase.Set(this._rawData, "minimum_unit_amount", value); }
    }

    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string PricingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "pricing_key"); }
        init { ModelBase.Set(this._rawData, "pricing_key", value); }
    }

    /// <summary>
    /// Scale the unit rates by the scaling factor.
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.ScalingFactor> ScalingFactors
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Subscriptions.ScalingFactor>>(
                this.RawData,
                "scaling_factors"
            );
        }
        init { ModelBase.Set(this._rawData, "scaling_factors", value); }
    }

    /// <summary>
    /// Used to determine the unit rate scaling factor
    /// </summary>
    public required string ScalingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "scaling_key"); }
        init { ModelBase.Set(this._rawData, "scaling_key", value); }
    }

    /// <summary>
    /// Apply per unit pricing to each pricing value. The minimum amount is applied
    /// any unmatched usage.
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.UnitAmount> UnitAmounts
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Subscriptions.UnitAmount>>(
                this.RawData,
                "unit_amounts"
            );
        }
        init { ModelBase.Set(this._rawData, "unit_amounts", value); }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MinimumUnitAmount;
        _ = this.PricingKey;
        foreach (var item in this.ScalingFactors)
        {
            item.Validate();
        }
        _ = this.ScalingKey;
        foreach (var item in this.UnitAmounts)
        {
            item.Validate();
        }
    }

    public GroupedWithMeteredMinimumConfig() { }

    public GroupedWithMeteredMinimumConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMeteredMinimumConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.GroupedWithMeteredMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMeteredMinimumConfigFromRaw
    : IFromRaw<global::Orb.Models.Subscriptions.GroupedWithMeteredMinimumConfig>
{
    public global::Orb.Models.Subscriptions.GroupedWithMeteredMinimumConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.GroupedWithMeteredMinimumConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a scaling factor
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.ScalingFactor,
        global::Orb.Models.Subscriptions.ScalingFactorFromRaw
    >)
)]
public sealed record class ScalingFactor : ModelBase
{
    /// <summary>
    /// Scaling factor
    /// </summary>
    public required string ScalingFactor1
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "scaling_factor"); }
        init { ModelBase.Set(this._rawData, "scaling_factor", value); }
    }

    /// <summary>
    /// Scaling value
    /// </summary>
    public required string ScalingValue
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "scaling_value"); }
        init { ModelBase.Set(this._rawData, "scaling_value", value); }
    }

    public override void Validate()
    {
        _ = this.ScalingFactor1;
        _ = this.ScalingValue;
    }

    public ScalingFactor() { }

    public ScalingFactor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScalingFactor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.ScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScalingFactorFromRaw : IFromRaw<global::Orb.Models.Subscriptions.ScalingFactor>
{
    public global::Orb.Models.Subscriptions.ScalingFactor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.ScalingFactor.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a unit amount
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.UnitAmount,
        global::Orb.Models.Subscriptions.UnitAmountFromRaw
    >)
)]
public sealed record class UnitAmount : ModelBase
{
    /// <summary>
    /// Pricing value
    /// </summary>
    public required string PricingValue
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "pricing_value"); }
        init { ModelBase.Set(this._rawData, "pricing_value", value); }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount1
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    public override void Validate()
    {
        _ = this.PricingValue;
        _ = this.UnitAmount1;
    }

    public UnitAmount() { }

    public UnitAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.UnitAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnitAmountFromRaw : IFromRaw<global::Orb.Models.Subscriptions.UnitAmount>
{
    public global::Orb.Models.Subscriptions.UnitAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.UnitAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(NewSubscriptionGroupedWithMeteredMinimumPriceModelTypeConverter))]
public enum NewSubscriptionGroupedWithMeteredMinimumPriceModelType
{
    GroupedWithMeteredMinimum,
}

sealed class NewSubscriptionGroupedWithMeteredMinimumPriceModelTypeConverter
    : JsonConverter<NewSubscriptionGroupedWithMeteredMinimumPriceModelType>
{
    public override NewSubscriptionGroupedWithMeteredMinimumPriceModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "grouped_with_metered_minimum" =>
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
            _ => (NewSubscriptionGroupedWithMeteredMinimumPriceModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionGroupedWithMeteredMinimumPriceModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum =>
                    "grouped_with_metered_minimum",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfigConverter))]
public record class NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig"
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
                "Data did not match any variant of NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig"
            ),
        };
    }

    public static implicit operator NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(
        NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfigConverter
    : JsonConverter<NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig>
{
    public override NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig? Read(
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
                return new NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewSubscriptionGroupedWithMeteredMinimumPriceConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
