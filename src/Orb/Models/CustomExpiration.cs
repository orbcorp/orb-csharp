using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<CustomExpiration>))]
public sealed record class CustomExpiration : ModelBase, IFromRaw<CustomExpiration>
{
    public required long Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duration' cannot be null",
                    new System::ArgumentOutOfRangeException("duration", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DurationUnitModel> DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duration_unit' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "duration_unit",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DurationUnitModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["duration_unit"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomExpiration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomExpiration FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(DurationUnitModelConverter))]
public enum DurationUnitModel
{
    Day,
    Month,
}

sealed class DurationUnitModelConverter : JsonConverter<DurationUnitModel>
{
    public override DurationUnitModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => DurationUnitModel.Day,
            "month" => DurationUnitModel.Month,
            _ => (DurationUnitModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DurationUnitModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DurationUnitModel.Day => "day",
                DurationUnitModel.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
