using System.Collections.Generic;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedMatrixValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedMatrixValue
        {
            DimensionValues = ["string"],
            UnitAmount = "unit_amount",
        };

        List<string?> expectedDimensionValues = ["string"];
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedDimensionValues.Count, model.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], model.DimensionValues[i]);
        }
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}
