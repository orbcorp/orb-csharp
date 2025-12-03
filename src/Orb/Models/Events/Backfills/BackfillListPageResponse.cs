using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Events.Backfills;

[JsonConverter(typeof(ModelConverter<BackfillListPageResponse, BackfillListPageResponseFromRaw>))]
public sealed record class BackfillListPageResponse : ModelBase
{
    public required IReadOnlyList<global::Orb.Models.Events.Backfills.Data> Data
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Events.Backfills.Data>>(
                this.RawData,
                "data"
            );
        }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return ModelBase.GetNotNullClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public BackfillListPageResponse() { }

    public BackfillListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BackfillListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BackfillListPageResponseFromRaw.FromRawUnchecked"/>
    public static BackfillListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BackfillListPageResponseFromRaw : IFromRaw<BackfillListPageResponse>
{
    /// <inheritdoc/>
    public BackfillListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BackfillListPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A backfill represents an update to historical usage data, adding or replacing
/// events in a timeframe.
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Events.Backfills.Data,
        global::Orb.Models.Events.Backfills.DataFromRaw
    >)
)]
public sealed record class Data : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// If in the future, the time at which the backfill will automatically close.
    /// If in the past, the time at which the backfill was closed.
    /// </summary>
    public required System::DateTimeOffset? CloseTime
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "close_time");
        }
        init { ModelBase.Set(this._rawData, "close_time", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The Orb-generated ID of the customer to which this backfill is scoped. If
    /// `null`, this backfill is scoped to all customers.
    /// </summary>
    public required string? CustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "customer_id"); }
        init { ModelBase.Set(this._rawData, "customer_id", value); }
    }

    /// <summary>
    /// The number of events ingested in this backfill.
    /// </summary>
    public required long EventsIngested
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "events_ingested"); }
        init { ModelBase.Set(this._rawData, "events_ingested", value); }
    }

    /// <summary>
    /// If `true`, existing events in the backfill's timeframe will be replaced with
    /// the newly ingested events associated with the backfill. If `false`, newly
    /// ingested events will be added to the existing events.
    /// </summary>
    public required bool ReplaceExistingEvents
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "replace_existing_events"); }
        init { ModelBase.Set(this._rawData, "replace_existing_events", value); }
    }

    /// <summary>
    /// The time at which this backfill was reverted.
    /// </summary>
    public required System::DateTimeOffset? RevertedAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "reverted_at");
        }
        init { ModelBase.Set(this._rawData, "reverted_at", value); }
    }

    /// <summary>
    /// The status of the backfill.
    /// </summary>
    public required ApiEnum<string, DataStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DataStatus>>(this.RawData, "status");
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public required System::DateTimeOffset TimeframeEnd
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "timeframe_end"
            );
        }
        init { ModelBase.Set(this._rawData, "timeframe_end", value); }
    }

    public required System::DateTimeOffset TimeframeStart
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "timeframe_start"
            );
        }
        init { ModelBase.Set(this._rawData, "timeframe_start", value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the set of events to deprecate
    /// </summary>
    public string? DeprecationFilter
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "deprecation_filter"); }
        init { ModelBase.Set(this._rawData, "deprecation_filter", value); }
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

    public Data() { }

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Events.Backfills.DataFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Events.Backfills.Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRaw<global::Orb.Models.Events.Backfills.Data>
{
    /// <inheritdoc/>
    public global::Orb.Models.Events.Backfills.Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Events.Backfills.Data.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the backfill.
/// </summary>
[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    Pending,
    Reflected,
    PendingRevert,
    Reverted,
}

sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => DataStatus.Pending,
            "reflected" => DataStatus.Reflected,
            "pending_revert" => DataStatus.PendingRevert,
            "reverted" => DataStatus.Reverted,
            _ => (DataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataStatus.Pending => "pending",
                DataStatus.Reflected => "reflected",
                DataStatus.PendingRevert => "pending_revert",
                DataStatus.Reverted => "reverted",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
