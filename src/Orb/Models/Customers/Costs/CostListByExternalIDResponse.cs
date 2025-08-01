using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Costs;

[JsonConverter(typeof(ModelConverter<CostListByExternalIDResponse>))]
public sealed record class CostListByExternalIDResponse
    : ModelBase,
        IFromRaw<CostListByExternalIDResponse>
{
    public required List<AggregatedCost> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<AggregatedCost>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("data");
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

    public CostListByExternalIDResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostListByExternalIDResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CostListByExternalIDResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    public CostListByExternalIDResponse(List<AggregatedCost> data)
    {
        this.Data = data;
    }
}
