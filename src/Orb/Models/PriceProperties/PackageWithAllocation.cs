using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.PriceProperties.PackageWithAllocationProperties;
using Models = Orb.Models;

namespace Orb.Models.PriceProperties;

[JsonConverter(typeof(ModelConverter<PackageWithAllocation>))]
public sealed record class PackageWithAllocation : ModelBase, IFromRaw<PackageWithAllocation>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BillableMetricTiny? BillableMetric
    {
        get
        {
            if (!this.Properties.TryGetValue("billable_metric", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BillableMetricTiny?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["billable_metric"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BillingCycleConfiguration BillingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue("billing_cycle_configuration", out JsonElement element)
            )
                throw new OrbInvalidDataException(
                    "'billing_cycle_configuration' cannot be null",
                    new ArgumentOutOfRangeException(
                        "billing_cycle_configuration",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<BillingCycleConfiguration>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'billing_cycle_configuration' cannot be null",
                    new ArgumentNullException("billing_cycle_configuration")
                );
        }
        set
        {
            this.Properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, BillingMode> BillingMode
    {
        get
        {
            if (!this.Properties.TryGetValue("billing_mode", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'billing_mode' cannot be null",
                    new ArgumentOutOfRangeException("billing_mode", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, BillingMode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["billing_mode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Cadence> Cadence
    {
        get
        {
            if (!this.Properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<TransformPriceFilter>? CompositePriceFilters
    {
        get
        {
            if (!this.Properties.TryGetValue("composite_price_filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<TransformPriceFilter>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["composite_price_filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double? ConversionRate
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Allocation? CreditAllocation
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_allocation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Allocation?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["credit_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentNullException("currency")
                );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Discount? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Discount?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double? FixedPriceQuantity
    {
        get
        {
            if (!this.Properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<BillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A minimal representation of an Item containing only the essential identifying information.
    /// </summary>
    public required ItemSlim Item
    {
        get
        {
            if (!this.Properties.TryGetValue("item", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item' cannot be null",
                    new ArgumentOutOfRangeException("item", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ItemSlim>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item' cannot be null",
                    new ArgumentNullException("item")
                );
        }
        set
        {
            this.Properties["item"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Maximum? Maximum
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Maximum?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Models::Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Models::Minimum?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["minimum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ModelType ModelType
    {
        get
        {
            if (!this.Properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new ArgumentOutOfRangeException("model_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ModelType>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new ArgumentNullException("model_type")
                );
        }
        set
        {
            this.Properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for package_with_allocation pricing
    /// </summary>
    public required PackageWithAllocationConfig PackageWithAllocationConfig
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "package_with_allocation_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'package_with_allocation_config' cannot be null",
                    new ArgumentOutOfRangeException(
                        "package_with_allocation_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PackageWithAllocationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'package_with_allocation_config' cannot be null",
                    new ArgumentNullException("package_with_allocation_config")
                );
        }
        set
        {
            this.Properties["package_with_allocation_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, PriceType> PriceType
    {
        get
        {
            if (!this.Properties.TryGetValue("price_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price_type' cannot be null",
                    new ArgumentOutOfRangeException("price_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PriceType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["price_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["replaces_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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

            return JsonSerializer.Deserialize<Models::DimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.BillableMetric?.Validate();
        this.BillingCycleConfiguration.Validate();
        this.BillingMode.Validate();
        this.Cadence.Validate();
        foreach (var item in this.CompositePriceFilters ?? [])
        {
            item.Validate();
        }
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
        this.PackageWithAllocationConfig.Validate();
        _ = this.PlanPhaseOrder;
        this.PriceType.Validate();
        _ = this.ReplacesPriceID;
        this.DimensionalPriceConfiguration?.Validate();
    }

    public PackageWithAllocation()
    {
        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PackageWithAllocation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PackageWithAllocation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
