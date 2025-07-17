using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using UsageDiscountProperties = Orb.Models.UsageDiscountProperties;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<UsageDiscount>))]
public sealed record class UsageDiscount : Orb::ModelBase, Orb::IFromRaw<UsageDiscount>
{
    public required UsageDiscountProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<UsageDiscountProperties::DiscountType>(element)
                ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public required double UsageDiscount1
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

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public Generic::List<string>? AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set
        {
            this.Properties["applies_to_price_ids"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public Generic::List<TransformPriceFilter>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<TransformPriceFilter>?>(element);
        }
        set { this.Properties["filters"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["reason"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.UsageDiscount1;
        foreach (var item in this.AppliesToPriceIDs ?? [])
        {
            _ = item;
        }
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public UsageDiscount() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    UsageDiscount(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UsageDiscount FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
