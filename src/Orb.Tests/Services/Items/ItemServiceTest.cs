using System.Threading.Tasks;
using Orb.Models.Items.ItemUpdateParamsProperties.ExternalConnectionProperties;

namespace Orb.Tests.Services.Items;

public class ItemServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var item = await this.client.Items.Create(
            new()
            {
                Name = "API requests",
                Metadata = new() { { "foo", "string" } },
            }
        );
        item.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var item = await this.client.Items.Update(
            new()
            {
                ItemID = "item_id",
                ExternalConnections =
                [
                    new()
                    {
                        ExternalConnectionName = ExternalConnectionName.Stripe,
                        ExternalEntityID = "external_entity_id",
                    },
                ],
                Metadata = new() { { "foo", "string" } },
                Name = "name",
            }
        );
        item.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Items.List(new() { Cursor = "cursor", Limit = 1 });
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var item = await this.client.Items.Archive(new() { ItemID = "item_id" });
        item.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var item = await this.client.Items.Fetch(new() { ItemID = "item_id" });
        item.Validate();
    }
}
