using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewBillingCycleConfiguration>))]
public sealed record class NewBillingCycleConfiguration
    : ModelBase,
        IFromRaw<NewBillingCycleConfiguration>
{
    /// <summary>
    /// The duration of the billing period.
    /// </summary>
    public required long Duration
    {
        get
        {
            if (!this._properties.TryGetValue("duration", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duration' cannot be null",
                    new System::ArgumentOutOfRangeException("duration", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unit of billing period duration.
    /// </summary>
    public required ApiEnum<string, DurationUnit1> DurationUnit
    {
        get
        {
            if (!this._properties.TryGetValue("duration_unit", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duration_unit' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "duration_unit",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DurationUnit1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["duration_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Duration;
        this.DurationUnit.Validate();
    }

    public NewBillingCycleConfiguration() { }

    public NewBillingCycleConfiguration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewBillingCycleConfiguration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewBillingCycleConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The unit of billing period duration.
/// </summary>
[JsonConverter(typeof(DurationUnit1Converter))]
public enum DurationUnit1
{
    Day,
    Month,
}

sealed class DurationUnit1Converter : JsonConverter<DurationUnit1>
{
    public override DurationUnit1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => DurationUnit1.Day,
            "month" => DurationUnit1.Month,
            _ => (DurationUnit1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DurationUnit1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DurationUnit1.Day => "day",
                DurationUnit1.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
