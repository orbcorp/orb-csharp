using ExternalConnectionProperties = Orb.Models.Items.ItemUpdateParamsProperties.ExternalConnectionProperties;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Items;

public class ItemServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
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
    public async Tasks::Task Update_Works()
    {
        var item = await this.client.Items.Update(
            new()
            {
                ItemID = "item_id",
                ExternalConnections =
                [
                    new()
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
        var page = await this.client.Items.List(new() { Cursor = "cursor", Limit = 1 });
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Archive_Works()
    {
        var item = await this.client.Items.Archive(new() { ItemID = "item_id" });
        item.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var item = await this.client.Items.Fetch(new() { ItemID = "item_id" });
        item.Validate();
    }
}
