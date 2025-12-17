using System.Text.Json;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class AccountingProviderConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = "provider_type",
        };

        string expectedExternalProviderID = "external_provider_id";
        string expectedProviderType = "provider_type";

        Assert.Equal(expectedExternalProviderID, model.ExternalProviderID);
        Assert.Equal(expectedProviderType, model.ProviderType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = "provider_type",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AccountingProviderConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = "provider_type",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AccountingProviderConfig>(element);
        Assert.NotNull(deserialized);

        string expectedExternalProviderID = "external_provider_id";
        string expectedProviderType = "provider_type";

        Assert.Equal(expectedExternalProviderID, deserialized.ExternalProviderID);
        Assert.Equal(expectedProviderType, deserialized.ProviderType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = "provider_type",
        };

        model.Validate();
    }
}
