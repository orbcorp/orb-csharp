using System.Threading.Tasks;

namespace Orb.Tests.Services.Licenses;

public class ExternalLicenseServiceTest : TestBase
{
    [Fact]
    public async Task GetUsage_Works()
    {
        var response = await this.client.Licenses.ExternalLicenses.GetUsage(
            "external_license_id",
            new() { LicenseTypeID = "license_type_id", SubscriptionID = "subscription_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
