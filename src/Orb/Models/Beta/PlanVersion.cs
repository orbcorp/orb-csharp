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

namespace Orb.Models.Beta;

/// <summary>
/// The PlanVersion resource represents the prices and adjustments present on a specific
/// version of a plan.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlanVersion, PlanVersionFromRaw>))]
public sealed record class PlanVersion : JsonModel
{
    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required IReadOnlyList<PlanVersionAdjustment> Adjustments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PlanVersionAdjustment>>(
                "adjustments"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanVersionAdjustment>>(
                "adjustments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public required IReadOnlyList<PlanVersionPhase>? PlanPhases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PlanVersionPhase>>("plan_phases");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanVersionPhase>?>(
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
        foreach (var item in this.Adjustments)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        foreach (var item in this.PlanPhases ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Prices)
        {
            item.Validate();
        }
        _ = this.Version;
    }

    public PlanVersion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanVersion(PlanVersion planVersion)
        : base(planVersion) { }
#pragma warning restore CS8618

    public PlanVersion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanVersion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanVersionFromRaw.FromRawUnchecked"/>
    public static PlanVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanVersionFromRaw : IFromRawJson<PlanVersion>
{
    /// <inheritdoc/>
    public PlanVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanVersion.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanVersionAdjustmentConverter))]
public record class PlanVersionAdjustment : ModelBase
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
                tieredPercentageDiscount: (x) => x.ID,
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
                tieredPercentageDiscount: (x) => x.IsInvoiceLevel,
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
                tieredPercentageDiscount: (x) => x.PlanPhaseOrder,
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
                tieredPercentageDiscount: (x) => x.Reason,
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
                tieredPercentageDiscount: (x) => x.ReplacesAdjustmentID,
                planPhaseMinimum: (x) => x.ReplacesAdjustmentID,
                planPhaseMaximum: (x) => x.ReplacesAdjustmentID
            );
        }
    }

    public PlanVersionAdjustment(
        Models::PlanPhaseUsageDiscountAdjustment value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanVersionAdjustment(
        Models::PlanPhaseAmountDiscountAdjustment value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanVersionAdjustment(
        Models::PlanPhasePercentageDiscountAdjustment value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanVersionAdjustment(
        PlanVersionAdjustmentTieredPercentageDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanVersionAdjustment(
        Models::PlanPhaseMinimumAdjustment value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanVersionAdjustment(
        Models::PlanPhaseMaximumAdjustment value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PlanVersionAdjustment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Models::PlanPhaseUsageDiscountAdjustment"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="PlanVersionAdjustmentTieredPercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredPercentageDiscount(out var value)) {
    ///     // `value` is of type `PlanVersionAdjustmentTieredPercentageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredPercentageDiscount(
        [NotNullWhen(true)] out PlanVersionAdjustmentTieredPercentageDiscount? value
    )
    {
        value = this.Value as PlanVersionAdjustmentTieredPercentageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Models::PlanPhaseMinimumAdjustment"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (Models::PlanPhaseUsageDiscountAdjustment value) =&gt; {...},
    ///     (Models::PlanPhaseAmountDiscountAdjustment value) =&gt; {...},
    ///     (Models::PlanPhasePercentageDiscountAdjustment value) =&gt; {...},
    ///     (PlanVersionAdjustmentTieredPercentageDiscount value) =&gt; {...},
    ///     (Models::PlanPhaseMinimumAdjustment value) =&gt; {...},
    ///     (Models::PlanPhaseMaximumAdjustment value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Models::PlanPhaseUsageDiscountAdjustment> planPhaseUsageDiscount,
        System::Action<Models::PlanPhaseAmountDiscountAdjustment> planPhaseAmountDiscount,
        System::Action<Models::PlanPhasePercentageDiscountAdjustment> planPhasePercentageDiscount,
        System::Action<PlanVersionAdjustmentTieredPercentageDiscount> tieredPercentageDiscount,
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
            case PlanVersionAdjustmentTieredPercentageDiscount value:
                tieredPercentageDiscount(value);
                break;
            case Models::PlanPhaseMinimumAdjustment value:
                planPhaseMinimum(value);
                break;
            case Models::PlanPhaseMaximumAdjustment value:
                planPhaseMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of PlanVersionAdjustment"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (Models::PlanPhaseUsageDiscountAdjustment value) =&gt; {...},
    ///     (Models::PlanPhaseAmountDiscountAdjustment value) =&gt; {...},
    ///     (Models::PlanPhasePercentageDiscountAdjustment value) =&gt; {...},
    ///     (PlanVersionAdjustmentTieredPercentageDiscount value) =&gt; {...},
    ///     (Models::PlanPhaseMinimumAdjustment value) =&gt; {...},
    ///     (Models::PlanPhaseMaximumAdjustment value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Models::PlanPhaseUsageDiscountAdjustment, T> planPhaseUsageDiscount,
        System::Func<Models::PlanPhaseAmountDiscountAdjustment, T> planPhaseAmountDiscount,
        System::Func<Models::PlanPhasePercentageDiscountAdjustment, T> planPhasePercentageDiscount,
        System::Func<PlanVersionAdjustmentTieredPercentageDiscount, T> tieredPercentageDiscount,
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
            PlanVersionAdjustmentTieredPercentageDiscount value => tieredPercentageDiscount(value),
            Models::PlanPhaseMinimumAdjustment value => planPhaseMinimum(value),
            Models::PlanPhaseMaximumAdjustment value => planPhaseMaximum(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of PlanVersionAdjustment"
            ),
        };
    }

    public static implicit operator PlanVersionAdjustment(
        Models::PlanPhaseUsageDiscountAdjustment value
    ) => new(value);

    public static implicit operator PlanVersionAdjustment(
        Models::PlanPhaseAmountDiscountAdjustment value
    ) => new(value);

    public static implicit operator PlanVersionAdjustment(
        Models::PlanPhasePercentageDiscountAdjustment value
    ) => new(value);

    public static implicit operator PlanVersionAdjustment(
        PlanVersionAdjustmentTieredPercentageDiscount value
    ) => new(value);

    public static implicit operator PlanVersionAdjustment(
        Models::PlanPhaseMinimumAdjustment value
    ) => new(value);

    public static implicit operator PlanVersionAdjustment(
        Models::PlanPhaseMaximumAdjustment value
    ) => new(value);

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
            throw new OrbInvalidDataException(
                "Data did not match any variant of PlanVersionAdjustment"
            );
        }
        this.Switch(
            (planPhaseUsageDiscount) => planPhaseUsageDiscount.Validate(),
            (planPhaseAmountDiscount) => planPhaseAmountDiscount.Validate(),
            (planPhasePercentageDiscount) => planPhasePercentageDiscount.Validate(),
            (tieredPercentageDiscount) => tieredPercentageDiscount.Validate(),
            (planPhaseMinimum) => planPhaseMinimum.Validate(),
            (planPhaseMaximum) => planPhaseMaximum.Validate()
        );
    }

    public virtual bool Equals(PlanVersionAdjustment? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Models::PlanPhaseUsageDiscountAdjustment _ => 0,
            Models::PlanPhaseAmountDiscountAdjustment _ => 1,
            Models::PlanPhasePercentageDiscountAdjustment _ => 2,
            PlanVersionAdjustmentTieredPercentageDiscount _ => 3,
            Models::PlanPhaseMinimumAdjustment _ => 4,
            Models::PlanPhaseMaximumAdjustment _ => 5,
            _ => -1,
        };
    }
}

