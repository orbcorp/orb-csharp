using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class ItemServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var item = await this.client.Items.Create(
            new() { Name = "API requests" },
            TestContext.Current.CancellationToken
        );
        item.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var item = await this.client.Items.Update(
            "item_id",
            new(),
            TestContext.Current.CancellationToken
        );
        item.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Items.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var item = await this.client.Items.Archive(
            "item_id",
            new(),
            TestContext.Current.CancellationToken
        );
        item.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var item = await this.client.Items.Fetch(
            "item_id",
            new(),
            TestContext.Current.CancellationToken
        );
        item.Validate();
    }
}
