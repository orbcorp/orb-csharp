using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Models = Orb.Models;
using System = System;

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
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
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
    public required List<global::Orb.Models.Plans.Adjustment1> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustments",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Plans.Adjustment1>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new System::ArgumentNullException("adjustments")
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

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
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
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
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
                    new System::ArgumentOutOfRangeException(
                        "description",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'description' cannot be null",
                    new System::ArgumentNullException("description")
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

    public required Discount1? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Discount1?>(element, ModelBase.SerializerOptions);
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
                    new System::ArgumentOutOfRangeException(
                        "invoicing_currency",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'invoicing_currency' cannot be null",
                    new System::ArgumentNullException("invoicing_currency")
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
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
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
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
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

    public required List<PlanPhaseModel>? PlanPhases
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phases", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PlanPhaseModel>?>(
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
    public required List<Models::Price> Prices
    {
        get
        {
            if (!this.Properties.TryGetValue("prices", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'prices' cannot be null",
                    new System::ArgumentOutOfRangeException("prices", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Models::Price>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'prices' cannot be null",
                    new System::ArgumentNullException("prices")
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
                    new System::ArgumentOutOfRangeException("product", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Product>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'product' cannot be null",
                    new System::ArgumentNullException("product")
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

    public required ApiEnum<string, Status1> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status1>>(
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
                    new System::ArgumentOutOfRangeException(
                        "trial_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TrialConfig>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'trial_config' cannot be null",
                    new System::ArgumentNullException("trial_config")
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
                    new System::ArgumentOutOfRangeException("version", "Missing required argument")
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

[JsonConverter(typeof(global::Orb.Models.Plans.Adjustment1Converter))]
public record class Adjustment1
{
    public object Value { get; private init; }

    public string ID
    {
        get
        {
            return Match(
                planPhaseUsageDiscount: (x) => x.ID,
                planPhaseAmountDiscount: (x) => x.ID,
                planPhasePercentageDiscount: (x) => x.ID,
                planPhaseMinimum: (x) => x.ID,
                planPhaseMaximum: (x) => x.ID
            );
        }
    }

    public bool IsInvoiceLevel
    {
        get
        {
            return Match(
                planPhaseUsageDiscount: (x) => x.IsInvoiceLevel,
                planPhaseAmountDiscount: (x) => x.IsInvoiceLevel,
                planPhasePercentageDiscount: (x) => x.IsInvoiceLevel,
                planPhaseMinimum: (x) => x.IsInvoiceLevel,
                planPhaseMaximum: (x) => x.IsInvoiceLevel
            );
        }
    }

    public long? PlanPhaseOrder
    {
        get
        {
            return Match<long?>(
                planPhaseUsageDiscount: (x) => x.PlanPhaseOrder,
                planPhaseAmountDiscount: (x) => x.PlanPhaseOrder,
                planPhasePercentageDiscount: (x) => x.PlanPhaseOrder,
                planPhaseMinimum: (x) => x.PlanPhaseOrder,
                planPhaseMaximum: (x) => x.PlanPhaseOrder
            );
        }
    }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                planPhaseUsageDiscount: (x) => x.Reason,
                planPhaseAmountDiscount: (x) => x.Reason,
                planPhasePercentageDiscount: (x) => x.Reason,
                planPhaseMinimum: (x) => x.Reason,
                planPhaseMaximum: (x) => x.Reason
            );
        }
    }

    public string? ReplacesAdjustmentID
    {
        get
        {
            return Match<string?>(
                planPhaseUsageDiscount: (x) => x.ReplacesAdjustmentID,
                planPhaseAmountDiscount: (x) => x.ReplacesAdjustmentID,
                planPhasePercentageDiscount: (x) => x.ReplacesAdjustmentID,
                planPhaseMinimum: (x) => x.ReplacesAdjustmentID,
                planPhaseMaximum: (x) => x.ReplacesAdjustmentID
            );
        }
    }

    public Adjustment1(PlanPhaseUsageDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment1(PlanPhaseAmountDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment1(PlanPhasePercentageDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment1(PlanPhaseMinimumAdjustment value)
    {
        Value = value;
    }

    public Adjustment1(PlanPhaseMaximumAdjustment value)
    {
        Value = value;
    }

    Adjustment1(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Plans.Adjustment1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickPlanPhaseUsageDiscount(
        [NotNullWhen(true)] out PlanPhaseUsageDiscountAdjustment? value
    )
    {
        value = this.Value as PlanPhaseUsageDiscountAdjustment;
        return value != null;
    }

    public bool TryPickPlanPhaseAmountDiscount(
        [NotNullWhen(true)] out PlanPhaseAmountDiscountAdjustment? value
    )
    {
        value = this.Value as PlanPhaseAmountDiscountAdjustment;
        return value != null;
    }

    public bool TryPickPlanPhasePercentageDiscount(
        [NotNullWhen(true)] out PlanPhasePercentageDiscountAdjustment? value
    )
    {
        value = this.Value as PlanPhasePercentageDiscountAdjustment;
        return value != null;
    }

    public bool TryPickPlanPhaseMinimum([NotNullWhen(true)] out PlanPhaseMinimumAdjustment? value)
    {
        value = this.Value as PlanPhaseMinimumAdjustment;
        return value != null;
    }

    public bool TryPickPlanPhaseMaximum([NotNullWhen(true)] out PlanPhaseMaximumAdjustment? value)
    {
        value = this.Value as PlanPhaseMaximumAdjustment;
        return value != null;
    }

    public void Switch(
        System::Action<PlanPhaseUsageDiscountAdjustment> planPhaseUsageDiscount,
        System::Action<PlanPhaseAmountDiscountAdjustment> planPhaseAmountDiscount,
        System::Action<PlanPhasePercentageDiscountAdjustment> planPhasePercentageDiscount,
        System::Action<PlanPhaseMinimumAdjustment> planPhaseMinimum,
        System::Action<PlanPhaseMaximumAdjustment> planPhaseMaximum
    )
    {
        switch (this.Value)
        {
            case PlanPhaseUsageDiscountAdjustment value:
                planPhaseUsageDiscount(value);
                break;
            case PlanPhaseAmountDiscountAdjustment value:
                planPhaseAmountDiscount(value);
                break;
            case PlanPhasePercentageDiscountAdjustment value:
                planPhasePercentageDiscount(value);
                break;
            case PlanPhaseMinimumAdjustment value:
                planPhaseMinimum(value);
                break;
            case PlanPhaseMaximumAdjustment value:
                planPhaseMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment1");
        }
    }

    public T Match<T>(
        System::Func<PlanPhaseUsageDiscountAdjustment, T> planPhaseUsageDiscount,
        System::Func<PlanPhaseAmountDiscountAdjustment, T> planPhaseAmountDiscount,
        System::Func<PlanPhasePercentageDiscountAdjustment, T> planPhasePercentageDiscount,
        System::Func<PlanPhaseMinimumAdjustment, T> planPhaseMinimum,
        System::Func<PlanPhaseMaximumAdjustment, T> planPhaseMaximum
    )
    {
        return this.Value switch
        {
            PlanPhaseUsageDiscountAdjustment value => planPhaseUsageDiscount(value),
            PlanPhaseAmountDiscountAdjustment value => planPhaseAmountDiscount(value),
            PlanPhasePercentageDiscountAdjustment value => planPhasePercentageDiscount(value),
            PlanPhaseMinimumAdjustment value => planPhaseMinimum(value),
            PlanPhaseMaximumAdjustment value => planPhaseMaximum(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment1"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Adjustment1Converter : JsonConverter<global::Orb.Models.Plans.Adjustment1>
{
    public override global::Orb.Models.Plans.Adjustment1? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = json.GetProperty("adjustment_type").GetString();
        }
        catch
        {
            adjustmentType = null;
        }

        switch (adjustmentType)
        {
            case "usage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PlanPhaseUsageDiscountAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Plans.Adjustment1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PlanPhaseUsageDiscountAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "amount_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustment>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Plans.Adjustment1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PlanPhaseAmountDiscountAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percentage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PlanPhasePercentageDiscountAdjustment>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Plans.Adjustment1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PlanPhasePercentageDiscountAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PlanPhaseMinimumAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Plans.Adjustment1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PlanPhaseMinimumAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "maximum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PlanPhaseMaximumAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Plans.Adjustment1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PlanPhaseMaximumAdjustment'",
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
        global::Orb.Models.Plans.Adjustment1 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<BasePlan>))]
public sealed record class BasePlan : ModelBase, IFromRaw<BasePlan>
{
    public required string? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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

    public required string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
    }

    public BasePlan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BasePlan(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BasePlan FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<PlanPhaseModel>))]
public sealed record class PlanPhaseModel : ModelBase, IFromRaw<PlanPhaseModel>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
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

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Discount1? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Discount1?>(element, ModelBase.SerializerOptions);
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
    /// How many terms of length `duration_unit` this phase is active for. If null,
    /// this phase is evergreen and active indefinitely
    /// </summary>
    public required long? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Plans.DurationUnitModel>? DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Orb.Models.Plans.DurationUnitModel
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration_unit"] = JsonSerializer.SerializeToElement(
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
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
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
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get
        {
            if (!this.Properties.TryGetValue("order", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'order' cannot be null",
                    new System::ArgumentOutOfRangeException("order", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        this.Discount?.Validate();
        _ = this.Duration;
        this.DurationUnit?.Validate();
        this.Maximum?.Validate();
        _ = this.MaximumAmount;
        this.Minimum?.Validate();
        _ = this.MinimumAmount;
        _ = this.Name;
        _ = this.Order;
    }

    public PlanPhaseModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPhaseModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanPhaseModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(global::Orb.Models.Plans.DurationUnitModelConverter))]
public enum DurationUnitModel
{
    Daily,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
}

sealed class DurationUnitModelConverter : JsonConverter<global::Orb.Models.Plans.DurationUnitModel>
{
    public override global::Orb.Models.Plans.DurationUnitModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => global::Orb.Models.Plans.DurationUnitModel.Daily,
            "monthly" => global::Orb.Models.Plans.DurationUnitModel.Monthly,
            "quarterly" => global::Orb.Models.Plans.DurationUnitModel.Quarterly,
            "semi_annual" => global::Orb.Models.Plans.DurationUnitModel.SemiAnnual,
            "annual" => global::Orb.Models.Plans.DurationUnitModel.Annual,
            _ => (global::Orb.Models.Plans.DurationUnitModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Plans.DurationUnitModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Plans.DurationUnitModel.Daily => "daily",
                global::Orb.Models.Plans.DurationUnitModel.Monthly => "monthly",
                global::Orb.Models.Plans.DurationUnitModel.Quarterly => "quarterly",
                global::Orb.Models.Plans.DurationUnitModel.SemiAnnual => "semi_annual",
                global::Orb.Models.Plans.DurationUnitModel.Annual => "annual",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Product>))]
public sealed record class Product : ModelBase, IFromRaw<Product>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
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

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
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
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
    }

    public Product() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Product(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Product FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(Status1Converter))]
public enum Status1
{
    Active,
    Archived,
    Draft,
}

sealed class Status1Converter : JsonConverter<Status1>
{
    public override Status1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status1.Active,
            "archived" => Status1.Archived,
            "draft" => Status1.Draft,
            _ => (Status1)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status1 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status1.Active => "active",
                Status1.Archived => "archived",
                Status1.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<TrialConfig>))]
public sealed record class TrialConfig : ModelBase, IFromRaw<TrialConfig>
{
    public required long? TrialPeriod
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trial_period"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, TrialPeriodUnit> TrialPeriodUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period_unit", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'trial_period_unit' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "trial_period_unit",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TrialPeriodUnit>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["trial_period_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TrialPeriod;
        this.TrialPeriodUnit.Validate();
    }

    public TrialConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TrialConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(TrialPeriodUnitConverter))]
public enum TrialPeriodUnit
{
    Days,
}

sealed class TrialPeriodUnitConverter : JsonConverter<TrialPeriodUnit>
{
    public override TrialPeriodUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "days" => TrialPeriodUnit.Days,
            _ => (TrialPeriodUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialPeriodUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrialPeriodUnit.Days => "days",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
