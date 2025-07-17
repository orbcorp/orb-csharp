using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<NewAccountingSyncConfiguration>))]
public sealed record class NewAccountingSyncConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<NewAccountingSyncConfiguration>
{
    public Generic::List<AccountingProviderConfig>? AccountingProviders
    {
        get
        {
            if (!this.Properties.TryGetValue("accounting_providers", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<AccountingProviderConfig>?>(
                element
            );
        }
        set
        {
            this.Properties["accounting_providers"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public bool? Excluded
    {
        get
        {
            if (!this.Properties.TryGetValue("excluded", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.Properties["excluded"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.AccountingProviders ?? [])
        {
            item.Validate();
        }
        _ = this.Excluded;
    }

    public NewAccountingSyncConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    NewAccountingSyncConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewAccountingSyncConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
