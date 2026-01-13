using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class PriceEvaluatePreviewEventsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponse
        {
            Data =
            [
                new()
                {
                    Currency = "currency",
                    PriceGroups =
                    [
                        new()
                        {
                            Amount = "amount",
                            GroupingValues = ["string"],
                            Quantity = 0,
                        },
                    ],
                    ExternalPriceID = "external_price_id",
                    InlinePriceIndex = 0,
                    PriceID = "price_id",
                },
            ],
        };

        List<PriceEvaluatePreviewEventsResponseData> expectedData =
        [
            new()
            {
                Currency = "currency",
                PriceGroups =
                [
                    new()
                    {
                        Amount = "amount",
                        GroupingValues = ["string"],
                        Quantity = 0,
                    },
                ],
                ExternalPriceID = "external_price_id",
                InlinePriceIndex = 0,
                PriceID = "price_id",
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
        var model = new PriceEvaluatePreviewEventsResponse
        {
            Data =
            [
                new()
                {
                    Currency = "currency",
                    PriceGroups =
                    [
                        new()
                        {
                            Amount = "amount",
                            GroupingValues = ["string"],
                            Quantity = 0,
                        },
                    ],
                    ExternalPriceID = "external_price_id",
                    InlinePriceIndex = 0,
                    PriceID = "price_id",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEvaluatePreviewEventsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponse
        {
            Data =
            [
                new()
                {
                    Currency = "currency",
                    PriceGroups =
                    [
                        new()
                        {
                            Amount = "amount",
                            GroupingValues = ["string"],
                            Quantity = 0,
                        },
                    ],
                    ExternalPriceID = "external_price_id",
                    InlinePriceIndex = 0,
                    PriceID = "price_id",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEvaluatePreviewEventsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PriceEvaluatePreviewEventsResponseData> expectedData =
        [
            new()
            {
                Currency = "currency",
                PriceGroups =
                [
                    new()
                    {
                        Amount = "amount",
                        GroupingValues = ["string"],
                        Quantity = 0,
                    },
                ],
                ExternalPriceID = "external_price_id",
                InlinePriceIndex = 0,
                PriceID = "price_id",
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
        var model = new PriceEvaluatePreviewEventsResponse
        {
            Data =
            [
                new()
                {
                    Currency = "currency",
                    PriceGroups =
                    [
                        new()
                        {
                            Amount = "amount",
                            GroupingValues = ["string"],
                            Quantity = 0,
                        },
                    ],
                    ExternalPriceID = "external_price_id",
                    InlinePriceIndex = 0,
                    PriceID = "price_id",
                },
            ],
        };

        model.Validate();
    }
}

public class PriceEvaluatePreviewEventsResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponseData
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            InlinePriceIndex = 0,
            PriceID = "price_id",
        };

        string expectedCurrency = "currency";
        List<EvaluatePriceGroup> expectedPriceGroups =
        [
            new()
            {
                Amount = "amount",
                GroupingValues = ["string"],
                Quantity = 0,
            },
        ];
        string expectedExternalPriceID = "external_price_id";
        long expectedInlinePriceIndex = 0;
        string expectedPriceID = "price_id";

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedPriceGroups.Count, model.PriceGroups.Count);
        for (int i = 0; i < expectedPriceGroups.Count; i++)
        {
            Assert.Equal(expectedPriceGroups[i], model.PriceGroups[i]);
        }
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedInlinePriceIndex, model.InlinePriceIndex);
        Assert.Equal(expectedPriceID, model.PriceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponseData
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            InlinePriceIndex = 0,
            PriceID = "price_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEvaluatePreviewEventsResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponseData
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            InlinePriceIndex = 0,
            PriceID = "price_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEvaluatePreviewEventsResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrency = "currency";
        List<EvaluatePriceGroup> expectedPriceGroups =
        [
            new()
            {
                Amount = "amount",
                GroupingValues = ["string"],
                Quantity = 0,
            },
        ];
        string expectedExternalPriceID = "external_price_id";
        long expectedInlinePriceIndex = 0;
        string expectedPriceID = "price_id";

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedPriceGroups.Count, deserialized.PriceGroups.Count);
        for (int i = 0; i < expectedPriceGroups.Count; i++)
        {
            Assert.Equal(expectedPriceGroups[i], deserialized.PriceGroups[i]);
        }
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedInlinePriceIndex, deserialized.InlinePriceIndex);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponseData
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            InlinePriceIndex = 0,
            PriceID = "price_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponseData
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],
        };

        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.InlinePriceIndex);
        Assert.False(model.RawData.ContainsKey("inline_price_index"));
        Assert.Null(model.PriceID);
        Assert.False(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponseData
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponseData
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],

            ExternalPriceID = null,
            InlinePriceIndex = null,
            PriceID = null,
        };

        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.InlinePriceIndex);
        Assert.True(model.RawData.ContainsKey("inline_price_index"));
        Assert.Null(model.PriceID);
        Assert.True(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponseData
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],

            ExternalPriceID = null,
            InlinePriceIndex = null,
            PriceID = null,
        };

        model.Validate();
    }
}
