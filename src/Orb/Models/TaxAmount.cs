using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TaxAmount, TaxAmountFromRaw>))]
public sealed record class TaxAmount : ModelBase
{
    /// <summary>
    /// The amount of additional tax incurred by this tax rate.
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The human-readable description of the applied tax rate.
    /// </summary>
    public required string TaxRateDescription
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tax_rate_description"); }
        init { ModelBase.Set(this._rawData, "tax_rate_description", value); }
    }

    /// <summary>
    /// The tax rate percentage, out of 100.
    /// </summary>
    public required string? TaxRatePercentage
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tax_rate_percentage"); }
        init { ModelBase.Set(this._rawData, "tax_rate_percentage", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TaxAmountFromRaw.FromRawUnchecked"/>
    public static TaxAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TaxAmountFromRaw : IFromRaw<TaxAmount>
{
    /// <inheritdoc/>
    public TaxAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TaxAmount.FromRawUnchecked(rawData);
}
