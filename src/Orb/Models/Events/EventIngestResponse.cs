using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Events;

[JsonConverter(typeof(ModelConverter<EventIngestResponse, EventIngestResponseFromRaw>))]
public sealed record class EventIngestResponse : ModelBase
{
    /// <summary>
    /// Contains all failing validation events. In the case of a 200, this array will
    /// always be empty. This field will always be present.
    /// </summary>
    public required List<ValidationFailed> ValidationFailed
    {
        get
        {
            if (!this._rawData.TryGetValue("validation_failed", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'validation_failed' cannot be null",
                    new ArgumentOutOfRangeException(
                        "validation_failed",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<ValidationFailed>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'validation_failed' cannot be null",
                    new ArgumentNullException("validation_failed")
                );
        }
        init
        {
            this._rawData["validation_failed"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("debug", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Debug?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["debug"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.ValidationFailed)
        {
            item.Validate();
        }
        this.Debug?.Validate();
    }

    public EventIngestResponse() { }

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

class EventIngestResponseFromRaw : IFromRaw<EventIngestResponse>
{
    public EventIngestResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventIngestResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ValidationFailed, ValidationFailedFromRaw>))]
public sealed record class ValidationFailed : ModelBase
{
    /// <summary>
    /// The passed idempotency_key corresponding to the validation_errors
    /// </summary>
    public required string IdempotencyKey
    {
        get
        {
            if (!this._rawData.TryGetValue("idempotency_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'idempotency_key' cannot be null",
                    new ArgumentOutOfRangeException("idempotency_key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'idempotency_key' cannot be null",
                    new ArgumentNullException("idempotency_key")
                );
        }
        init
        {
            this._rawData["idempotency_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of strings corresponding to validation failures for this idempotency_key.
    /// </summary>
    public required List<string> ValidationErrors
    {
        get
        {
            if (!this._rawData.TryGetValue("validation_errors", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'validation_errors' cannot be null",
                    new ArgumentOutOfRangeException(
                        "validation_errors",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'validation_errors' cannot be null",
                    new ArgumentNullException("validation_errors")
                );
        }
        init
        {
            this._rawData["validation_errors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.IdempotencyKey;
        _ = this.ValidationErrors;
    }

    public ValidationFailed() { }

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

    public static ValidationFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValidationFailedFromRaw : IFromRaw<ValidationFailed>
{
    public ValidationFailed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ValidationFailed.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional debug information (only present when debug=true is passed to the endpoint).
/// Contains ingested and duplicate event idempotency keys.
/// </summary>
[JsonConverter(typeof(ModelConverter<Debug, DebugFromRaw>))]
public sealed record class Debug : ModelBase
{
    public required List<string> Duplicate
    {
        get
        {
            if (!this._rawData.TryGetValue("duplicate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duplicate' cannot be null",
                    new ArgumentOutOfRangeException("duplicate", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'duplicate' cannot be null",
                    new ArgumentNullException("duplicate")
                );
        }
        init
        {
            this._rawData["duplicate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<string> Ingested
    {
        get
        {
            if (!this._rawData.TryGetValue("ingested", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'ingested' cannot be null",
                    new ArgumentOutOfRangeException("ingested", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'ingested' cannot be null",
                    new ArgumentNullException("ingested")
                );
        }
        init
        {
            this._rawData["ingested"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Duplicate;
        _ = this.Ingested;
    }

    public Debug() { }

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

    public static Debug FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DebugFromRaw : IFromRaw<Debug>
{
    public Debug FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Debug.FromRawUnchecked(rawData);
}
