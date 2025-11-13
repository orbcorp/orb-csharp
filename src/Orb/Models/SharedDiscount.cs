using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(SharedDiscountConverter))]
public record class SharedDiscount
{
    public object Value { get; private init; }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                percentage: (x) => x.Reason,
                trial: (x) => x.Reason,
                usage: (x) => x.Reason,
                amount: (x) => x.Reason
            );
        }
    }

    public SharedDiscount(PercentageDiscount value)
    {
        Value = value;
    }

    public SharedDiscount(TrialDiscount value)
    {
        Value = value;
    }

    public SharedDiscount(UsageDiscount value)
    {
        Value = value;
    }

    public SharedDiscount(AmountDiscount value)
    {
        Value = value;
    }

    SharedDiscount(UnknownVariant value)
    {
        Value = value;
    }

    public static SharedDiscount CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = this.Value as PercentageDiscount;
        return value != null;
    }

    public bool TryPickTrial([NotNullWhen(true)] out TrialDiscount? value)
    {
        value = this.Value as TrialDiscount;
        return value != null;
    }

    public bool TryPickUsage([NotNullWhen(true)] out UsageDiscount? value)
    {
        value = this.Value as UsageDiscount;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = this.Value as AmountDiscount;
        return value != null;
    }

    public void Switch(
        System::Action<PercentageDiscount> percentage,
        System::Action<TrialDiscount> trial,
        System::Action<UsageDiscount> usage,
        System::Action<AmountDiscount> amount
    )
    {
        switch (this.Value)
        {
            case PercentageDiscount value:
                percentage(value);
                break;
            case TrialDiscount value:
                trial(value);
                break;
            case UsageDiscount value:
                usage(value);
                break;
            case AmountDiscount value:
                amount(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of SharedDiscount"
                );
        }
    }

    public T Match<T>(
        System::Func<PercentageDiscount, T> percentage,
        System::Func<TrialDiscount, T> trial,
        System::Func<UsageDiscount, T> usage,
        System::Func<AmountDiscount, T> amount
    )
    {
        return this.Value switch
        {
            PercentageDiscount value => percentage(value),
            TrialDiscount value => trial(value),
            UsageDiscount value => usage(value),
            AmountDiscount value => amount(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of SharedDiscount"
            ),
        };
    }

    public static implicit operator SharedDiscount(PercentageDiscount value) => new(value);

    public static implicit operator SharedDiscount(TrialDiscount value) => new(value);

    public static implicit operator SharedDiscount(UsageDiscount value) => new(value);

    public static implicit operator SharedDiscount(AmountDiscount value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of SharedDiscount");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class SharedDiscountConverter : JsonConverter<SharedDiscount>
{
    public override SharedDiscount? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            case "percentage":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SharedDiscount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PercentageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "trial":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TrialDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SharedDiscount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TrialDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "usage":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SharedDiscount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UsageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "amount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SharedDiscount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'AmountDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
        SharedDiscount value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
