using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for bulk pricing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BulkConfig, BulkConfigFromRaw>))]
public sealed record class BulkConfig : JsonModel
{
    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<BulkTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BulkTier>>("tiers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BulkTier>>(
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

    public BulkConfig() { }

    public BulkConfig(BulkConfig bulkConfig)
        : base(bulkConfig) { }

    public BulkConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkConfigFromRaw.FromRawUnchecked"/>
    public static BulkConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BulkConfig(IReadOnlyList<BulkTier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

class BulkConfigFromRaw : IFromRawJson<BulkConfig>
{
    /// <inheritdoc/>
    public BulkConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BulkConfig.FromRawUnchecked(rawData);
}
