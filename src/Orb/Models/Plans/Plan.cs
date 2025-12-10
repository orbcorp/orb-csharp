using System.Collections.Frozen;
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
[JsonConverter(typeof(ModelConverter<Plan, PlanFromRaw>))]
public sealed record class Plan : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required IReadOnlyList<PlanAdjustment> Adjustments
    {
        get { return ModelBase.GetNotNullClass<List<PlanAdjustment>>(this.RawData, "adjustments"); }
        init { ModelBase.Set(this._rawData, "adjustments", value); }
    }

    /// <summary>
    /// Legacy field representing the parent plan if the current plan is a 'child
    /// plan', overriding prices from the parent.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required BasePlan? BasePlan
    {
        get { return ModelBase.GetNullableClass<BasePlan>(this.RawData, "base_plan"); }
        init { ModelBase.Set(this._rawData, "base_plan", value); }
    }

    /// <summary>
    /// Legacy field representing the parent plan ID if the current plan is a 'child
    /// plan', overriding prices from the parent.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required string? BasePlanID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "base_plan_id"); }
        init { ModelBase.Set(this._rawData, "base_plan_id", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string or custom pricing unit (`credits`) for this plan's prices.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The default memo text on the invoices corresponding to subscriptions on this
    /// plan. Note that each subscription may configure its own memo.
    /// </summary>
    public required string? DefaultInvoiceMemo
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "default_invoice_memo"); }
        init { ModelBase.Set(this._rawData, "default_invoice_memo", value); }
    }

    public required string Description
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    [System::Obsolete("deprecated")]
    public required SharedDiscount? Discount
    {
        get { return ModelBase.GetNullableClass<SharedDiscount>(this.RawData, "discount"); }
        init { ModelBase.Set(this._rawData, "discount", value); }
    }

    /// <summary>
    /// An optional user-defined ID for this plan resource, used throughout the system
    /// as an alias for this Plan. Use this field to identify a plan by an existing
    /// identifier in your system.
    /// </summary>
    public required string? ExternalPlanID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_plan_id"); }
        init { ModelBase.Set(this._rawData, "external_plan_id", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this plan is billed in. Matches `currency`
    /// unless `currency` is a custom pricing unit.
    /// </summary>
    public required string InvoicingCurrency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "invoicing_currency"); }
        init { ModelBase.Set(this._rawData, "invoicing_currency", value); }
    }

    [System::Obsolete("deprecated")]
    public required Maximum? Maximum
    {
        get { return ModelBase.GetNullableClass<Maximum>(this.RawData, "maximum"); }
        init { ModelBase.Set(this._rawData, "maximum", value); }
    }

    [System::Obsolete("deprecated")]
    public required string? MaximumAmount
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "maximum_amount"); }
        init { ModelBase.Set(this._rawData, "maximum_amount", value); }
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
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    [System::Obsolete("deprecated")]
    public required Minimum? Minimum
    {
        get { return ModelBase.GetNullableClass<Minimum>(this.RawData, "minimum"); }
        init { ModelBase.Set(this._rawData, "minimum", value); }
    }

    [System::Obsolete("deprecated")]
    public required string? MinimumAmount
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "minimum_amount"); }
        init { ModelBase.Set(this._rawData, "minimum_amount", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
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
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "net_terms"); }
        init { ModelBase.Set(this._rawData, "net_terms", value); }
    }

    public required IReadOnlyList<PlanPlanPhase>? PlanPhases
    {
        get { return ModelBase.GetNullableClass<List<PlanPlanPhase>>(this.RawData, "plan_phases"); }
        init { ModelBase.Set(this._rawData, "plan_phases", value); }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across
    /// all phases of the plan.
    /// </summary>
    public required IReadOnlyList<Models::Price> Prices
    {
        get { return ModelBase.GetNotNullClass<List<Models::Price>>(this.RawData, "prices"); }
        init { ModelBase.Set(this._rawData, "prices", value); }
    }

    public required Product Product
    {
        get { return ModelBase.GetNotNullClass<Product>(this.RawData, "product"); }
        init { ModelBase.Set(this._rawData, "product", value); }
    }

    public required ApiEnum<string, PlanStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, PlanStatus>>(this.RawData, "status");
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public required TrialConfig TrialConfig
    {
        get { return ModelBase.GetNotNullClass<TrialConfig>(this.RawData, "trial_config"); }
        init { ModelBase.Set(this._rawData, "trial_config", value); }
    }

    public required long Version
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "version"); }
        init { ModelBase.Set(this._rawData, "version", value); }
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

    [System::Obsolete(
        "Required properties are deprecated: base_plan, base_plan_id, currency, discount, maximum, maximum_amount, minimum, minimum_amount"
    )]
    public Plan(Plan plan)
        : base(plan) { }

    [System::Obsolete(
        "Required properties are deprecated: base_plan, base_plan_id, currency, discount, maximum, maximum_amount, minimum, minimum_amount"
    )]
    public Plan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [System::Obsolete(
        "Required properties are deprecated: base_plan, base_plan_id, currency, discount, maximum, maximum_amount, minimum, minimum_amount"
    )]
    [SetsRequiredMembers]
    Plan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanFromRaw.FromRawUnchecked"/>
    public static Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanFromRaw : IFromRaw<Plan>
{
    /// <inheritdoc/>
    public Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Plan.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanAdjustmentConverter))]
