using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class LicenseServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var license = await this.client.Licenses.Create(
            new()
            {
                ExternalLicenseID = "external_license_id",
                LicenseTypeID = "license_type_id",
                SubscriptionID = "subscription_id",
            },
            TestContext.Current.CancellationToken
        );
        license.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var license = await this.client.Licenses.Retrieve(
            "license_id",
            new(),
            TestContext.Current.CancellationToken
        );
        license.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Licenses.List(
            new() { SubscriptionID = "subscription_id" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Deactivate_Works()
    {
        var response = await this.client.Licenses.Deactivate(
            "license_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task RetrieveByExternalID_Works()
    {
        var response = await this.client.Licenses.RetrieveByExternalID(
            "external_license_id",
            new() { LicenseTypeID = "license_type_id", SubscriptionID = "subscription_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
