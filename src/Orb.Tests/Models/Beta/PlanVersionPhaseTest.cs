using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Beta;

namespace Orb.Tests.Models.Beta;

public class PlanVersionPhaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanVersionPhase
        {
            ID = "id",
            Description = "description",
            Duration = 0,
            DurationUnit = DurationUnit.Daily,
            Name = "name",
            Order = 0,
        };

        string expectedID = "id";
        string expectedDescription = "description";
        long expectedDuration = 0;
        ApiEnum<string, DurationUnit> expectedDurationUnit = DurationUnit.Daily;
        string expectedName = "name";
        long expectedOrder = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedDurationUnit, model.DurationUnit);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrder, model.Order);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanVersionPhase
        {
            ID = "id",
            Description = "description",
            Duration = 0,
            DurationUnit = DurationUnit.Daily,
            Name = "name",
            Order = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanVersionPhase>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanVersionPhase
        {
            ID = "id",
            Description = "description",
            Duration = 0,
            DurationUnit = DurationUnit.Daily,
            Name = "name",
            Order = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanVersionPhase>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "description";
        long expectedDuration = 0;
        ApiEnum<string, DurationUnit> expectedDurationUnit = DurationUnit.Daily;
        string expectedName = "name";
        long expectedOrder = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedDurationUnit, deserialized.DurationUnit);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrder, deserialized.Order);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanVersionPhase
        {
            ID = "id",
            Description = "description",
            Duration = 0,
            DurationUnit = DurationUnit.Daily,
            Name = "name",
            Order = 0,
        };

        model.Validate();
    }
}

public class DurationUnitTest : TestBase
{
    [Theory]
    [InlineData(DurationUnit.Daily)]
    [InlineData(DurationUnit.Monthly)]
    [InlineData(DurationUnit.Quarterly)]
    [InlineData(DurationUnit.SemiAnnual)]
    [InlineData(DurationUnit.Annual)]
    public void Validation_Works(DurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DurationUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DurationUnit.Daily)]
    [InlineData(DurationUnit.Monthly)]
    [InlineData(DurationUnit.Quarterly)]
    [InlineData(DurationUnit.SemiAnnual)]
    [InlineData(DurationUnit.Annual)]
    public void SerializationRoundtrip_Works(DurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DurationUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