sealed class PlanVersionAdjustmentConverter : JsonConverter<PlanVersionAdjustment>
{
    public override PlanVersionAdjustment? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_percentage_discount":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PlanVersionAdjustmentTieredPercentageDiscount>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PlanVersionAdjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanVersionAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlanVersionAdjustmentTieredPercentageDiscount,
        PlanVersionAdjustmentTieredPercentageDiscountFromRaw
    >)
)]
public sealed record class PlanVersionAdjustmentTieredPercentageDiscount : JsonModel
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

    public JsonElement AdjustmentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("adjustment_type");
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required IReadOnlyList<string> AppliesToPriceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("applies_to_price_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "applies_to_price_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this adjustment to.
    /// </summary>
    public required IReadOnlyList<PlanVersionAdjustmentTieredPercentageDiscountFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<PlanVersionAdjustmentTieredPercentageDiscountFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanVersionAdjustmentTieredPercentageDiscountFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// True for adjustments that apply to an entire invoice, false for adjustments
    /// that apply to only one price.
    /// </summary>
    public required bool IsInvoiceLevel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_invoice_level");
        }
        init { this._rawData.Set("is_invoice_level", value); }
    }

    /// <summary>
    /// The plan phase in which this adjustment is active.
    /// </summary>
    public required long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <summary>
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the
    /// place of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("replaces_adjustment_id");
        }
        init { this._rawData.Set("replaces_adjustment_id", value); }
    }

    /// <summary>
    /// The ordered, contiguous bands of cumulative eligible spend, each discounted
    /// at its own percentage (progressive fill-a-tier), applied to the prices this
    /// adjustment covers in a given billing period.
    /// </summary>
    public required IReadOnlyList<PlanVersionAdjustmentTieredPercentageDiscountTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<PlanVersionAdjustmentTieredPercentageDiscountTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanVersionAdjustmentTieredPercentageDiscountTier>>(
                "tiers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.AdjustmentType,
                JsonSerializer.SerializeToElement("tiered_percentage_discount")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanVersionAdjustmentTieredPercentageDiscount()
    {
        this.AdjustmentType = JsonSerializer.SerializeToElement("tiered_percentage_discount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanVersionAdjustmentTieredPercentageDiscount(
        PlanVersionAdjustmentTieredPercentageDiscount planVersionAdjustmentTieredPercentageDiscount
    )
        : base(planVersionAdjustmentTieredPercentageDiscount) { }
#pragma warning restore CS8618

    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    public PlanVersionAdjustmentTieredPercentageDiscount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.AdjustmentType = JsonSerializer.SerializeToElement("tiered_percentage_discount");
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: applies_to_price_ids")]
    [SetsRequiredMembers]
    PlanVersionAdjustmentTieredPercentageDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanVersionAdjustmentTieredPercentageDiscountFromRaw.FromRawUnchecked"/>
    public static PlanVersionAdjustmentTieredPercentageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanVersionAdjustmentTieredPercentageDiscountFromRaw
    : IFromRawJson<PlanVersionAdjustmentTieredPercentageDiscount>
{
    /// <inheritdoc/>
    public PlanVersionAdjustmentTieredPercentageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanVersionAdjustmentTieredPercentageDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlanVersionAdjustmentTieredPercentageDiscountFilter,
        PlanVersionAdjustmentTieredPercentageDiscountFilterFromRaw
    >)
)]
public sealed record class PlanVersionAdjustmentTieredPercentageDiscountFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<
        string,
        PlanVersionAdjustmentTieredPercentageDiscountFilterOperator
    > Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanVersionAdjustmentTieredPercentageDiscountFilterOperator>
            >("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public PlanVersionAdjustmentTieredPercentageDiscountFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanVersionAdjustmentTieredPercentageDiscountFilter(
        PlanVersionAdjustmentTieredPercentageDiscountFilter planVersionAdjustmentTieredPercentageDiscountFilter
    )
        : base(planVersionAdjustmentTieredPercentageDiscountFilter) { }
