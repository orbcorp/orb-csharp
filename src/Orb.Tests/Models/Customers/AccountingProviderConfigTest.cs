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
}
