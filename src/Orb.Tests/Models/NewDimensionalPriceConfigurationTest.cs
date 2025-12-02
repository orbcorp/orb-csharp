using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewDimensionalPriceConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewDimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        List<string> expectedDimensionValues = ["string"];
        string expectedDimensionalPriceGroupID = "dimensional_price_group_id";
        string expectedExternalDimensionalPriceGroupID = "external_dimensional_price_group_id";

        Assert.Equal(expectedDimensionValues.Count, model.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], model.DimensionValues[i]);
        }
        Assert.Equal(expectedDimensionalPriceGroupID, model.DimensionalPriceGroupID);
        Assert.Equal(
            expectedExternalDimensionalPriceGroupID,
            model.ExternalDimensionalPriceGroupID
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewDimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewDimensionalPriceConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewDimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewDimensionalPriceConfiguration>(json);
        Assert.NotNull(deserialized);

        List<string> expectedDimensionValues = ["string"];
        string expectedDimensionalPriceGroupID = "dimensional_price_group_id";
        string expectedExternalDimensionalPriceGroupID = "external_dimensional_price_group_id";

        Assert.Equal(expectedDimensionValues.Count, deserialized.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], deserialized.DimensionValues[i]);
        }
        Assert.Equal(expectedDimensionalPriceGroupID, deserialized.DimensionalPriceGroupID);
        Assert.Equal(
            expectedExternalDimensionalPriceGroupID,
            deserialized.ExternalDimensionalPriceGroupID
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewDimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewDimensionalPriceConfiguration { DimensionValues = ["string"] };

        Assert.Null(model.DimensionalPriceGroupID);
        Assert.False(model.RawData.ContainsKey("dimensional_price_group_id"));
        Assert.Null(model.ExternalDimensionalPriceGroupID);
        Assert.False(model.RawData.ContainsKey("external_dimensional_price_group_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewDimensionalPriceConfiguration { DimensionValues = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewDimensionalPriceConfiguration
        {
            DimensionValues = ["string"],

            DimensionalPriceGroupID = null,
            ExternalDimensionalPriceGroupID = null,
        };

        Assert.Null(model.DimensionalPriceGroupID);
        Assert.True(model.RawData.ContainsKey("dimensional_price_group_id"));
        Assert.Null(model.ExternalDimensionalPriceGroupID);
        Assert.True(model.RawData.ContainsKey("external_dimensional_price_group_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewDimensionalPriceConfiguration
        {
            DimensionValues = ["string"],

            DimensionalPriceGroupID = null,
            ExternalDimensionalPriceGroupID = null,
        };

        model.Validate();
    }
}