public record class PlanAdjustment
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public PlanAdjustment(Models::PlanPhaseUsageDiscountAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PlanAdjustment(Models::PlanPhaseAmountDiscountAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PlanAdjustment(
        Models::PlanPhasePercentageDiscountAdjustment value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PlanAdjustment(Models::PlanPhaseMinimumAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PlanAdjustment(Models::PlanPhaseMaximumAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PlanAdjustment(JsonElement json)
    {
        this._json = json;
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
    public void Validate()
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
}

sealed class PlanAdjustmentConverter : JsonConverter<PlanAdjustment>
{
    public override PlanAdjustment? Read(
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
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhaseUsageDiscountAdjustment>(
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
            case "amount_discount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhaseAmountDiscountAdjustment>(
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
            case "percentage_discount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhasePercentageDiscountAdjustment>(
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
            case "minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhaseMinimumAdjustment>(
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
            case "maximum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::PlanPhaseMaximumAdjustment>(
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
                return new PlanAdjustment(json);
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
[JsonConverter(typeof(ModelConverter<BasePlan, BasePlanFromRaw>))]
public sealed record class BasePlan : ModelBase
{
    public required string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// An optional user-defined ID for this plan resource, used throughout the system
    /// as an alias for this Plan. Use this field to identify a plan by an existing
    /// identifier in your system.
    /// </summary>
    public required string? ExternalPlanID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_plan_id"); }
        init { ModelBase.Set(this._rawData, "external_plan_id", value); }
    }

    public required string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
    }

    public BasePlan() { }

    public BasePlan(BasePlan basePlan)
        : base(basePlan) { }

    public BasePlan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BasePlan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BasePlanFromRaw.FromRawUnchecked"/>
    public static BasePlan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BasePlanFromRaw : IFromRaw<BasePlan>
{
    /// <inheritdoc/>
    public BasePlan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BasePlan.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<PlanPlanPhase, PlanPlanPhaseFromRaw>))]
public sealed record class PlanPlanPhase : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    public required SharedDiscount? Discount
    {
        get { return ModelBase.GetNullableClass<SharedDiscount>(this.RawData, "discount"); }
        init { ModelBase.Set(this._rawData, "discount", value); }
    }

    /// <summary>
    /// How many terms of length `duration_unit` this phase is active for. If null,
    /// this phase is evergreen and active indefinitely
    /// </summary>
    public required long? Duration
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "duration"); }
        init { ModelBase.Set(this._rawData, "duration", value); }
    }

    public required ApiEnum<string, PlanPlanPhaseDurationUnit>? DurationUnit
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, PlanPlanPhaseDurationUnit>>(
                this.RawData,
                "duration_unit"
            );
        }
        init { ModelBase.Set(this._rawData, "duration_unit", value); }
    }

    public required Maximum? Maximum
    {
        get { return ModelBase.GetNullableClass<Maximum>(this.RawData, "maximum"); }
        init { ModelBase.Set(this._rawData, "maximum", value); }
    }

    public required string? MaximumAmount
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "maximum_amount"); }
        init { ModelBase.Set(this._rawData, "maximum_amount", value); }
    }

    public required Minimum? Minimum
    {
        get { return ModelBase.GetNullableClass<Minimum>(this.RawData, "minimum"); }
        init { ModelBase.Set(this._rawData, "minimum", value); }
    }

    public required string? MinimumAmount
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "minimum_amount"); }
        init { ModelBase.Set(this._rawData, "minimum_amount", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "order"); }
        init { ModelBase.Set(this._rawData, "order", value); }
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

    public PlanPlanPhase(PlanPlanPhase planPlanPhase)
        : base(planPlanPhase) { }

    public PlanPlanPhase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPlanPhase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPlanPhaseFromRaw.FromRawUnchecked"/>
    public static PlanPlanPhase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPlanPhaseFromRaw : IFromRaw<PlanPlanPhase>
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

[JsonConverter(typeof(ModelConverter<Product, ProductFromRaw>))]
public sealed record class Product : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
    }

    public Product() { }

    public Product(Product product)
        : base(product) { }

    public Product(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Product(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductFromRaw.FromRawUnchecked"/>
    public static Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductFromRaw : IFromRaw<Product>
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

[JsonConverter(typeof(ModelConverter<TrialConfig, TrialConfigFromRaw>))]
public sealed record class TrialConfig : ModelBase
{
    public required long? TrialPeriod
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "trial_period"); }
        init { ModelBase.Set(this._rawData, "trial_period", value); }
    }

    public required ApiEnum<string, TrialPeriodUnit> TrialPeriodUnit
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, TrialPeriodUnit>>(
                this.RawData,
                "trial_period_unit"
            );
        }
        init { ModelBase.Set(this._rawData, "trial_period_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TrialPeriod;
        this.TrialPeriodUnit.Validate();
    }

    public TrialConfig() { }

    public TrialConfig(TrialConfig trialConfig)
        : base(trialConfig) { }

    public TrialConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrialConfigFromRaw.FromRawUnchecked"/>
    public static TrialConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrialConfigFromRaw : IFromRaw<TrialConfig>
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
