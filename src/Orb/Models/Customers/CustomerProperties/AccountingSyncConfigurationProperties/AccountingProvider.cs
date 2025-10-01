using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties.AccountingProviderProperties;

namespace Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties;

[JsonConverter(typeof(ModelConverter<AccountingProvider>))]
public sealed record class AccountingProvider : ModelBase, IFromRaw<AccountingProvider>
{
    public required string? ExternalProviderID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_provider_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["external_provider_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, ProviderType> ProviderType
    {
        get
        {
            if (!this.Properties.TryGetValue("provider_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'provider_type' cannot be null",
                    new ArgumentOutOfRangeException("provider_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProviderType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["provider_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
