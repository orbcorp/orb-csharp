using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PriceEvaluatePreviewEventsResponseProperties = Orb.Models.Prices.PriceEvaluatePreviewEventsResponseProperties;
using System = System;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<PriceEvaluatePreviewEventsResponse>))]
public sealed record class PriceEvaluatePreviewEventsResponse
    : ModelBase,
        IFromRaw<PriceEvaluatePreviewEventsResponse>
{
    public required List<PriceEvaluatePreviewEventsResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<
                    List<PriceEvaluatePreviewEventsResponseProperties::Data>
                >(element) ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PriceEvaluatePreviewEventsResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
