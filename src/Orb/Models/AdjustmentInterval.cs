using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AdjustmentInterval, AdjustmentIntervalFromRaw>))]
public sealed record class AdjustmentInterval : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
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
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required AdjustmentIntervalAdjustment Adjustment
    {
        get
        {
            if (!this._rawData.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AdjustmentIntervalAdjustment>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentNullException("adjustment")
                );
        }
        init
        {
            this._rawData["adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price interval IDs that this adjustment applies to.
    /// </summary>
    public required IReadOnlyList<string> AppliesToPriceIntervalIDs
    {
        get
        {
            if (
                !this._rawData.TryGetValue("applies_to_price_interval_ids", out JsonElement element)
            )
                throw new OrbInvalidDataException(
                    "'applies_to_price_interval_ids' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "applies_to_price_interval_ids",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'applies_to_price_interval_ids' cannot be null",
                    new System::ArgumentNullException("applies_to_price_interval_ids")
                );
        }
        init
        {
            this._rawData["applies_to_price_interval_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the adjustment interval.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            if (!this._rawData.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the adjustment interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            if (!this._rawData.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "start_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.Adjustment.Validate();
        _ = this.AppliesToPriceIntervalIDs;
        _ = this.EndDate;
        _ = this.StartDate;
    }

    public AdjustmentInterval() { }

    public AdjustmentInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdjustmentInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AdjustmentInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdjustmentIntervalFromRaw : IFromRaw<AdjustmentInterval>
{
    public AdjustmentInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AdjustmentInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AdjustmentIntervalAdjustmentConverter))]
public record class AdjustmentIntervalAdjustment
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

    public AdjustmentIntervalAdjustment(
        PlanPhaseUsageDiscountAdjustment value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentIntervalAdjustment(
        PlanPhaseAmountDiscountAdjustment value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentIntervalAdjustment(
        PlanPhasePercentageDiscountAdjustment value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentIntervalAdjustment(PlanPhaseMinimumAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentIntervalAdjustment(PlanPhaseMaximumAdjustment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AdjustmentIntervalAdjustment(JsonElement json)
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
                    "Data did not match any variant of AdjustmentIntervalAdjustment"
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
                "Data did not match any variant of AdjustmentIntervalAdjustment"
            ),
        };
    }

    public static implicit operator AdjustmentIntervalAdjustment(
        PlanPhaseUsageDiscountAdjustment value
    ) => new(value);

    public static implicit operator AdjustmentIntervalAdjustment(
        PlanPhaseAmountDiscountAdjustment value
    ) => new(value);

    public static implicit operator AdjustmentIntervalAdjustment(
        PlanPhasePercentageDiscountAdjustment value
    ) => new(value);

    public static implicit operator AdjustmentIntervalAdjustment(
        PlanPhaseMinimumAdjustment value
    ) => new(value);

    public static implicit operator AdjustmentIntervalAdjustment(
        PlanPhaseMaximumAdjustment value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AdjustmentIntervalAdjustment"
            );
        }
    }

    public virtual bool Equals(AdjustmentIntervalAdjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class AdjustmentIntervalAdjustmentConverter : JsonConverter<AdjustmentIntervalAdjustment>
{
    public override AdjustmentIntervalAdjustment? Read(
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
                return new AdjustmentIntervalAdjustment(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdjustmentIntervalAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
