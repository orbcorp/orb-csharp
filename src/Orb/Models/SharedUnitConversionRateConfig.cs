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
        SharedUnitConversionRateConfig,
        SharedUnitConversionRateConfigFromRaw
    >)
)]
public sealed record class SharedUnitConversionRateConfig : JsonModel
{
    public required ApiEnum<
        string,
        SharedUnitConversionRateConfigConversionRateType
    > ConversionRateType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SharedUnitConversionRateConfigConversionRateType>
            >("conversion_rate_type");
        }
        init { this._rawData.Set("conversion_rate_type", value); }
    }

    public required ConversionRateUnitConfig UnitConfig
    {
        get { return this._rawData.GetNotNullClass<ConversionRateUnitConfig>("unit_config"); }
        init { this._rawData.Set("unit_config", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ConversionRateType.Validate();
        this.UnitConfig.Validate();
    }

    public SharedUnitConversionRateConfig() { }

    public SharedUnitConversionRateConfig(
        SharedUnitConversionRateConfig sharedUnitConversionRateConfig
    )
        : base(sharedUnitConversionRateConfig) { }

    public SharedUnitConversionRateConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedUnitConversionRateConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedUnitConversionRateConfigFromRaw.FromRawUnchecked"/>
    public static SharedUnitConversionRateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedUnitConversionRateConfigFromRaw : IFromRawJson<SharedUnitConversionRateConfig>
{
    /// <inheritdoc/>
    public SharedUnitConversionRateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SharedUnitConversionRateConfig.FromRawUnchecked(rawData);
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
