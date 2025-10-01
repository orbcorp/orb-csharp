using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

[JsonConverter(typeof(ModelConverter<Percentage>))]
public sealed record class Percentage : ModelBase, IFromRaw<Percentage>
{
    public JsonElement DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new ArgumentOutOfRangeException("discount_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
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
                    new ArgumentOutOfRangeException(
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
        _ = this.PercentageDiscount;
    }

    public Percentage()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
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
