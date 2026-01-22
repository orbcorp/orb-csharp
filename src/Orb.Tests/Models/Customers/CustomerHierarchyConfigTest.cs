using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerHierarchyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIds = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        List<string> expectedChildCustomerIds = ["string"];
        string expectedParentCustomerID = "parent_customer_id";

        Assert.NotNull(model.ChildCustomerIds);
        Assert.Equal(expectedChildCustomerIds.Count, model.ChildCustomerIds.Count);
        for (int i = 0; i < expectedChildCustomerIds.Count; i++)
        {
            Assert.Equal(expectedChildCustomerIds[i], model.ChildCustomerIds[i]);
        }
        Assert.Equal(expectedParentCustomerID, model.ParentCustomerID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIds = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerHierarchyConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIds = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerHierarchyConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChildCustomerIds = ["string"];
        string expectedParentCustomerID = "parent_customer_id";

        Assert.NotNull(deserialized.ChildCustomerIds);
        Assert.Equal(expectedChildCustomerIds.Count, deserialized.ChildCustomerIds.Count);
        for (int i = 0; i < expectedChildCustomerIds.Count; i++)
        {
            Assert.Equal(expectedChildCustomerIds[i], deserialized.ChildCustomerIds[i]);
        }
        Assert.Equal(expectedParentCustomerID, deserialized.ParentCustomerID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIds = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerHierarchyConfig { ParentCustomerID = "parent_customer_id" };

        Assert.Null(model.ChildCustomerIds);
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
            ChildCustomerIds = null,
        };

        Assert.Null(model.ChildCustomerIds);
        Assert.False(model.RawData.ContainsKey("child_customer_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ParentCustomerID = "parent_customer_id",

            // Null should be interpreted as omitted for these properties
            ChildCustomerIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerHierarchyConfig { ChildCustomerIds = ["string"] };

        Assert.Null(model.ParentCustomerID);
        Assert.False(model.RawData.ContainsKey("parent_customer_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerHierarchyConfig { ChildCustomerIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIds = ["string"],

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
            ChildCustomerIds = ["string"],

            ParentCustomerID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerHierarchyConfig
        {
            ChildCustomerIds = ["string"],
            ParentCustomerID = "parent_customer_id",
        };

        CustomerHierarchyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
