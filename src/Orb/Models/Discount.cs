using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DiscountVariants = Orb.Models.DiscountVariants;

namespace Orb.Models;

[JsonConverter(typeof(DiscountConverter))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(PercentageDiscount value) =>
        new DiscountVariants::PercentageDiscount(value);

    public static implicit operator Discount(TrialDiscount value) =>
        new DiscountVariants::TrialDiscount(value);

    public static implicit operator Discount(UsageDiscount value) =>
        new DiscountVariants::UsageDiscount(value);

    public static implicit operator Discount(AmountDiscount value) =>
        new DiscountVariants::AmountDiscount(value);

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = (this as DiscountVariants::PercentageDiscount)?.Value;
        return value != null;
    }

    public bool TryPickTrial([NotNullWhen(true)] out TrialDiscount? value)
    {
        value = (this as DiscountVariants::TrialDiscount)?.Value;
        return value != null;
    }

    public bool TryPickUsage([NotNullWhen(true)] out UsageDiscount? value)
    {
        value = (this as DiscountVariants::UsageDiscount)?.Value;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = (this as DiscountVariants::AmountDiscount)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DiscountVariants::PercentageDiscount> percentage,
        Action<DiscountVariants::TrialDiscount> trial,
        Action<DiscountVariants::UsageDiscount> usage,
        Action<DiscountVariants::AmountDiscount> amount
    )
    {
        switch (this)
        {
            case DiscountVariants::PercentageDiscount inner:
                percentage(inner);
                break;
            case DiscountVariants::TrialDiscount inner:
                trial(inner);
                break;
            case DiscountVariants::UsageDiscount inner:
                usage(inner);
                break;
            case DiscountVariants::AmountDiscount inner:
                amount(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<DiscountVariants::PercentageDiscount, T> percentage,
        Func<DiscountVariants::TrialDiscount, T> trial,
        Func<DiscountVariants::UsageDiscount, T> usage,
        Func<DiscountVariants::AmountDiscount, T> amount
    )
    {
        return this switch
        {
            DiscountVariants::PercentageDiscount inner => percentage(inner),
            DiscountVariants::TrialDiscount inner => trial(inner),
            DiscountVariants::UsageDiscount inner => usage(inner),
            DiscountVariants::AmountDiscount inner => amount(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class DiscountConverter : JsonConverter<Discount>
{
    public override Discount? Read(
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
            case "percentage":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DiscountVariants::PercentageDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "trial":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TrialDiscount>(json, options);
                    if (deserialized != null)
                    {
                        return new DiscountVariants::TrialDiscount(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<UsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        return new DiscountVariants::UsageDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "amount":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        return new DiscountVariants::AmountDiscount(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Discount value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            DiscountVariants::PercentageDiscount(var percentage) => percentage,
            DiscountVariants::TrialDiscount(var trial) => trial,
            DiscountVariants::UsageDiscount(var usage) => usage,
            DiscountVariants::AmountDiscount(var amount) => amount,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
