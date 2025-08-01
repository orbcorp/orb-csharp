using System;
using System.Threading.Tasks;
using AlertCreateForCustomerParamsProperties = Orb.Models.Alerts.AlertCreateForCustomerParamsProperties;
using AlertCreateForExternalCustomerParamsProperties = Orb.Models.Alerts.AlertCreateForExternalCustomerParamsProperties;
using AlertCreateForSubscriptionParamsProperties = Orb.Models.Alerts.AlertCreateForSubscriptionParamsProperties;

namespace Orb.Tests.Services.Alerts;

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
            new()
            {
                AlertConfigurationID = "alert_configuration_id",
                Thresholds = [new() { Value = 0 }],
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Alerts.List(
            new()
            {
                CreatedAtGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                CustomerID = "customer_id",
                ExternalCustomerID = "external_customer_id",
                Limit = 1,
                SubscriptionID = "subscription_id",
            }
        );
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
                Type = AlertCreateForCustomerParamsProperties::Type.CreditBalanceDepleted,
                Thresholds = [new() { Value = 0 }],
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
                Type = AlertCreateForExternalCustomerParamsProperties::Type.CreditBalanceDepleted,
                Thresholds = [new() { Value = 0 }],
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
                Thresholds = [new() { Value = 0 }],
                Type = AlertCreateForSubscriptionParamsProperties::Type.UsageExceeded,
                MetricID = "metric_id",
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Task Disable_Works()
    {
        var alert = await this.client.Alerts.Disable(
            new()
            {
                AlertConfigurationID = "alert_configuration_id",
                SubscriptionID = "subscription_id",
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Task Enable_Works()
    {
        var alert = await this.client.Alerts.Enable(
            new()
            {
                AlertConfigurationID = "alert_configuration_id",
                SubscriptionID = "subscription_id",
            }
        );
        alert.Validate();
    }
}
