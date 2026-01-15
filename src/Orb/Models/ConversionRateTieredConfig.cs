using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<ConversionRateTieredConfig, ConversionRateTieredConfigFromRaw>)
)]
public sealed record class ConversionRateTieredConfig : JsonModel
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// </summary>
    public required IReadOnlyList<ConversionRateTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ConversionRateTier>>("tiers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ConversionRateTier>>(
                "tiers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversionRateTieredConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    public ConversionRateTieredConfig(IReadOnlyList<ConversionRateTier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

class ConversionRateTieredConfigFromRaw : IFromRawJson<ConversionRateTieredConfig>
{
    /// <inheritdoc/>
    public ConversionRateTieredConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversionRateTieredConfig.FromRawUnchecked(rawData);
}
