using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<ConversionRateTier, ConversionRateTierFromRaw>))]
public sealed record class ConversionRateTier : JsonModel
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
    /// Amount per unit of overage
    /// </summary>
    public required string UnitAmount
    {
        get { return this._rawData.GetNotNullClass<string>("unit_amount"); }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// Inclusive tier ending value. If null, this is treated as the last tier
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

    public ConversionRateTier() { }

    public ConversionRateTier(ConversionRateTier conversionRateTier)
        : base(conversionRateTier) { }

    public ConversionRateTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversionRateTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversionRateTierFromRaw.FromRawUnchecked"/>
    public static ConversionRateTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversionRateTierFromRaw : IFromRawJson<ConversionRateTier>
{
    /// <inheritdoc/>
    public ConversionRateTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ConversionRateTier.FromRawUnchecked(rawData);
}
