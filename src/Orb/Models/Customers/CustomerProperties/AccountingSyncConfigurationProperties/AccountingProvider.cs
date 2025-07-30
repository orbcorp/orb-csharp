using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AccountingProviderProperties = Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties.AccountingProviderProperties;

namespace Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties;

[JsonConverter(typeof(ModelConverter<AccountingProvider>))]
public sealed record class AccountingProvider : ModelBase, IFromRaw<AccountingProvider>
{
    public required string? ExternalProviderID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_provider_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "external_provider_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["external_provider_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required AccountingProviderProperties::ProviderType ProviderType
    {
        get
        {
            if (!this.Properties.TryGetValue("provider_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("provider_type", "Missing required argument");

            return JsonSerializer.Deserialize<AccountingProviderProperties::ProviderType>(element)
                ?? throw new ArgumentNullException("provider_type");
        }
        set { this.Properties["provider_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ExternalProviderID;
        this.ProviderType.Validate();
    }

    public AccountingProvider() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountingProvider(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AccountingProvider FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
