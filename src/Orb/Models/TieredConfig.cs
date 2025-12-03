using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for tiered pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<TieredConfig, TieredConfigFromRaw>))]
public sealed record class TieredConfig : ModelBase
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// </summary>
    public required IReadOnlyList<SharedTier> Tiers
    {
        get { return ModelBase.GetNotNullClass<List<SharedTier>>(this.RawData, "tiers"); }
        init { ModelBase.Set(this._rawData, "tiers", value); }
    }

    /// <summary>
    /// If true, subtotals from this price are prorated based on the service period
    /// </summary>
    public bool? Prorated
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "prorated"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "prorated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
        _ = this.Prorated;
    }

    public TieredConfig() { }

    public TieredConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TieredConfigFromRaw.FromRawUnchecked"/>
    public static TieredConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TieredConfig(List<SharedTier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

class TieredConfigFromRaw : IFromRaw<TieredConfig>
{
    /// <inheritdoc/>
    public TieredConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TieredConfig.FromRawUnchecked(rawData);
}
