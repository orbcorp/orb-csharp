using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<PerPriceCost>))]
public sealed record class PerPriceCost : ModelBase, IFromRaw<PerPriceCost>
{
    /// <summary>
    /// The price object
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                throw new ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("price");
        }
        set
        {
            this.Properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price the cost is associated with
    /// </summary>
    public required string PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("price_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("price_id");
        }
        set
        {
            this.Properties["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Price's contributions for the timeframe, excluding any minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out JsonElement element))
                throw new ArgumentOutOfRangeException("subtotal", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("subtotal");
        }
        set
        {
            this.Properties["subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Price's contributions for the timeframe, including minimums and discounts.
    /// </summary>
    public required string Total
    {
        get
        {
            if (!this.Properties.TryGetValue("total", out JsonElement element))
                throw new ArgumentOutOfRangeException("total", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("total");
        }
        set
        {
            this.Properties["total"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price's quantity for the timeframe
    /// </summary>
    public double? Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Price.Validate();
        _ = this.PriceID;
        _ = this.Subtotal;
        _ = this.Total;
        _ = this.Quantity;
    }

    public PerPriceCost() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PerPriceCost(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PerPriceCost FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
