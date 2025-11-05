using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Events;

[JsonConverter(typeof(ModelConverter<EventIngestResponse>))]
public sealed record class EventIngestResponse : ModelBase, IFromRaw<EventIngestResponse>
{
    /// <summary>
    /// Contains all failing validation events. In the case of a 200, this array
    /// will always be empty. This field will always be present.
    /// </summary>
    public required List<ValidationFailed> ValidationFailed
    {
        get
        {
            if (!this.Properties.TryGetValue("validation_failed", out JsonElement element))
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
        set
        {
            this.Properties["validation_failed"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("debug", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Debug?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["debug"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventIngestResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventIngestResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public EventIngestResponse(List<ValidationFailed> validationFailed)
        : this()
    {
        this.ValidationFailed = validationFailed;
    }
}

[JsonConverter(typeof(ModelConverter<ValidationFailed>))]
public sealed record class ValidationFailed : ModelBase, IFromRaw<ValidationFailed>
{
    /// <summary>
    /// The passed idempotency_key corresponding to the validation_errors
    /// </summary>
    public required string IdempotencyKey
    {
        get
        {
            if (!this.Properties.TryGetValue("idempotency_key", out JsonElement element))
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
        set
        {
            this.Properties["idempotency_key"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("validation_errors", out JsonElement element))
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
        set
        {
            this.Properties["validation_errors"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValidationFailed(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ValidationFailed FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Optional debug information (only present when debug=true is passed to the endpoint).
/// Contains ingested and duplicate event idempotency keys.
/// </summary>
[JsonConverter(typeof(ModelConverter<Debug>))]
public sealed record class Debug : ModelBase, IFromRaw<Debug>
{
    public required List<string> Duplicate
    {
        get
        {
            if (!this.Properties.TryGetValue("duplicate", out JsonElement element))
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
        set
        {
            this.Properties["duplicate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<string> Ingested
    {
        get
        {
            if (!this.Properties.TryGetValue("ingested", out JsonElement element))
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
        set
        {
            this.Properties["ingested"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Debug(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Debug FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
