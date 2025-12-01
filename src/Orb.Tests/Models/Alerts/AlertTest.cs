using System;
using System.Collections.Generic;
using Orb.Core;
using Orb.Models;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Alert
        {
            ID = "XuxCbt7x9L82yyeF",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            Enabled = true,
            Metric = new("id"),
            Plan = new()
            {
                ID = "m2t5akQeh2obwxeU",
                ExternalPlanID = "m2t5akQeh2obwxeU",
                Name = "Example plan",
                PlanVersion = "plan_version",
            },
            Subscription = new("VDGsT23osdLb84KD"),
            Thresholds = [new(0)],
            Type = AlertType.CreditBalanceDepleted,
            BalanceAlertStatus = [new() { InAlert = true, ThresholdValue = 0 }],
        };

        string expectedID = "XuxCbt7x9L82yyeF";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        bool expectedEnabled = true;
        Metric expectedMetric = new("id");
        Plan expectedPlan = new()
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
            PlanVersion = "plan_version",
        };
        SubscriptionMinified expectedSubscription = new("VDGsT23osdLb84KD");
        List<Threshold> expectedThresholds = [new(0)];
        ApiEnum<string, AlertType> expectedType = AlertType.CreditBalanceDepleted;
        List<BalanceAlertStatus> expectedBalanceAlertStatus =
        [
            new() { InAlert = true, ThresholdValue = 0 },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedMetric, model.Metric);
        Assert.Equal(expectedPlan, model.Plan);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedThresholds.Count, model.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], model.Thresholds[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedBalanceAlertStatus.Count, model.BalanceAlertStatus.Count);
        for (int i = 0; i < expectedBalanceAlertStatus.Count; i++)
        {
            Assert.Equal(expectedBalanceAlertStatus[i], model.BalanceAlertStatus[i]);
        }
    }
}

public class MetricTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metric { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }
}

public class PlanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
            PlanVersion = "plan_version",
        };

        string expectedID = "m2t5akQeh2obwxeU";
        string expectedExternalPlanID = "m2t5akQeh2obwxeU";
        string expectedName = "Example plan";
        string expectedPlanVersion = "plan_version";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalPlanID, model.ExternalPlanID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlanVersion, model.PlanVersion);
    }
}

public class BalanceAlertStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceAlertStatus { InAlert = true, ThresholdValue = 0 };

        bool expectedInAlert = true;
        double expectedThresholdValue = 0;

        Assert.Equal(expectedInAlert, model.InAlert);
        Assert.Equal(expectedThresholdValue, model.ThresholdValue);
    }
}
