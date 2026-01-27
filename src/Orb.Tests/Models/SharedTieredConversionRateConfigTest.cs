using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedTieredConversionRateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        ApiEnum<string, ConversionRateType> expectedConversionRateType = ConversionRateType.Tiered;
        ConversionRateTieredConfig expectedTieredConfig = new(
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ]
        );

        Assert.Equal(expectedConversionRateType, model.ConversionRateType);
        Assert.Equal(expectedTieredConfig, model.TieredConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ConversionRateType> expectedConversionRateType = ConversionRateType.Tiered;
        ConversionRateTieredConfig expectedTieredConfig = new(
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ]
        );

        Assert.Equal(expectedConversionRateType, deserialized.ConversionRateType);
        Assert.Equal(expectedTieredConfig, deserialized.TieredConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        SharedTieredConversionRateConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversionRateTypeTest : TestBase
{
    [Theory]
    [InlineData(ConversionRateType.Tiered)]
    public void Validation_Works(ConversionRateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConversionRateType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConversionRateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConversionRateType.Tiered)]
    public void SerializationRoundtrip_Works(ConversionRateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConversionRateType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConversionRateType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConversionRateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConversionRateType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
