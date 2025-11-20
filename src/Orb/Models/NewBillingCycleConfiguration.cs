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
            if (!this._rawData.TryGetValue("duration", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duration' cannot be null",
                    new System::ArgumentOutOfRangeException("duration", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unit of billing period duration.
    /// </summary>
    public required ApiEnum<string, NewBillingCycleConfigurationDurationUnit> DurationUnit
    {
        get
        {
            if (!this._rawData.TryGetValue("duration_unit", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duration_unit' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "duration_unit",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, NewBillingCycleConfigurationDurationUnit>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["duration_unit"] = JsonSerializer.SerializeToElement(
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

    public NewBillingCycleConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewBillingCycleConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewBillingCycleConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// The unit of billing period duration.
/// </summary>
[JsonConverter(typeof(NewBillingCycleConfigurationDurationUnitConverter))]
public enum NewBillingCycleConfigurationDurationUnit
{
    Day,
    Month,
}

sealed class NewBillingCycleConfigurationDurationUnitConverter
    : JsonConverter<NewBillingCycleConfigurationDurationUnit>
{
    public override NewBillingCycleConfigurationDurationUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => NewBillingCycleConfigurationDurationUnit.Day,
            "month" => NewBillingCycleConfigurationDurationUnit.Month,
            _ => (NewBillingCycleConfigurationDurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewBillingCycleConfigurationDurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewBillingCycleConfigurationDurationUnit.Day => "day",
                NewBillingCycleConfigurationDurationUnit.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
