using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class BillingCycleAnchorConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingCycleAnchorConfiguration
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };

        long expectedDay = 1;
        long expectedMonth = 1;
        long expectedYear = 0;

        Assert.Equal(expectedDay, model.Day);
        Assert.Equal(expectedMonth, model.Month);
        Assert.Equal(expectedYear, model.Year);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingCycleAnchorConfiguration
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillingCycleAnchorConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingCycleAnchorConfiguration
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillingCycleAnchorConfiguration>(json);
        Assert.NotNull(deserialized);

        long expectedDay = 1;
        long expectedMonth = 1;
        long expectedYear = 0;

        Assert.Equal(expectedDay, deserialized.Day);
        Assert.Equal(expectedMonth, deserialized.Month);
        Assert.Equal(expectedYear, deserialized.Year);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingCycleAnchorConfiguration
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingCycleAnchorConfiguration { Day = 1 };

        Assert.Null(model.Month);
        Assert.False(model.RawData.ContainsKey("month"));
        Assert.Null(model.Year);
        Assert.False(model.RawData.ContainsKey("year"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingCycleAnchorConfiguration { Day = 1 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BillingCycleAnchorConfiguration
        {
            Day = 1,

            Month = null,
            Year = null,
        };

        Assert.Null(model.Month);
        Assert.True(model.RawData.ContainsKey("month"));
        Assert.Null(model.Year);
        Assert.True(model.RawData.ContainsKey("year"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingCycleAnchorConfiguration
        {
            Day = 1,

            Month = null,
            Year = null,
        };

        model.Validate();
    }
}
