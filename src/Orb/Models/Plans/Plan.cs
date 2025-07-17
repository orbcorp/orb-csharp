using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using PlanProperties = Orb.Models.Plans.PlanProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Plans;

/// <summary>
/// The [Plan](/core-concepts#plan-and-price) resource represents a plan that can
/// be subscribed to by a customer. Plans define the billing behavior of the subscription.
/// You can see more about how to configure prices in the [Price resource](/reference/price).
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Plan>))]
public sealed record class Plan : Orb::ModelBase, Orb::IFromRaw<Plan>
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

    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required Generic::List<PlanProperties::Adjustment> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustments",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<PlanProperties::Adjustment>>(
                    element
                ) ?? throw new System::ArgumentNullException("adjustments");
        }
        set { this.Properties["adjustments"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required PlanProperties::BasePlan? BasePlan
    {
        get
        {
            if (!this.Properties.TryGetValue("base_plan", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "base_plan",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<PlanProperties::BasePlan?>(element);
        }
        set { this.Properties["base_plan"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The parent plan id if the given plan was created by overriding one or more
    /// of the parent's prices
    /// </summary>
    public required string? BasePlanID
    {
        get
        {
            if (!this.Properties.TryGetValue("base_plan_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "base_plan_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["base_plan_id"] = Json::JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// An ISO 4217 currency string or custom pricing unit (`credits`) for this plan's prices.
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

    /// <summary>
    /// The default memo text on the invoices corresponding to subscriptions on this
    /// plan. Note that each subscription may configure its own memo.
    /// </summary>
    public required string? DefaultInvoiceMemo
    {
        get
        {
            if (!this.Properties.TryGetValue("default_invoice_memo", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "default_invoice_memo",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["default_invoice_memo"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required string Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "description",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("description");
        }
        set { this.Properties["description"] = Json::JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// An optional user-defined ID for this plan resource, used throughout the system
    /// as an alias for this Plan. Use this field to identify a plan by an existing
    /// identifier in your system.
    /// </summary>
    public required string? ExternalPlanID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_plan_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "external_plan_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_plan_id"] = Json::JsonSerializer.SerializeToElement(value);
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
            if (!this.Properties.TryGetValue("invoicing_currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoicing_currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("invoicing_currency");
        }
        set
        {
            this.Properties["invoicing_currency"] = Json::JsonSerializer.SerializeToElement(value);
        }
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
    /// Determines the difference between the invoice issue date and the due date. A
    /// value of "0" here signifies that invoices are due on issue, whereas a value
    /// of "30" means that the customer has a month to pay the invoice before its overdue.
    /// Note that individual subscriptions or invoices may set a different net terms configuration.
    /// </summary>
    public required long? NetTerms
    {
        get
        {
            if (!this.Properties.TryGetValue("net_terms", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "net_terms",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["net_terms"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Generic::List<PlanProperties::PlanPhase>? PlanPhases
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phases", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "plan_phases",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<PlanProperties::PlanPhase>?>(
                element
            );
        }
        set { this.Properties["plan_phases"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across all
    /// phases of the plan.
    /// </summary>
    public required Generic::List<Models::Price> Prices
    {
        get
        {
            if (!this.Properties.TryGetValue("prices", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "prices",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::Price>>(element)
                ?? throw new System::ArgumentNullException("prices");
        }
        set { this.Properties["prices"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required PlanProperties::Product Product
    {
        get
        {
            if (!this.Properties.TryGetValue("product", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "product",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<PlanProperties::Product>(element)
                ?? throw new System::ArgumentNullException("product");
        }
        set { this.Properties["product"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required PlanProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "status",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<PlanProperties::Status>(element)
                ?? throw new System::ArgumentNullException("status");
        }
        set { this.Properties["status"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required PlanProperties::TrialConfig TrialConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_config", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "trial_config",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<PlanProperties::TrialConfig>(element)
                ?? throw new System::ArgumentNullException("trial_config");
        }
        set { this.Properties["trial_config"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required long Version
    {
        get
        {
            if (!this.Properties.TryGetValue("version", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "version",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["version"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    Plan(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Plan FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
