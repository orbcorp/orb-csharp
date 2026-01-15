using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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
        Assert.NotNull(model.Thresholds);
        Assert.Equal(expectedThresholds.Count, model.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], model.Thresholds[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.BalanceAlertStatus);
        Assert.Equal(expectedBalanceAlertStatus.Count, model.BalanceAlertStatus.Count);
        for (int i = 0; i < expectedBalanceAlertStatus.Count; i++)
        {
            Assert.Equal(expectedBalanceAlertStatus[i], model.BalanceAlertStatus[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Alert>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Alert>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedMetric, deserialized.Metric);
        Assert.Equal(expectedPlan, deserialized.Plan);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
        Assert.NotNull(deserialized.Thresholds);
        Assert.Equal(expectedThresholds.Count, deserialized.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], deserialized.Thresholds[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.BalanceAlertStatus);
        Assert.Equal(expectedBalanceAlertStatus.Count, deserialized.BalanceAlertStatus.Count);
        for (int i = 0; i < expectedBalanceAlertStatus.Count; i++)
        {
            Assert.Equal(expectedBalanceAlertStatus[i], deserialized.BalanceAlertStatus[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.BalanceAlertStatus);
        Assert.False(model.RawData.ContainsKey("balance_alert_status"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            BalanceAlertStatus = null,
        };

        Assert.Null(model.BalanceAlertStatus);
        Assert.True(model.RawData.ContainsKey("balance_alert_status"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            BalanceAlertStatus = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metric { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metric>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metric { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metric>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metric { ID = "id" };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
            PlanVersion = "plan_version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plan>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
            PlanVersion = "plan_version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plan>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "m2t5akQeh2obwxeU";
        string expectedExternalPlanID = "m2t5akQeh2obwxeU";
        string expectedName = "Example plan";
        string expectedPlanVersion = "plan_version";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalPlanID, deserialized.ExternalPlanID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPlanVersion, deserialized.PlanVersion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
            PlanVersion = "plan_version",
        };

        model.Validate();
    }
}

public class AlertTypeTest : TestBase
{
    [Theory]
    [InlineData(AlertType.CreditBalanceDepleted)]
    [InlineData(AlertType.CreditBalanceDropped)]
    [InlineData(AlertType.CreditBalanceRecovered)]
    [InlineData(AlertType.UsageExceeded)]
    [InlineData(AlertType.CostExceeded)]
    public void Validation_Works(AlertType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AlertType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlertType.CreditBalanceDepleted)]
    [InlineData(AlertType.CreditBalanceDropped)]
    [InlineData(AlertType.CreditBalanceRecovered)]
    [InlineData(AlertType.UsageExceeded)]
    [InlineData(AlertType.CostExceeded)]
    public void SerializationRoundtrip_Works(AlertType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AlertType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AlertType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AlertType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceAlertStatus { InAlert = true, ThresholdValue = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceAlertStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceAlertStatus { InAlert = true, ThresholdValue = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceAlertStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedInAlert = true;
        double expectedThresholdValue = 0;

        Assert.Equal(expectedInAlert, deserialized.InAlert);
        Assert.Equal(expectedThresholdValue, deserialized.ThresholdValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceAlertStatus { InAlert = true, ThresholdValue = 0 };

        model.Validate();
    }
}
