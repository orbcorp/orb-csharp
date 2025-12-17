using System.Collections.Frozen;
using System.Collections.Generic;
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
            return JsonModel.GetNotNullClass<List<ValidationFailed>>(
                this.RawData,
                "validation_failed"
            );
        }
        init { JsonModel.Set(this._rawData, "validation_failed", value); }
    }

    /// <summary>
    /// Optional debug information (only present when debug=true is passed to the
    /// endpoint). Contains ingested and duplicate event idempotency keys.
    /// </summary>
    public Debug? Debug
    {
        get { return JsonModel.GetNullableClass<Debug>(this.RawData, "debug"); }
        init { JsonModel.Set(this._rawData, "debug", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventIngestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public EventIngestResponse(List<ValidationFailed> validationFailed)
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "idempotency_key"); }
        init { JsonModel.Set(this._rawData, "idempotency_key", value); }
    }

    /// <summary>
    /// An array of strings corresponding to validation failures for this idempotency_key.
    /// </summary>
    public required IReadOnlyList<string> ValidationErrors
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "validation_errors"); }
        init { JsonModel.Set(this._rawData, "validation_errors", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValidationFailed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "duplicate"); }
        init { JsonModel.Set(this._rawData, "duplicate", value); }
    }

    public required IReadOnlyList<string> Ingested
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "ingested"); }
        init { JsonModel.Set(this._rawData, "ingested", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Debug(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
