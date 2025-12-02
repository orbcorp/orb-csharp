using System;
using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UngroupedSubscriptionUsage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UngroupedSubscriptionUsage>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedBillableMetric, deserialized.BillableMetric);
        Assert.Equal(expectedUsage.Count, deserialized.Usage.Count);
        for (int i = 0; i < expectedUsage.Count; i++)
        {
            Assert.Equal(expectedUsage[i], deserialized.Usage[i]);
        }
        Assert.Equal(expectedViewMode, deserialized.ViewMode);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillableMetric { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillableMetric>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillableMetric { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillableMetric>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillableMetric { ID = "id", Name = "name" };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);
        Assert.NotNull(deserialized);

        double expectedQuantity = 0;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedTimeframeEnd, deserialized.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, deserialized.TimeframeStart);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsage>(json);
        Assert.NotNull(deserialized);

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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.PaginationMetadata);
        Assert.False(model.RawData.ContainsKey("pagination_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            PaginationMetadata = null,
        };

        Assert.Null(model.PaginationMetadata);
        Assert.True(model.RawData.ContainsKey("pagination_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            PaginationMetadata = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DataModel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DataModel>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedBillableMetric, deserialized.BillableMetric);
        Assert.Equal(expectedMetricGroup, deserialized.MetricGroup);
        Assert.Equal(expectedUsage.Count, deserialized.Usage.Count);
        for (int i = 0; i < expectedUsage.Count; i++)
        {
            Assert.Equal(expectedUsage[i], deserialized.Usage[i]);
        }
        Assert.Equal(expectedViewMode, deserialized.ViewMode);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataModelBillableMetric { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DataModelBillableMetric>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataModelBillableMetric { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DataModelBillableMetric>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataModelBillableMetric { ID = "id", Name = "name" };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MetricGroup
        {
            PropertyKey = "property_key",
            PropertyValue = "property_value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MetricGroup>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MetricGroup
        {
            PropertyKey = "property_key",
            PropertyValue = "property_value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MetricGroup>(json);
        Assert.NotNull(deserialized);

        string expectedPropertyKey = "property_key";
        string expectedPropertyValue = "property_value";

        Assert.Equal(expectedPropertyKey, deserialized.PropertyKey);
        Assert.Equal(expectedPropertyValue, deserialized.PropertyValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MetricGroup
        {
            PropertyKey = "property_key",
            PropertyValue = "property_value",
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageModel
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageModel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageModel
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageModel>(json);
        Assert.NotNull(deserialized);

        double expectedQuantity = 0;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedTimeframeEnd, deserialized.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, deserialized.TimeframeStart);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageModel
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}
