using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Events.EventIngestResponseProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ValidationFailed>))]
public sealed record class ValidationFailed : Orb::ModelBase, Orb::IFromRaw<ValidationFailed>
{
    /// <summary>
    /// The passed idempotency_key corresponding to the validation_errors
    /// </summary>
    public required string IdempotencyKey
    {
        get
        {
            if (!this.Properties.TryGetValue("idempotency_key", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "idempotency_key",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("idempotency_key");
        }
        set { this.Properties["idempotency_key"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An array of strings corresponding to validation failures for this idempotency_key.
    /// </summary>
    public required Generic::List<string> ValidationErrors
    {
        get
        {
            if (!this.Properties.TryGetValue("validation_errors", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "validation_errors",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("validation_errors");
        }
        set
        {
            this.Properties["validation_errors"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.IdempotencyKey;
        foreach (var item in this.ValidationErrors)
        {
            _ = item;
        }
    }

    public ValidationFailed() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ValidationFailed(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ValidationFailed FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
