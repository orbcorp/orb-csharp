using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BillableMetricTiny>))]
public sealed record class BillableMetricTiny : ModelBase, IFromRaw<BillableMetricTiny>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public BillableMetricTiny() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillableMetricTiny(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BillableMetricTiny FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public BillableMetricTiny(string id)
    {
        this.ID = id;
    }
}
