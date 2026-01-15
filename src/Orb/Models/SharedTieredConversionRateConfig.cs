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
    typeof(JsonModelConverter<
        SharedTieredConversionRateConfig,
        SharedTieredConversionRateConfigFromRaw
    >)
)]
public sealed record class SharedTieredConversionRateConfig : JsonModel
{
    public required ApiEnum<string, ConversionRateType> ConversionRateType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ConversionRateType>>(
                "conversion_rate_type"
            );
        }
        init { this._rawData.Set("conversion_rate_type", value); }
    }

    public required ConversionRateTieredConfig TieredConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConversionRateTieredConfig>("tiered_config");
        }
        init { this._rawData.Set("tiered_config", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ConversionRateType.Validate();
        this.TieredConfig.Validate();
    }

    public SharedTieredConversionRateConfig() { }

    public SharedTieredConversionRateConfig(
        SharedTieredConversionRateConfig sharedTieredConversionRateConfig
    )
        : base(sharedTieredConversionRateConfig) { }

    public SharedTieredConversionRateConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedTieredConversionRateConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedTieredConversionRateConfigFromRaw.FromRawUnchecked"/>
    public static SharedTieredConversionRateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedTieredConversionRateConfigFromRaw : IFromRawJson<SharedTieredConversionRateConfig>
{
    /// <inheritdoc/>
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
