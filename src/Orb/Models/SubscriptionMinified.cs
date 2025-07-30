using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubscriptionMinified>))]
public sealed record class SubscriptionMinified : ModelBase, IFromRaw<SubscriptionMinified>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public SubscriptionMinified() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionMinified(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionMinified FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
