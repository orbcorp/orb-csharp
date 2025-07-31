using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Models = Orb.Models;
using PlanPhaseProperties = Orb.Models.Plans.PlanProperties.PlanPhaseProperties;

namespace Orb.Models.Plans.PlanProperties;

[JsonConverter(typeof(ModelConverter<PlanPhase>))]
public sealed record class PlanPhase : ModelBase, IFromRaw<PlanPhase>
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

    public required Models::Discount2? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                throw new ArgumentOutOfRangeException("discount", "Missing required argument");

            return JsonSerializer.Deserialize<Models::Discount2?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["discount"] = JsonSerializer.SerializeToElement(value); }
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

    public required PlanPhaseProperties::DurationUnit? DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                throw new ArgumentOutOfRangeException("duration_unit", "Missing required argument");

            return JsonSerializer.Deserialize<PlanPhaseProperties::DurationUnit?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["duration_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Maximum? Maximum
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum", out JsonElement element))
                throw new ArgumentOutOfRangeException("maximum", "Missing required argument");

            return JsonSerializer.Deserialize<Models::Maximum?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["maximum"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "maximum_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out JsonElement element))
                throw new ArgumentOutOfRangeException("minimum", "Missing required argument");

            return JsonSerializer.Deserialize<Models::Minimum?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["minimum"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    PlanPhase(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanPhase FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
