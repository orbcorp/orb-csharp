using System.Threading.Tasks;

namespace Orb.Tests.Services.Licenses;

public class UsageServiceTest : TestBase
{
    [Fact]
    public async Task GetAllUsage_Works()
    {
        var response = await this.client.Licenses.Usage.GetAllUsage(
            new() { LicenseTypeID = "license_type_id", SubscriptionID = "subscription_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task GetUsage_Works()
    {
        var response = await this.client.Licenses.Usage.GetUsage(
            "license_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
