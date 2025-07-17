using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<AggregatedCost>))]
public sealed record class AggregatedCost : Orb::ModelBase, Orb::IFromRaw<AggregatedCost>
{
    public required Generic::List<PerPriceCost> PerPriceCosts
    {
        get
        {
            if (!this.Properties.TryGetValue("per_price_costs", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "per_price_costs",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<PerPriceCost>>(element)
                ?? throw new System::ArgumentNullException("per_price_costs");
        }
        set { this.Properties["per_price_costs"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Total costs for the timeframe, excluding any minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subtotal",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("subtotal");
        }
        set { this.Properties["subtotal"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime TimeframeEnd
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_end", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_end",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["timeframe_end"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime TimeframeStart
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_start", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["timeframe_start"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Total costs for the timeframe, including any minimums and discounts.
    /// </summary>
    public required string Total
    {
        get
        {
            if (!this.Properties.TryGetValue("total", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("total", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("total");
        }
        set { this.Properties["total"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.PerPriceCosts)
        {
            item.Validate();
        }
        _ = this.Subtotal;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
        _ = this.Total;
    }

    public AggregatedCost() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    AggregatedCost(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AggregatedCost FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
