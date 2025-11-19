using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class ItemServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var item = await this.client.Items.Create(new() { Name = "API requests" });
        item.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var item = await this.client.Items.Update("item_id");
        item.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Items.List();
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var item = await this.client.Items.Archive("item_id");
        item.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var item = await this.client.Items.Fetch("item_id");
        item.Validate();
    }
}
