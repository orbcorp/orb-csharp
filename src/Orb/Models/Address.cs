using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<Address>))]
public sealed record class Address : ModelBase, IFromRaw<Address>
{
    public required string? City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("city", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["city"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "country",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["country"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? Line1
    {
        get
        {
            if (!this.Properties.TryGetValue("line1", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("line1", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["line1"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? Line2
    {
        get
        {
            if (!this.Properties.TryGetValue("line2", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("line2", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["line2"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? PostalCode
    {
        get
        {
            if (!this.Properties.TryGetValue("postal_code", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "postal_code",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["postal_code"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? State
    {
        get
        {
            if (!this.Properties.TryGetValue("state", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("state", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["state"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public Address() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Address FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
