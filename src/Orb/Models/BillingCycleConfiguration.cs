using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BillingCycleConfiguration>))]
public sealed record class BillingCycleConfiguration
    : ModelBase,
        IFromRaw<BillingCycleConfiguration>
{
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

    public required ApiEnum<string, DurationUnit> DurationUnit
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

            return JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
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

    public BillingCycleConfiguration() { }

    public BillingCycleConfiguration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingCycleConfiguration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BillingCycleConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(DurationUnitConverter))]
public enum DurationUnit
{
    Day,
    Month,
}

sealed class DurationUnitConverter : JsonConverter<DurationUnit>
{
    public override DurationUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => DurationUnit.Day,
            "month" => DurationUnit.Month,
            _ => (DurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DurationUnit.Day => "day",
                DurationUnit.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
