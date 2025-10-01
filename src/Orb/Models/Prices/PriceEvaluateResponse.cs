using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<PriceEvaluateResponse>))]
public sealed record class PriceEvaluateResponse : ModelBase, IFromRaw<PriceEvaluateResponse>
{
    public required List<EvaluatePriceGroup> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<EvaluatePriceGroup>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
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

    [SetsRequiredMembers]
    public PriceEvaluateResponse(List<EvaluatePriceGroup> data)
        : this()
    {
        this.Data = data;
    }
}
