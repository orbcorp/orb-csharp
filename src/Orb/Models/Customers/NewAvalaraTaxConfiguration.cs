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
    typeof(JsonModelConverter<NewAvalaraTaxConfiguration, NewAvalaraTaxConfigurationFromRaw>)
)]
public sealed record class NewAvalaraTaxConfiguration : JsonModel
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

    public required ApiEnum<string, TaxProvider> TaxProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TaxProvider>>("tax_provider");
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

    public string? TaxExemptionCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_exemption_code");
        }
        init { this._rawData.Set("tax_exemption_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
        _ = this.AutomaticTaxEnabled;
        _ = this.TaxExemptionCode;
    }

    public NewAvalaraTaxConfiguration() { }

    public NewAvalaraTaxConfiguration(NewAvalaraTaxConfiguration newAvalaraTaxConfiguration)
        : base(newAvalaraTaxConfiguration) { }

    public NewAvalaraTaxConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAvalaraTaxConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewAvalaraTaxConfigurationFromRaw.FromRawUnchecked"/>
    public static NewAvalaraTaxConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAvalaraTaxConfigurationFromRaw : IFromRawJson<NewAvalaraTaxConfiguration>
{
    /// <inheritdoc/>
    public NewAvalaraTaxConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewAvalaraTaxConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TaxProviderConverter))]
public enum TaxProvider
{
    Avalara,
}

sealed class TaxProviderConverter : JsonConverter<TaxProvider>
{
    public override TaxProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "avalara" => TaxProvider.Avalara,
            _ => (TaxProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TaxProvider.Avalara => "avalara",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
