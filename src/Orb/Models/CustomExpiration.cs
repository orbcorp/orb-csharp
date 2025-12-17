using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<CustomExpiration, CustomExpirationFromRaw>))]
public sealed record class CustomExpiration : JsonModel
{
    public required long Duration
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "duration"); }
        init { JsonModel.Set(this._rawData, "duration", value); }
    }

    public required ApiEnum<string, CustomExpirationDurationUnit> DurationUnit
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, CustomExpirationDurationUnit>>(
                this.RawData,
                "duration_unit"
            );
        }
        init { JsonModel.Set(this._rawData, "duration_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        this.DurationUnit.Validate();
    }

    public CustomExpiration() { }

    public CustomExpiration(CustomExpiration customExpiration)
        : base(customExpiration) { }

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

    /// <inheritdoc cref="CustomExpirationFromRaw.FromRawUnchecked"/>
    public static CustomExpiration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomExpirationFromRaw : IFromRawJson<CustomExpiration>
{
    /// <inheritdoc/>
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
