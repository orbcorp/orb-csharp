using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<SubLineItemGrouping, SubLineItemGroupingFromRaw>))]
public sealed record class SubLineItemGrouping : JsonModel
{
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// No value indicates the default group
    /// </summary>
    public required string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        _ = this.Value;
    }

    public SubLineItemGrouping() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubLineItemGrouping(SubLineItemGrouping subLineItemGrouping)
        : base(subLineItemGrouping) { }
#pragma warning restore CS8618

    public SubLineItemGrouping(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubLineItemGrouping(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubLineItemGroupingFromRaw.FromRawUnchecked"/>
    public static SubLineItemGrouping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubLineItemGroupingFromRaw : IFromRawJson<SubLineItemGrouping>
{
    /// <inheritdoc/>
    public SubLineItemGrouping FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubLineItemGrouping.FromRawUnchecked(rawData);
}
