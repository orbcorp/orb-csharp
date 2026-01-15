using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class SubscriptionChangeServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var subscriptionChange = await this.client.SubscriptionChanges.Retrieve(
            "subscription_change_id",
            new(),
            TestContext.Current.CancellationToken
        );
        subscriptionChange.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.SubscriptionChanges.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Apply_Works()
    {
        var response = await this.client.SubscriptionChanges.Apply(
            "subscription_change_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var response = await this.client.SubscriptionChanges.Cancel(
            "subscription_change_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
