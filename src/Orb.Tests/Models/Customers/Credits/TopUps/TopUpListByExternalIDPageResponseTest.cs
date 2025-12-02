using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class TopUpListByExternalIDPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUpListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    Currency = "currency",
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        Memo = "memo",
                        RequireSuccessfulPayment = true,
                    },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Threshold = "threshold",
                    ExpiresAfter = 0,
                    ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<DataModel> expectedData =
        [
            new()
            {
                ID = "id",
                Amount = "amount",
                Currency = "currency",
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    NetTerms = 0,
                    Memo = "memo",
                    RequireSuccessfulPayment = true,
                },
                PerUnitCostBasis = "per_unit_cost_basis",
                Threshold = "threshold",
                ExpiresAfter = 0,
                ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
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
        var model = new TopUpListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    Currency = "currency",
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        Memo = "memo",
                        RequireSuccessfulPayment = true,
                    },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Threshold = "threshold",
                    ExpiresAfter = 0,
                    ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TopUpListByExternalIDPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUpListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    Currency = "currency",
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        Memo = "memo",
                        RequireSuccessfulPayment = true,
                    },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Threshold = "threshold",
                    ExpiresAfter = 0,
                    ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TopUpListByExternalIDPageResponse>(json);
        Assert.NotNull(deserialized);

        List<DataModel> expectedData =
        [
            new()
            {
                ID = "id",
                Amount = "amount",
                Currency = "currency",
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    NetTerms = 0,
                    Memo = "memo",
                    RequireSuccessfulPayment = true,
                },
                PerUnitCostBasis = "per_unit_cost_basis",
                Threshold = "threshold",
                ExpiresAfter = 0,
                ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
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
        var model = new TopUpListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    Currency = "currency",
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        Memo = "memo",
                        RequireSuccessfulPayment = true,
                    },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Threshold = "threshold",
                    ExpiresAfter = 0,
                    ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
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
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",
            ExpiresAfter = 0,
            ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
        };

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedCurrency = "currency";
        TopUpInvoiceSettings expectedInvoiceSettings = new()
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        string expectedThreshold = "threshold";
        long expectedExpiresAfter = 0;
        ApiEnum<string, DataModelExpiresAfterUnit> expectedExpiresAfterUnit =
            DataModelExpiresAfterUnit.Day;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedInvoiceSettings, model.InvoiceSettings);
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
        Assert.Equal(expectedThreshold, model.Threshold);
        Assert.Equal(expectedExpiresAfter, model.ExpiresAfter);
        Assert.Equal(expectedExpiresAfterUnit, model.ExpiresAfterUnit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataModel
        {
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",
            ExpiresAfter = 0,
            ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
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
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",
            ExpiresAfter = 0,
            ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DataModel>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedCurrency = "currency";
        TopUpInvoiceSettings expectedInvoiceSettings = new()
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        string expectedThreshold = "threshold";
        long expectedExpiresAfter = 0;
        ApiEnum<string, DataModelExpiresAfterUnit> expectedExpiresAfterUnit =
            DataModelExpiresAfterUnit.Day;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedInvoiceSettings, deserialized.InvoiceSettings);
        Assert.Equal(expectedPerUnitCostBasis, deserialized.PerUnitCostBasis);
        Assert.Equal(expectedThreshold, deserialized.Threshold);
        Assert.Equal(expectedExpiresAfter, deserialized.ExpiresAfter);
        Assert.Equal(expectedExpiresAfterUnit, deserialized.ExpiresAfterUnit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataModel
        {
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",
            ExpiresAfter = 0,
            ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataModel
        {
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",
        };

        Assert.Null(model.ExpiresAfter);
        Assert.False(model.RawData.ContainsKey("expires_after"));
        Assert.Null(model.ExpiresAfterUnit);
        Assert.False(model.RawData.ContainsKey("expires_after_unit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataModel
        {
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataModel
        {
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",

            ExpiresAfter = null,
            ExpiresAfterUnit = null,
        };

        Assert.Null(model.ExpiresAfter);
        Assert.True(model.RawData.ContainsKey("expires_after"));
        Assert.Null(model.ExpiresAfterUnit);
        Assert.True(model.RawData.ContainsKey("expires_after_unit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataModel
        {
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",

            ExpiresAfter = null,
            ExpiresAfterUnit = null,
        };

        model.Validate();
    }
}
