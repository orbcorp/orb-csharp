using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<CustomerMinified>))]
public sealed record class CustomerMinified : ModelBase, IFromRaw<CustomerMinified>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? ExternalCustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_customer_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "external_customer_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["external_customer_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalCustomerID;
    }

    public CustomerMinified() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerMinified(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerMinified FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
