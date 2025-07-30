using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Prices.ExternalPriceID;

public class ExternalPriceIDServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Update_Works()
    {
        var price = await this.client.Prices.ExternalPriceID.Update(
            new()
            {
                ExternalPriceID = "external_price_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        price.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var price = await this.client.Prices.ExternalPriceID.Fetch(
            new() { ExternalPriceID = "external_price_id" }
        );
        price.Validate();
    }
}
