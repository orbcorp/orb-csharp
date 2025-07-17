using AmountProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties.AmountProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Amount>))]
public sealed record class Amount : Orb::ModelBase, Orb::IFromRaw<Amount>
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required double AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount_discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["amount_discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required AmountProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<AmountProperties::DiscountType>(element)
                ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.AmountDiscount;
        this.DiscountType.Validate();
    }

    public Amount() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Amount(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Amount FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
