using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AdjustmentVariants = Orb.Models.ChangedSubscriptionResourcesProperties.CreatedInvoiceProperties.LineItemProperties.AdjustmentVariants;

namespace Orb.Models.ChangedSubscriptionResourcesProperties.CreatedInvoiceProperties.LineItemProperties;

[JsonConverter(typeof(AdjustmentConverter))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(MonetaryUsageDiscountAdjustment value) =>
        new AdjustmentVariants::MonetaryUsageDiscountAdjustment(value);

    public static implicit operator Adjustment(MonetaryAmountDiscountAdjustment value) =>
        new AdjustmentVariants::MonetaryAmountDiscountAdjustment(value);

    public static implicit operator Adjustment(MonetaryPercentageDiscountAdjustment value) =>
        new AdjustmentVariants::MonetaryPercentageDiscountAdjustment(value);

    public static implicit operator Adjustment(MonetaryMinimumAdjustment value) =>
        new AdjustmentVariants::MonetaryMinimumAdjustment(value);

    public static implicit operator Adjustment(MonetaryMaximumAdjustment value) =>
        new AdjustmentVariants::MonetaryMaximumAdjustment(value);

    public bool TryPickMonetaryUsageDiscount(
        [NotNullWhen(true)] out MonetaryUsageDiscountAdjustment? value
    )
    {
        value = (this as AdjustmentVariants::MonetaryUsageDiscountAdjustment)?.Value;
        return value != null;
    }

    public bool TryPickMonetaryAmountDiscount(
        [NotNullWhen(true)] out MonetaryAmountDiscountAdjustment? value
    )
    {
        value = (this as AdjustmentVariants::MonetaryAmountDiscountAdjustment)?.Value;
        return value != null;
    }

    public bool TryPickMonetaryPercentageDiscount(
        [NotNullWhen(true)] out MonetaryPercentageDiscountAdjustment? value
    )
    {
        value = (this as AdjustmentVariants::MonetaryPercentageDiscountAdjustment)?.Value;
        return value != null;
    }

    public bool TryPickMonetaryMinimum([NotNullWhen(true)] out MonetaryMinimumAdjustment? value)
    {
        value = (this as AdjustmentVariants::MonetaryMinimumAdjustment)?.Value;
        return value != null;
    }

    public bool TryPickMonetaryMaximum([NotNullWhen(true)] out MonetaryMaximumAdjustment? value)
    {
        value = (this as AdjustmentVariants::MonetaryMaximumAdjustment)?.Value;
        return value != null;
    }

    public void Switch(
        Action<AdjustmentVariants::MonetaryUsageDiscountAdjustment> monetaryUsageDiscount,
        Action<AdjustmentVariants::MonetaryAmountDiscountAdjustment> monetaryAmountDiscount,
        Action<AdjustmentVariants::MonetaryPercentageDiscountAdjustment> monetaryPercentageDiscount,
        Action<AdjustmentVariants::MonetaryMinimumAdjustment> monetaryMinimum,
        Action<AdjustmentVariants::MonetaryMaximumAdjustment> monetaryMaximum
    )
    {
        switch (this)
        {
            case AdjustmentVariants::MonetaryUsageDiscountAdjustment inner:
                monetaryUsageDiscount(inner);
                break;
            case AdjustmentVariants::MonetaryAmountDiscountAdjustment inner:
                monetaryAmountDiscount(inner);
                break;
            case AdjustmentVariants::MonetaryPercentageDiscountAdjustment inner:
                monetaryPercentageDiscount(inner);
                break;
            case AdjustmentVariants::MonetaryMinimumAdjustment inner:
                monetaryMinimum(inner);
                break;
            case AdjustmentVariants::MonetaryMaximumAdjustment inner:
                monetaryMaximum(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<AdjustmentVariants::MonetaryUsageDiscountAdjustment, T> monetaryUsageDiscount,
        Func<AdjustmentVariants::MonetaryAmountDiscountAdjustment, T> monetaryAmountDiscount,
        Func<
            AdjustmentVariants::MonetaryPercentageDiscountAdjustment,
            T
        > monetaryPercentageDiscount,
        Func<AdjustmentVariants::MonetaryMinimumAdjustment, T> monetaryMinimum,
        Func<AdjustmentVariants::MonetaryMaximumAdjustment, T> monetaryMaximum
    )
    {
        return this switch
        {
            AdjustmentVariants::MonetaryUsageDiscountAdjustment inner => monetaryUsageDiscount(
                inner
            ),
            AdjustmentVariants::MonetaryAmountDiscountAdjustment inner => monetaryAmountDiscount(
                inner
            ),
            AdjustmentVariants::MonetaryPercentageDiscountAdjustment inner =>
                monetaryPercentageDiscount(inner),
            AdjustmentVariants::MonetaryMinimumAdjustment inner => monetaryMinimum(inner),
            AdjustmentVariants::MonetaryMaximumAdjustment inner => monetaryMaximum(inner),
            _ => throw new InvalidOperationException(),
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::MonetaryUsageDiscountAdjustment(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "amount_discount":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryAmountDiscountAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::MonetaryAmountDiscountAdjustment(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "percentage_discount":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<MonetaryPercentageDiscountAdjustment>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::MonetaryPercentageDiscountAdjustment(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryMinimumAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::MonetaryMinimumAdjustment(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "maximum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryMaximumAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new AdjustmentVariants::MonetaryMaximumAdjustment(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
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
            AdjustmentVariants::MonetaryUsageDiscountAdjustment(var monetaryUsageDiscount) =>
                monetaryUsageDiscount,
            AdjustmentVariants::MonetaryAmountDiscountAdjustment(var monetaryAmountDiscount) =>
                monetaryAmountDiscount,
            AdjustmentVariants::MonetaryPercentageDiscountAdjustment(
                var monetaryPercentageDiscount
            ) => monetaryPercentageDiscount,
            AdjustmentVariants::MonetaryMinimumAdjustment(var monetaryMinimum) => monetaryMinimum,
            AdjustmentVariants::MonetaryMaximumAdjustment(var monetaryMaximum) => monetaryMaximum,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
