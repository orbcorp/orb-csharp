using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for a single tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SharedTier, SharedTierFromRaw>))]
public sealed record class SharedTier : JsonModel
{
    /// <summary>
    /// Exclusive tier starting value
    /// </summary>
    public required double FirstUnit
    {
        get { return this._rawData.GetNotNullStruct<double>("first_unit"); }
        init { this._rawData.Set("first_unit", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return this._rawData.GetNotNullClass<string>("unit_amount"); }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// Inclusive tier ending value. This value is null if and only if this is the
    /// last tier.
    /// </summary>
    public double? LastUnit
    {
        get { return this._rawData.GetNullableStruct<double>("last_unit"); }
        init { this._rawData.Set("last_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstUnit;
        _ = this.UnitAmount;
        _ = this.LastUnit;
    }

    public SharedTier() { }

    public SharedTier(SharedTier sharedTier)
        : base(sharedTier) { }

    public SharedTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedTierFromRaw.FromRawUnchecked"/>
    public static SharedTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedTierFromRaw : IFromRawJson<SharedTier>
{
    /// <inheritdoc/>
    public SharedTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SharedTier.FromRawUnchecked(rawData);
}
