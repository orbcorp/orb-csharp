using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using PlanPhaseProperties = Orb.Models.Plans.PlanProperties.PlanPhaseProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Plans.PlanProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<PlanPhase>))]
public sealed record class PlanPhase : Orb::ModelBase, Orb::IFromRaw<PlanPhase>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "description",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["description"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Discount? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Discount?>(element);
        }
        set { this.Properties["discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// How many terms of length `duration_unit` this phase is active for. If null,
    /// this phase is evergreen and active indefinitely
    /// </summary>
    public required long? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["duration"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required PlanPhaseProperties::DurationUnit? DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration_unit",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<PlanPhaseProperties::DurationUnit?>(element);
        }
        set { this.Properties["duration_unit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Maximum? Maximum
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "maximum",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Maximum?>(element);
        }
        set { this.Properties["maximum"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "maximum_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["maximum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Minimum?>(element);
        }
        set { this.Properties["minimum"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["minimum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get
        {
            if (!this.Properties.TryGetValue("order", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("order", "Missing required argument");

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["order"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        this.Discount?.Validate();
        _ = this.Duration;
        this.DurationUnit?.Validate();
        this.Maximum?.Validate();
        _ = this.MaximumAmount;
        this.Minimum?.Validate();
        _ = this.MinimumAmount;
        _ = this.Name;
        _ = this.Order;
    }

    public PlanPhase() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    PlanPhase(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanPhase FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
