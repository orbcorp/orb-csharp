using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Models = Orb.Models;
using PlanProperties = Orb.Models.Plans.PlanProperties;

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
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required List<PlanProperties::Adjustment> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out JsonElement element))
                throw new ArgumentOutOfRangeException("adjustments", "Missing required argument");

            return JsonSerializer.Deserialize<List<PlanProperties::Adjustment>>(element)
                ?? throw new ArgumentNullException("adjustments");
        }
        set { this.Properties["adjustments"] = JsonSerializer.SerializeToElement(value); }
    }

    public required PlanProperties::BasePlan? BasePlan
    {
        get
        {
            if (!this.Properties.TryGetValue("base_plan", out JsonElement element))
                throw new ArgumentOutOfRangeException("base_plan", "Missing required argument");

            return JsonSerializer.Deserialize<PlanProperties::BasePlan?>(element);
        }
        set { this.Properties["base_plan"] = JsonSerializer.SerializeToElement(value); }
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
                throw new ArgumentOutOfRangeException("base_plan_id", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["base_plan_id"] = JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// An ISO 4217 currency string or custom pricing unit (`credits`) for this plan's prices.
    /// </summary>
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

    /// <summary>
    /// The default memo text on the invoices corresponding to subscriptions on this
    /// plan. Note that each subscription may configure its own memo.
    /// </summary>
    public required string? DefaultInvoiceMemo
    {
        get
        {
            if (!this.Properties.TryGetValue("default_invoice_memo", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "default_invoice_memo",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["default_invoice_memo"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                throw new ArgumentOutOfRangeException("description", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("description");
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
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
                throw new ArgumentOutOfRangeException(
                    "external_plan_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["external_plan_id"] = JsonSerializer.SerializeToElement(value); }
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
                throw new ArgumentOutOfRangeException(
                    "invoicing_currency",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("invoicing_currency");
        }
        set { this.Properties["invoicing_currency"] = JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// Determines the difference between the invoice issue date and the due date. A
    /// value of "0" here signifies that invoices are due on issue, whereas a value
    /// of "30" means that the customer has a month to pay the invoice before its overdue.
    /// Note that individual subscriptions or invoices may set a different net terms configuration.
    /// </summary>
    public required long? NetTerms
    {
        get
        {
            if (!this.Properties.TryGetValue("net_terms", out JsonElement element))
                throw new ArgumentOutOfRangeException("net_terms", "Missing required argument");

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["net_terms"] = JsonSerializer.SerializeToElement(value); }
    }

    public required List<PlanProperties::PlanPhase>? PlanPhases
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phases", out JsonElement element))
                throw new ArgumentOutOfRangeException("plan_phases", "Missing required argument");

            return JsonSerializer.Deserialize<List<PlanProperties::PlanPhase>?>(element);
        }
        set { this.Properties["plan_phases"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across all
    /// phases of the plan.
    /// </summary>
    public required List<Models::Price> Prices
    {
        get
        {
            if (!this.Properties.TryGetValue("prices", out JsonElement element))
                throw new ArgumentOutOfRangeException("prices", "Missing required argument");

            return JsonSerializer.Deserialize<List<Models::Price>>(element)
                ?? throw new ArgumentNullException("prices");
        }
        set { this.Properties["prices"] = JsonSerializer.SerializeToElement(value); }
    }

    public required PlanProperties::Product Product
    {
        get
        {
            if (!this.Properties.TryGetValue("product", out JsonElement element))
                throw new ArgumentOutOfRangeException("product", "Missing required argument");

            return JsonSerializer.Deserialize<PlanProperties::Product>(element)
                ?? throw new ArgumentNullException("product");
        }
        set { this.Properties["product"] = JsonSerializer.SerializeToElement(value); }
    }

    public required PlanProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new ArgumentOutOfRangeException("status", "Missing required argument");

            return JsonSerializer.Deserialize<PlanProperties::Status>(element)
                ?? throw new ArgumentNullException("status");
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public required PlanProperties::TrialConfig TrialConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_config", out JsonElement element))
                throw new ArgumentOutOfRangeException("trial_config", "Missing required argument");

            return JsonSerializer.Deserialize<PlanProperties::TrialConfig>(element)
                ?? throw new ArgumentNullException("trial_config");
        }
        set { this.Properties["trial_config"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long Version
    {
        get
        {
            if (!this.Properties.TryGetValue("version", out JsonElement element))
                throw new ArgumentOutOfRangeException("version", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["version"] = JsonSerializer.SerializeToElement(value); }
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
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
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
