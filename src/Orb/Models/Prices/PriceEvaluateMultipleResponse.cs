using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PriceEvaluateMultipleResponseProperties = Orb.Models.Prices.PriceEvaluateMultipleResponseProperties;
using System = System;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<PriceEvaluateMultipleResponse>))]
public sealed record class PriceEvaluateMultipleResponse
    : ModelBase,
        IFromRaw<PriceEvaluateMultipleResponse>
{
    public required List<PriceEvaluateMultipleResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<PriceEvaluateMultipleResponseProperties::Data>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("data");
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

    public PriceEvaluateMultipleResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluateMultipleResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PriceEvaluateMultipleResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
