using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewAvalaraTaxConfigurationProperties = Orb.Models.Customers.NewAvalaraTaxConfigurationProperties;
using System = System;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<NewAvalaraTaxConfiguration>))]
public sealed record class NewAvalaraTaxConfiguration
    : ModelBase,
        IFromRaw<NewAvalaraTaxConfiguration>
{
    public required bool TaxExempt
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_exempt", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_exempt",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["tax_exempt"] = JsonSerializer.SerializeToElement(value); }
    }

    public required NewAvalaraTaxConfigurationProperties::TaxProvider TaxProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_provider", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_provider",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<NewAvalaraTaxConfigurationProperties::TaxProvider>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("tax_provider");
        }
        set { this.Properties["tax_provider"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? TaxExemptionCode
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_exemption_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["tax_exemption_code"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
        _ = this.TaxExemptionCode;
    }

    public NewAvalaraTaxConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAvalaraTaxConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewAvalaraTaxConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
