using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.CreditBlocks;
using Models = Orb.Models;

namespace Orb.Tests.Models.CreditBlocks;

public class CreditBlockListInvoicesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditBlockListInvoicesResponse
        {
            Block = new()
            {
                ID = "id",
                Balance = 0,
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = BlockFilterField.PriceID,
                        Operator = BlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = BlockStatus.Active,
            },
            Invoices =
            [
                new()
                {
                    ID = "id",
                    Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                    InvoiceNumber = "invoice_number",
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                },
            ],
        };

        Block expectedBlock = new()
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = BlockFilterField.PriceID,
                    Operator = BlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = BlockStatus.Active,
        };
        List<Invoice> expectedInvoices =
        [
            new()
            {
                ID = "id",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                InvoiceNumber = "invoice_number",
                Status = InvoiceStatus.Issued,
                Subscription = new("VDGsT23osdLb84KD"),
            },
        ];

        Assert.Equal(expectedBlock, model.Block);
        Assert.Equal(expectedInvoices.Count, model.Invoices.Count);
        for (int i = 0; i < expectedInvoices.Count; i++)
        {
            Assert.Equal(expectedInvoices[i], model.Invoices[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditBlockListInvoicesResponse
        {
            Block = new()
            {
                ID = "id",
                Balance = 0,
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = BlockFilterField.PriceID,
                        Operator = BlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = BlockStatus.Active,
            },
            Invoices =
            [
                new()
                {
                    ID = "id",
                    Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                    InvoiceNumber = "invoice_number",
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBlockListInvoicesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditBlockListInvoicesResponse
        {
            Block = new()
            {
                ID = "id",
                Balance = 0,
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = BlockFilterField.PriceID,
                        Operator = BlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = BlockStatus.Active,
            },
            Invoices =
            [
                new()
                {
                    ID = "id",
                    Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                    InvoiceNumber = "invoice_number",
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBlockListInvoicesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Block expectedBlock = new()
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = BlockFilterField.PriceID,
                    Operator = BlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = BlockStatus.Active,
        };
        List<Invoice> expectedInvoices =
        [
            new()
            {
                ID = "id",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                InvoiceNumber = "invoice_number",
                Status = InvoiceStatus.Issued,
                Subscription = new("VDGsT23osdLb84KD"),
            },
        ];

        Assert.Equal(expectedBlock, deserialized.Block);
        Assert.Equal(expectedInvoices.Count, deserialized.Invoices.Count);
        for (int i = 0; i < expectedInvoices.Count; i++)
        {
            Assert.Equal(expectedInvoices[i], deserialized.Invoices[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditBlockListInvoicesResponse
        {
            Block = new()
            {
                ID = "id",
                Balance = 0,
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = BlockFilterField.PriceID,
                        Operator = BlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = BlockStatus.Active,
            },
            Invoices =
            [
                new()
                {
                    ID = "id",
                    Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                    InvoiceNumber = "invoice_number",
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditBlockListInvoicesResponse
        {
            Block = new()
            {
                ID = "id",
                Balance = 0,
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = BlockFilterField.PriceID,
                        Operator = BlockFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = BlockStatus.Active,
            },
            Invoices =
            [
                new()
                {
                    ID = "id",
                    Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                    InvoiceNumber = "invoice_number",
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                },
            ],
        };

        CreditBlockListInvoicesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = BlockFilterField.PriceID,
                    Operator = BlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = BlockStatus.Active,
        };

        string expectedID = "id";
        double expectedBalance = 0;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BlockFilter> expectedFilters =
        [
            new()
            {
                Field = BlockFilterField.PriceID,
                Operator = BlockFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, BlockStatus> expectedStatus = BlockStatus.Active;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedMaximumInitialBalance, model.MaximumInitialBalance);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = BlockFilterField.PriceID,
                    Operator = BlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = BlockStatus.Active,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = BlockFilterField.PriceID,
                    Operator = BlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = BlockStatus.Active,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedBalance = 0;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BlockFilter> expectedFilters =
        [
            new()
            {
                Field = BlockFilterField.PriceID,
                Operator = BlockFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, BlockStatus> expectedStatus = BlockStatus.Active;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedMaximumInitialBalance, deserialized.MaximumInitialBalance);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPerUnitCostBasis, deserialized.PerUnitCostBasis);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = BlockFilterField.PriceID,
                    Operator = BlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = BlockStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = BlockFilterField.PriceID,
                    Operator = BlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = BlockStatus.Active,
        };

        Block copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BlockFilter
        {
            Field = BlockFilterField.PriceID,
            Operator = BlockFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, BlockFilterField> expectedField = BlockFilterField.PriceID;
        ApiEnum<string, BlockFilterOperator> expectedOperator = BlockFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BlockFilter
        {
            Field = BlockFilterField.PriceID,
            Operator = BlockFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BlockFilter
        {
            Field = BlockFilterField.PriceID,
            Operator = BlockFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BlockFilterField> expectedField = BlockFilterField.PriceID;
        ApiEnum<string, BlockFilterOperator> expectedOperator = BlockFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BlockFilter
        {
            Field = BlockFilterField.PriceID,
            Operator = BlockFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BlockFilter
        {
            Field = BlockFilterField.PriceID,
            Operator = BlockFilterOperator.Includes,
            Values = ["string"],
        };

        BlockFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(BlockFilterField.PriceID)]
    [InlineData(BlockFilterField.ItemID)]
    [InlineData(BlockFilterField.PriceType)]
    [InlineData(BlockFilterField.Currency)]
    [InlineData(BlockFilterField.PricingUnitID)]
    public void Validation_Works(BlockFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockFilterField.PriceID)]
    [InlineData(BlockFilterField.ItemID)]
    [InlineData(BlockFilterField.PriceType)]
    [InlineData(BlockFilterField.Currency)]
    [InlineData(BlockFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(BlockFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BlockFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(BlockFilterOperator.Includes)]
    [InlineData(BlockFilterOperator.Excludes)]
    public void Validation_Works(BlockFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockFilterOperator.Includes)]
    [InlineData(BlockFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(BlockFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BlockStatusTest : TestBase
{
    [Theory]
    [InlineData(BlockStatus.Active)]
    [InlineData(BlockStatus.PendingPayment)]
    public void Validation_Works(BlockStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockStatus.Active)]
    [InlineData(BlockStatus.PendingPayment)]
    public void SerializationRoundtrip_Works(BlockStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoice
        {
            ID = "id",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceNumber = "invoice_number",
            Status = InvoiceStatus.Issued,
            Subscription = new("VDGsT23osdLb84KD"),
        };

        string expectedID = "id";
        Models::CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        string expectedInvoiceNumber = "invoice_number";
        ApiEnum<string, InvoiceStatus> expectedStatus = InvoiceStatus.Issued;
        Models::SubscriptionMinified expectedSubscription = new("VDGsT23osdLb84KD");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedInvoiceNumber, model.InvoiceNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscription, model.Subscription);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoice
        {
            ID = "id",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceNumber = "invoice_number",
            Status = InvoiceStatus.Issued,
            Subscription = new("VDGsT23osdLb84KD"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoice
        {
            ID = "id",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceNumber = "invoice_number",
            Status = InvoiceStatus.Issued,
            Subscription = new("VDGsT23osdLb84KD"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Models::CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        string expectedInvoiceNumber = "invoice_number";
        ApiEnum<string, InvoiceStatus> expectedStatus = InvoiceStatus.Issued;
        Models::SubscriptionMinified expectedSubscription = new("VDGsT23osdLb84KD");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedInvoiceNumber, deserialized.InvoiceNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoice
        {
            ID = "id",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceNumber = "invoice_number",
            Status = InvoiceStatus.Issued,
            Subscription = new("VDGsT23osdLb84KD"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice
        {
            ID = "id",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceNumber = "invoice_number",
            Status = InvoiceStatus.Issued,
            Subscription = new("VDGsT23osdLb84KD"),
        };

        Invoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(InvoiceStatus.Issued)]
    [InlineData(InvoiceStatus.Paid)]
    [InlineData(InvoiceStatus.Synced)]
    [InlineData(InvoiceStatus.Void)]
    [InlineData(InvoiceStatus.Draft)]
    public void Validation_Works(InvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoiceStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceStatus.Issued)]
    [InlineData(InvoiceStatus.Paid)]
    [InlineData(InvoiceStatus.Synced)]
    [InlineData(InvoiceStatus.Void)]
    [InlineData(InvoiceStatus.Draft)]
    public void SerializationRoundtrip_Works(InvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvoiceStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoiceStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvoiceStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
