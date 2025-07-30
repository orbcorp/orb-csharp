using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PlanVersionProperties = Orb.Models.Beta.PlanVersionProperties;

namespace Orb.Models.Beta;

/// <summary>
/// The PlanVersion resource represents the prices and adjustments present on a specific
/// version of a plan.
/// </summary>
[JsonConverter(typeof(ModelConverter<PlanVersion>))]
public sealed record class PlanVersion : ModelBase, IFromRaw<PlanVersion>
{
    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required List<PlanVersionProperties::Adjustment> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out JsonElement element))
                throw new ArgumentOutOfRangeException("adjustments", "Missing required argument");

            return JsonSerializer.Deserialize<List<PlanVersionProperties::Adjustment>>(element)
                ?? throw new ArgumentNullException("adjustments");
        }
        set { this.Properties["adjustments"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element);
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public required List<PlanVersionPhase>? PlanPhases
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phases", out JsonElement element))
                throw new ArgumentOutOfRangeException("plan_phases", "Missing required argument");

            return JsonSerializer.Deserialize<List<PlanVersionPhase>?>(element);
        }
        set { this.Properties["plan_phases"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across all
    /// phases of the plan.
    /// </summary>
    public required List<Price> Prices
    {
        get
        {
            if (!this.Properties.TryGetValue("prices", out JsonElement element))
                throw new ArgumentOutOfRangeException("prices", "Missing required argument");

            return JsonSerializer.Deserialize<List<Price>>(element)
                ?? throw new ArgumentNullException("prices");
        }
        set { this.Properties["prices"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long Version
    {
        get
        {
            if (!this.Properties.TryGetValue("version", out JsonElement element))
                throw new ArgumentOutOfRangeException("version", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["version"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Adjustments)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        foreach (var item in this.PlanPhases ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Prices)
        {
            item.Validate();
        }
        _ = this.Version;
    }

    public PlanVersion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanVersion(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanVersion FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
