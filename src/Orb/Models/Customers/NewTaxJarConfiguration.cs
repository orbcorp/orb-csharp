using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Customers.NewTaxJarConfigurationProperties;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<NewTaxJarConfiguration>))]
public sealed record class NewTaxJarConfiguration : ModelBase, IFromRaw<NewTaxJarConfiguration>
{
    public required bool TaxExempt
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_exempt", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_exempt", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tax_exempt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, TaxProvider> TaxProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_provider", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_provider", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, TaxProvider>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["tax_provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
    }

    public NewTaxJarConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewTaxJarConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewTaxJarConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
