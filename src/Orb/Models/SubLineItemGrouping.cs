using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubLineItemGrouping>))]
public sealed record class SubLineItemGrouping : ModelBase, IFromRaw<SubLineItemGrouping>
{
    public required string Key
    {
        get
        {
            if (!this.Properties.TryGetValue("key", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("key", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("key");
        }
        set { this.Properties["key"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// No value indicates the default group
    /// </summary>
    public required string? Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("value", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["value"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Key;
        _ = this.Value;
    }

    public SubLineItemGrouping() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubLineItemGrouping(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubLineItemGrouping FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
