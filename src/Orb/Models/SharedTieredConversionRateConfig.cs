using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<
        SharedTieredConversionRateConfig,
        SharedTieredConversionRateConfigFromRaw
    >)
)]
public sealed record class SharedTieredConversionRateConfig : ModelBase
{
    public required ApiEnum<string, ConversionRateType> ConversionRateType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, ConversionRateType>>(
                this.RawData,
                "conversion_rate_type"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_type", value); }
    }

    public required ConversionRateTieredConfig TieredConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<ConversionRateTieredConfig>(
                this.RawData,
                "tiered_config"
            );
        }
        init { ModelBase.Set(this._rawData, "tiered_config", value); }
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

class SharedTieredConversionRateConfigFromRaw : IFromRaw<SharedTieredConversionRateConfig>
{
    public SharedTieredConversionRateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SharedTieredConversionRateConfig.FromRawUnchecked(rawData);
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
