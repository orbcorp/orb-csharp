using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using NewTaxJarConfigurationProperties = Orb.Models.Customers.NewTaxJarConfigurationProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<NewTaxJarConfiguration>))]
public sealed record class NewTaxJarConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<NewTaxJarConfiguration>
{
    public required bool TaxExempt
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_exempt", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_exempt",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["tax_exempt"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required NewTaxJarConfigurationProperties::TaxProvider TaxProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_provider", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_provider",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<NewTaxJarConfigurationProperties::TaxProvider>(
                    element
                ) ?? throw new System::ArgumentNullException("tax_provider");
        }
        set { this.Properties["tax_provider"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
    }

    public NewTaxJarConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    NewTaxJarConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewTaxJarConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
