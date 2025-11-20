using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SharedUnitConversionRateConfig>))]
public sealed record class SharedUnitConversionRateConfig
    : ModelBase,
        IFromRaw<SharedUnitConversionRateConfig>
{
    public required ApiEnum<
        string,
        SharedUnitConversionRateConfigConversionRateType
    > ConversionRateType
    {
        get
        {
            if (!this._rawData.TryGetValue("conversion_rate_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'conversion_rate_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conversion_rate_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, SharedUnitConversionRateConfigConversionRateType>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["conversion_rate_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ConversionRateUnitConfig UnitConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ConversionRateUnitConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'unit_config' cannot be null",
                    new System::ArgumentNullException("unit_config")
                );
        }
        init
        {
            this._rawData["unit_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ConversionRateType.Validate();
        this.UnitConfig.Validate();
    }

    public SharedUnitConversionRateConfig() { }

    public SharedUnitConversionRateConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedUnitConversionRateConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SharedUnitConversionRateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

[JsonConverter(typeof(SharedUnitConversionRateConfigConversionRateTypeConverter))]
public enum SharedUnitConversionRateConfigConversionRateType
{
    Unit,
}

sealed class SharedUnitConversionRateConfigConversionRateTypeConverter
    : JsonConverter<SharedUnitConversionRateConfigConversionRateType>
{
    public override SharedUnitConversionRateConfigConversionRateType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unit" => SharedUnitConversionRateConfigConversionRateType.Unit,
            _ => (SharedUnitConversionRateConfigConversionRateType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SharedUnitConversionRateConfigConversionRateType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SharedUnitConversionRateConfigConversionRateType.Unit => "unit",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
