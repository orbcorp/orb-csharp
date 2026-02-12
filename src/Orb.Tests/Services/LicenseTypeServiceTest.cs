using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class LicenseTypeServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var licenseType = await this.client.LicenseTypes.Create(
            new() { GroupingKey = "grouping_key", Name = "name" },
            TestContext.Current.CancellationToken
        );
        licenseType.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var licenseType = await this.client.LicenseTypes.Retrieve(
            "license_type_id",
            new(),
            TestContext.Current.CancellationToken
        );
        licenseType.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.LicenseTypes.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
