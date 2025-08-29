using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DiscountIntervalVariants = Orb.Models.Subscriptions.SubscriptionProperties.DiscountIntervalVariants;

namespace Orb.Models.Subscriptions.SubscriptionProperties;

[JsonConverter(typeof(DiscountIntervalConverter))]
public abstract record class DiscountInterval
{
    internal DiscountInterval() { }

    public static implicit operator DiscountInterval(AmountDiscountInterval value) =>
        new DiscountIntervalVariants::AmountDiscountInterval(value);

    public static implicit operator DiscountInterval(PercentageDiscountInterval value) =>
        new DiscountIntervalVariants::PercentageDiscountInterval(value);

    public static implicit operator DiscountInterval(UsageDiscountInterval value) =>
        new DiscountIntervalVariants::UsageDiscountInterval(value);

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscountInterval? value)
    {
        value = (this as DiscountIntervalVariants::AmountDiscountInterval)?.Value;
        return value != null;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscountInterval? value)
    {
        value = (this as DiscountIntervalVariants::PercentageDiscountInterval)?.Value;
        return value != null;
    }

    public bool TryPickUsage([NotNullWhen(true)] out UsageDiscountInterval? value)
    {
        value = (this as DiscountIntervalVariants::UsageDiscountInterval)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DiscountIntervalVariants::AmountDiscountInterval> amount,
        Action<DiscountIntervalVariants::PercentageDiscountInterval> percentage,
        Action<DiscountIntervalVariants::UsageDiscountInterval> usage
    )
    {
        switch (this)
        {
            case DiscountIntervalVariants::AmountDiscountInterval inner:
                amount(inner);
                break;
            case DiscountIntervalVariants::PercentageDiscountInterval inner:
                percentage(inner);
                break;
            case DiscountIntervalVariants::UsageDiscountInterval inner:
                usage(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<DiscountIntervalVariants::AmountDiscountInterval, T> amount,
        Func<DiscountIntervalVariants::PercentageDiscountInterval, T> percentage,
        Func<DiscountIntervalVariants::UsageDiscountInterval, T> usage
    )
    {
        return this switch
        {
            DiscountIntervalVariants::AmountDiscountInterval inner => amount(inner),
            DiscountIntervalVariants::PercentageDiscountInterval inner => percentage(inner),
            DiscountIntervalVariants::UsageDiscountInterval inner => usage(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class DiscountIntervalConverter : JsonConverter<DiscountInterval>
{
    public override DiscountInterval? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? discountType;
        try
        {
            discountType = json.GetProperty("discount_type").GetString();
        }
        catch
        {
            discountType = null;
        }

        switch (discountType)
        {
            case "amount":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DiscountIntervalVariants::AmountDiscountInterval(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "percentage":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DiscountIntervalVariants::PercentageDiscountInterval(
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
            case "usage":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DiscountIntervalVariants::UsageDiscountInterval(deserialized);
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
        DiscountInterval value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            DiscountIntervalVariants::AmountDiscountInterval(var amount) => amount,
            DiscountIntervalVariants::PercentageDiscountInterval(var percentage) => percentage,
            DiscountIntervalVariants::UsageDiscountInterval(var usage) => usage,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
