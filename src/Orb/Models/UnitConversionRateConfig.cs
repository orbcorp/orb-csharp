using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<UnitConversionRateConfig>))]
public sealed record class UnitConversionRateConfig : ModelBase, IFromRaw<UnitConversionRateConfig>
{
    public required ApiEnum<string, ConversionRateTypeModel> ConversionRateType
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'conversion_rate_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "conversion_rate_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ConversionRateTypeModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ConversionRateUnitConfig UnitConfig
    {
        get
        {
            if (!this._properties.TryGetValue("unit_config", out JsonElement element))
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
            this._properties["unit_config"] = JsonSerializer.SerializeToElement(
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

    public UnitConversionRateConfig() { }

    public UnitConversionRateConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitConversionRateConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static UnitConversionRateConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ConversionRateTypeModelConverter))]
public enum ConversionRateTypeModel
{
    Unit,
}

sealed class ConversionRateTypeModelConverter : JsonConverter<ConversionRateTypeModel>
{
    public override ConversionRateTypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unit" => ConversionRateTypeModel.Unit,
            _ => (ConversionRateTypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversionRateTypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConversionRateTypeModel.Unit => "unit",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
