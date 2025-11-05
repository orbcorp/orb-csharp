using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Coupons;

/// <summary>
/// This endpoint allows the creation of coupons, which can then be redeemed at subscription
/// creation or plan change.
/// </summary>
public sealed record class CouponCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required global::Orb.Models.Coupons.Discount Discount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new System::ArgumentOutOfRangeException("discount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Coupons.Discount>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new System::ArgumentNullException("discount")
                );
        }
        set
        {
            this.BodyProperties["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This string can be used to redeem this coupon for a given subscription.
    /// </summary>
    public required string RedemptionCode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("redemption_code", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'redemption_code' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "redemption_code",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'redemption_code' cannot be null",
                    new System::ArgumentNullException("redemption_code")
                );
        }
        set
        {
            this.BodyProperties["redemption_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This allows for a coupon's discount to apply for a limited time (determined
    /// in months); a `null` value here means "unlimited time".
    /// </summary>
    public long? DurationInMonths
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("duration_in_months", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["duration_in_months"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of redemptions allowed for this coupon before it is exhausted;`null`
    /// here means "unlimited".
    /// </summary>
    public long? MaxRedemptions
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("max_redemptions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["max_redemptions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/coupons")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(DiscountConverter))]
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

    public static global::Orb.Models.Coupons.Discount CreateUnknownVariant(JsonElement value)
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

    public void Switch(System::Action<Percentage> percentage, System::Action<Amount> amount)
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

    public T Match<T>(System::Func<Percentage, T> percentage, System::Func<Amount, T> amount)
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

sealed class DiscountConverter : JsonConverter<global::Orb.Models.Coupons.Discount>
{
    public override global::Orb.Models.Coupons.Discount? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Percentage>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Coupons.Discount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'Percentage'",
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
                    var deserialized = JsonSerializer.Deserialize<Amount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Coupons.Discount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException("Data does not match union variant 'Amount'", e)
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
        global::Orb.Models.Coupons.Discount value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<Percentage>))]
public sealed record class Percentage : ModelBase, IFromRaw<Percentage>
{
    public global::Orb.Models.Coupons.DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Coupons.DiscountType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentNullException("discount_type")
                );
        }
        set
        {
            this.Properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percentage_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percentage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
    }

    public Percentage()
    {
        this.DiscountType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percentage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Percentage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Percentage(double percentageDiscount)
        : this()
    {
        this.PercentageDiscount = percentageDiscount;
    }
}

[JsonConverter(typeof(Converter))]
public class DiscountType
{
    public JsonElement Json { get; private init; }

    public DiscountType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
    }

    DiscountType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Coupons.DiscountType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Coupons.DiscountType'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Coupons.DiscountType>
    {
        public override global::Orb.Models.Coupons.DiscountType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Coupons.DiscountType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Amount>))]
public sealed record class Amount : ModelBase, IFromRaw<Amount>
{
    public required string AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "amount_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_discount' cannot be null",
                    new System::ArgumentNullException("amount_discount")
                );
        }
        set
        {
            this.Properties["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public global::Orb.Models.Coupons.DiscountTypeModel DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Coupons.DiscountTypeModel>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentNullException("discount_type")
                );
        }
        set
        {
            this.Properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AmountDiscount;
        this.DiscountType.Validate();
    }

    public Amount()
    {
        this.DiscountType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Amount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Amount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Amount(string amountDiscount)
        : this()
    {
        this.AmountDiscount = amountDiscount;
    }
}

[JsonConverter(typeof(Converter))]
public class DiscountTypeModel
{
    public JsonElement Json { get; private init; }

    public DiscountTypeModel()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"amount\"");
    }

    DiscountTypeModel(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Coupons.DiscountTypeModel().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Coupons.DiscountTypeModel'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Coupons.DiscountTypeModel>
    {
        public override global::Orb.Models.Coupons.DiscountTypeModel? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Coupons.DiscountTypeModel value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
