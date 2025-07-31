using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AggregatedCost>))]
public sealed record class AggregatedCost : ModelBase, IFromRaw<AggregatedCost>
{
    public required List<PerPriceCost> PerPriceCosts
    {
        get
        {
            if (!this.Properties.TryGetValue("per_price_costs", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "per_price_costs",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<PerPriceCost>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("per_price_costs");
        }
        set { this.Properties["per_price_costs"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Total costs for the timeframe, excluding any minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subtotal",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("subtotal");
        }
        set { this.Properties["subtotal"] = JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime TimeframeEnd
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_end", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_end",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["timeframe_end"] = JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime TimeframeStart
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_start", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["timeframe_start"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Total costs for the timeframe, including any minimums and discounts.
    /// </summary>
    public required string Total
    {
        get
        {
            if (!this.Properties.TryGetValue("total", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("total", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("total");
        }
        set { this.Properties["total"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    AggregatedCost(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AggregatedCost FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
