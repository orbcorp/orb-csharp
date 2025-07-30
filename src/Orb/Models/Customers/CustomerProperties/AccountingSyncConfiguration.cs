using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AccountingSyncConfigurationProperties = Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties;

namespace Orb.Models.Customers.CustomerProperties;

[JsonConverter(typeof(ModelConverter<AccountingSyncConfiguration>))]
public sealed record class AccountingSyncConfiguration
    : ModelBase,
        IFromRaw<AccountingSyncConfiguration>
{
    public required List<AccountingSyncConfigurationProperties::AccountingProvider> AccountingProviders
    {
        get
        {
            if (!this.Properties.TryGetValue("accounting_providers", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "accounting_providers",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<
                    List<AccountingSyncConfigurationProperties::AccountingProvider>
                >(element) ?? throw new ArgumentNullException("accounting_providers");
        }
        set { this.Properties["accounting_providers"] = JsonSerializer.SerializeToElement(value); }
    }

    public required bool Excluded
    {
        get
        {
            if (!this.Properties.TryGetValue("excluded", out JsonElement element))
                throw new ArgumentOutOfRangeException("excluded", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["excluded"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    AccountingSyncConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AccountingSyncConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
