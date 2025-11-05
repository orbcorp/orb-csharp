using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<NewTaxJarConfiguration>))]
public sealed record class NewTaxJarConfiguration : ModelBase, IFromRaw<NewTaxJarConfiguration>
{
    public required bool TaxExempt
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_exempt' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_exempt",
                        "Missing required argument"
                    )
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

    public required ApiEnum<string, TaxProvider7> TaxProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_provider", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_provider",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TaxProvider7>>(
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

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get
        {
            if (!this.Properties.TryGetValue("automatic_tax_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["automatic_tax_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
        _ = this.AutomaticTaxEnabled;
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

[JsonConverter(typeof(TaxProvider7Converter))]
public enum TaxProvider7
{
    Taxjar,
}

sealed class TaxProvider7Converter : JsonConverter<TaxProvider7>
{
    public override TaxProvider7 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "taxjar" => TaxProvider7.Taxjar,
            _ => (TaxProvider7)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxProvider7 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TaxProvider7.Taxjar => "taxjar",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
