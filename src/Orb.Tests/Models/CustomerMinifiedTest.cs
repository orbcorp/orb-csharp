using System.Text.Json;
using Orb.Core;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerMinified { ID = "id", ExternalCustomerID = "external_customer_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerMinified>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerMinified { ID = "id", ExternalCustomerID = "external_customer_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerMinified>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalCustomerID, deserialized.ExternalCustomerID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerMinified { ID = "id", ExternalCustomerID = "external_customer_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerMinified { ID = "id", ExternalCustomerID = "external_customer_id" };

        CustomerMinified copied = new(model);

        Assert.Equal(model, copied);
    }
}
