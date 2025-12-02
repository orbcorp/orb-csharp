using System.Text.Json;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerMinified>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerMinified { ID = "id", ExternalCustomerID = "external_customer_id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerMinified>(json);
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
}
