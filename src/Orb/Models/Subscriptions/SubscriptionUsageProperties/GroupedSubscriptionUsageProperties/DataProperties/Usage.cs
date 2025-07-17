using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties.DataProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Usage>))]
public sealed record class Usage : Orb::ModelBase, Orb::IFromRaw<Usage>
{
    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
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

    public override void Validate()
    {
        _ = this.Quantity;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
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
