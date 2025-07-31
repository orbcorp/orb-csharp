using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewSphereConfigurationProperties = Orb.Models.Customers.NewSphereConfigurationProperties;
using System = System;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<NewSphereConfiguration>))]
public sealed record class NewSphereConfiguration : ModelBase, IFromRaw<NewSphereConfiguration>
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

    public required NewSphereConfigurationProperties::TaxProvider TaxProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_provider", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_provider",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<NewSphereConfigurationProperties::TaxProvider>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("tax_provider");
        }
        set { this.Properties["tax_provider"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
    }

    public NewSphereConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSphereConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewSphereConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
