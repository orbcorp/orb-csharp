using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<ConversionRateTieredConfig, ConversionRateTieredConfigFromRaw>)
)]
public sealed record class ConversionRateTieredConfig : ModelBase
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// </summary>
    public required IReadOnlyList<ConversionRateTier> Tiers
    {
        get { return ModelBase.GetNotNullClass<List<ConversionRateTier>>(this.RawData, "tiers"); }
        init { ModelBase.Set(this._rawData, "tiers", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public ConversionRateTieredConfig() { }

    public ConversionRateTieredConfig(ConversionRateTieredConfig conversionRateTieredConfig)
        : base(conversionRateTieredConfig) { }

    public ConversionRateTieredConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversionRateTieredConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversionRateTieredConfigFromRaw.FromRawUnchecked"/>
    public static ConversionRateTieredConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConversionRateTieredConfig(List<ConversionRateTier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

class ConversionRateTieredConfigFromRaw : IFromRaw<ConversionRateTieredConfig>
{
    /// <inheritdoc/>
    public ConversionRateTieredConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversionRateTieredConfig.FromRawUnchecked(rawData);
}
