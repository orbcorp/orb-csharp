using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedUnitConversionRateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        ApiEnum<
            string,
            SharedUnitConversionRateConfigConversionRateType
        > expectedConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit;
        ConversionRateUnitConfig expectedUnitConfig = new("unit_amount");

        Assert.Equal(expectedConversionRateType, model.ConversionRateType);
        Assert.Equal(expectedUnitConfig, model.UnitConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(element);
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SharedUnitConversionRateConfigConversionRateType
        > expectedConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit;
        ConversionRateUnitConfig expectedUnitConfig = new("unit_amount");

        Assert.Equal(expectedConversionRateType, deserialized.ConversionRateType);
        Assert.Equal(expectedUnitConfig, deserialized.UnitConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        model.Validate();
    }
}

public class SharedUnitConversionRateConfigConversionRateTypeTest : TestBase
{
    [Theory]
    [InlineData(SharedUnitConversionRateConfigConversionRateType.Unit)]
    public void Validation_Works(SharedUnitConversionRateConfigConversionRateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharedUnitConversionRateConfigConversionRateType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SharedUnitConversionRateConfigConversionRateType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SharedUnitConversionRateConfigConversionRateType.Unit)]
    public void SerializationRoundtrip_Works(
        SharedUnitConversionRateConfigConversionRateType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharedUnitConversionRateConfigConversionRateType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SharedUnitConversionRateConfigConversionRateType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SharedUnitConversionRateConfigConversionRateType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SharedUnitConversionRateConfigConversionRateType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
