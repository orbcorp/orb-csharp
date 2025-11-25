using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<ConversionRateUnitConfig, ConversionRateUnitConfigFromRaw>))]
public sealed record class ConversionRateUnitConfig : ModelBase
{
    /// <summary>
    /// Amount per unit of overage
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new ArgumentOutOfRangeException("unit_amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._rawData["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
    }

    public ConversionRateUnitConfig() { }

    public ConversionRateUnitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversionRateUnitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ConversionRateUnitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConversionRateUnitConfig(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class ConversionRateUnitConfigFromRaw : IFromRaw<ConversionRateUnitConfig>
{
    public ConversionRateUnitConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversionRateUnitConfig.FromRawUnchecked(rawData);
}
