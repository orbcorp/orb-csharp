using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using ScalableMatrixWithTieredPricingProperties = Orb.Models.PriceProperties.ScalableMatrixWithTieredPricingProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.PriceProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ScalableMatrixWithTieredPricing>))]
public sealed record class ScalableMatrixWithTieredPricing
    : Orb::ModelBase,
        Orb::IFromRaw<ScalableMatrixWithTieredPricing>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::BillableMetricTiny? BillableMetric
    {
        get
        {
            if (!this.Properties.TryGetValue("billable_metric", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "billable_metric",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::BillableMetricTiny?>(element);
        }
        set { this.Properties["billable_metric"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::BillingCycleConfiguration BillingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "billing_cycle_configuration",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "billing_cycle_configuration",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::BillingCycleConfiguration>(element)
                ?? throw new System::ArgumentNullException("billing_cycle_configuration");
        }
        set
        {
            this.Properties["billing_cycle_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required ScalableMatrixWithTieredPricingProperties::Cadence Cadence
    {
        get
        {
            if (!this.Properties.TryGetValue("cadence", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "cadence",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ScalableMatrixWithTieredPricingProperties::Cadence>(
                    element
                ) ?? throw new System::ArgumentNullException("cadence");
        }
        set { this.Properties["cadence"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double? ConversionRate
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conversion_rate",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["conversion_rate"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required ScalableMatrixWithTieredPricingProperties::ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "conversion_rate_config",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "conversion_rate_config",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ScalableMatrixWithTieredPricingProperties::ConversionRateConfig?>(
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

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Allocation? CreditAllocation
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_allocation", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "credit_allocation",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Allocation?>(element);
        }
        set
        {
            this.Properties["credit_allocation"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

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

    public required Models::Discount? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Discount?>(element);
        }
        set { this.Properties["discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "external_price_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_price_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required double? FixedPriceQuantity
    {
        get
        {
            if (!this.Properties.TryGetValue("fixed_price_quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "fixed_price_quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set
        {
            this.Properties["fixed_price_quantity"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required Models::BillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "invoicing_cycle_configuration",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::BillingCycleConfiguration?>(element);
        }
        set
        {
            this.Properties["invoicing_cycle_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required Models::ItemSlim Item
    {
        get
        {
            if (!this.Properties.TryGetValue("item", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("item", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Models::ItemSlim>(element)
                ?? throw new System::ArgumentNullException("item");
        }
        set { this.Properties["item"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Maximum? Maximum
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "maximum",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Maximum?>(element);
        }
        set { this.Properties["maximum"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "maximum_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["maximum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Generic::Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "metadata",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string>>(element)
                ?? throw new System::ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Minimum?>(element);
        }
        set { this.Properties["minimum"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["minimum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required ScalableMatrixWithTieredPricingProperties::ModelType ModelType
    {
        get
        {
            if (!this.Properties.TryGetValue("model_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "model_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ScalableMatrixWithTieredPricingProperties::ModelType>(
                    element
                ) ?? throw new System::ArgumentNullException("model_type");
        }
        set { this.Properties["model_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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

    public required long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "plan_phase_order",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["plan_phase_order"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required ScalableMatrixWithTieredPricingProperties::PriceType PriceType
    {
        get
        {
            if (!this.Properties.TryGetValue("price_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ScalableMatrixWithTieredPricingProperties::PriceType>(
                    element
                ) ?? throw new System::ArgumentNullException("price_type");
        }
        set { this.Properties["price_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The price id this price replaces. This price will take the place of the replaced
    /// price in plan version migrations.
    /// </summary>
    public required string? ReplacesPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("replaces_price_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "replaces_price_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["replaces_price_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required Generic::Dictionary<
        string,
        Json::JsonElement
    > ScalableMatrixWithTieredPricingConfig
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "scalable_matrix_with_tiered_pricing_config",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "scalable_matrix_with_tiered_pricing_config",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, Json::JsonElement>>(
                    element
                )
                ?? throw new System::ArgumentNullException(
                    "scalable_matrix_with_tiered_pricing_config"
                );
        }
        set
        {
            this.Properties["scalable_matrix_with_tiered_pricing_config"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public Models::DimensionalPriceConfiguration? DimensionalPriceConfiguration
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

            return Json::JsonSerializer.Deserialize<Models::DimensionalPriceConfiguration?>(
                element
            );
        }
        set
        {
            this.Properties["dimensional_price_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
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
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.PlanPhaseOrder;
        this.PriceType.Validate();
        _ = this.ReplacesPriceID;
        foreach (var item in this.ScalableMatrixWithTieredPricingConfig.Values)
        {
            _ = item;
        }
        this.DimensionalPriceConfiguration?.Validate();
    }

    public ScalableMatrixWithTieredPricing() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ScalableMatrixWithTieredPricing(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ScalableMatrixWithTieredPricing FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
