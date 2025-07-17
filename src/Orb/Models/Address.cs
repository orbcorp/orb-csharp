using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Address>))]
public sealed record class Address : Orb::ModelBase, Orb::IFromRaw<Address>
{
    public required string? City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("city", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["city"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "country",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["country"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? Line1
    {
        get
        {
            if (!this.Properties.TryGetValue("line1", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("line1", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["line1"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? Line2
    {
        get
        {
            if (!this.Properties.TryGetValue("line2", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("line2", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["line2"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? PostalCode
    {
        get
        {
            if (!this.Properties.TryGetValue("postal_code", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "postal_code",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["postal_code"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? State
    {
        get
        {
            if (!this.Properties.TryGetValue("state", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("state", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["state"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    Address(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Address FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
