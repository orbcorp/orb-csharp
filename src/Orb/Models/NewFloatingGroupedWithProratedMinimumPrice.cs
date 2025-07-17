using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using NewFloatingGroupedWithProratedMinimumPriceProperties = Orb.Models.NewFloatingGroupedWithProratedMinimumPriceProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(
    typeof(Orb::ModelConverter<NewFloatingGroupedWithProratedMinimumPrice>)
)]
public sealed record class NewFloatingGroupedWithProratedMinimumPrice
    : Orb::ModelBase,
        Orb::IFromRaw<NewFloatingGroupedWithProratedMinimumPrice>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required NewFloatingGroupedWithProratedMinimumPriceProperties::Cadence Cadence
    {
        get
        {
            if (!this.Properties.TryGetValue("cadence", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "cadence",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPriceProperties::Cadence>(
                    element
                ) ?? throw new System::ArgumentNullException("cadence");
        }
        set { this.Properties["cadence"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Generic::Dictionary<string, Json::JsonElement> GroupedWithProratedMinimumConfig
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "grouped_with_prorated_minimum_config",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "grouped_with_prorated_minimum_config",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, Json::JsonElement>>(
                    element
                )
                ?? throw new System::ArgumentNullException("grouped_with_prorated_minimum_config");
        }
        set
        {
            this.Properties["grouped_with_prorated_minimum_config"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "item_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("item_id");
        }
        set { this.Properties["item_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required NewFloatingGroupedWithProratedMinimumPriceProperties::ModelType ModelType
    {
        get
        {
            if (!this.Properties.TryGetValue("model_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "model_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPriceProperties::ModelType>(
                    element
                ) ?? throw new System::ArgumentNullException("model_type");
        }
        set { this.Properties["model_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this.Properties.TryGetValue("billable_metric_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["billable_metric_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance if
    /// this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this.Properties.TryGetValue("billed_in_advance", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.Properties["billed_in_advance"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "billing_cycle_configuration",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(element);
        }
        set
        {
            this.Properties["billing_cycle_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["conversion_rate"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public NewFloatingGroupedWithProratedMinimumPriceProperties::ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "conversion_rate_config",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPriceProperties::ConversionRateConfig?>(
                element
            );
        }
        set
        {
            this.Properties["conversion_rate_config"] = Json::JsonSerializer.SerializeToElement(
                value
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
                !this.Properties.TryGetValue(
                    "dimensional_price_configuration",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(element);
        }
        set
        {
            this.Properties["dimensional_price_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_price_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this.Properties.TryGetValue("fixed_price_quantity", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set
        {
            this.Properties["fixed_price_quantity"] = Json::JsonSerializer.SerializeToElement(
                value
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
            if (!this.Properties.TryGetValue("invoice_grouping_key", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["invoice_grouping_key"] = Json::JsonSerializer.SerializeToElement(
                value
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
                !this.Properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(element);
        }
        set
        {
            this.Properties["invoicing_cycle_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Generic::Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string?>?>(element);
        }
        set { this.Properties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        foreach (var item in this.GroupedWithProratedMinimumConfig.Values)
        {
            _ = item;
        }
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
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                _ = item;
            }
        }
    }

    public NewFloatingGroupedWithProratedMinimumPrice() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    NewFloatingGroupedWithProratedMinimumPrice(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewFloatingGroupedWithProratedMinimumPrice FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
