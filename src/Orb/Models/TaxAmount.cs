using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TaxAmount, TaxAmountFromRaw>))]
public sealed record class TaxAmount : ModelBase
{
    /// <summary>
    /// The amount of additional tax incurred by this tax rate.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentNullException("amount")
                );
        }
        init
        {
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The human-readable description of the applied tax rate.
    /// </summary>
    public required string TaxRateDescription
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_rate_description", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_rate_description' cannot be null",
                    new ArgumentOutOfRangeException(
                        "tax_rate_description",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tax_rate_description' cannot be null",
                    new ArgumentNullException("tax_rate_description")
                );
        }
        init
        {
            this._rawData["tax_rate_description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The tax rate percentage, out of 100.
    /// </summary>
    public required string? TaxRatePercentage
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_rate_percentage", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tax_rate_percentage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.TaxRateDescription;
        _ = this.TaxRatePercentage;
    }

    public TaxAmount() { }

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

    public static TaxAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TaxAmountFromRaw : IFromRaw<TaxAmount>
{
    public TaxAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TaxAmount.FromRawUnchecked(rawData);
}
