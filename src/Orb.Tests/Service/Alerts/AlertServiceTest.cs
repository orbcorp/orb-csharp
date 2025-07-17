using AlertCreateForCustomerParamsProperties = Orb.Models.Alerts.AlertCreateForCustomerParamsProperties;
using AlertCreateForExternalCustomerParamsProperties = Orb.Models.Alerts.AlertCreateForExternalCustomerParamsProperties;
using AlertCreateForSubscriptionParamsProperties = Orb.Models.Alerts.AlertCreateForSubscriptionParamsProperties;
using Alerts = Orb.Models.Alerts;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Alerts;

public class AlertServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Retrieve_Works()
    {
        var alert = await this.client.Alerts.Retrieve(
            new Alerts::AlertRetrieveParams() { AlertID = "alert_id" }
        );
        alert.Validate();
    }

    [Fact]
    public async Tasks::Task Update_Works()
    {
        var alert = await this.client.Alerts.Update(
            new Alerts::AlertUpdateParams()
            {
                AlertConfigurationID = "alert_configuration_id",
                Thresholds = [new Alerts::Threshold() { Value = 0 }],
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Alerts.List(
            new Alerts::AlertListParams()
            {
                CreatedAtGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
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
    public async Tasks::Task CreateForCustomer_Works()
    {
        var alert = await this.client.Alerts.CreateForCustomer(
            new Alerts::AlertCreateForCustomerParams()
            {
                CustomerID = "customer_id",
                Currency = "currency",
                Type = AlertCreateForCustomerParamsProperties::Type.CreditBalanceDepleted,
                Thresholds = [new Alerts::Threshold() { Value = 0 }],
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Tasks::Task CreateForExternalCustomer_Works()
    {
        var alert = await this.client.Alerts.CreateForExternalCustomer(
            new Alerts::AlertCreateForExternalCustomerParams()
            {
                ExternalCustomerID = "external_customer_id",
                Currency = "currency",
                Type = AlertCreateForExternalCustomerParamsProperties::Type.CreditBalanceDepleted,
                Thresholds = [new Alerts::Threshold() { Value = 0 }],
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Tasks::Task CreateForSubscription_Works()
    {
        var alert = await this.client.Alerts.CreateForSubscription(
            new Alerts::AlertCreateForSubscriptionParams()
            {
                SubscriptionID = "subscription_id",
                Thresholds = [new Alerts::Threshold() { Value = 0 }],
                Type = AlertCreateForSubscriptionParamsProperties::Type.UsageExceeded,
                MetricID = "metric_id",
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Tasks::Task Disable_Works()
    {
        var alert = await this.client.Alerts.Disable(
            new Alerts::AlertDisableParams()
            {
                AlertConfigurationID = "alert_configuration_id",
                SubscriptionID = "subscription_id",
            }
        );
        alert.Validate();
    }

    [Fact]
    public async Tasks::Task Enable_Works()
    {
        var alert = await this.client.Alerts.Enable(
            new Alerts::AlertEnableParams()
            {
                AlertConfigurationID = "alert_configuration_id",
                SubscriptionID = "subscription_id",
            }
        );
        alert.Validate();
    }
}
