using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties;

[JsonConverter(typeof(ModelConverter<AutoCollection>))]
public sealed record class AutoCollection : ModelBase, IFromRaw<AutoCollection>
{
    /// <summary>
    /// True only if auto-collection is enabled for this invoice.
    /// </summary>
    public required bool? Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "enabled",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["enabled"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If the invoice is scheduled for auto-collection, this field will reflect when
    /// the next attempt will occur. If dunning has been exhausted, or auto-collection
    /// is not enabled for this invoice, this field will be `null`.
    /// </summary>
    public required System::DateTime? NextAttemptAt
    {
        get
        {
            if (!this.Properties.TryGetValue("next_attempt_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "next_attempt_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["next_attempt_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of auto-collection payment attempts.
    /// </summary>
    public required long? NumAttempts
    {
        get
        {
            if (!this.Properties.TryGetValue("num_attempts", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "num_attempts",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["num_attempts"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If Orb has ever attempted payment auto-collection for this invoice, this field
    /// will reflect when that attempt occurred. In conjunction with `next_attempt_at`,
    /// this can be used to tell whether the invoice is currently in dunning (that is,
    /// `previously_attempted_at` is non-null, and `next_attempt_time` is non-null),
    /// or if dunning has been exhausted (`previously_attempted_at` is non-null, but
    /// `next_attempt_time` is null).
    /// </summary>
    public required System::DateTime? PreviouslyAttemptedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("previously_attempted_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "previously_attempted_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["previously_attempted_at"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.NextAttemptAt;
        _ = this.NumAttempts;
        _ = this.PreviouslyAttemptedAt;
    }

    public AutoCollection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoCollection(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutoCollection FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
