using System.Collections.Generic;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class NewAccountingSyncConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewAccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = "provider_type",
                },
            ],
            Excluded = true,
        };

        List<AccountingProviderConfig> expectedAccountingProviders =
        [
            new() { ExternalProviderID = "external_provider_id", ProviderType = "provider_type" },
        ];
        bool expectedExcluded = true;

        Assert.Equal(expectedAccountingProviders.Count, model.AccountingProviders.Count);
        for (int i = 0; i < expectedAccountingProviders.Count; i++)
        {
            Assert.Equal(expectedAccountingProviders[i], model.AccountingProviders[i]);
        }
        Assert.Equal(expectedExcluded, model.Excluded);
    }
}
