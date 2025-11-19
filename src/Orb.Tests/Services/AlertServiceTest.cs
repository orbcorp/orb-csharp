using System.Threading.Tasks;
using Orb.Models.Alerts;

namespace Orb.Tests.Services;

public class AlertServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var alert = await this.client.Alerts.Retrieve("alert_id");
        alert.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var alert = await this.client.Alerts.Update(
            "alert_configuration_id",
            new() { Thresholds = [new(0)] }
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
            "customer_id",
            new() { Currency = "currency", Type = Type.CreditBalanceDepleted }
        );
        alert.Validate();
    }

    [Fact]
    public async Task CreateForExternalCustomer_Works()
    {
        var alert = await this.client.Alerts.CreateForExternalCustomer(
            "external_customer_id",
            new() { Currency = "currency", Type = TypeModel.CreditBalanceDepleted }
        );
        alert.Validate();
    }

    [Fact]
    public async Task CreateForSubscription_Works()
    {
        var alert = await this.client.Alerts.CreateForSubscription(
            "subscription_id",
            new() { Thresholds = [new(0)], Type = Type1.UsageExceeded }
        );
        alert.Validate();
    }

    [Fact]
    public async Task Disable_Works()
    {
        var alert = await this.client.Alerts.Disable("alert_configuration_id");
        alert.Validate();
    }

    [Fact]
    public async Task Enable_Works()
    {
        var alert = await this.client.Alerts.Enable("alert_configuration_id");
        alert.Validate();
    }
}
