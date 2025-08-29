using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Events.EventIngestResponseProperties;

/// <summary>
/// Optional debug information (only present when debug=true is passed to the endpoint).
/// Contains ingested and duplicate event idempotency keys.
/// </summary>
[JsonConverter(typeof(ModelConverter<Debug>))]
public sealed record class Debug : ModelBase, IFromRaw<Debug>
{
    public required List<string> Duplicate
    {
        get
        {
            if (!this.Properties.TryGetValue("duplicate", out JsonElement element))
                throw new ArgumentOutOfRangeException("duplicate", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("duplicate");
        }
        set
        {
            this.Properties["duplicate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<string> Ingested
    {
        get
        {
            if (!this.Properties.TryGetValue("ingested", out JsonElement element))
                throw new ArgumentOutOfRangeException("ingested", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("ingested");
        }
        set
        {
            this.Properties["ingested"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Duplicate)
        {
            _ = item;
        }
        foreach (var item in this.Ingested)
        {
            _ = item;
        }
    }

    public Debug() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Debug(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Debug FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
