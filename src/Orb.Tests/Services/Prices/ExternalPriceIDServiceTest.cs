using System.Threading.Tasks;

namespace Orb.Tests.Services.Prices;

public class ExternalPriceIDServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var price = await this.client.Prices.ExternalPriceID.Update(
            "external_price_id",
            new(),
            TestContext.Current.CancellationToken
        );
        price.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var price = await this.client.Prices.ExternalPriceID.Fetch(
            "external_price_id",
            new(),
            TestContext.Current.CancellationToken
        );
        price.Validate();
    }
}
