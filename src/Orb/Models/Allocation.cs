using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<Allocation>))]
public sealed record class Allocation : ModelBase, IFromRaw<Allocation>
{
    public required bool AllowsRollover
    {
        get
        {
            if (!this.Properties.TryGetValue("allows_rollover", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "allows_rollover",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["allows_rollover"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    public required CustomExpiration? CustomExpiration
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_expiration", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "custom_expiration",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<CustomExpiration?>(element);
        }
        set { this.Properties["custom_expiration"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.AllowsRollover;
        _ = this.Currency;
        this.CustomExpiration?.Validate();
    }

    public Allocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Allocation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Allocation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
