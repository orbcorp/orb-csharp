using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans.PlanProperties;

namespace Orb.Models.Plans;

/// <summary>
/// The [Plan](/core-concepts#plan-and-price) resource represents a plan that can
/// be subscribed to by a customer. Plans define the billing behavior of the subscription.
/// You can see more about how to configure prices in the [Price resource](/reference/price).
/// </summary>
[JsonConverter(typeof(ModelConverter<Plan>))]
public sealed record class Plan : ModelBase, IFromRaw<Plan>
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

    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required List<Adjustment> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new ArgumentOutOfRangeException("adjustments", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Adjustment>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new ArgumentNullException("adjustments")
                );
        }
        set
        {
            this.Properties["adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BasePlan? BasePlan
    {
        get
        {
            if (!this.Properties.TryGetValue("base_plan", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BasePlan?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["base_plan"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The parent plan id if the given plan was created by overriding one or more
    /// of the parent's prices
    /// </summary>
    public required string? BasePlanID
    {
        get
        {
            if (!this.Properties.TryGetValue("base_plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["base_plan_id"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// An ISO 4217 currency string or custom pricing unit (`credits`) for this plan's prices.
    /// </summary>
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

    /// <summary>
    /// The default memo text on the invoices corresponding to subscriptions on this
    /// plan. Note that each subscription may configure its own memo.
    /// </summary>
    public required string? DefaultInvoiceMemo
    {
        get
        {
            if (!this.Properties.TryGetValue("default_invoice_memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["default_invoice_memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'description' cannot be null",
                    new ArgumentOutOfRangeException("description", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'description' cannot be null",
                    new ArgumentNullException("description")
                );
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// An optional user-defined ID for this plan resource, used throughout the system
    /// as an alias for this Plan. Use this field to identify a plan by an existing
    /// identifier in your system.
    /// </summary>
    public required string? ExternalPlanID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["external_plan_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this plan is billed in. Matches `currency`
    /// unless `currency` is a custom pricing unit.
    /// </summary>
    public required string InvoicingCurrency
    {
        get
        {
            if (!this.Properties.TryGetValue("invoicing_currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoicing_currency' cannot be null",
                    new ArgumentOutOfRangeException(
                        "invoicing_currency",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'invoicing_currency' cannot be null",
                    new ArgumentNullException("invoicing_currency")
                );
        }
        set
        {
            this.Properties["invoicing_currency"] = JsonSerializer.SerializeToElement(
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

    public required Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Minimum?>(element, ModelBase.SerializerOptions);
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
    /// Determines the difference between the invoice issue date and the due date.
    /// A value of "0" here signifies that invoices are due on issue, whereas a value
    /// of "30" means that the customer has a month to pay the invoice before its
    /// overdue. Note that individual subscriptions or invoices may set a different
    /// net terms configuration.
    /// </summary>
    public required long? NetTerms
    {
        get
        {
            if (!this.Properties.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["net_terms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<PlanPhase>? PlanPhases
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phases", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PlanPhase>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["plan_phases"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across
    /// all phases of the plan.
    /// </summary>
    public required List<Price> Prices
    {
        get
        {
            if (!this.Properties.TryGetValue("prices", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'prices' cannot be null",
                    new ArgumentOutOfRangeException("prices", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Price>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'prices' cannot be null",
                    new ArgumentNullException("prices")
                );
        }
        set
        {
            this.Properties["prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Product Product
    {
        get
        {
            if (!this.Properties.TryGetValue("product", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'product' cannot be null",
                    new ArgumentOutOfRangeException("product", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Product>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'product' cannot be null",
                    new ArgumentNullException("product")
                );
        }
        set
        {
            this.Properties["product"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required TrialConfig TrialConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'trial_config' cannot be null",
                    new ArgumentOutOfRangeException("trial_config", "Missing required argument")
                );

            return JsonSerializer.Deserialize<TrialConfig>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'trial_config' cannot be null",
                    new ArgumentNullException("trial_config")
                );
        }
        set
        {
            this.Properties["trial_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Version
    {
        get
        {
            if (!this.Properties.TryGetValue("version", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Adjustments)
        {
            item.Validate();
        }
        this.BasePlan?.Validate();
        _ = this.BasePlanID;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.DefaultInvoiceMemo;
        _ = this.Description;
        this.Discount?.Validate();
        _ = this.ExternalPlanID;
        _ = this.InvoicingCurrency;
        this.Maximum?.Validate();
        _ = this.MaximumAmount;
        _ = this.Metadata;
        this.Minimum?.Validate();
        _ = this.MinimumAmount;
        _ = this.Name;
        _ = this.NetTerms;
        foreach (var item in this.PlanPhases ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Prices)
        {
            item.Validate();
        }
        this.Product.Validate();
        this.Status.Validate();
        this.TrialConfig.Validate();
        _ = this.Version;
    }

    public Plan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Plan(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Plan FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
