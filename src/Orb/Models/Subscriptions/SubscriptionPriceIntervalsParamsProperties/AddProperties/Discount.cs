using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;
using DiscountVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountVariants;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;

[JsonConverter(typeof(DiscountConverter))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(Amount value) => new DiscountVariants::Amount(value);

    public static implicit operator Discount(Percentage value) =>
        new DiscountVariants::Percentage(value);

    public static implicit operator Discount(Usage value) => new DiscountVariants::Usage(value);

    public bool TryPickAmount([NotNullWhen(true)] out Amount? value)
    {
        value = (this as DiscountVariants::Amount)?.Value;
        return value != null;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out Percentage? value)
    {
        value = (this as DiscountVariants::Percentage)?.Value;
        return value != null;
    }

    public bool TryPickUsage([NotNullWhen(true)] out Usage? value)
    {
        value = (this as DiscountVariants::Usage)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DiscountVariants::Amount> amount,
        Action<DiscountVariants::Percentage> percentage,
        Action<DiscountVariants::Usage> usage
    )
    {
        switch (this)
        {
            case DiscountVariants::Amount inner:
                amount(inner);
                break;
            case DiscountVariants::Percentage inner:
                percentage(inner);
                break;
            case DiscountVariants::Usage inner:
                usage(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
    }

    public T Match<T>(
        Func<DiscountVariants::Amount, T> amount,
        Func<DiscountVariants::Percentage, T> percentage,
        Func<DiscountVariants::Usage, T> usage
    )
    {
        return this switch
        {
            DiscountVariants::Amount inner => amount(inner),
            DiscountVariants::Percentage inner => percentage(inner),
            DiscountVariants::Usage inner => usage(inner),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Discount"),
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
            case "amount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Amount>(json, options);
                    if (deserialized != null)
                    {
                        return new DiscountVariants::Amount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant DiscountVariants::Amount",
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
                    var deserialized = JsonSerializer.Deserialize<Percentage>(json, options);
                    if (deserialized != null)
                    {
                        return new DiscountVariants::Percentage(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant DiscountVariants::Percentage",
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
                    var deserialized = JsonSerializer.Deserialize<Usage>(json, options);
                    if (deserialized != null)
                    {
                        return new DiscountVariants::Usage(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant DiscountVariants::Usage",
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

    public override void Write(Utf8JsonWriter writer, Discount value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            DiscountVariants::Amount(var amount) => amount,
            DiscountVariants::Percentage(var percentage) => percentage,
            DiscountVariants::Usage(var usage) => usage,
            _ => throw new OrbInvalidDataException("Data did not match any variant of Discount"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
