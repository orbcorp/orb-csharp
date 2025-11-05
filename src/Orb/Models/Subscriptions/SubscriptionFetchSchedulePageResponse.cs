using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<SubscriptionFetchSchedulePageResponse>))]
public sealed record class SubscriptionFetchSchedulePageResponse
    : ModelBase,
        IFromRaw<SubscriptionFetchSchedulePageResponse>
{
    public required List<Data1> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Data1>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'pagination_metadata' cannot be null",
                    new ArgumentOutOfRangeException(
                        "pagination_metadata",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PaginationMetadata>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'pagination_metadata' cannot be null",
                    new ArgumentNullException("pagination_metadata")
                );
        }
        set
        {
            this.Properties["pagination_metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public SubscriptionFetchSchedulePageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchSchedulePageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionFetchSchedulePageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Data1>))]
public sealed record class Data1 : ModelBase, IFromRaw<Data1>
{
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

    public required DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Plan? Plan
    {
        get
        {
            if (!this.Properties.TryGetValue("plan", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Plan?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["plan"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new ArgumentOutOfRangeException("start_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.EndDate;
        this.Plan?.Validate();
        _ = this.StartDate;
    }

    public Data1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Plan>))]
public sealed record class Plan : ModelBase, IFromRaw<Plan>
{
    public required string? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["external_plan_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
    }

    public Plan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Plan(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Plan FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
