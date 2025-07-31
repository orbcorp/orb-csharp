using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ReplacePriceProperties = Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<ReplacePrice>))]
public sealed record class ReplacePrice : ModelBase, IFromRaw<ReplacePrice>
{
    /// <summary>
    /// The id of the price on the plan to replace in the subscription.
    /// </summary>
    public required string ReplacesPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("replaces_price_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "replaces_price_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("replaces_price_id");
        }
        set { this.Properties["replaces_price_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewAllocationPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["allocation_price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's discounts for the
    /// replacement price.
    /// </summary>
    public List<DiscountOverride>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<DiscountOverride>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["discounts"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["external_price_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The new quantity of the price, if the price is a fixed price.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this.Properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's maximum amount
    /// for the replacement price.
    /// </summary>
    public string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// [DEPRECATED] Use add_adjustments instead. The subscription's minimum amount
    /// for the replacement price.
    /// </summary>
    public string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The definition of a new price to create and add to the subscription.
    /// </summary>
    public ReplacePriceProperties::Price1? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePriceProperties::Price1?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["price_id"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    ReplacePrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ReplacePrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
