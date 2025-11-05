using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// A backfill represents an update to historical usage data, adding or replacing
/// events in a timeframe.
/// </summary>
[JsonConverter(typeof(ModelConverter<BackfillRevertResponse>))]
public sealed record class BackfillRevertResponse : ModelBase, IFromRaw<BackfillRevertResponse>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
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
    /// If in the future, the time at which the backfill will automatically close.
    /// If in the past, the time at which the backfill was closed.
    /// </summary>
    public required System::DateTime? CloseTime
    {
        get
        {
            if (!this.Properties.TryGetValue("close_time", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["close_time"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Orb-generated ID of the customer to which this backfill is scoped. If
    /// `null`, this backfill is scoped to all customers.
    /// </summary>
    public required string? CustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of events ingested in this backfill.
    /// </summary>
    public required long EventsIngested
    {
        get
        {
            if (!this.Properties.TryGetValue("events_ingested", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'events_ingested' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "events_ingested",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["events_ingested"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If `true`, existing events in the backfill's timeframe will be replaced with
    /// the newly ingested events associated with the backfill. If `false`, newly
    /// ingested events will be added to the existing events.
    /// </summary>
    public required bool ReplaceExistingEvents
    {
        get
        {
            if (!this.Properties.TryGetValue("replace_existing_events", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'replace_existing_events' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "replace_existing_events",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["replace_existing_events"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("reverted_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["reverted_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The status of the backfill.
    /// </summary>
    public required ApiEnum<string, Status3> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status3>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTime TimeframeEnd
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_end", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_end' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timeframe_end",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["timeframe_end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTime TimeframeStart
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_start", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_start' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "timeframe_start",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the set of events to deprecate
    /// </summary>
    public string? DeprecationFilter
    {
        get
        {
            if (!this.Properties.TryGetValue("deprecation_filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["deprecation_filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
    [SetsRequiredMembers]
    BackfillRevertResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BackfillRevertResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// The status of the backfill.
/// </summary>
[JsonConverter(typeof(Status3Converter))]
public enum Status3
{
    Pending,
    Reflected,
    PendingRevert,
    Reverted,
}

sealed class Status3Converter : JsonConverter<Status3>
{
    public override Status3 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status3.Pending,
            "reflected" => Status3.Reflected,
            "pending_revert" => Status3.PendingRevert,
            "reverted" => Status3.Reverted,
            _ => (Status3)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status3 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status3.Pending => "pending",
                Status3.Reflected => "reflected",
                Status3.PendingRevert => "pending_revert",
                Status3.Reverted => "reverted",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
