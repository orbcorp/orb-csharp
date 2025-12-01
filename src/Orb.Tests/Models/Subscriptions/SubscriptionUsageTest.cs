using System;
using System.Collections.Generic;
using Orb.Core;
using Orb.Models;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class UngroupedSubscriptionUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UngroupedSubscriptionUsage
        {
            Data =
            [
                new()
                {
                    BillableMetric = new() { ID = "id", Name = "name" },
                    Usage =
                    [
                        new()
                        {
                            Quantity = 0,
                            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    ViewMode = DataViewMode.Periodic,
                },
            ],
        };

        List<Data> expectedData =
        [
            new()
            {
                BillableMetric = new() { ID = "id", Name = "name" },
                Usage =
                [
                    new()
                    {
                        Quantity = 0,
                        TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                ViewMode = DataViewMode.Periodic,
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            BillableMetric = new() { ID = "id", Name = "name" },
            Usage =
            [
                new()
                {
                    Quantity = 0,
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            ViewMode = DataViewMode.Periodic,
        };

        BillableMetric expectedBillableMetric = new() { ID = "id", Name = "name" };
        List<Usage> expectedUsage =
        [
            new()
            {
                Quantity = 0,
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        ApiEnum<string, DataViewMode> expectedViewMode = DataViewMode.Periodic;

        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedUsage.Count, model.Usage.Count);
        for (int i = 0; i < expectedUsage.Count; i++)
        {
            Assert.Equal(expectedUsage[i], model.Usage[i]);
        }
        Assert.Equal(expectedViewMode, model.ViewMode);
    }
}

public class BillableMetricTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillableMetric { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        double expectedQuantity = 0;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTimeframeEnd, model.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, model.TimeframeStart);
    }
}

public class GroupedSubscriptionUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedSubscriptionUsage
        {
            Data =
            [
                new()
                {
                    BillableMetric = new() { ID = "id", Name = "name" },
                    MetricGroup = new()
                    {
                        PropertyKey = "property_key",
                        PropertyValue = "property_value",
                    },
                    Usage =
                    [
                        new()
                        {
                            Quantity = 0,
                            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    ViewMode = DataModelViewMode.Periodic,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<DataModel> expectedData =
        [
            new()
            {
                BillableMetric = new() { ID = "id", Name = "name" },
                MetricGroup = new()
                {
                    PropertyKey = "property_key",
                    PropertyValue = "property_value",
                },
                Usage =
                [
                    new()
                    {
                        Quantity = 0,
                        TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                ViewMode = DataModelViewMode.Periodic,
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
}

public class DataModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataModel
        {
            BillableMetric = new() { ID = "id", Name = "name" },
            MetricGroup = new() { PropertyKey = "property_key", PropertyValue = "property_value" },
            Usage =
            [
                new()
                {
                    Quantity = 0,
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            ViewMode = DataModelViewMode.Periodic,
        };

        DataModelBillableMetric expectedBillableMetric = new() { ID = "id", Name = "name" };
        MetricGroup expectedMetricGroup = new()
        {
            PropertyKey = "property_key",
            PropertyValue = "property_value",
        };
        List<UsageModel> expectedUsage =
        [
            new()
            {
                Quantity = 0,
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        ApiEnum<string, DataModelViewMode> expectedViewMode = DataModelViewMode.Periodic;

        Assert.Equal(expectedBillableMetric, model.BillableMetric);
        Assert.Equal(expectedMetricGroup, model.MetricGroup);
        Assert.Equal(expectedUsage.Count, model.Usage.Count);
        for (int i = 0; i < expectedUsage.Count; i++)
        {
            Assert.Equal(expectedUsage[i], model.Usage[i]);
        }
        Assert.Equal(expectedViewMode, model.ViewMode);
    }
}

public class DataModelBillableMetricTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataModelBillableMetric { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }
}

public class MetricGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetricGroup
        {
            PropertyKey = "property_key",
            PropertyValue = "property_value",
        };

        string expectedPropertyKey = "property_key";
        string expectedPropertyValue = "property_value";

        Assert.Equal(expectedPropertyKey, model.PropertyKey);
        Assert.Equal(expectedPropertyValue, model.PropertyValue);
    }
}

public class UsageModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageModel
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        double expectedQuantity = 0;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTimeframeEnd, model.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, model.TimeframeStart);
    }
}
