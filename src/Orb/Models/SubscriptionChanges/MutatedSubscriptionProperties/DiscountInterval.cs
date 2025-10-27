using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.SubscriptionChanges.MutatedSubscriptionProperties;

[JsonConverter(typeof(DiscountIntervalConverter))]
public record class DiscountInterval
{
    public object Value { get; private init; }

    public DateTime? EndDate
    {
        get
        {
            return Match<DateTime?>(
                amount: (x) => x.EndDate,
                percentage: (x) => x.EndDate,
                usage: (x) => x.EndDate
            );
        }
    }

    public DateTime StartDate
    {
        get
        {
            return Match(
                amount: (x) => x.StartDate,
                percentage: (x) => x.StartDate,
                usage: (x) => x.StartDate
            );
        }
    }

    public DiscountInterval(AmountDiscountInterval value)
    {
        Value = value;
    }

    public DiscountInterval(PercentageDiscountInterval value)
    {
        Value = value;
    }

    public DiscountInterval(UsageDiscountInterval value)
    {
        Value = value;
    }

    DiscountInterval(UnknownVariant value)
    {
        Value = value;
    }

    public static DiscountInterval CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscountInterval? value)
    {
        value = this.Value as AmountDiscountInterval;
        return value != null;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscountInterval? value)
    {
        value = this.Value as PercentageDiscountInterval;
        return value != null;
    }

    public bool TryPickUsage([NotNullWhen(true)] out UsageDiscountInterval? value)
    {
        value = this.Value as UsageDiscountInterval;
        return value != null;
    }

    public void Switch(
        Action<AmountDiscountInterval> amount,
        Action<PercentageDiscountInterval> percentage,
        Action<UsageDiscountInterval> usage
    )
    {
        switch (this.Value)
        {
            case AmountDiscountInterval value:
                amount(value);
                break;
            case PercentageDiscountInterval value:
                percentage(value);
                break;
            case UsageDiscountInterval value:
                usage(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of DiscountInterval"
                );
        }
    }

    public T Match<T>(
        Func<AmountDiscountInterval, T> amount,
        Func<PercentageDiscountInterval, T> percentage,
        Func<UsageDiscountInterval, T> usage
    )
    {
        return this.Value switch
        {
            AmountDiscountInterval value => amount(value),
            PercentageDiscountInterval value => percentage(value),
            UsageDiscountInterval value => usage(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of DiscountInterval"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DiscountInterval");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new DiscountInterval(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'AmountDiscountInterval'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "percentage":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new DiscountInterval(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PercentageDiscountInterval'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "usage":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new DiscountInterval(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UsageDiscountInterval'",
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
        DiscountInterval value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
