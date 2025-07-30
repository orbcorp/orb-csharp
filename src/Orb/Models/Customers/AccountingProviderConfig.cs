using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<AccountingProviderConfig>))]
public sealed record class AccountingProviderConfig : ModelBase, IFromRaw<AccountingProviderConfig>
{
    public required string ExternalProviderID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_provider_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "external_provider_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("external_provider_id");
        }
        set { this.Properties["external_provider_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string ProviderType
    {
        get
        {
            if (!this.Properties.TryGetValue("provider_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "provider_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("provider_type");
        }
        set { this.Properties["provider_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ExternalProviderID;
        _ = this.ProviderType;
    }

    public AccountingProviderConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountingProviderConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AccountingProviderConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
