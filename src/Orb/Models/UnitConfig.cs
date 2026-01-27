using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for unit pricing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnitConfig, UnitConfigFromRaw>))]
public sealed record class UnitConfig : JsonModel
{
    /// <summary>
    /// Rate per unit of usage
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// If true, subtotals from this price are prorated based on the service period
    /// </summary>
    public bool? Prorated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("prorated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prorated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.Prorated;
    }

    public UnitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnitConfig(UnitConfig unitConfig)
        : base(unitConfig) { }
#pragma warning restore CS8618

    public UnitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnitConfigFromRaw.FromRawUnchecked"/>
    public static UnitConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnitConfig(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class UnitConfigFromRaw : IFromRawJson<UnitConfig>
{
    /// <inheritdoc/>
    public UnitConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnitConfig.FromRawUnchecked(rawData);
}
