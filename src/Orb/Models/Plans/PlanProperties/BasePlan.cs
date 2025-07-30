using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanProperties;

[JsonConverter(typeof(ModelConverter<BasePlan>))]
public sealed record class BasePlan : ModelBase, IFromRaw<BasePlan>
{
    public required string? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional user-defined ID for this plan resource, used throughout the system
    /// as an alias for this Plan. Use this field to identify a plan by an existing
    /// identifier in your system.
    /// </summary>
    public required string? ExternalPlanID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_plan_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "external_plan_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["external_plan_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
    }

    public BasePlan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BasePlan(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BasePlan FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
