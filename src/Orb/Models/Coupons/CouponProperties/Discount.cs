using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using DiscountVariants = Orb.Models.Coupons.CouponProperties.DiscountVariants;

namespace Orb.Models.Coupons.CouponProperties;

[JsonConverter(typeof(DiscountConverter))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(PercentageDiscount value) =>
        new DiscountVariants::PercentageDiscount(value);

    public static implicit operator Discount(AmountDiscount value) =>
        new DiscountVariants::AmountDiscount(value);

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = (this as DiscountVariants::PercentageDiscount)?.Value;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = (this as DiscountVariants::AmountDiscount)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DiscountVariants::PercentageDiscount> percentage,
        Action<DiscountVariants::AmountDiscount> amount
    )
    {
        switch (this)
        {
            case DiscountVariants::PercentageDiscount inner:
                percentage(inner);
                break;
            case DiscountVariants::AmountDiscount inner:
                amount(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
    }

    public T Match<T>(
        Func<DiscountVariants::PercentageDiscount, T> percentage,
        Func<DiscountVariants::AmountDiscount, T> amount
    )
    {
        return this switch
        {
            DiscountVariants::PercentageDiscount inner => percentage(inner),
            DiscountVariants::AmountDiscount inner => amount(inner),
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
                        return new DiscountVariants::PercentageDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant DiscountVariants::PercentageDiscount",
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
                        return new DiscountVariants::AmountDiscount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant DiscountVariants::AmountDiscount",
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
            DiscountVariants::PercentageDiscount(var percentage) => percentage,
            DiscountVariants::AmountDiscount(var amount) => amount,
            _ => throw new OrbInvalidDataException("Data did not match any variant of Discount"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
