using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using UsageProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties.UsageProperties;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Usage>))]
public sealed record class Usage : Orb::ModelBase, Orb::IFromRaw<Usage>
{
    public required UsageProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<UsageProperties::DiscountType>(element)
                ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for.
    /// </summary>
    public required double UsageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "usage_discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["usage_discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.UsageDiscount;
    }

    public Usage() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Usage(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Usage FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
