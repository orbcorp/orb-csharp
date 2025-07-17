using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Prices = Orb.Models.Prices;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Prices.PriceEvaluatePreviewEventsResponseProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Data>))]
public sealed record class Data : Orb::ModelBase, Orb::IFromRaw<Data>
{
    /// <summary>
    /// The currency of the price
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The computed price groups associated with input price.
    /// </summary>
    public required Generic::List<Prices::EvaluatePriceGroup> PriceGroups
    {
        get
        {
            if (!this.Properties.TryGetValue("price_groups", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_groups",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Prices::EvaluatePriceGroup>>(
                    element
                ) ?? throw new System::ArgumentNullException("price_groups");
        }
        set { this.Properties["price_groups"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The external ID of the price
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
    /// The index of the inline price
    /// </summary>
    public long? InlinePriceIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("inline_price_index", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["inline_price_index"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The ID of the price
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
        _ = this.Currency;
        foreach (var item in this.PriceGroups)
        {
            item.Validate();
        }
        _ = this.ExternalPriceID;
        _ = this.InlinePriceIndex;
        _ = this.PriceID;
    }

    public Data() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Data(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
