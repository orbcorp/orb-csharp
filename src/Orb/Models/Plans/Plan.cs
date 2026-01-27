using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
[JsonConverter(typeof(JsonModelConverter<Plan, PlanFromRaw>))]
public sealed record class Plan : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required IReadOnlyList<PlanAdjustment> Adjustments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PlanAdjustment>>("adjustments");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanAdjustment>>(
                "adjustments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Legacy field representing the parent plan if the current plan is a 'child
    /// plan', overriding prices from the parent.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required BasePlan? BasePlan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BasePlan>("base_plan");
        }
        init { this._rawData.Set("base_plan", value); }
    }

    /// <summary>
    /// Legacy field representing the parent plan ID if the current plan is a 'child
    /// plan', overriding prices from the parent.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required string? BasePlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("base_plan_id");
        }
        init { this._rawData.Set("base_plan_id", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string or custom pricing unit (`credits`) for this plan's prices.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The default memo text on the invoices corresponding to subscriptions on this
    /// plan. Note that each subscription may configure its own memo.
    /// </summary>
    public required string? DefaultInvoiceMemo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("default_invoice_memo");
        }
        init { this._rawData.Set("default_invoice_memo", value); }
    }

    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    [System::Obsolete("deprecated")]
    public required SharedDiscount? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SharedDiscount>("discount");
        }
        init { this._rawData.Set("discount", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_plan_id");
        }
        init { this._rawData.Set("external_plan_id", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this plan is billed in. Matches `currency`
    /// unless `currency` is a custom pricing unit.
    /// </summary>
    public required string InvoicingCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoicing_currency");
        }
        init { this._rawData.Set("invoicing_currency", value); }
    }

    [System::Obsolete("deprecated")]
    public required Maximum? Maximum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Maximum>("maximum");
        }
        init { this._rawData.Set("maximum", value); }
    }

    [System::Obsolete("deprecated")]
    public required string? MaximumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maximum_amount");
        }
        init { this._rawData.Set("maximum_amount", value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    [System::Obsolete("deprecated")]
    public required Minimum? Minimum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Minimum>("minimum");
        }
        init { this._rawData.Set("minimum", value); }
    }

    [System::Obsolete("deprecated")]
    public required string? MinimumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("net_terms");
        }
        init { this._rawData.Set("net_terms", value); }
    }

    public required IReadOnlyList<PlanPlanPhase>? PlanPhases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PlanPlanPhase>>("plan_phases");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanPlanPhase>?>(
                "plan_phases",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across
    /// all phases of the plan.
    /// </summary>
    public required IReadOnlyList<Models::Price> Prices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Models::Price>>("prices");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Models::Price>>(
                "prices",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Product Product
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Product>("product");
        }
        init { this._rawData.Set("product", value); }
    }

    public required ApiEnum<string, PlanStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PlanStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required TrialConfig TrialConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TrialConfig>("trial_config");
        }
        init { this._rawData.Set("trial_config", value); }
    }

    public required long Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
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

    [System::Obsolete(
        "Required properties are deprecated: base_plan, base_plan_id, currency, discount, maximum, maximum_amount, minimum, minimum_amount"
    )]
    public Plan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [System::Obsolete(
        "Required properties are deprecated: base_plan, base_plan_id, currency, discount, maximum, maximum_amount, minimum, minimum_amount"
    )]
    public Plan(Plan plan)
        : base(plan) { }
#pragma warning restore CS8618

    [System::Obsolete(
        "Required properties are deprecated: base_plan, base_plan_id, currency, discount, maximum, maximum_amount, minimum, minimum_amount"
    )]
    public Plan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete(
        "Required properties are deprecated: base_plan, base_plan_id, currency, discount, maximum, maximum_amount, minimum, minimum_amount"
    )]
    [SetsRequiredMembers]
    Plan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanFromRaw.FromRawUnchecked"/>
    public static Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanFromRaw : IFromRawJson<Plan>
{
    /// <inheritdoc/>
    public Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Plan.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanAdjustmentConverter))]
