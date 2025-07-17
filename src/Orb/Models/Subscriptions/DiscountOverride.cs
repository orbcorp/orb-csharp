using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using DiscountOverrideProperties = Orb.Models.Subscriptions.DiscountOverrideProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<DiscountOverride>))]
public sealed record class DiscountOverride : Orb::ModelBase, Orb::IFromRaw<DiscountOverride>
{
    public required DiscountOverrideProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<DiscountOverrideProperties::DiscountType>(
                    element
                ) ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public string? AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["amount_discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between 0
    /// and 1.
    /// </summary>
    public double? PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set
        {
            this.Properties["percentage_discount"] = Json::JsonSerializer.SerializeToElement(value);
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
            if (!this.Properties.TryGetValue("usage_discount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["usage_discount"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    DiscountOverride(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DiscountOverride FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
