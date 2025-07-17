using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<AccountingProviderConfig>))]
public sealed record class AccountingProviderConfig
    : Orb::ModelBase,
        Orb::IFromRaw<AccountingProviderConfig>
{
    public required string ExternalProviderID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_provider_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "external_provider_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("external_provider_id");
        }
        set
        {
            this.Properties["external_provider_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required string ProviderType
    {
        get
        {
            if (!this.Properties.TryGetValue("provider_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "provider_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("provider_type");
        }
        set { this.Properties["provider_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ExternalProviderID;
        _ = this.ProviderType;
    }

    public AccountingProviderConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    AccountingProviderConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AccountingProviderConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
