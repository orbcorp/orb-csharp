using Orb.Models;

namespace Orb.Tests.Models;

public class CustomerMinifiedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerMinified { ID = "id", ExternalCustomerID = "external_customer_id" };

        string expectedID = "id";
        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalCustomerID, model.ExternalCustomerID);
    }
}
