using SubscriptionChanges = Orb.Models.SubscriptionChanges;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.SubscriptionChanges;

public class SubscriptionChangeServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Retrieve_Works()
    {
        var subscriptionChange = await this.client.SubscriptionChanges.Retrieve(
            new SubscriptionChanges::SubscriptionChangeRetrieveParams()
            {
                SubscriptionChangeID = "subscription_change_id",
            }
        );
        subscriptionChange.Validate();
    }

    [Fact]
    public async Tasks::Task Apply_Works()
    {
        var response = await this.client.SubscriptionChanges.Apply(
            new SubscriptionChanges::SubscriptionChangeApplyParams()
            {
                SubscriptionChangeID = "subscription_change_id",
                Description = "description",
                PreviouslyCollectedAmount = "previously_collected_amount",
            }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task Cancel_Works()
    {
        var response = await this.client.SubscriptionChanges.Cancel(
            new SubscriptionChanges::SubscriptionChangeCancelParams()
            {
                SubscriptionChangeID = "subscription_change_id",
            }
        );
        response.Validate();
    }
}
