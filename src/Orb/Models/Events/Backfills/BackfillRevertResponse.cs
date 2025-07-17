using BackfillRevertResponseProperties = Orb.Models.Events.Backfills.BackfillRevertResponseProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// A backfill represents an update to historical usage data, adding or replacing
/// events in a timeframe.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<BackfillRevertResponse>))]
public sealed record class BackfillRevertResponse
    : Orb::ModelBase,
        Orb::IFromRaw<BackfillRevertResponse>
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

    /// <summary>
    /// If in the future, the time at which the backfill will automatically close.
    /// If in the past, the time at which the backfill was closed.
    /// </summary>
    public required System::DateTime? CloseTime
    {
        get
        {
            if (!this.Properties.TryGetValue("close_time", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "close_time",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["close_time"] = Json::JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// The Orb-generated ID of the customer to which this backfill is scoped. If `null`,
    /// this backfill is scoped to all customers.
    /// </summary>
    public required string? CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "customer_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["customer_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of events ingested in this backfill.
    /// </summary>
    public required long EventsIngested
    {
        get
        {
            if (!this.Properties.TryGetValue("events_ingested", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "events_ingested",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["events_ingested"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If `true`, existing events in the backfill's timeframe will be replaced with
    /// the newly ingested events associated with the backfill. If `false`, newly ingested
    /// events will be added to the existing events.
    /// </summary>
    public required bool ReplaceExistingEvents
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "replace_existing_events",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "replace_existing_events",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set
        {
            this.Properties["replace_existing_events"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The time at which this backfill was reverted.
    /// </summary>
    public required System::DateTime? RevertedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("reverted_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reverted_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["reverted_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The status of the backfill.
    /// </summary>
    public required BackfillRevertResponseProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "status",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BackfillRevertResponseProperties::Status>(
                    element
                ) ?? throw new System::ArgumentNullException("status");
        }
        set { this.Properties["status"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime TimeframeEnd
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_end", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_end",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["timeframe_end"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime TimeframeStart
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_start", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["timeframe_start"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the set of events to deprecate
    /// </summary>
    public string? DeprecationFilter
    {
        get
        {
            if (!this.Properties.TryGetValue("deprecation_filter", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["deprecation_filter"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CloseTime;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.EventsIngested;
        _ = this.ReplaceExistingEvents;
        _ = this.RevertedAt;
        this.Status.Validate();
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
        _ = this.DeprecationFilter;
    }

    public BackfillRevertResponse() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BackfillRevertResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BackfillRevertResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
