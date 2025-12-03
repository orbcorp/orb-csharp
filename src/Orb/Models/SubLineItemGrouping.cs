using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubLineItemGrouping, SubLineItemGroupingFromRaw>))]
public sealed record class SubLineItemGrouping : ModelBase
{
    public required string Key
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "key"); }
        init { ModelBase.Set(this._rawData, "key", value); }
    }

    /// <summary>
    /// No value indicates the default group
    /// </summary>
    public required string? Value
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        _ = this.Value;
    }

    public SubLineItemGrouping() { }

    public SubLineItemGrouping(SubLineItemGrouping subLineItemGrouping)
        : base(subLineItemGrouping) { }

    public SubLineItemGrouping(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubLineItemGrouping(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SubLineItemGroupingFromRaw : IFromRaw<SubLineItemGrouping>
{
    /// <inheritdoc/>
    public SubLineItemGrouping FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubLineItemGrouping.FromRawUnchecked(rawData);
}
