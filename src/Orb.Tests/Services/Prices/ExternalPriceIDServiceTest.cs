using System.Threading.Tasks;

namespace Orb.Tests.Services.Prices;

public class ExternalPriceIDServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var price = await this.client.Prices.ExternalPriceID.Update(
            new() { ExternalPriceID = "external_price_id" }
        );
        price.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var price = await this.client.Prices.ExternalPriceID.Fetch(
            new() { ExternalPriceID = "external_price_id" }
        );
        price.Validate();
    }
}
