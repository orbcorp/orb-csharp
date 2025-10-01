using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using ConversionRateConfigVariants = Orb.Models.PriceProperties.CumulativeGroupedBulkProperties.ConversionRateConfigVariants;

namespace Orb.Models.PriceProperties.CumulativeGroupedBulkProperties;

[JsonConverter(typeof(ConversionRateConfigConverter))]
public abstract record class ConversionRateConfig
{
    internal ConversionRateConfig() { }

    public static implicit operator ConversionRateConfig(UnitConversionRateConfig value) =>
        new ConversionRateConfigVariants::UnitConversionRateConfig(value);

    public static implicit operator ConversionRateConfig(TieredConversionRateConfig value) =>
        new ConversionRateConfigVariants::TieredConversionRateConfig(value);

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = (this as ConversionRateConfigVariants::UnitConversionRateConfig)?.Value;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = (this as ConversionRateConfigVariants::TieredConversionRateConfig)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ConversionRateConfigVariants::UnitConversionRateConfig> unit,
        Action<ConversionRateConfigVariants::TieredConversionRateConfig> tiered
    )
    {
        switch (this)
        {
            case ConversionRateConfigVariants::UnitConversionRateConfig inner:
                unit(inner);
                break;
            case ConversionRateConfigVariants::TieredConversionRateConfig inner:
                tiered(inner);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        Func<ConversionRateConfigVariants::UnitConversionRateConfig, T> unit,
        Func<ConversionRateConfigVariants::TieredConversionRateConfig, T> tiered
    )
    {
        return this switch
        {
            ConversionRateConfigVariants::UnitConversionRateConfig inner => unit(inner),
            ConversionRateConfigVariants::TieredConversionRateConfig inner => tiered(inner),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ConversionRateConfigConverter : JsonConverter<ConversionRateConfig>
{
    public override ConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ConversionRateConfigVariants::UnitConversionRateConfig(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant ConversionRateConfigVariants::UnitConversionRateConfig",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ConversionRateConfigVariants::TieredConversionRateConfig(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant ConversionRateConfigVariants::TieredConversionRateConfig",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ConversionRateConfigVariants::UnitConversionRateConfig(var unit) => unit,
            ConversionRateConfigVariants::TieredConversionRateConfig(var tiered) => tiered,
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
