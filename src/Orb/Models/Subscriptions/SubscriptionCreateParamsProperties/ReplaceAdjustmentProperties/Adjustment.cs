using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using AdjustmentVariants = Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplaceAdjustmentProperties.AdjustmentVariants;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplaceAdjustmentProperties;

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(AdjustmentConverter))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(NewPercentageDiscount value) =>
        new AdjustmentVariants::NewPercentageDiscount(value);

    public static implicit operator Adjustment(NewUsageDiscount value) =>
        new AdjustmentVariants::NewUsageDiscount(value);

    public static implicit operator Adjustment(NewAmountDiscount value) =>
        new AdjustmentVariants::NewAmountDiscount(value);

    public static implicit operator Adjustment(NewMinimum value) =>
        new AdjustmentVariants::NewMinimum(value);

    public static implicit operator Adjustment(NewMaximum value) =>
        new AdjustmentVariants::NewMaximum(value);

    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = (this as AdjustmentVariants::NewPercentageDiscount)?.Value;
        return value != null;
    }

    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = (this as AdjustmentVariants::NewUsageDiscount)?.Value;
        return value != null;
    }

    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = (this as AdjustmentVariants::NewAmountDiscount)?.Value;
        return value != null;
    }

    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = (this as AdjustmentVariants::NewMinimum)?.Value;
        return value != null;
    }

    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = (this as AdjustmentVariants::NewMaximum)?.Value;
        return value != null;
    }

    public void Switch(
        Action<AdjustmentVariants::NewPercentageDiscount> newPercentageDiscount,
        Action<AdjustmentVariants::NewUsageDiscount> newUsageDiscount,
        Action<AdjustmentVariants::NewAmountDiscount> newAmountDiscount,
        Action<AdjustmentVariants::NewMinimum> newMinimum,
        Action<AdjustmentVariants::NewMaximum> newMaximum
    )
    {
        switch (this)
        {
            case AdjustmentVariants::NewPercentageDiscount inner:
                newPercentageDiscount(inner);
                break;
            case AdjustmentVariants::NewUsageDiscount inner:
                newUsageDiscount(inner);
                break;
            case AdjustmentVariants::NewAmountDiscount inner:
                newAmountDiscount(inner);
                break;
            case AdjustmentVariants::NewMinimum inner:
                newMinimum(inner);
                break;
            case AdjustmentVariants::NewMaximum inner:
                newMaximum(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    public T Match<T>(
        Func<AdjustmentVariants::NewPercentageDiscount, T> newPercentageDiscount,
        Func<AdjustmentVariants::NewUsageDiscount, T> newUsageDiscount,
        Func<AdjustmentVariants::NewAmountDiscount, T> newAmountDiscount,
        Func<AdjustmentVariants::NewMinimum, T> newMinimum,
        Func<AdjustmentVariants::NewMaximum, T> newMaximum
    )
    {
        return this switch
        {
            AdjustmentVariants::NewPercentageDiscount inner => newPercentageDiscount(inner),
            AdjustmentVariants::NewUsageDiscount inner => newUsageDiscount(inner),
            AdjustmentVariants::NewAmountDiscount inner => newAmountDiscount(inner),
            AdjustmentVariants::NewMinimum inner => newMinimum(inner),
            AdjustmentVariants::NewMaximum inner => newMaximum(inner),
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
            case "percentage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::NewPercentageDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::NewPercentageDiscount",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "usage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::NewUsageDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::NewUsageDiscount",
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
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::NewAmountDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::NewAmountDiscount",
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
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::NewMinimum(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::NewMinimum",
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
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::NewMaximum(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant AdjustmentVariants::NewMaximum",
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
            AdjustmentVariants::NewPercentageDiscount(var newPercentageDiscount) =>
                newPercentageDiscount,
            AdjustmentVariants::NewUsageDiscount(var newUsageDiscount) => newUsageDiscount,
            AdjustmentVariants::NewAmountDiscount(var newAmountDiscount) => newAmountDiscount,
            AdjustmentVariants::NewMinimum(var newMinimum) => newMinimum,
            AdjustmentVariants::NewMaximum(var newMaximum) => newMaximum,
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
