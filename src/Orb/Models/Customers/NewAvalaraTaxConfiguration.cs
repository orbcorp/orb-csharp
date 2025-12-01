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
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "tax_exempt"); }
        init { ModelBase.Set(this._rawData, "tax_exempt", value); }
    }

    public required ApiEnum<string, NewAvalaraTaxConfigurationTaxProvider> TaxProvider
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewAvalaraTaxConfigurationTaxProvider>
            >(this.RawData, "tax_provider");
        }
        init { ModelBase.Set(this._rawData, "tax_provider", value); }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "automatic_tax_enabled"); }
        init { ModelBase.Set(this._rawData, "automatic_tax_enabled", value); }
    }

    public string? TaxExemptionCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tax_exemption_code"); }
        init { ModelBase.Set(this._rawData, "tax_exemption_code", value); }
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
