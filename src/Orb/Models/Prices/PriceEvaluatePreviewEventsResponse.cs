using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Prices.PriceEvaluatePreviewEventsResponseProperties;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<PriceEvaluatePreviewEventsResponse>))]
public sealed record class PriceEvaluatePreviewEventsResponse
    : ModelBase,
        IFromRaw<PriceEvaluatePreviewEventsResponse>
{
    public required List<Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<Data>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("data");
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    [SetsRequiredMembers]
    public PriceEvaluatePreviewEventsResponse(List<Data> data)
        : this()
    {
        this.Data = data;
    }
}
