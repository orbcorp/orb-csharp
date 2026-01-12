using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<TaxAmount, TaxAmountFromRaw>))]
public sealed record class TaxAmount : JsonModel
{
    /// <summary>
    /// The amount of additional tax incurred by this tax rate.
    /// </summary>
    public required string Amount
    {
        get { return this._rawData.GetNotNullClass<string>("amount"); }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The human-readable description of the applied tax rate.
    /// </summary>
    public required string TaxRateDescription
    {
        get { return this._rawData.GetNotNullClass<string>("tax_rate_description"); }
        init { this._rawData.Set("tax_rate_description", value); }
    }

    /// <summary>
    /// The tax rate percentage, out of 100.
    /// </summary>
    public required string? TaxRatePercentage
    {
        get { return this._rawData.GetNullableClass<string>("tax_rate_percentage"); }
        init { this._rawData.Set("tax_rate_percentage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.TaxRateDescription;
        _ = this.TaxRatePercentage;
    }

    public TaxAmount() { }

    public TaxAmount(TaxAmount taxAmount)
        : base(taxAmount) { }

    public TaxAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TaxAmountFromRaw.FromRawUnchecked"/>
    public static TaxAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TaxAmountFromRaw : IFromRawJson<TaxAmount>
{
    /// <inheritdoc/>
    public TaxAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TaxAmount.FromRawUnchecked(rawData);
}
