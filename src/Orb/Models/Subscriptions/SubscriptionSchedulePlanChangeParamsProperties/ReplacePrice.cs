using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using ReplacePriceProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties;
using Serialization = System.Text.Json.Serialization;
using Subscriptions = Orb.Models.Subscriptions;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ReplacePrice>))]
public sealed record class ReplacePrice : Orb::ModelBase, Orb::IFromRaw<ReplacePrice>
{
    /// <summary>
    /// The id of the price on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("replaces_price_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "replaces_price_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("replaces_price_id");
        }
        set
        {
            this.Properties["replaces_price_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public Models::NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation_price", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Models::NewAllocationPrice?>(element);
        }
        set
        {
            this.Properties["allocation_price"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's discounts for the
    /// replacement price.
    /// </summary>
    public Generic::List<Subscriptions::DiscountOverride>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<Subscriptions::DiscountOverride>?>(
                element
            );
        }
        set { this.Properties["discounts"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_price_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The new quantity of the price, if the price is a fixed price.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this.Properties.TryGetValue("fixed_price_quantity", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set
        {
            this.Properties["fixed_price_quantity"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's maximum amount
    /// for the replacement price.
    /// </summary>
    public string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["maximum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's minimum amount
    /// for the replacement price.
    /// </summary>
    public string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["minimum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The definition of a new price to create and add to the subscription.
    /// </summary>
    public ReplacePriceProperties::Price? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<ReplacePriceProperties::Price?>(element);
        }
        set { this.Properties["price"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["price_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ReplacesPriceID;
        this.AllocationPrice?.Validate();
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.MaximumAmount;
        _ = this.MinimumAmount;
        this.Price?.Validate();
        _ = this.PriceID;
    }

    public ReplacePrice() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ReplacePrice(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ReplacePrice FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
