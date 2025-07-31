using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PlanVersionPhaseProperties = Orb.Models.Beta.PlanVersionPhaseProperties;

namespace Orb.Models.Beta;

[JsonConverter(typeof(ModelConverter<PlanVersionPhase>))]
public sealed record class PlanVersionPhase : ModelBase, IFromRaw<PlanVersionPhase>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                throw new ArgumentOutOfRangeException("description", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// How many terms of length `duration_unit` this phase is active for. If null,
    /// this phase is evergreen and active indefinitely
    /// </summary>
    public required long? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                throw new ArgumentOutOfRangeException("duration", "Missing required argument");

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["duration"] = JsonSerializer.SerializeToElement(value); }
    }

    public required PlanVersionPhaseProperties::DurationUnit? DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                throw new ArgumentOutOfRangeException("duration_unit", "Missing required argument");

            return JsonSerializer.Deserialize<PlanVersionPhaseProperties::DurationUnit?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["duration_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get
        {
            if (!this.Properties.TryGetValue("order", out JsonElement element))
                throw new ArgumentOutOfRangeException("order", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["order"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Duration;
        this.DurationUnit?.Validate();
        _ = this.Name;
        _ = this.Order;
    }

    public PlanVersionPhase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanVersionPhase(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanVersionPhase FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
