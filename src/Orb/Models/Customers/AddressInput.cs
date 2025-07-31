using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<AddressInput>))]
public sealed record class AddressInput : ModelBase, IFromRaw<AddressInput>
{
    public string? City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["city"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["country"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Line1
    {
        get
        {
            if (!this.Properties.TryGetValue("line1", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["line1"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Line2
    {
        get
        {
            if (!this.Properties.TryGetValue("line2", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["line2"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? PostalCode
    {
        get
        {
            if (!this.Properties.TryGetValue("postal_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["postal_code"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? State
    {
        get
        {
            if (!this.Properties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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

    public AddressInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressInput(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddressInput FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
