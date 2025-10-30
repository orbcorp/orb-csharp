using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Coupons.CouponProperties;

[JsonConverter(typeof(global::Orb.Models.Coupons.CouponProperties.DiscountConverter))]
public record class Discount
{
    public object Value { get; private init; }

    public string? Reason
    {
        get { return Match<string?>(percentage: (x) => x.Reason, amount: (x) => x.Reason); }
    }

    public Discount(PercentageDiscount value)
    {
        Value = value;
    }

    public Discount(AmountDiscount value)
    {
        Value = value;
    }

    Discount(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Coupons.CouponProperties.Discount CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = this.Value as PercentageDiscount;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = this.Value as AmountDiscount;
        return value != null;
    }

    public void Switch(Action<PercentageDiscount> percentage, Action<AmountDiscount> amount)
    {
        switch (this.Value)
        {
            case PercentageDiscount value:
                percentage(value);
                break;
            case AmountDiscount value:
                amount(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
    }

    public T Match<T>(Func<PercentageDiscount, T> percentage, Func<AmountDiscount, T> amount)
    {
        return this.Value switch
        {
            PercentageDiscount value => percentage(value),
            AmountDiscount value => amount(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Discount"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class DiscountConverter : JsonConverter<global::Orb.Models.Coupons.CouponProperties.Discount>
{
    public override global::Orb.Models.Coupons.CouponProperties.Discount? Read(
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
                        deserialized.Validate();
                        return new global::Orb.Models.Coupons.CouponProperties.Discount(
                            deserialized
                        );
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PercentageDiscount'",
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
                        deserialized.Validate();
                        return new global::Orb.Models.Coupons.CouponProperties.Discount(
                            deserialized
                        );
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'AmountDiscount'",
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
        global::Orb.Models.Coupons.CouponProperties.Discount value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
