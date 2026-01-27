using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<ConversionRateUnitConfig, ConversionRateUnitConfigFromRaw>)
)]
public sealed record class ConversionRateUnitConfig : JsonModel
{
    /// <summary>
    /// Amount per unit of overage
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
    }

    public ConversionRateUnitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversionRateUnitConfig(ConversionRateUnitConfig conversionRateUnitConfig)
        : base(conversionRateUnitConfig) { }
#pragma warning restore CS8618

    public ConversionRateUnitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversionRateUnitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversionRateUnitConfigFromRaw.FromRawUnchecked"/>
    public static ConversionRateUnitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConversionRateUnitConfig(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class ConversionRateUnitConfigFromRaw : IFromRawJson<ConversionRateUnitConfig>
{
    /// <inheritdoc/>
    public ConversionRateUnitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversionRateUnitConfig.FromRawUnchecked(rawData);
}
