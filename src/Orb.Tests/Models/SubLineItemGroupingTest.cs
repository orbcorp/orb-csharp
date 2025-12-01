using Orb.Models;

namespace Orb.Tests.Models;

public class SubLineItemGroupingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubLineItemGrouping { Key = "region", Value = "west" };

        string expectedKey = "region";
        string expectedValue = "west";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedValue, model.Value);
    }
}
