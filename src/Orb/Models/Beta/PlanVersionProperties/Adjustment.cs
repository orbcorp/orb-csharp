using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using AdjustmentVariants = Orb.Models.Beta.PlanVersionProperties.AdjustmentVariants;

namespace Orb.Models.Beta.PlanVersionProperties;

[JsonConverter(typeof(AdjustmentConverter))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(PlanPhaseUsageDiscountAdjustment value) =>
        new AdjustmentVariants::PlanPhaseUsageDiscountAdjustment(value);

    public static implicit operator Adjustment(PlanPhaseAmountDiscountAdjustment value) =>
        new AdjustmentVariants::PlanPhaseAmountDiscountAdjustment(value);

    public static implicit operator Adjustment(PlanPhasePercentageDiscountAdjustment value) =>
        new AdjustmentVariants::PlanPhasePercentageDiscountAdjustment(value);

    public static implicit operator Adjustment(PlanPhaseMinimumAdjustment value) =>
        new AdjustmentVariants::PlanPhaseMinimumAdjustment(value);

    public static implicit operator Adjustment(PlanPhaseMaximumAdjustment value) =>
        new AdjustmentVariants::PlanPhaseMaximumAdjustment(value);

    public bool TryPickPlanPhaseUsageDiscount(
        [NotNullWhen(true)] out PlanPhaseUsageDiscountAdjustment? value
    )
    {
        value = (this as AdjustmentVariants::PlanPhaseUsageDiscountAdjustment)?.Value;
        return value != null;
    }

    public bool TryPickPlanPhaseAmountDiscount(
        [NotNullWhen(true)] out PlanPhaseAmountDiscountAdjustment? value
    )
    {
        value = (this as AdjustmentVariants::PlanPhaseAmountDiscountAdjustment)?.Value;
        return value != null;
    }

    public bool TryPickPlanPhasePercentageDiscount(
        [NotNullWhen(true)] out PlanPhasePercentageDiscountAdjustment? value
    )
    {
        value = (this as AdjustmentVariants::PlanPhasePercentageDiscountAdjustment)?.Value;
        return value != null;
    }

    public bool TryPickPlanPhaseMinimum([NotNullWhen(true)] out PlanPhaseMinimumAdjustment? value)
    {
        value = (this as AdjustmentVariants::PlanPhaseMinimumAdjustment)?.Value;
        return value != null;
    }

    public bool TryPickPlanPhaseMaximum([NotNullWhen(true)] out PlanPhaseMaximumAdjustment? value)
    {
        value = (this as AdjustmentVariants::PlanPhaseMaximumAdjustment)?.Value;
        return value != null;
    }

    public void Switch(
        Action<AdjustmentVariants::PlanPhaseUsageDiscountAdjustment> planPhaseUsageDiscount,
        Action<AdjustmentVariants::PlanPhaseAmountDiscountAdjustment> planPhaseAmountDiscount,
        Action<AdjustmentVariants::PlanPhasePercentageDiscountAdjustment> planPhasePercentageDiscount,
        Action<AdjustmentVariants::PlanPhaseMinimumAdjustment> planPhaseMinimum,
        Action<AdjustmentVariants::PlanPhaseMaximumAdjustment> planPhaseMaximum
    )
    {
        switch (this)
        {
            case AdjustmentVariants::PlanPhaseUsageDiscountAdjustment inner:
                planPhaseUsageDiscount(inner);
                break;
            case AdjustmentVariants::PlanPhaseAmountDiscountAdjustment inner:
                planPhaseAmountDiscount(inner);
                break;
            case AdjustmentVariants::PlanPhasePercentageDiscountAdjustment inner:
                planPhasePercentageDiscount(inner);
                break;
            case AdjustmentVariants::PlanPhaseMinimumAdjustment inner:
                planPhaseMinimum(inner);
                break;
            case AdjustmentVariants::PlanPhaseMaximumAdjustment inner:
                planPhaseMaximum(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    public T Match<T>(
        Func<AdjustmentVariants::PlanPhaseUsageDiscountAdjustment, T> planPhaseUsageDiscount,
        Func<AdjustmentVariants::PlanPhaseAmountDiscountAdjustment, T> planPhaseAmountDiscount,
        Func<
            AdjustmentVariants::PlanPhasePercentageDiscountAdjustment,
            T
        > planPhasePercentageDiscount,
        Func<AdjustmentVariants::PlanPhaseMinimumAdjustment, T> planPhaseMinimum,
        Func<AdjustmentVariants::PlanPhaseMaximumAdjustment, T> planPhaseMaximum
    )
    {
        return this switch
        {
            AdjustmentVariants::PlanPhaseUsageDiscountAdjustment inner => planPhaseUsageDiscount(
                inner
            ),
            AdjustmentVariants::PlanPhaseAmountDiscountAdjustment inner => planPhaseAmountDiscount(
                inner
            ),
            AdjustmentVariants::PlanPhasePercentageDiscountAdjustment inner =>
                planPhasePercentageDiscount(inner),
            AdjustmentVariants::PlanPhaseMinimumAdjustment inner => planPhaseMinimum(inner),
            AdjustmentVariants::PlanPhaseMaximumAdjustment inner => planPhaseMaximum(inner),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment"),
        };
    }

    public abstract void Validate();
}

sealed class AdjustmentConverter : JsonConverter<Adjustment>
{
    public override Adjustment? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                        return new AdjustmentVariants::PlanPhaseUsageDiscountAdjustment(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::PlanPhaseUsageDiscountAdjustment",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new AdjustmentVariants::PlanPhaseAmountDiscountAdjustment(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::PlanPhaseAmountDiscountAdjustment",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new AdjustmentVariants::PlanPhasePercentageDiscountAdjustment(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::PlanPhasePercentageDiscountAdjustment",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new AdjustmentVariants::PlanPhaseMinimumAdjustment(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::PlanPhaseMinimumAdjustment",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new AdjustmentVariants::PlanPhaseMaximumAdjustment(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::PlanPhaseMaximumAdjustment",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
        Adjustment value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            AdjustmentVariants::PlanPhaseUsageDiscountAdjustment(var planPhaseUsageDiscount) =>
                planPhaseUsageDiscount,
            AdjustmentVariants::PlanPhaseAmountDiscountAdjustment(var planPhaseAmountDiscount) =>
                planPhaseAmountDiscount,
            AdjustmentVariants::PlanPhasePercentageDiscountAdjustment(
                var planPhasePercentageDiscount
            ) => planPhasePercentageDiscount,
            AdjustmentVariants::PlanPhaseMinimumAdjustment(var planPhaseMinimum) =>
                planPhaseMinimum,
            AdjustmentVariants::PlanPhaseMaximumAdjustment(var planPhaseMaximum) =>
                planPhaseMaximum,
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
