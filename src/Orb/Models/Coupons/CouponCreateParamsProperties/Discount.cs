using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

namespace Orb.Models.Coupons.CouponCreateParamsProperties;

[JsonConverter(typeof(global::Orb.Models.Coupons.CouponCreateParamsProperties.DiscountConverter))]
public record class Discount
{
    public object Value { get; private init; }

    public Discount(Percentage value)
    {
        Value = value;
    }

    public Discount(Amount value)
    {
        Value = value;
    }

    Discount(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Coupons.CouponCreateParamsProperties.Discount CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickPercentage([NotNullWhen(true)] out Percentage? value)
    {
        value = this.Value as Percentage;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out Amount? value)
    {
        value = this.Value as Amount;
        return value != null;
    }

    public void Switch(Action<Percentage> percentage, Action<Amount> amount)
    {
        switch (this.Value)
        {
            case Percentage value:
                percentage(value);
                break;
            case Amount value:
                amount(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
    }

    public T Match<T>(Func<Percentage, T> percentage, Func<Amount, T> amount)
    {
        return this.Value switch
        {
            Percentage value => percentage(value),
            Amount value => amount(value),
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

    record struct UnknownVariant(JsonElement value);
}

sealed class DiscountConverter
    : JsonConverter<global::Orb.Models.Coupons.CouponCreateParamsProperties.Discount>
{
    public override global::Orb.Models.Coupons.CouponCreateParamsProperties.Discount? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Percentage>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Coupons.CouponCreateParamsProperties.Discount(
                            deserialized
                        );
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'Percentage'",
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
                    var deserialized = JsonSerializer.Deserialize<Amount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Coupons.CouponCreateParamsProperties.Discount(
                            deserialized
                        );
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException("Data does not match union variant 'Amount'", e)
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
        global::Orb.Models.Coupons.CouponCreateParamsProperties.Discount value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
