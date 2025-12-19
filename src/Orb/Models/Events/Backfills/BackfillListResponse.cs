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
[JsonConverter(typeof(JsonModelConverter<BackfillListResponse, BackfillListResponseFromRaw>))]
public sealed record class BackfillListResponse : JsonModel
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
    public required ApiEnum<string, BackfillListResponseStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, BackfillListResponseStatus>>(
                this.RawData,
                "status"
            );
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

    public BackfillListResponse() { }

    public BackfillListResponse(BackfillListResponse backfillListResponse)
        : base(backfillListResponse) { }

    public BackfillListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BackfillListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BackfillListResponseFromRaw.FromRawUnchecked"/>
    public static BackfillListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BackfillListResponseFromRaw : IFromRawJson<BackfillListResponse>
{
    /// <inheritdoc/>
    public BackfillListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BackfillListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the backfill.
/// </summary>
[JsonConverter(typeof(BackfillListResponseStatusConverter))]
public enum BackfillListResponseStatus
{
    Pending,
    Reflected,
    PendingRevert,
    Reverted,
}

sealed class BackfillListResponseStatusConverter : JsonConverter<BackfillListResponseStatus>
{
    public override BackfillListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => BackfillListResponseStatus.Pending,
            "reflected" => BackfillListResponseStatus.Reflected,
            "pending_revert" => BackfillListResponseStatus.PendingRevert,
            "reverted" => BackfillListResponseStatus.Reverted,
            _ => (BackfillListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BackfillListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BackfillListResponseStatus.Pending => "pending",
                BackfillListResponseStatus.Reflected => "reflected",
                BackfillListResponseStatus.PendingRevert => "pending_revert",
                BackfillListResponseStatus.Reverted => "reverted",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
