using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers;

[JsonConverter(
    typeof(ModelConverter<NewAvalaraTaxConfiguration, NewAvalaraTaxConfigurationFromRaw>)
)]
public sealed record class NewAvalaraTaxConfiguration : ModelBase
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

    public required ApiEnum<string, NewAvalaraTaxConfigurationTaxProvider> TaxProvider
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

            return JsonSerializer.Deserialize<
                    ApiEnum<string, NewAvalaraTaxConfigurationTaxProvider>
                >(element, ModelBase.SerializerOptions)
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

    public string? TaxExemptionCode
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_exemption_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tax_exemption_code"] = JsonSerializer.SerializeToElement(
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
        _ = this.TaxExemptionCode;
    }

    public NewAvalaraTaxConfiguration() { }

    public NewAvalaraTaxConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAvalaraTaxConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewAvalaraTaxConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAvalaraTaxConfigurationFromRaw : IFromRaw<NewAvalaraTaxConfiguration>
{
    public NewAvalaraTaxConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewAvalaraTaxConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewAvalaraTaxConfigurationTaxProviderConverter))]
public enum NewAvalaraTaxConfigurationTaxProvider
{
    Avalara,
}

sealed class NewAvalaraTaxConfigurationTaxProviderConverter
    : JsonConverter<NewAvalaraTaxConfigurationTaxProvider>
{
    public override NewAvalaraTaxConfigurationTaxProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "avalara" => NewAvalaraTaxConfigurationTaxProvider.Avalara,
            _ => (NewAvalaraTaxConfigurationTaxProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewAvalaraTaxConfigurationTaxProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewAvalaraTaxConfigurationTaxProvider.Avalara => "avalara",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
