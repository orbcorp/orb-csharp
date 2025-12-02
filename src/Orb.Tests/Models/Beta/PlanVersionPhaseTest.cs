using System.Text.Json;
using Orb.Core;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanVersionPhase>(json);
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
