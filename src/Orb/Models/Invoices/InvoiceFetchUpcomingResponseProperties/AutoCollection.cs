using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<AutoCollection>))]
public sealed record class AutoCollection : Orb::ModelBase, Orb::IFromRaw<AutoCollection>
{
    /// <summary>
    /// True only if auto-collection is enabled for this invoice.
    /// </summary>
    public required bool? Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "enabled",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.Properties["enabled"] = Json::JsonSerializer.SerializeToElement(value); }
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
            if (!this.Properties.TryGetValue("next_attempt_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "next_attempt_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["next_attempt_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of auto-collection payment attempts.
    /// </summary>
    public required long? NumAttempts
    {
        get
        {
            if (!this.Properties.TryGetValue("num_attempts", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "num_attempts",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["num_attempts"] = Json::JsonSerializer.SerializeToElement(value); }
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
            if (
                !this.Properties.TryGetValue(
                    "previously_attempted_at",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "previously_attempted_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.Properties["previously_attempted_at"] = Json::JsonSerializer.SerializeToElement(
                value
            );
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
    [CodeAnalysis::SetsRequiredMembers]
    AutoCollection(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutoCollection FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
