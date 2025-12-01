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
    public required IReadOnlyList<global::Orb.Models.Plans.AdjustmentModel> Adjustments
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Plans.AdjustmentModel>>(
                this.RawData,
                "adjustments"
            );
        }
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

    public required IReadOnlyList<PlanPhaseModel>? PlanPhases
    {
        get
        {
            return ModelBase.GetNullableClass<List<PlanPhaseModel>>(this.RawData, "plan_phases");
        }
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
    public Plan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [
        System::Obsolete(
            "Required properties are deprecated: base_plan, base_plan_id, currency, discount, maximum, maximum_amount, minimum, minimum_amount"
        ),
        SetsRequiredMembers
    ]
    Plan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanFromRaw : IFromRaw<Plan>
{
    public Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Plan.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Plans.AdjustmentModelConverter))]
public record class AdjustmentModel
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

    public AdjustmentModel(PlanPhaseUsageDiscountAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentModel(PlanPhaseAmountDiscountAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentModel(PlanPhasePercentageDiscountAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentModel(PlanPhaseMinimumAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentModel(PlanPhaseMaximumAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentModel(JsonElement json)
    {
        this._json = json;
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
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AdjustmentModel"
                );
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
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AdjustmentModel"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Plans.AdjustmentModel(
        PlanPhaseUsageDiscountAdjustment value
    ) => new(value);

    public static implicit operator global::Orb.Models.Plans.AdjustmentModel(
        PlanPhaseAmountDiscountAdjustment value
    ) => new(value);

    public static implicit operator global::Orb.Models.Plans.AdjustmentModel(
        PlanPhasePercentageDiscountAdjustment value
    ) => new(value);

    public static implicit operator global::Orb.Models.Plans.AdjustmentModel(
        PlanPhaseMinimumAdjustment value
    ) => new(value);

    public static implicit operator global::Orb.Models.Plans.AdjustmentModel(
        PlanPhaseMaximumAdjustment value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of AdjustmentModel");
        }
    }

    public virtual bool Equals(global::Orb.Models.Plans.AdjustmentModel? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class AdjustmentModelConverter : JsonConverter<global::Orb.Models.Plans.AdjustmentModel>
{
    public override global::Orb.Models.Plans.AdjustmentModel? Read(
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
                    var deserialized = JsonSerializer.Deserialize<PlanPhaseUsageDiscountAdjustment>(
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
                        JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustment>(
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
                        JsonSerializer.Deserialize<PlanPhasePercentageDiscountAdjustment>(
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
                    var deserialized = JsonSerializer.Deserialize<PlanPhaseMinimumAdjustment>(
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
                    var deserialized = JsonSerializer.Deserialize<PlanPhaseMaximumAdjustment>(
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
                return new global::Orb.Models.Plans.AdjustmentModel(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Plans.AdjustmentModel value,
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
[System::Obsolete("deprecated"), JsonConverter(typeof(ModelConverter<BasePlan, BasePlanFromRaw>))]
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
    }

    public BasePlan() { }

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

    public static BasePlan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BasePlanFromRaw : IFromRaw<BasePlan>
{
    public BasePlan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BasePlan.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<PlanPhaseModel, PlanPhaseModelFromRaw>))]
public sealed record class PlanPhaseModel : ModelBase
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

    public required ApiEnum<string, PlanPhaseModelDurationUnit>? DurationUnit
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, PlanPhaseModelDurationUnit>>(
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

    public PlanPhaseModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPhaseModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PlanPhaseModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanPhaseModelFromRaw : IFromRaw<PlanPhaseModel>
{
    public PlanPhaseModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanPhaseModel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanPhaseModelDurationUnitConverter))]
public enum PlanPhaseModelDurationUnit
{
    Daily,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
}

sealed class PlanPhaseModelDurationUnitConverter : JsonConverter<PlanPhaseModelDurationUnit>
{
    public override PlanPhaseModelDurationUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => PlanPhaseModelDurationUnit.Daily,
            "monthly" => PlanPhaseModelDurationUnit.Monthly,
            "quarterly" => PlanPhaseModelDurationUnit.Quarterly,
            "semi_annual" => PlanPhaseModelDurationUnit.SemiAnnual,
            "annual" => PlanPhaseModelDurationUnit.Annual,
            _ => (PlanPhaseModelDurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanPhaseModelDurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanPhaseModelDurationUnit.Daily => "daily",
                PlanPhaseModelDurationUnit.Monthly => "monthly",
                PlanPhaseModelDurationUnit.Quarterly => "quarterly",
                PlanPhaseModelDurationUnit.SemiAnnual => "semi_annual",
                PlanPhaseModelDurationUnit.Annual => "annual",
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
    }

    public Product() { }

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

    public static Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductFromRaw : IFromRaw<Product>
{
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

    public override void Validate()
    {
        _ = this.TrialPeriod;
        this.TrialPeriodUnit.Validate();
    }

    public TrialConfig() { }

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

    public static TrialConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrialConfigFromRaw : IFromRaw<TrialConfig>
{
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
