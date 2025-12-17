using System.Collections.Frozen;
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
[JsonConverter(typeof(JsonModelConverter<BackfillCreateResponse, BackfillCreateResponseFromRaw>))]
public sealed record class BackfillCreateResponse : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// If in the future, the time at which the backfill will automatically close.
    /// If in the past, the time at which the backfill was closed.
    /// </summary>
    public required System::DateTimeOffset? CloseTime
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "close_time");
        }
        init { JsonModel.Set(this._rawData, "close_time", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The Orb-generated ID of the customer to which this backfill is scoped. If
    /// `null`, this backfill is scoped to all customers.
    /// </summary>
    public required string? CustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "customer_id"); }
        init { JsonModel.Set(this._rawData, "customer_id", value); }
    }

    /// <summary>
    /// The number of events ingested in this backfill.
    /// </summary>
    public required long EventsIngested
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "events_ingested"); }
        init { JsonModel.Set(this._rawData, "events_ingested", value); }
    }

    /// <summary>
    /// If `true`, existing events in the backfill's timeframe will be replaced with
    /// the newly ingested events associated with the backfill. If `false`, newly
    /// ingested events will be added to the existing events.
    /// </summary>
    public required bool ReplaceExistingEvents
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "replace_existing_events"); }
        init { JsonModel.Set(this._rawData, "replace_existing_events", value); }
    }

    /// <summary>
    /// The time at which this backfill was reverted.
    /// </summary>
    public required System::DateTimeOffset? RevertedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "reverted_at");
        }
        init { JsonModel.Set(this._rawData, "reverted_at", value); }
    }

    /// <summary>
    /// The status of the backfill.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Events.Backfills.Status> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Events.Backfills.Status>
            >(this.RawData, "status");
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    public required System::DateTimeOffset TimeframeEnd
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "timeframe_end"
            );
        }
        init { JsonModel.Set(this._rawData, "timeframe_end", value); }
    }

    public required System::DateTimeOffset TimeframeStart
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "timeframe_start"
            );
        }
        init { JsonModel.Set(this._rawData, "timeframe_start", value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the set of events to deprecate
    /// </summary>
    public string? DeprecationFilter
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "deprecation_filter"); }
        init { JsonModel.Set(this._rawData, "deprecation_filter", value); }
    }

    /// <inheritdoc/>
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

    public BackfillCreateResponse() { }

    public BackfillCreateResponse(BackfillCreateResponse backfillCreateResponse)
        : base(backfillCreateResponse) { }

    public BackfillCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BackfillCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BackfillCreateResponseFromRaw.FromRawUnchecked"/>
    public static BackfillCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BackfillCreateResponseFromRaw : IFromRawJson<BackfillCreateResponse>
{
    /// <inheritdoc/>
    public BackfillCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BackfillCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the backfill.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Events.Backfills.StatusConverter))]
public enum Status
{
    Pending,
    Reflected,
    PendingRevert,
    Reverted,
}

sealed class StatusConverter : JsonConverter<global::Orb.Models.Events.Backfills.Status>
{
    public override global::Orb.Models.Events.Backfills.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => global::Orb.Models.Events.Backfills.Status.Pending,
            "reflected" => global::Orb.Models.Events.Backfills.Status.Reflected,
            "pending_revert" => global::Orb.Models.Events.Backfills.Status.PendingRevert,
            "reverted" => global::Orb.Models.Events.Backfills.Status.Reverted,
            _ => (global::Orb.Models.Events.Backfills.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Events.Backfills.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Events.Backfills.Status.Pending => "pending",
                global::Orb.Models.Events.Backfills.Status.Reflected => "reflected",
                global::Orb.Models.Events.Backfills.Status.PendingRevert => "pending_revert",
                global::Orb.Models.Events.Backfills.Status.Reverted => "reverted",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
