using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AlertListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Alert> expectedData =
        [
            new()
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
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, model.PaginationMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AlertListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlertListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AlertListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlertListPageResponse>(json);
        Assert.NotNull(deserialized);

        List<Alert> expectedData =
        [
            new()
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
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, deserialized.PaginationMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AlertListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
