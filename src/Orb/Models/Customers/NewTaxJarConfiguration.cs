using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<NewTaxJarConfiguration, NewTaxJarConfigurationFromRaw>))]
public sealed record class NewTaxJarConfiguration : JsonModel
{
    public required bool TaxExempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_exempt");
        }
        init { this._rawData.Set("tax_exempt", value); }
    }

    public required ApiEnum<string, NewTaxJarConfigurationTaxProvider> TaxProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewTaxJarConfigurationTaxProvider>
            >("tax_provider");
        }
        init { this._rawData.Set("tax_provider", value); }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("automatic_tax_enabled");
        }
        init { this._rawData.Set("automatic_tax_enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
        _ = this.AutomaticTaxEnabled;
    }

    public NewTaxJarConfiguration() { }

    public NewTaxJarConfiguration(NewTaxJarConfiguration newTaxJarConfiguration)
        : base(newTaxJarConfiguration) { }

    public NewTaxJarConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewTaxJarConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewTaxJarConfigurationFromRaw.FromRawUnchecked"/>
    public static NewTaxJarConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewTaxJarConfigurationFromRaw : IFromRawJson<NewTaxJarConfiguration>
{
    /// <inheritdoc/>
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
