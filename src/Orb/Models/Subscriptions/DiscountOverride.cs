using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<DiscountOverride>))]
public sealed record class DiscountOverride : ModelBase, IFromRaw<DiscountOverride>
{
    public required ApiEnum<string, global::Orb.Models.Subscriptions.DiscountType2> DiscountType
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

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.DiscountType2>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public string? AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public double? PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public double? UsageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["usage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.AmountDiscount;
        _ = this.PercentageDiscount;
        _ = this.UsageDiscount;
    }

    public DiscountOverride() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountOverride(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DiscountOverride FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public DiscountOverride(
        ApiEnum<string, global::Orb.Models.Subscriptions.DiscountType2> discountType
    )
        : this()
    {
        this.DiscountType = discountType;
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.DiscountType2Converter))]
public enum DiscountType2
{
    Percentage,
    Usage,
    Amount,
}

sealed class DiscountType2Converter : JsonConverter<global::Orb.Models.Subscriptions.DiscountType2>
{
    public override global::Orb.Models.Subscriptions.DiscountType2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => global::Orb.Models.Subscriptions.DiscountType2.Percentage,
            "usage" => global::Orb.Models.Subscriptions.DiscountType2.Usage,
            "amount" => global::Orb.Models.Subscriptions.DiscountType2.Amount,
            _ => (global::Orb.Models.Subscriptions.DiscountType2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.DiscountType2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.DiscountType2.Percentage => "percentage",
                global::Orb.Models.Subscriptions.DiscountType2.Usage => "usage",
                global::Orb.Models.Subscriptions.DiscountType2.Amount => "amount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
