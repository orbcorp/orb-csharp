using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class BulkTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkTier { UnitAmount = "unit_amount", MaximumUnits = 0 };

        string expectedUnitAmount = "unit_amount";
        double expectedMaximumUnits = 0;

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedMaximumUnits, model.MaximumUnits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkTier { UnitAmount = "unit_amount", MaximumUnits = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkTier>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkTier { UnitAmount = "unit_amount", MaximumUnits = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUnitAmount = "unit_amount";
        double expectedMaximumUnits = 0;

        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
        Assert.Equal(expectedMaximumUnits, deserialized.MaximumUnits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkTier { UnitAmount = "unit_amount", MaximumUnits = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BulkTier { UnitAmount = "unit_amount" };

        Assert.Null(model.MaximumUnits);
        Assert.False(model.RawData.ContainsKey("maximum_units"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BulkTier { UnitAmount = "unit_amount" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BulkTier
        {
            UnitAmount = "unit_amount",

            MaximumUnits = null,
        };

        Assert.Null(model.MaximumUnits);
        Assert.True(model.RawData.ContainsKey("maximum_units"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BulkTier
        {
            UnitAmount = "unit_amount",

            MaximumUnits = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BulkTier { UnitAmount = "unit_amount", MaximumUnits = 0 };

        BulkTier copied = new(model);

        Assert.Equal(model, copied);
    }
}
