using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DiscountVariants = Orb.Models.Coupons.CouponProperties.DiscountVariants;
using Models = Orb.Models;

namespace Orb.Models.Coupons.CouponProperties;

[JsonConverter(typeof(DiscountConverter))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(Models::PercentageDiscount value) =>
        new DiscountVariants::PercentageDiscount(value);

    public static implicit operator Discount(Models::AmountDiscount value) =>
        new DiscountVariants::AmountDiscount(value);

    public bool TryPickPercentage([NotNullWhen(true)] out Models::PercentageDiscount? value)
    {
        value = (this as DiscountVariants::PercentageDiscount)?.Value;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out Models::AmountDiscount? value)
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
                throw new InvalidOperationException();
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
                    var deserialized = JsonSerializer.Deserialize<Models::PercentageDiscount>(
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
            case "amount":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Models::AmountDiscount>(
                        json,
                        options
                    );
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
            DiscountVariants::AmountDiscount(var amount) => amount,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
