using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// Thresholds are used to define the conditions under which an alert will be triggered.
/// </summary>
[JsonConverter(typeof(ModelConverter<Threshold>))]
public sealed record class Threshold : ModelBase, IFromRaw<Threshold>
{
    /// <summary>
    /// The value at which an alert will fire. For credit balance alerts, the alert
    /// will fire at or below this value. For usage and cost alerts, the alert will
    /// fire at or above this value.
    /// </summary>
    public required double Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Value;
    }

    public Threshold() { }

    public Threshold(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Threshold(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Threshold FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Threshold(double value)
        : this()
    {
        this.Value = value;
    }
}
