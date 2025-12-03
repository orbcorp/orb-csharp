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
[JsonConverter(typeof(ModelConverter<UnitConfig, UnitConfigFromRaw>))]
public sealed record class UnitConfig : ModelBase
{
    /// <summary>
    /// Rate per unit of usage
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// If true, subtotals from this price are prorated based on the service period
    /// </summary>
    public bool? Prorated
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "prorated"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "prorated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.Prorated;
    }

    public UnitConfig() { }

    public UnitConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class UnitConfigFromRaw : IFromRaw<UnitConfig>
{
    /// <inheritdoc/>
    public UnitConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnitConfig.FromRawUnchecked(rawData);
}