public record class PlanAdjustment : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public PlanAdjustment(
        Models::PlanPhaseUsageDiscountAdjustment value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanAdjustment(
        Models::PlanPhaseAmountDiscountAdjustment value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanAdjustment(
        Models::PlanPhasePercentageDiscountAdjustment value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanAdjustment(Models::PlanPhaseMinimumAdjustment value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PlanAdjustment(Models::PlanPhaseMaximumAdjustment value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PlanAdjustment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Models::PlanPhaseUsageDiscountAdjustment"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlanPhaseUsageDiscount(out var value)) {
    ///     // `value` is of type `Models::PlanPhaseUsageDiscountAdjustment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlanPhaseUsageDiscount(
        [NotNullWhen(true)] out Models::PlanPhaseUsageDiscountAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhaseUsageDiscountAdjustment;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Models::PlanPhaseAmountDiscountAdjustment"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlanPhaseAmountDiscount(out var value)) {
    ///     // `value` is of type `Models::PlanPhaseAmountDiscountAdjustment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlanPhaseAmountDiscount(
        [NotNullWhen(true)] out Models::PlanPhaseAmountDiscountAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhaseAmountDiscountAdjustment;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Models::PlanPhasePercentageDiscountAdjustment"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlanPhasePercentageDiscount(out var value)) {
    ///     // `value` is of type `Models::PlanPhasePercentageDiscountAdjustment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlanPhasePercentageDiscount(
        [NotNullWhen(true)] out Models::PlanPhasePercentageDiscountAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhasePercentageDiscountAdjustment;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Models::PlanPhaseMinimumAdjustment"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlanPhaseMinimum(out var value)) {
    ///     // `value` is of type `Models::PlanPhaseMinimumAdjustment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlanPhaseMinimum(
        [NotNullWhen(true)] out Models::PlanPhaseMinimumAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhaseMinimumAdjustment;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Models::PlanPhaseMaximumAdjustment"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlanPhaseMaximum(out var value)) {
    ///     // `value` is of type `Models::PlanPhaseMaximumAdjustment`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlanPhaseMaximum(
        [NotNullWhen(true)] out Models::PlanPhaseMaximumAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhaseMaximumAdjustment;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Models::PlanPhaseUsageDiscountAdjustment value) => {...},
    ///     (Models::PlanPhaseAmountDiscountAdjustment value) => {...},
    ///     (Models::PlanPhasePercentageDiscountAdjustment value) => {...},
    ///     (Models::PlanPhaseMinimumAdjustment value) => {...},
    ///     (Models::PlanPhaseMaximumAdjustment value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Models::PlanPhaseUsageDiscountAdjustment> planPhaseUsageDiscount,
        System::Action<Models::PlanPhaseAmountDiscountAdjustment> planPhaseAmountDiscount,
        System::Action<Models::PlanPhasePercentageDiscountAdjustment> planPhasePercentageDiscount,
        System::Action<Models::PlanPhaseMinimumAdjustment> planPhaseMinimum,
        System::Action<Models::PlanPhaseMaximumAdjustment> planPhaseMaximum
    )
    {
        switch (this.Value)
        {
            case Models::PlanPhaseUsageDiscountAdjustment value:
                planPhaseUsageDiscount(value);
                break;
            case Models::PlanPhaseAmountDiscountAdjustment value:
                planPhaseAmountDiscount(value);
                break;
            case Models::PlanPhasePercentageDiscountAdjustment value:
                planPhasePercentageDiscount(value);
                break;
            case Models::PlanPhaseMinimumAdjustment value:
                planPhaseMinimum(value);
                break;
            case Models::PlanPhaseMaximumAdjustment value:
                planPhaseMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of PlanAdjustment"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Models::PlanPhaseUsageDiscountAdjustment value) => {...},
    ///     (Models::PlanPhaseAmountDiscountAdjustment value) => {...},
    ///     (Models::PlanPhasePercentageDiscountAdjustment value) => {...},
    ///     (Models::PlanPhaseMinimumAdjustment value) => {...},
    ///     (Models::PlanPhaseMaximumAdjustment value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Models::PlanPhaseUsageDiscountAdjustment, T> planPhaseUsageDiscount,
        System::Func<Models::PlanPhaseAmountDiscountAdjustment, T> planPhaseAmountDiscount,
        System::Func<Models::PlanPhasePercentageDiscountAdjustment, T> planPhasePercentageDiscount,
        System::Func<Models::PlanPhaseMinimumAdjustment, T> planPhaseMinimum,
        System::Func<Models::PlanPhaseMaximumAdjustment, T> planPhaseMaximum
    )
    {
        return this.Value switch
        {
            Models::PlanPhaseUsageDiscountAdjustment value => planPhaseUsageDiscount(value),
            Models::PlanPhaseAmountDiscountAdjustment value => planPhaseAmountDiscount(value),
            Models::PlanPhasePercentageDiscountAdjustment value => planPhasePercentageDiscount(
                value
            ),
            Models::PlanPhaseMinimumAdjustment value => planPhaseMinimum(value),
            Models::PlanPhaseMaximumAdjustment value => planPhaseMaximum(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of PlanAdjustment"
            ),
        };
    }

    public static implicit operator PlanAdjustment(
        Models::PlanPhaseUsageDiscountAdjustment value
    ) => new(value);

    public static implicit operator PlanAdjustment(
        Models::PlanPhaseAmountDiscountAdjustment value
    ) => new(value);

    public static implicit operator PlanAdjustment(
        Models::PlanPhasePercentageDiscountAdjustment value
    ) => new(value);

    public static implicit operator PlanAdjustment(Models::PlanPhaseMinimumAdjustment value) =>
        new(value);

    public static implicit operator PlanAdjustment(Models::PlanPhaseMaximumAdjustment value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of PlanAdjustment");
        }
        this.Switch(
            (planPhaseUsageDiscount) => planPhaseUsageDiscount.Validate(),
            (planPhaseAmountDiscount) => planPhaseAmountDiscount.Validate(),
            (planPhasePercentageDiscount) => planPhasePercentageDiscount.Validate(),
            (planPhaseMinimum) => planPhaseMinimum.Validate(),
            (planPhaseMaximum) => planPhaseMaximum.Validate()
        );
    }

    public virtual bool Equals(PlanAdjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class PlanAdjustmentConverter : JsonConverter<PlanAdjustment>
{
    public override PlanAdjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = element.GetProperty("adjustment_type").GetString();
        }
        catch
        {
            adjustmentType = null;
        }

        switch (adjustmentType)
        {
            case "usage_discount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhaseUsageDiscountAdjustment>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "amount_discount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhaseAmountDiscountAdjustment>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "percentage_discount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhasePercentageDiscountAdjustment>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhaseMinimumAdjustment>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "maximum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhaseMaximumAdjustment>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PlanAdjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Legacy field representing the parent plan if the current plan is a 'child plan',
/// overriding prices from the parent.
/// </summary>
[System::Obsolete("deprecated")]
[JsonConverter(typeof(JsonModelConverter<BasePlan, BasePlanFromRaw>))]
public sealed record class BasePlan : JsonModel
{
    public required string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_plan_id");
        }
        init { this._rawData.Set("external_plan_id", value); }
    }

    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
    }

    public BasePlan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BasePlan(BasePlan basePlan)
        : base(basePlan) { }
#pragma warning restore CS8618

    public BasePlan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BasePlan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BasePlanFromRaw.FromRawUnchecked"/>
    public static BasePlan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BasePlanFromRaw : IFromRawJson<BasePlan>
{
    /// <inheritdoc/>
    public BasePlan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BasePlan.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PlanPlanPhase, PlanPlanPhaseFromRaw>))]
public sealed record class PlanPlanPhase : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required SharedDiscount? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SharedDiscount>("discount");
        }
        init { this._rawData.Set("discount", value); }
    }

    /// <summary>
    /// How many terms of length `duration_unit` this phase is active for. If null,
    /// this phase is evergreen and active indefinitely
    /// </summary>
    public required long? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    public required ApiEnum<string, PlanPlanPhaseDurationUnit>? DurationUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PlanPlanPhaseDurationUnit>>(
                "duration_unit"
            );
        }
        init { this._rawData.Set("duration_unit", value); }
    }

    public required Maximum? Maximum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Maximum>("maximum");
        }
        init { this._rawData.Set("maximum", value); }
    }

    public required string? MaximumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maximum_amount");
        }
        init { this._rawData.Set("maximum_amount", value); }
    }

    public required Minimum? Minimum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Minimum>("minimum");
        }
        init { this._rawData.Set("minimum", value); }
    }

    public required string? MinimumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("order");
        }
        init { this._rawData.Set("order", value); }
    }

    /// <inheritdoc/>
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

    public PlanPlanPhase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanPlanPhase(PlanPlanPhase planPlanPhase)
        : base(planPlanPhase) { }
