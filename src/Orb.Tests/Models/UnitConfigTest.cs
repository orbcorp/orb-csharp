using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class UnitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitConfig { UnitAmount = "unit_amount", Prorated = true };

        string expectedUnitAmount = "unit_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedProrated, model.Prorated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnitConfig { UnitAmount = "unit_amount", Prorated = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnitConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnitConfig { UnitAmount = "unit_amount", Prorated = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnitConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUnitAmount = "unit_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
        Assert.Equal(expectedProrated, deserialized.Prorated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnitConfig { UnitAmount = "unit_amount", Prorated = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnitConfig { UnitAmount = "unit_amount" };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnitConfig { UnitAmount = "unit_amount" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnitConfig
        {
            UnitAmount = "unit_amount",

            // Null should be interpreted as omitted for these properties
            Prorated = null,
        };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnitConfig
        {
            UnitAmount = "unit_amount",

            // Null should be interpreted as omitted for these properties
            Prorated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnitConfig { UnitAmount = "unit_amount", Prorated = true };

        UnitConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
