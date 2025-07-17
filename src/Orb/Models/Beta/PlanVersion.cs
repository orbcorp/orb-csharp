using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using PlanVersionProperties = Orb.Models.Beta.PlanVersionProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Beta;

/// <summary>
/// The PlanVersion resource represents the prices and adjustments present on a specific
/// version of a plan.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<PlanVersion>))]
public sealed record class PlanVersion : Orb::ModelBase, Orb::IFromRaw<PlanVersion>
{
    /// <summary>
    /// Adjustments for this plan. If the plan has phases, this includes adjustments
    /// across all phases of the plan.
    /// </summary>
    public required Generic::List<PlanVersionProperties::Adjustment> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustments",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<PlanVersionProperties::Adjustment>>(
                    element
                ) ?? throw new System::ArgumentNullException("adjustments");
        }
        set { this.Properties["adjustments"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Generic::List<PlanVersionPhase>? PlanPhases
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phases", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "plan_phases",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<PlanVersionPhase>?>(element);
        }
        set { this.Properties["plan_phases"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Prices for this plan. If the plan has phases, this includes prices across all
    /// phases of the plan.
    /// </summary>
    public required Generic::List<Models::Price> Prices
    {
        get
        {
            if (!this.Properties.TryGetValue("prices", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "prices",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::Price>>(element)
                ?? throw new System::ArgumentNullException("prices");
        }
        set { this.Properties["prices"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required long Version
    {
        get
        {
            if (!this.Properties.TryGetValue("version", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "version",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["version"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    PlanVersion(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanVersion FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
