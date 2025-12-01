using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<NewTaxJarConfiguration, NewTaxJarConfigurationFromRaw>))]
public sealed record class NewTaxJarConfiguration : ModelBase
{
    public required bool TaxExempt
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_exempt' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_exempt",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tax_exempt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, NewTaxJarConfigurationTaxProvider> TaxProvider
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_provider", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_provider",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, NewTaxJarConfigurationTaxProvider>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentNullException("tax_provider")
                );
        }
        init
        {
            this._rawData["tax_provider"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("automatic_tax_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["automatic_tax_enabled"] = JsonSerializer.SerializeToElement(
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

    public NewTaxJarConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewTaxJarConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewTaxJarConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewTaxJarConfigurationFromRaw : IFromRaw<NewTaxJarConfiguration>
{
    public NewTaxJarConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewTaxJarConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewTaxJarConfigurationTaxProviderConverter))]
public enum NewTaxJarConfigurationTaxProvider
{
    Taxjar,
}

sealed class NewTaxJarConfigurationTaxProviderConverter
    : JsonConverter<NewTaxJarConfigurationTaxProvider>
{
    public override NewTaxJarConfigurationTaxProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "taxjar" => NewTaxJarConfigurationTaxProvider.Taxjar,
            _ => (NewTaxJarConfigurationTaxProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewTaxJarConfigurationTaxProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewTaxJarConfigurationTaxProvider.Taxjar => "taxjar",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
