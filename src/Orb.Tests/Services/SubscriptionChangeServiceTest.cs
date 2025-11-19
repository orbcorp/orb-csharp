using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class SubscriptionChangeServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var subscriptionChange = await this.client.SubscriptionChanges.Retrieve(
            "subscription_change_id"
        );
        subscriptionChange.Validate();
    }

    [Fact]
    public async Task Apply_Works()
    {
        var response = await this.client.SubscriptionChanges.Apply("subscription_change_id");
        response.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var response = await this.client.SubscriptionChanges.Cancel("subscription_change_id");
        response.Validate();
    }
}
