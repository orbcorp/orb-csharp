using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

/// <summary>
/// Configuration for bulk pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<BulkConfig, BulkConfigFromRaw>))]
public sealed record class BulkConfig : ModelBase
{
    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<BulkTier> Tiers
    {
        get
        {
            if (!this._rawData.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<BulkTier>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new ArgumentNullException("tiers")
                );
        }
        init
        {
            this._rawData["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public BulkConfig() { }

    public BulkConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BulkConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BulkConfig(List<BulkTier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

class BulkConfigFromRaw : IFromRaw<BulkConfig>
{
    public BulkConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BulkConfig.FromRawUnchecked(rawData);
}
