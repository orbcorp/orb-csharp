using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BulkTier, BulkTierFromRaw>))]
public sealed record class BulkTier : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return this._rawData.GetNotNullClass<string>("unit_amount"); }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// Upper bound for this tier
    /// </summary>
    public double? MaximumUnits
    {
        get { return this._rawData.GetNullableStruct<double>("maximum_units"); }
        init { this._rawData.Set("maximum_units", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.MaximumUnits;
    }

    public BulkTier() { }

    public BulkTier(BulkTier bulkTier)
        : base(bulkTier) { }

    public BulkTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkTierFromRaw.FromRawUnchecked"/>
    public static BulkTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BulkTier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class BulkTierFromRaw : IFromRawJson<BulkTier>
{
    /// <inheritdoc/>
    public BulkTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BulkTier.FromRawUnchecked(rawData);
}