#pragma warning restore CS8618

    public PlanVersionAdjustmentTieredPercentageDiscountFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanVersionAdjustmentTieredPercentageDiscountFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanVersionAdjustmentTieredPercentageDiscountFilterFromRaw.FromRawUnchecked"/>
    public static PlanVersionAdjustmentTieredPercentageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanVersionAdjustmentTieredPercentageDiscountFilterFromRaw
    : IFromRawJson<PlanVersionAdjustmentTieredPercentageDiscountFilter>
{
    /// <inheritdoc/>
    public PlanVersionAdjustmentTieredPercentageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanVersionAdjustmentTieredPercentageDiscountFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(PlanVersionAdjustmentTieredPercentageDiscountFilterFieldConverter))]
public enum PlanVersionAdjustmentTieredPercentageDiscountFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class PlanVersionAdjustmentTieredPercentageDiscountFilterFieldConverter
    : JsonConverter<PlanVersionAdjustmentTieredPercentageDiscountFilterField>
{
    public override PlanVersionAdjustmentTieredPercentageDiscountFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID,
            "item_id" => PlanVersionAdjustmentTieredPercentageDiscountFilterField.ItemID,
            "price_type" => PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceType,
            "currency" => PlanVersionAdjustmentTieredPercentageDiscountFilterField.Currency,
            "pricing_unit_id" =>
                PlanVersionAdjustmentTieredPercentageDiscountFilterField.PricingUnitID,
            _ => (PlanVersionAdjustmentTieredPercentageDiscountFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanVersionAdjustmentTieredPercentageDiscountFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceID => "price_id",
                PlanVersionAdjustmentTieredPercentageDiscountFilterField.ItemID => "item_id",
                PlanVersionAdjustmentTieredPercentageDiscountFilterField.PriceType => "price_type",
                PlanVersionAdjustmentTieredPercentageDiscountFilterField.Currency => "currency",
                PlanVersionAdjustmentTieredPercentageDiscountFilterField.PricingUnitID =>
                    "pricing_unit_id",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(PlanVersionAdjustmentTieredPercentageDiscountFilterOperatorConverter))]
