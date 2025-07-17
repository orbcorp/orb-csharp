using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<AddressInput>))]
public sealed record class AddressInput : Orb::ModelBase, Orb::IFromRaw<AddressInput>
{
    public string? City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["city"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["country"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? Line1
    {
        get
        {
            if (!this.Properties.TryGetValue("line1", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["line1"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? Line2
    {
        get
        {
            if (!this.Properties.TryGetValue("line2", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["line2"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? PostalCode
    {
        get
        {
            if (!this.Properties.TryGetValue("postal_code", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["postal_code"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? State
    {
        get
        {
            if (!this.Properties.TryGetValue("state", out Json::JsonElement element))
                return null;

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

    public AddressInput() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    AddressInput(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddressInput FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
