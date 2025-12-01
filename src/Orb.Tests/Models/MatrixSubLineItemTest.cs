using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MatrixSubLineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
            ScaledQuantity = 0,
        };

        string expectedAmount = "9.00";
        SubLineItemGrouping expectedGrouping = new() { Key = "region", Value = "west" };
        SubLineItemMatrixConfig expectedMatrixConfig = new(["string"]);
        string expectedName = "Tier One";
        double expectedQuantity = 5;
        ApiEnum<string, MatrixSubLineItemType> expectedType = MatrixSubLineItemType.Matrix;
        double expectedScaledQuantity = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedGrouping, model.Grouping);
        Assert.Equal(expectedMatrixConfig, model.MatrixConfig);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedScaledQuantity, model.ScaledQuantity);
    }
}