public enum PlanVersionAdjustmentTieredPercentageDiscountFilterOperator
{
    Includes,
    Excludes,
}

sealed class PlanVersionAdjustmentTieredPercentageDiscountFilterOperatorConverter
    : JsonConverter<PlanVersionAdjustmentTieredPercentageDiscountFilterOperator>
{
    public override PlanVersionAdjustmentTieredPercentageDiscountFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes,
            "excludes" => PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Excludes,
            _ => (PlanVersionAdjustmentTieredPercentageDiscountFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanVersionAdjustmentTieredPercentageDiscountFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Includes => "includes",
                PlanVersionAdjustmentTieredPercentageDiscountFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// One band of a tiered percentage discount. Bounds are denominated in the discount's
/// currency. `lower_bound` is the exclusive start of the band and `upper_bound`
/// is the inclusive end; `upper_bound` is null only for the open-ended final tier.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanVersionAdjustmentTieredPercentageDiscountTier,
        PlanVersionAdjustmentTieredPercentageDiscountTierFromRaw
    >)
)]
public sealed record class PlanVersionAdjustmentTieredPercentageDiscountTier : JsonModel
{
    /// <summary>
    /// Exclusive lower bound of cumulative spend for this tier.
    /// </summary>
    public required double LowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("lower_bound");
        }
        init { this._rawData.Set("lower_bound", value); }
    }

    /// <summary>
    /// The percentage (between 0 and 1) discounted from spend that falls within
    /// this tier.
    /// </summary>
    public required double Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentage");
        }
        init { this._rawData.Set("percentage", value); }
    }

    /// <summary>
    /// Inclusive upper bound of cumulative spend for this tier; null for the final
    /// open-ended tier.
    /// </summary>
    public double? UpperBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upper_bound");
        }
        init { this._rawData.Set("upper_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LowerBound;
        _ = this.Percentage;
        _ = this.UpperBound;
    }

    public PlanVersionAdjustmentTieredPercentageDiscountTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanVersionAdjustmentTieredPercentageDiscountTier(
        PlanVersionAdjustmentTieredPercentageDiscountTier planVersionAdjustmentTieredPercentageDiscountTier
    )
        : base(planVersionAdjustmentTieredPercentageDiscountTier) { }
#pragma warning restore CS8618

    public PlanVersionAdjustmentTieredPercentageDiscountTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanVersionAdjustmentTieredPercentageDiscountTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanVersionAdjustmentTieredPercentageDiscountTierFromRaw.FromRawUnchecked"/>
    public static PlanVersionAdjustmentTieredPercentageDiscountTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanVersionAdjustmentTieredPercentageDiscountTierFromRaw
    : IFromRawJson<PlanVersionAdjustmentTieredPercentageDiscountTier>
{
    /// <inheritdoc/>
    public PlanVersionAdjustmentTieredPercentageDiscountTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanVersionAdjustmentTieredPercentageDiscountTier.FromRawUnchecked(rawData);
}
