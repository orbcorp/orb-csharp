using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Models = Orb.Models;
using ThresholdTotalAmountProperties = Orb.Models.PriceProperties.ThresholdTotalAmountProperties;

namespace Orb.Models.PriceProperties;

[JsonConverter(typeof(ModelConverter<ThresholdTotalAmount>))]
public sealed record class ThresholdTotalAmount : ModelBase, IFromRaw<ThresholdTotalAmount>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::BillableMetricTiny? BillableMetric
    {
        get
        {
            if (!this.Properties.TryGetValue("billable_metric", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "billable_metric",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Models::BillableMetricTiny?>(element);
        }
        set { this.Properties["billable_metric"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::BillingCycleConfiguration BillingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue("billing_cycle_configuration", out JsonElement element)
            )
                throw new ArgumentOutOfRangeException(
                    "billing_cycle_configuration",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Models::BillingCycleConfiguration>(element)
                ?? throw new ArgumentNullException("billing_cycle_configuration");
        }
        set
        {
            this.Properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required ThresholdTotalAmountProperties::Cadence Cadence
    {
        get
        {
            if (!this.Properties.TryGetValue("cadence", out JsonElement element))
                throw new ArgumentOutOfRangeException("cadence", "Missing required argument");

            return JsonSerializer.Deserialize<ThresholdTotalAmountProperties::Cadence>(element)
                ?? throw new ArgumentNullException("cadence");
        }
        set { this.Properties["cadence"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double? ConversionRate
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "conversion_rate",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["conversion_rate"] = JsonSerializer.SerializeToElement(value); }
    }

    public required ThresholdTotalAmountProperties::ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_config", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "conversion_rate_config",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ThresholdTotalAmountProperties::ConversionRateConfig?>(
                element
            );
        }
        set
        {
            this.Properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element);
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Allocation? CreditAllocation
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_allocation", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "credit_allocation",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Models::Allocation?>(element);
        }
        set { this.Properties["credit_allocation"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new ArgumentOutOfRangeException("currency", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Discount2? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                throw new ArgumentOutOfRangeException("discount", "Missing required argument");

            return JsonSerializer.Deserialize<Models::Discount2?>(element);
        }
        set { this.Properties["discount"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "external_price_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["external_price_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double? FixedPriceQuantity
    {
        get
        {
            if (!this.Properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "fixed_price_quantity",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::BillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                throw new ArgumentOutOfRangeException(
                    "invoicing_cycle_configuration",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Models::BillingCycleConfiguration?>(element);
        }
        set
        {
            this.Properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required Models::ItemSlim Item
    {
        get
        {
            if (!this.Properties.TryGetValue("item", out JsonElement element))
                throw new ArgumentOutOfRangeException("item", "Missing required argument");

            return JsonSerializer.Deserialize<Models::ItemSlim>(element)
                ?? throw new ArgumentNullException("item");
        }
        set { this.Properties["item"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Maximum? Maximum
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum", out JsonElement element))
                throw new ArgumentOutOfRangeException("maximum", "Missing required argument");

            return JsonSerializer.Deserialize<Models::Maximum?>(element);
        }
        set { this.Properties["maximum"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "maximum_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new ArgumentOutOfRangeException("metadata", "Missing required argument");

            return JsonSerializer.Deserialize<Dictionary<string, string>>(element)
                ?? throw new ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out JsonElement element))
                throw new ArgumentOutOfRangeException("minimum", "Missing required argument");

            return JsonSerializer.Deserialize<Models::Minimum?>(element);
        }
        set { this.Properties["minimum"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement ModelType
    {
        get
        {
            if (!this.Properties.TryGetValue("model_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("model_type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element);
        }
        set { this.Properties["model_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "plan_phase_order",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["plan_phase_order"] = JsonSerializer.SerializeToElement(value); }
    }

    public required ThresholdTotalAmountProperties::PriceType PriceType
    {
        get
        {
            if (!this.Properties.TryGetValue("price_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("price_type", "Missing required argument");

            return JsonSerializer.Deserialize<ThresholdTotalAmountProperties::PriceType>(element)
                ?? throw new ArgumentNullException("price_type");
        }
        set { this.Properties["price_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The price id this price replaces. This price will take the place of the replaced
    /// price in plan version migrations.
    /// </summary>
    public required string? ReplacesPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("replaces_price_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "replaces_price_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["replaces_price_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Dictionary<string, JsonElement> ThresholdTotalAmountConfig
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "threshold_total_amount_config",
                    out JsonElement element
                )
            )
                throw new ArgumentOutOfRangeException(
                    "threshold_total_amount_config",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(element)
                ?? throw new ArgumentNullException("threshold_total_amount_config");
        }
        set
        {
            this.Properties["threshold_total_amount_config"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public Models::DimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<Models::DimensionalPriceConfiguration?>(element);
        }
        set
        {
            this.Properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.BillableMetric?.Validate();
        this.BillingCycleConfiguration.Validate();
        this.Cadence.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.CreatedAt;
        this.CreditAllocation?.Validate();
        _ = this.Currency;
        this.Discount?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        this.InvoicingCycleConfiguration?.Validate();
        this.Item.Validate();
        this.Maximum?.Validate();
        _ = this.MaximumAmount;
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
        this.Minimum?.Validate();
        _ = this.MinimumAmount;
        _ = this.Name;
        _ = this.PlanPhaseOrder;
        this.PriceType.Validate();
        _ = this.ReplacesPriceID;
        foreach (var item in this.ThresholdTotalAmountConfig.Values)
        {
            _ = item;
        }
        this.DimensionalPriceConfiguration?.Validate();
    }

    public ThresholdTotalAmount()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"threshold_total_amount\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdTotalAmount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ThresholdTotalAmount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
