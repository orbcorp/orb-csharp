using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<ConversionRateUnitConfig, ConversionRateUnitConfigFromRaw>))]
public sealed record class ConversionRateUnitConfig : ModelBase
{
    /// <summary>
    /// Amount per unit of overage
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
    }

    public ConversionRateUnitConfig() { }

    public ConversionRateUnitConfig(ConversionRateUnitConfig conversionRateUnitConfig)
        : base(conversionRateUnitConfig) { }

    public ConversionRateUnitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversionRateUnitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class ConversionRateUnitConfigFromRaw : IFromRaw<ConversionRateUnitConfig>
{
    /// <inheritdoc/>
    public ConversionRateUnitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversionRateUnitConfig.FromRawUnchecked(rawData);
}
