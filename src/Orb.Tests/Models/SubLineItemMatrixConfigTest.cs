using System.Collections.Generic;
using Orb.Models;

namespace Orb.Tests.Models;

public class SubLineItemMatrixConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubLineItemMatrixConfig { DimensionValues = ["string"] };

        List<string?> expectedDimensionValues = ["string"];

        Assert.Equal(expectedDimensionValues.Count, model.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], model.DimensionValues[i]);
        }
    }
}
