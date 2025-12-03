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
[JsonConverter(typeof(ModelConverter<SharedTier, SharedTierFromRaw>))]
public sealed record class SharedTier : ModelBase
{
    /// <summary>
    /// Exclusive tier starting value
    /// </summary>
    public required double FirstUnit
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "first_unit"); }
        init { ModelBase.Set(this._rawData, "first_unit", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// Inclusive tier ending value. This value is null if and only if this is the
    /// last tier.
    /// </summary>
    public double? LastUnit
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "last_unit"); }
        init { ModelBase.Set(this._rawData, "last_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstUnit;
        _ = this.UnitAmount;
        _ = this.LastUnit;
    }

    public SharedTier() { }

    public SharedTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedTierFromRaw.FromRawUnchecked"/>
    public static SharedTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedTierFromRaw : IFromRaw<SharedTier>
{
    /// <inheritdoc/>
    public SharedTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SharedTier.FromRawUnchecked(rawData);
}
