using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.CustomerUpdateByExternalIDParamsProperties.TaxConfigurationProperties;

[JsonConverter(typeof(ModelConverter<Numeral>))]
public sealed record class Numeral : ModelBase, IFromRaw<Numeral>
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

    public JsonElement TaxProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_provider", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_provider", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
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
    }

    public Numeral()
    {
        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Numeral(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Numeral FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Numeral(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}
