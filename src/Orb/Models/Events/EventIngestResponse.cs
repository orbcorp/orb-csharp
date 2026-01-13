using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Events;

[JsonConverter(typeof(JsonModelConverter<EventIngestResponse, EventIngestResponseFromRaw>))]
public sealed record class EventIngestResponse : JsonModel
{
    /// <summary>
    /// Contains all failing validation events. In the case of a 200, this array will
    /// always be empty. This field will always be present.
    /// </summary>
    public required IReadOnlyList<ValidationFailed> ValidationFailed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ValidationFailed>>(
                "validation_failed"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ValidationFailed>>(
                "validation_failed",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional debug information (only present when debug=true is passed to the
    /// endpoint). Contains ingested and duplicate event idempotency keys.
    /// </summary>
    public Debug? Debug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Debug>("debug");
        }
        init { this._rawData.Set("debug", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ValidationFailed)
        {
            item.Validate();
        }
        this.Debug?.Validate();
    }

    public EventIngestResponse() { }

    public EventIngestResponse(EventIngestResponse eventIngestResponse)
        : base(eventIngestResponse) { }

    public EventIngestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventIngestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventIngestResponseFromRaw.FromRawUnchecked"/>
    public static EventIngestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventIngestResponse(IReadOnlyList<ValidationFailed> validationFailed)
        : this()
    {
        this.ValidationFailed = validationFailed;
    }
}

class EventIngestResponseFromRaw : IFromRawJson<EventIngestResponse>
{
    /// <inheritdoc/>
    public EventIngestResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventIngestResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ValidationFailed, ValidationFailedFromRaw>))]
public sealed record class ValidationFailed : JsonModel
{
    /// <summary>
    /// The passed idempotency_key corresponding to the validation_errors
    /// </summary>
    public required string IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("idempotency_key");
        }
        init { this._rawData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// An array of strings corresponding to validation failures for this idempotency_key.
    /// </summary>
    public required IReadOnlyList<string> ValidationErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("validation_errors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "validation_errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IdempotencyKey;
        _ = this.ValidationErrors;
    }

    public ValidationFailed() { }

    public ValidationFailed(ValidationFailed validationFailed)
        : base(validationFailed) { }

    public ValidationFailed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValidationFailed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValidationFailedFromRaw.FromRawUnchecked"/>
    public static ValidationFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValidationFailedFromRaw : IFromRawJson<ValidationFailed>
{
    /// <inheritdoc/>
    public ValidationFailed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ValidationFailed.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional debug information (only present when debug=true is passed to the endpoint).
/// Contains ingested and duplicate event idempotency keys.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Debug, DebugFromRaw>))]
public sealed record class Debug : JsonModel
{
    public required IReadOnlyList<string> Duplicate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("duplicate");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "duplicate",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<string> Ingested
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("ingested");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "ingested",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duplicate;
        _ = this.Ingested;
    }

    public Debug() { }

    public Debug(Debug debug)
        : base(debug) { }

    public Debug(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Debug(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DebugFromRaw.FromRawUnchecked"/>
    public static Debug FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DebugFromRaw : IFromRawJson<Debug>
{
    /// <inheritdoc/>
    public Debug FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Debug.FromRawUnchecked(rawData);
}
