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
[JsonConverter(typeof(ModelConverter<PlanVersion, PlanVersionFromRaw>))]
public sealed record class PlanVersion : ModelBase
{
    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required IReadOnlyList<PlanVersionAdjustment> Adjustments
    {
        get
        {
            return ModelBase.GetNotNullClass<List<PlanVersionAdjustment>>(
                this.RawData,
                "adjustments"
            );
        }
        init { ModelBase.Set(this._rawData, "adjustments", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required IReadOnlyList<PlanVersionPhase>? PlanPhases
    {
        get
        {
            return ModelBase.GetNullableClass<List<PlanVersionPhase>>(this.RawData, "plan_phases");
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

    public required long Version
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "version"); }
        init { ModelBase.Set(this._rawData, "version", value); }
    }

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

    public static PlanVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanVersionFromRaw : IFromRaw<PlanVersion>
{
    public PlanVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanVersion.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanVersionAdjustmentConverter))]
public record class PlanVersionAdjustment
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

    public PlanVersionAdjustment(
        Models::PlanPhaseUsageDiscountAdjustment value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PlanVersionAdjustment(
        Models::PlanPhaseAmountDiscountAdjustment value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PlanVersionAdjustment(
        Models::PlanPhasePercentageDiscountAdjustment value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PlanVersionAdjustment(Models::PlanPhaseMinimumAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PlanVersionAdjustment(Models::PlanPhaseMaximumAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PlanVersionAdjustment(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickPlanPhaseUsageDiscount(
        [NotNullWhen(true)] out Models::PlanPhaseUsageDiscountAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhaseUsageDiscountAdjustment;
        return value != null;
    }

    public bool TryPickPlanPhaseAmountDiscount(
        [NotNullWhen(true)] out Models::PlanPhaseAmountDiscountAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhaseAmountDiscountAdjustment;
        return value != null;
    }

    public bool TryPickPlanPhasePercentageDiscount(
        [NotNullWhen(true)] out Models::PlanPhasePercentageDiscountAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhasePercentageDiscountAdjustment;
        return value != null;
    }

    public bool TryPickPlanPhaseMinimum(
        [NotNullWhen(true)] out Models::PlanPhaseMinimumAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhaseMinimumAdjustment;
        return value != null;
    }

    public bool TryPickPlanPhaseMaximum(
        [NotNullWhen(true)] out Models::PlanPhaseMaximumAdjustment? value
    )
    {
        value = this.Value as Models::PlanPhaseMaximumAdjustment;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PlanVersionAdjustment"
            );
        }
    }

    public virtual bool Equals(PlanVersionAdjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
                return new PlanVersionAdjustment(json);
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
