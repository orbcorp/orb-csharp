using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.CustomerCreateParamsProperties.TaxConfigurationProperties.NumeralProperties;

namespace Orb.Models.Customers.CustomerCreateParamsProperties.TaxConfigurationProperties;

[JsonConverter(typeof(ModelConverter<Numeral>))]
public sealed record class Numeral : ModelBase, IFromRaw<Numeral>
{
    public required bool TaxExempt
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_exempt' cannot be null",
                    new ArgumentOutOfRangeException("tax_exempt", "Missing required argument")
                );

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

    public TaxProvider TaxProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_provider", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new ArgumentOutOfRangeException("tax_provider", "Missing required argument")
                );

            return JsonSerializer.Deserialize<TaxProvider>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new ArgumentNullException("tax_provider")
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

    public Numeral()
    {
        this.TaxProvider = new();
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