#pragma warning restore CS8618

    public PlanPlanPhase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPlanPhase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPlanPhaseFromRaw.FromRawUnchecked"/>
    public static PlanPlanPhase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPlanPhaseFromRaw : IFromRawJson<PlanPlanPhase>
{
    /// <inheritdoc/>
    public PlanPlanPhase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanPlanPhase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanPlanPhaseDurationUnitConverter))]
public enum PlanPlanPhaseDurationUnit
{
    Daily,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
}

sealed class PlanPlanPhaseDurationUnitConverter : JsonConverter<PlanPlanPhaseDurationUnit>
{
    public override PlanPlanPhaseDurationUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => PlanPlanPhaseDurationUnit.Daily,
            "monthly" => PlanPlanPhaseDurationUnit.Monthly,
            "quarterly" => PlanPlanPhaseDurationUnit.Quarterly,
            "semi_annual" => PlanPlanPhaseDurationUnit.SemiAnnual,
            "annual" => PlanPlanPhaseDurationUnit.Annual,
            _ => (PlanPlanPhaseDurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPlanPhaseDurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPlanPhaseDurationUnit.Daily => "daily",
                PlanPlanPhaseDurationUnit.Monthly => "monthly",
                PlanPlanPhaseDurationUnit.Quarterly => "quarterly",
                PlanPlanPhaseDurationUnit.SemiAnnual => "semi_annual",
                PlanPlanPhaseDurationUnit.Annual => "annual",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Product, ProductFromRaw>))]
