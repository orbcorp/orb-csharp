using System.Collections.Generic;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerHierarchyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIDs = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        List<string> expectedChildCustomerIDs = ["string"];
        string expectedParentCustomerID = "parent_customer_id";

        Assert.Equal(expectedChildCustomerIDs.Count, model.ChildCustomerIDs.Count);
        for (int i = 0; i < expectedChildCustomerIDs.Count; i++)
        {
            Assert.Equal(expectedChildCustomerIDs[i], model.ChildCustomerIDs[i]);
        }
        Assert.Equal(expectedParentCustomerID, model.ParentCustomerID);
    }
}
