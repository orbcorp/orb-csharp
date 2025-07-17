using ExternalConnectionProperties = Orb.Models.Items.ItemUpdateParamsProperties.ExternalConnectionProperties;
using Items = Orb.Models.Items;
using ItemUpdateParamsProperties = Orb.Models.Items.ItemUpdateParamsProperties;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Items;

public class ItemServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var item = await this.client.Items.Create(
            new Items::ItemCreateParams()
            {
                Name = "API requests",
                Metadata = new() { { "foo", "string" } },
            }
        );
        item.Validate();
    }

    [Fact]
    public async Tasks::Task Update_Works()
    {
        var item = await this.client.Items.Update(
            new Items::ItemUpdateParams()
            {
                ItemID = "item_id",
                ExternalConnections =
                [
                    new ItemUpdateParamsProperties::ExternalConnection()
                    {
                        ExternalConnectionName =
                            ExternalConnectionProperties::ExternalConnectionName.Stripe,
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
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Items.List(
            new Items::ItemListParams() { Cursor = "cursor", Limit = 1 }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Archive_Works()
    {
        var item = await this.client.Items.Archive(
            new Items::ItemArchiveParams() { ItemID = "item_id" }
        );
        item.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var item = await this.client.Items.Fetch(
            new Items::ItemFetchParams() { ItemID = "item_id" }
        );
        item.Validate();
    }
}