public sealed record class Product : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
    }

    public Product() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Product(Product product)
        : base(product) { }
#pragma warning restore CS8618

    public Product(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Product(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductFromRaw.FromRawUnchecked"/>
    public static Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductFromRaw : IFromRawJson<Product>
{
    /// <inheritdoc/>
    public Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Product.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanStatusConverter))]
public enum PlanStatus
{
    Active,
    Archived,
    Draft,
}

sealed class PlanStatusConverter : JsonConverter<PlanStatus>
{
    public override PlanStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => PlanStatus.Active,
            "archived" => PlanStatus.Archived,
            "draft" => PlanStatus.Draft,
            _ => (PlanStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanStatus.Active => "active",
                PlanStatus.Archived => "archived",
                PlanStatus.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TrialConfig, TrialConfigFromRaw>))]
public sealed record class TrialConfig : JsonModel
{
    public required long? TrialPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("trial_period");
        }
        init { this._rawData.Set("trial_period", value); }
    }

    public required ApiEnum<string, TrialPeriodUnit> TrialPeriodUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TrialPeriodUnit>>(
                "trial_period_unit"
            );
        }
        init { this._rawData.Set("trial_period_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TrialPeriod;
        this.TrialPeriodUnit.Validate();
    }

    public TrialConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrialConfig(TrialConfig trialConfig)
        : base(trialConfig) { }
#pragma warning restore CS8618

    public TrialConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrialConfigFromRaw.FromRawUnchecked"/>
    public static TrialConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrialConfigFromRaw : IFromRawJson<TrialConfig>
{
    /// <inheritdoc/>
    public TrialConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrialConfig.FromRawUnchecked(rawData);
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
