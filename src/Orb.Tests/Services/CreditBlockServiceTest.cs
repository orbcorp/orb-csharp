using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class CreditBlockServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var creditBlock = await this.client.CreditBlocks.Retrieve(
            "block_id",
            new(),
            TestContext.Current.CancellationToken
        );
        creditBlock.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.CreditBlocks.Delete(
            "block_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
