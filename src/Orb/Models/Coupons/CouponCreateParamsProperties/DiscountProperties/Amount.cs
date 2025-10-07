using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties.AmountProperties;

namespace Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

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
                    new ArgumentOutOfRangeException("amount_discount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_discount' cannot be null",
                    new ArgumentNullException("amount_discount")
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

    public DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new ArgumentOutOfRangeException("discount_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DiscountType>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new ArgumentNullException("discount_type")
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
