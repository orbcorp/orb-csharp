using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Allocation>))]
public sealed record class Allocation : Orb::ModelBase, Orb::IFromRaw<Allocation>
{
    public required bool AllowsRollover
    {
        get
        {
            if (!this.Properties.TryGetValue("allows_rollover", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "allows_rollover",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["allows_rollover"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required CustomExpiration? CustomExpiration
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_expiration", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "custom_expiration",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CustomExpiration?>(element);
        }
        set
        {
            this.Properties["custom_expiration"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.AllowsRollover;
        _ = this.Currency;
        this.CustomExpiration?.Validate();
    }

    public Allocation() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Allocation(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Allocation FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
