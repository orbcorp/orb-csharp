using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using NewAvalaraTaxConfigurationProperties = Orb.Models.Customers.NewAvalaraTaxConfigurationProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<NewAvalaraTaxConfiguration>))]
public sealed record class NewAvalaraTaxConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<NewAvalaraTaxConfiguration>
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

    public required NewAvalaraTaxConfigurationProperties::TaxProvider TaxProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_provider", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_provider",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<NewAvalaraTaxConfigurationProperties::TaxProvider>(
                    element
                ) ?? throw new System::ArgumentNullException("tax_provider");
        }
        set { this.Properties["tax_provider"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? TaxExemptionCode
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_exemption_code", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["tax_exemption_code"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
        _ = this.TaxExemptionCode;
    }

    public NewAvalaraTaxConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    NewAvalaraTaxConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewAvalaraTaxConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
