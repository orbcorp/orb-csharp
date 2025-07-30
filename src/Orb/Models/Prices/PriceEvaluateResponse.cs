using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<PriceEvaluateResponse>))]
public sealed record class PriceEvaluateResponse : ModelBase, IFromRaw<PriceEvaluateResponse>
{
    public required List<EvaluatePriceGroup> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<EvaluatePriceGroup>>(element)
                ?? throw new System::ArgumentNullException("data");
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

    public PriceEvaluateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PriceEvaluateResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
