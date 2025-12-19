using Orb.Models.InvoiceLineItems;

namespace Orb.Tests.Models.InvoiceLineItems;

public class InvoiceLineItemCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceLineItemCreateParams
        {
            Amount = "12.00",
            EndDate = "2023-09-22",
            InvoiceID = "4khy3nwzktxv7",
            Quantity = 1,
            StartDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            Name = "Item Name",
        };

        string expectedAmount = "12.00";
        string expectedEndDate = "2023-09-22";
        string expectedInvoiceID = "4khy3nwzktxv7";
        double expectedQuantity = 1;
        string expectedStartDate = "2023-09-22";
        string expectedItemID = "4khy3nwzktxv7";
        string expectedName = "Item Name";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedItemID, parameters.ItemID);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceLineItemCreateParams
        {
            Amount = "12.00",
            EndDate = "2023-09-22",
            InvoiceID = "4khy3nwzktxv7",
            Quantity = 1,
            StartDate = "2023-09-22",
        };

        Assert.Null(parameters.ItemID);
        Assert.False(parameters.RawBodyData.ContainsKey("item_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvoiceLineItemCreateParams
        {
            Amount = "12.00",
            EndDate = "2023-09-22",
            InvoiceID = "4khy3nwzktxv7",
            Quantity = 1,
            StartDate = "2023-09-22",

            ItemID = null,
            Name = null,
        };

        Assert.Null(parameters.ItemID);
        Assert.False(parameters.RawBodyData.ContainsKey("item_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }
}
