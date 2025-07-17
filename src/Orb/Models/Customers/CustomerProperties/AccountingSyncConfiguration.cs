using AccountingSyncConfigurationProperties = Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.CustomerProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<AccountingSyncConfiguration>))]
public sealed record class AccountingSyncConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<AccountingSyncConfiguration>
{
    public required Generic::List<AccountingSyncConfigurationProperties::AccountingProvider> AccountingProviders
    {
        get
        {
            if (!this.Properties.TryGetValue("accounting_providers", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "accounting_providers",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<AccountingSyncConfigurationProperties::AccountingProvider>>(
                    element
                ) ?? throw new System::ArgumentNullException("accounting_providers");
        }
        set
        {
            this.Properties["accounting_providers"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required bool Excluded
    {
        get
        {
            if (!this.Properties.TryGetValue("excluded", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "excluded",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["excluded"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.AccountingProviders)
        {
            item.Validate();
        }
        _ = this.Excluded;
    }

    public AccountingSyncConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    AccountingSyncConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AccountingSyncConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
