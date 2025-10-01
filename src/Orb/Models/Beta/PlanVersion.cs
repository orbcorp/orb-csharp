using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Beta.PlanVersionProperties;

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
    public required List<Adjustment> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new ArgumentOutOfRangeException("adjustments", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Adjustment>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new ArgumentNullException("adjustments")
                );
        }
        set
        {
            this.Properties["adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<PlanVersionPhase>? PlanPhases
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phases", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PlanVersionPhase>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["plan_phases"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across
    /// all phases of the plan.
    /// </summary>
    public required List<Price> Prices
    {
        get
        {
            if (!this.Properties.TryGetValue("prices", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'prices' cannot be null",
                    new ArgumentOutOfRangeException("prices", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Price>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'prices' cannot be null",
                    new ArgumentNullException("prices")
                );
        }
        set
        {
            this.Properties["prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Version
    {
        get
        {
            if (!this.Properties.TryGetValue("version", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
