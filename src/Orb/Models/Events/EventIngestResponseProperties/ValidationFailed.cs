using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Events.EventIngestResponseProperties;

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
