using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;
using DiscountVariants = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountVariants;

namespace Orb.Models.Coupons.CouponCreateParamsProperties;

[JsonConverter(typeof(DiscountConverter))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(Percentage value) =>
        new DiscountVariants::Percentage(value);

    public static implicit operator Discount(Amount value) => new DiscountVariants::Amount(value);

    public bool TryPickPercentage([NotNullWhen(true)] out Percentage? value)
    {
        value = (this as DiscountVariants::Percentage)?.Value;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out Amount? value)
    {
        value = (this as DiscountVariants::Amount)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DiscountVariants::Percentage> percentage,
        Action<DiscountVariants::Amount> amount
    )
    {
        switch (this)
        {
            case DiscountVariants::Percentage inner:
                percentage(inner);
                break;
            case DiscountVariants::Amount inner:
                amount(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<DiscountVariants::Percentage, T> percentage,
        Func<DiscountVariants::Amount, T> amount
    )
    {
        return this switch
        {
            DiscountVariants::Percentage inner => percentage(inner),
            DiscountVariants::Amount inner => amount(inner),
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
                    var deserialized = JsonSerializer.Deserialize<Percentage>(json, options);
                    if (deserialized != null)
                    {
                        return new DiscountVariants::Percentage(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Amount>(json, options);
                    if (deserialized != null)
                    {
                        return new DiscountVariants::Amount(deserialized);
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
            DiscountVariants::Percentage(var percentage) => percentage,
            DiscountVariants::Amount(var amount) => amount,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
