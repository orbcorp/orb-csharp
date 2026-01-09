using System.Collections.Frozen;
using System.Collections.Generic;
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
            return JsonModel.GetNotNullClass<List<PlanVersionAdjustment>>(
                this.RawData,
                "adjustments"
            );
        }
        init { JsonModel.Set(this._rawData, "adjustments", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required IReadOnlyList<PlanVersionPhase>? PlanPhases
    {
        get
        {
            return JsonModel.GetNullableClass<List<PlanVersionPhase>>(this.RawData, "plan_phases");
        }
        init { JsonModel.Set(this._rawData, "plan_phases", value); }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across
    /// all phases of the plan.
    /// </summary>
    public required IReadOnlyList<Models::Price> Prices
    {
        get { return JsonModel.GetNotNullClass<List<Models::Price>>(this.RawData, "prices"); }
        init { JsonModel.Set(this._rawData, "prices", value); }
    }

    public required long Version
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "version"); }
        init { JsonModel.Set(this._rawData, "version", value); }
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

    public PlanVersion(PlanVersion planVersion)
        : base(planVersion) { }

    public PlanVersion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanVersion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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
                    "Data did not match any variant of PlanVersionAdjustment"
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
            (planPhaseMinimum) => planPhaseMinimum.Validate(),
            (planPhaseMaximum) => planPhaseMaximum.Validate()
        );
    }

    public virtual bool Equals(PlanVersionAdjustment? other)
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
