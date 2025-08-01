using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Costs;

[JsonConverter(typeof(ModelConverter<CostListResponse>))]
public sealed record class CostListResponse : ModelBase, IFromRaw<CostListResponse>
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

    public CostListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostListResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CostListResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public CostListResponse(List<AggregatedCost> data)
    {
        this.Data = data;
    }
}
