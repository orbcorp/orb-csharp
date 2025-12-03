using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BillableMetricTiny, BillableMetricTinyFromRaw>))]
public sealed record class BillableMetricTiny : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public BillableMetricTiny() { }

    public BillableMetricTiny(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillableMetricTiny(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillableMetricTinyFromRaw.FromRawUnchecked"/>
    public static BillableMetricTiny FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BillableMetricTiny(string id)
        : this()
    {
        this.ID = id;
    }
}

class BillableMetricTinyFromRaw : IFromRaw<BillableMetricTiny>
{
    /// <inheritdoc/>
    public BillableMetricTiny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillableMetricTiny.FromRawUnchecked(rawData);
}
