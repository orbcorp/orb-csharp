using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<CustomExpiration, CustomExpirationFromRaw>))]
public sealed record class CustomExpiration : ModelBase
{
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

    public required ApiEnum<string, CustomExpirationDurationUnit> DurationUnit
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

            return JsonSerializer.Deserialize<ApiEnum<string, CustomExpirationDurationUnit>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'duration_unit' cannot be null",
                    new System::ArgumentNullException("duration_unit")
                );
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

    public CustomExpiration() { }

    public CustomExpiration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomExpiration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static CustomExpiration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomExpirationFromRaw : IFromRaw<CustomExpiration>
{
    public CustomExpiration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomExpiration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CustomExpirationDurationUnitConverter))]
public enum CustomExpirationDurationUnit
{
    Day,
    Month,
}

sealed class CustomExpirationDurationUnitConverter : JsonConverter<CustomExpirationDurationUnit>
{
    public override CustomExpirationDurationUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => CustomExpirationDurationUnit.Day,
            "month" => CustomExpirationDurationUnit.Month,
            _ => (CustomExpirationDurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomExpirationDurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomExpirationDurationUnit.Day => "day",
                CustomExpirationDurationUnit.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
