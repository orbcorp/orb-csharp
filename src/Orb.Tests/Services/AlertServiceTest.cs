using System.Threading.Tasks;
using Orb.Models.Alerts;

namespace Orb.Tests.Services;

public class AlertServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var alert = await this.client.Alerts.Retrieve(new() { AlertID = "alert_id" });
        alert.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var alert = await this.client.Alerts.Update(
            new() { AlertConfigurationID = "alert_configuration_id", Thresholds = [new(0)] }
        );
        alert.Validate();
    }

    [Fact(Skip = "plan_version=0 breaks Prism")]
    public async Task List_Works()
    {
        var page = await this.client.Alerts.List();
        page.Validate();
    }

    [Fact]
    public async Task CreateForCustomer_Works()
    {
        var alert = await this.client.Alerts.CreateForCustomer(
            new()
            {
                CustomerID = "customer_id",
                Currency = "currency",
                Type = Type.CreditBalanceDepleted,
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Task CreateForExternalCustomer_Works()
    {
        var alert = await this.client.Alerts.CreateForExternalCustomer(
            new()
            {
                ExternalCustomerID = "external_customer_id",
                Currency = "currency",
                Type = TypeModel.CreditBalanceDepleted,
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Task CreateForSubscription_Works()
    {
        var alert = await this.client.Alerts.CreateForSubscription(
            new()
            {
                SubscriptionID = "subscription_id",
                Thresholds = [new(0)],
                Type = Type1.UsageExceeded,
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Task Disable_Works()
    {
        var alert = await this.client.Alerts.Disable(
            new() { AlertConfigurationID = "alert_configuration_id" }
        );
        alert.Validate();
    }

    [Fact]
    public async Task Enable_Works()
    {
        var alert = await this.client.Alerts.Enable(
            new() { AlertConfigurationID = "alert_configuration_id" }
        );
        alert.Validate();
    }
}
