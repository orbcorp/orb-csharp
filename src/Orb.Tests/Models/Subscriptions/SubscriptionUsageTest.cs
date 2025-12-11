using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionUsageTest : TestBase
{
    [Fact]
    public void ungroupedValidation_Works()
    {
        SubscriptionUsage value = new(
            new UngroupedSubscriptionUsage(
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
                ]
            )
        );
        value.Validate();
    }

    [Fact]
    public void groupedValidation_Works()
    {
        SubscriptionUsage value = new(
            new GroupedSubscriptionUsage()
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
                        ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
                    },
                ],
                PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
            }
        );
        value.Validate();
    }

    [Fact]
    public void ungroupedSerializationRoundtrip_Works()
    {
        SubscriptionUsage value = new(
            new UngroupedSubscriptionUsage(
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
                ]
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SubscriptionUsage>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void groupedSerializationRoundtrip_Works()
    {
        SubscriptionUsage value = new(
            new GroupedSubscriptionUsage()
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
                        ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
                    },
                ],
                PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SubscriptionUsage>(json);

        Assert.Equal(value, deserialized);
    }
}

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
        List<DataUsage> expectedUsage =
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
        List<DataUsage> expectedUsage =
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

public class DataUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataUsage
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
        var model = new DataUsage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DataUsage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataUsage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DataUsage>(json);
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
        var model = new DataUsage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class DataViewModeTest : TestBase
{
    [Theory]
    [InlineData(DataViewMode.Periodic)]
    [InlineData(DataViewMode.Cumulative)]
    public void Validation_Works(DataViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataViewMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataViewMode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataViewMode.Periodic)]
    [InlineData(DataViewMode.Cumulative)]
    public void SerializationRoundtrip_Works(DataViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataViewMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataViewMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataViewMode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataViewMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
                    ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<GroupedSubscriptionUsageData> expectedData =
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
                ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
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
                    ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
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
                    ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsage>(json);
        Assert.NotNull(deserialized);

        List<GroupedSubscriptionUsageData> expectedData =
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
                ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
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
                    ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
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
                    ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
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
                    ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
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
                    ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
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
                    ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
                },
            ],

            PaginationMetadata = null,
        };

        model.Validate();
    }
}

public class GroupedSubscriptionUsageDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedSubscriptionUsageData
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
            ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
        };

        GroupedSubscriptionUsageDataBillableMetric expectedBillableMetric = new()
        {
            ID = "id",
            Name = "name",
        };
        MetricGroup expectedMetricGroup = new()
        {
            PropertyKey = "property_key",
            PropertyValue = "property_value",
        };
        List<GroupedSubscriptionUsageDataUsage> expectedUsage =
        [
            new()
            {
                Quantity = 0,
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        ApiEnum<string, GroupedSubscriptionUsageDataViewMode> expectedViewMode =
            GroupedSubscriptionUsageDataViewMode.Periodic;

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
        var model = new GroupedSubscriptionUsageData
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
            ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsageData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroupedSubscriptionUsageData
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
            ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsageData>(json);
        Assert.NotNull(deserialized);

        GroupedSubscriptionUsageDataBillableMetric expectedBillableMetric = new()
        {
            ID = "id",
            Name = "name",
        };
        MetricGroup expectedMetricGroup = new()
        {
            PropertyKey = "property_key",
            PropertyValue = "property_value",
        };
        List<GroupedSubscriptionUsageDataUsage> expectedUsage =
        [
            new()
            {
                Quantity = 0,
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        ApiEnum<string, GroupedSubscriptionUsageDataViewMode> expectedViewMode =
            GroupedSubscriptionUsageDataViewMode.Periodic;

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
        var model = new GroupedSubscriptionUsageData
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
            ViewMode = GroupedSubscriptionUsageDataViewMode.Periodic,
        };

        model.Validate();
    }
}

public class GroupedSubscriptionUsageDataBillableMetricTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedSubscriptionUsageDataBillableMetric { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroupedSubscriptionUsageDataBillableMetric { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsageDataBillableMetric>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroupedSubscriptionUsageDataBillableMetric { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsageDataBillableMetric>(
            json
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroupedSubscriptionUsageDataBillableMetric { ID = "id", Name = "name" };

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

public class GroupedSubscriptionUsageDataUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedSubscriptionUsageDataUsage
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
        var model = new GroupedSubscriptionUsageDataUsage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsageDataUsage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroupedSubscriptionUsageDataUsage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsageDataUsage>(json);
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
        var model = new GroupedSubscriptionUsageDataUsage
        {
            Quantity = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class GroupedSubscriptionUsageDataViewModeTest : TestBase
{
    [Theory]
    [InlineData(GroupedSubscriptionUsageDataViewMode.Periodic)]
    [InlineData(GroupedSubscriptionUsageDataViewMode.Cumulative)]
    public void Validation_Works(GroupedSubscriptionUsageDataViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupedSubscriptionUsageDataViewMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GroupedSubscriptionUsageDataViewMode>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GroupedSubscriptionUsageDataViewMode.Periodic)]
    [InlineData(GroupedSubscriptionUsageDataViewMode.Cumulative)]
    public void SerializationRoundtrip_Works(GroupedSubscriptionUsageDataViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupedSubscriptionUsageDataViewMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GroupedSubscriptionUsageDataViewMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GroupedSubscriptionUsageDataViewMode>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GroupedSubscriptionUsageDataViewMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
