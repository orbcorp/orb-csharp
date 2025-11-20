using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SharedTieredConversionRateConfig>))]
public sealed record class SharedTieredConversionRateConfig
    : ModelBase,
        IFromRaw<SharedTieredConversionRateConfig>
{
    public required ApiEnum<string, ConversionRateType> ConversionRateType
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

            return JsonSerializer.Deserialize<ApiEnum<string, ConversionRateType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["conversion_rate_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ConversionRateTieredConfig TieredConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("tiered_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiered_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tiered_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ConversionRateTieredConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiered_config' cannot be null",
                    new System::ArgumentNullException("tiered_config")
                );
        }
        init
        {
            this._rawData["tiered_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ConversionRateType.Validate();
        this.TieredConfig.Validate();
    }

    public SharedTieredConversionRateConfig() { }

    public SharedTieredConversionRateConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedTieredConversionRateConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SharedTieredConversionRateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

[JsonConverter(typeof(ConversionRateTypeConverter))]
public enum ConversionRateType
{
    Tiered,
}

sealed class ConversionRateTypeConverter : JsonConverter<ConversionRateType>
{
    public override ConversionRateType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tiered" => ConversionRateType.Tiered,
            _ => (ConversionRateType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversionRateType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConversionRateType.Tiered => "tiered",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
