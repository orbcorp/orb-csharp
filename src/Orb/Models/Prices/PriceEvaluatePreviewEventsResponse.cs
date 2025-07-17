using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using PriceEvaluatePreviewEventsResponseProperties = Orb.Models.Prices.PriceEvaluatePreviewEventsResponseProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Prices;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<PriceEvaluatePreviewEventsResponse>))]
public sealed record class PriceEvaluatePreviewEventsResponse
    : Orb::ModelBase,
        Orb::IFromRaw<PriceEvaluatePreviewEventsResponse>
{
    public required Generic::List<PriceEvaluatePreviewEventsResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<PriceEvaluatePreviewEventsResponseProperties::Data>>(
                    element
                ) ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public PriceEvaluatePreviewEventsResponse() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    PriceEvaluatePreviewEventsResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PriceEvaluatePreviewEventsResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
