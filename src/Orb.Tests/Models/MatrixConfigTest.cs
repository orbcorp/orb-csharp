using System.Collections.Generic;
using Orb.Models;

namespace Orb.Tests.Models;

public class MatrixConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixConfig
        {
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        string expectedDefaultUnitAmount = "default_unit_amount";
        List<string?> expectedDimensions = ["string"];
        List<SharedMatrixValue> expectedMatrixValues =
        [
            new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedDefaultUnitAmount, model.DefaultUnitAmount);
        Assert.Equal(expectedDimensions.Count, model.Dimensions.Count);
        for (int i = 0; i < expectedDimensions.Count; i++)
        {
            Assert.Equal(expectedDimensions[i], model.Dimensions[i]);
        }
        Assert.Equal(expectedMatrixValues.Count, model.MatrixValues.Count);
        for (int i = 0; i < expectedMatrixValues.Count; i++)
        {
            Assert.Equal(expectedMatrixValues[i], model.MatrixValues[i]);
        }
    }
}
