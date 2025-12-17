using System.Collections.Generic;
using System.Text.Json;
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

        Assert.NotNull(model.ChildCustomerIDs);
        Assert.Equal(expectedChildCustomerIDs.Count, model.ChildCustomerIDs.Count);
        for (int i = 0; i < expectedChildCustomerIDs.Count; i++)
        {
            Assert.Equal(expectedChildCustomerIDs[i], model.ChildCustomerIDs[i]);
        }
        Assert.Equal(expectedParentCustomerID, model.ParentCustomerID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIDs = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerHierarchyConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIDs = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerHierarchyConfig>(element);
        Assert.NotNull(deserialized);

        List<string> expectedChildCustomerIDs = ["string"];
        string expectedParentCustomerID = "parent_customer_id";

        Assert.NotNull(deserialized.ChildCustomerIDs);
        Assert.Equal(expectedChildCustomerIDs.Count, deserialized.ChildCustomerIDs.Count);
        for (int i = 0; i < expectedChildCustomerIDs.Count; i++)
        {
            Assert.Equal(expectedChildCustomerIDs[i], deserialized.ChildCustomerIDs[i]);
        }
        Assert.Equal(expectedParentCustomerID, deserialized.ParentCustomerID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIDs = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerHierarchyConfig { ParentCustomerID = "parent_customer_id" };

        Assert.Null(model.ChildCustomerIDs);
        Assert.False(model.RawData.ContainsKey("child_customer_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerHierarchyConfig { ParentCustomerID = "parent_customer_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ParentCustomerID = "parent_customer_id",

            // Null should be interpreted as omitted for these properties
            ChildCustomerIDs = null,
        };

        Assert.Null(model.ChildCustomerIDs);
        Assert.False(model.RawData.ContainsKey("child_customer_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ParentCustomerID = "parent_customer_id",

            // Null should be interpreted as omitted for these properties
            ChildCustomerIDs = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerHierarchyConfig { ChildCustomerIDs = ["string"] };

        Assert.Null(model.ParentCustomerID);
        Assert.False(model.RawData.ContainsKey("parent_customer_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerHierarchyConfig { ChildCustomerIDs = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIDs = ["string"],

            ParentCustomerID = null,
        };

        Assert.Null(model.ParentCustomerID);
        Assert.True(model.RawData.ContainsKey("parent_customer_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIDs = ["string"],

            ParentCustomerID = null,
        };

        model.Validate();
    }
}
