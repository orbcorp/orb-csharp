using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using InvoiceLevelDiscountVariants = Orb.Models.InvoiceLevelDiscountVariants;

namespace Orb.Models;

[JsonConverter(typeof(InvoiceLevelDiscountConverter))]
public abstract record class InvoiceLevelDiscount
{
    internal InvoiceLevelDiscount() { }

    public static implicit operator InvoiceLevelDiscount(PercentageDiscount value) =>
        new InvoiceLevelDiscountVariants::PercentageDiscount(value);

    public static implicit operator InvoiceLevelDiscount(AmountDiscount value) =>
        new InvoiceLevelDiscountVariants::AmountDiscount(value);

    public static implicit operator InvoiceLevelDiscount(TrialDiscount value) =>
        new InvoiceLevelDiscountVariants::TrialDiscount(value);

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = (this as InvoiceLevelDiscountVariants::PercentageDiscount)?.Value;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = (this as InvoiceLevelDiscountVariants::AmountDiscount)?.Value;
        return value != null;
    }

    public bool TryPickTrial([NotNullWhen(true)] out TrialDiscount? value)
    {
        value = (this as InvoiceLevelDiscountVariants::TrialDiscount)?.Value;
        return value != null;
    }

    public void Switch(
        Action<InvoiceLevelDiscountVariants::PercentageDiscount> percentage,
        Action<InvoiceLevelDiscountVariants::AmountDiscount> amount,
        Action<InvoiceLevelDiscountVariants::TrialDiscount> trial
    )
    {
        switch (this)
        {
            case InvoiceLevelDiscountVariants::PercentageDiscount inner:
                percentage(inner);
                break;
            case InvoiceLevelDiscountVariants::AmountDiscount inner:
                amount(inner);
                break;
            case InvoiceLevelDiscountVariants::TrialDiscount inner:
                trial(inner);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of InvoiceLevelDiscount"
                );
        }
    }

    public T Match<T>(
        Func<InvoiceLevelDiscountVariants::PercentageDiscount, T> percentage,
        Func<InvoiceLevelDiscountVariants::AmountDiscount, T> amount,
        Func<InvoiceLevelDiscountVariants::TrialDiscount, T> trial
    )
    {
        return this switch
        {
            InvoiceLevelDiscountVariants::PercentageDiscount inner => percentage(inner),
            InvoiceLevelDiscountVariants::AmountDiscount inner => amount(inner),
            InvoiceLevelDiscountVariants::TrialDiscount inner => trial(inner),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of InvoiceLevelDiscount"
            ),
        };
    }

    public abstract void Validate();
}

sealed class InvoiceLevelDiscountConverter : JsonConverter<InvoiceLevelDiscount>
{
    public override InvoiceLevelDiscount? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new InvoiceLevelDiscountVariants::PercentageDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant InvoiceLevelDiscountVariants::PercentageDiscount",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "amount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        return new InvoiceLevelDiscountVariants::AmountDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant InvoiceLevelDiscountVariants::AmountDiscount",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "trial":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TrialDiscount>(json, options);
                    if (deserialized != null)
                    {
                        return new InvoiceLevelDiscountVariants::TrialDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant InvoiceLevelDiscountVariants::TrialDiscount",
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
        InvoiceLevelDiscount value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            InvoiceLevelDiscountVariants::PercentageDiscount(var percentage) => percentage,
            InvoiceLevelDiscountVariants::AmountDiscount(var amount) => amount,
            InvoiceLevelDiscountVariants::TrialDiscount(var trial) => trial,
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of InvoiceLevelDiscount"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
