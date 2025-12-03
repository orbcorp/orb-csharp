using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Alerts;

/// <summary>
/// Thresholds are used to define the conditions under which an alert will be triggered.
/// </summary>
[JsonConverter(typeof(ModelConverter<Threshold, ThresholdFromRaw>))]
public sealed record class Threshold : ModelBase
{
    /// <summary>
    /// The value at which an alert will fire. For credit balance alerts, the alert
    /// will fire at or below this value. For usage and cost alerts, the alert will
    /// fire at or above this value.
    /// </summary>
    public required double Value
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Value;
    }

    public Threshold() { }

    public Threshold(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Threshold(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThresholdFromRaw.FromRawUnchecked"/>
    public static Threshold FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Threshold(double value)
        : this()
    {
        this.Value = value;
    }
}

class ThresholdFromRaw : IFromRaw<Threshold>
{
    /// <inheritdoc/>
    public Threshold FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Threshold.FromRawUnchecked(rawData);
}
