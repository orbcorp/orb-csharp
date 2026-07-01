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
                CreditBlockSource = BlockCreditBlockSource.Allocation,
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
                CreditAllocation = new()
                {
                    AllowsRollover = true,
                    Currency = "currency",
                    CustomExpiration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::CustomExpirationDurationUnit.Day,
                    },
                    ItemID = "item_id",
                    Filters =
                    [
                        new()
                        {
                            Field = BlockCreditAllocationFilterField.PriceID,
                            Operator = BlockCreditAllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
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
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = BlockCreditAllocationFilterField.PriceID,
                        Operator = BlockCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
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
                CreditBlockSource = BlockCreditBlockSource.Allocation,
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
                CreditAllocation = new()
                {
                    AllowsRollover = true,
                    Currency = "currency",
                    CustomExpiration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::CustomExpirationDurationUnit.Day,
                    },
                    ItemID = "item_id",
                    Filters =
                    [
                        new()
                        {
                            Field = BlockCreditAllocationFilterField.PriceID,
                            Operator = BlockCreditAllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
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
                CreditBlockSource = BlockCreditBlockSource.Allocation,
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
                CreditAllocation = new()
                {
                    AllowsRollover = true,
                    Currency = "currency",
                    CustomExpiration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::CustomExpirationDurationUnit.Day,
                    },
                    ItemID = "item_id",
                    Filters =
                    [
                        new()
                        {
                            Field = BlockCreditAllocationFilterField.PriceID,
                            Operator = BlockCreditAllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
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
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = BlockCreditAllocationFilterField.PriceID,
                        Operator = BlockCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
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
                CreditBlockSource = BlockCreditBlockSource.Allocation,
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
                CreditAllocation = new()
                {
                    AllowsRollover = true,
                    Currency = "currency",
                    CustomExpiration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::CustomExpirationDurationUnit.Day,
                    },
                    ItemID = "item_id",
                    Filters =
                    [
                        new()
                        {
                            Field = BlockCreditAllocationFilterField.PriceID,
                            Operator = BlockCreditAllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
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
                CreditBlockSource = BlockCreditBlockSource.Allocation,
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
                CreditAllocation = new()
                {
                    AllowsRollover = true,
                    Currency = "currency",
                    CustomExpiration = new()
                    {
                        Duration = 0,
                        DurationUnit = Models::CustomExpirationDurationUnit.Day,
                    },
                    ItemID = "item_id",
                    Filters =
                    [
                        new()
                        {
                            Field = BlockCreditAllocationFilterField.PriceID,
                            Operator = BlockCreditAllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
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
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = BlockCreditAllocationFilterField.PriceID,
                        Operator = BlockCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        string expectedID = "id";
        double expectedBalance = 0;
        ApiEnum<string, BlockCreditBlockSource> expectedCreditBlockSource =
            BlockCreditBlockSource.Allocation;
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
        BlockCreditAllocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedCreditBlockSource, model.CreditBlockSource);
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
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = BlockCreditAllocationFilterField.PriceID,
                        Operator = BlockCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
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
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = BlockCreditAllocationFilterField.PriceID,
                        Operator = BlockCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedBalance = 0;
        ApiEnum<string, BlockCreditBlockSource> expectedCreditBlockSource =
            BlockCreditBlockSource.Allocation;
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
        BlockCreditAllocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedCreditBlockSource, deserialized.CreditBlockSource);
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
        Assert.Equal(expectedCreditAllocation, deserialized.CreditAllocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = BlockCreditAllocationFilterField.PriceID,
                        Operator = BlockCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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

        Assert.Null(model.CreditAllocation);
        Assert.False(model.RawData.ContainsKey("credit_allocation"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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

            CreditAllocation = null,
        };

        Assert.Null(model.CreditAllocation);
        Assert.True(model.RawData.ContainsKey("credit_allocation"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Block
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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

            CreditAllocation = null,
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
            CreditBlockSource = BlockCreditBlockSource.Allocation,
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
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = BlockCreditAllocationFilterField.PriceID,
                        Operator = BlockCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        Block copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockCreditBlockSourceTest : TestBase
{
    [Theory]
    [InlineData(BlockCreditBlockSource.Allocation)]
    [InlineData(BlockCreditBlockSource.TopUp)]
    [InlineData(BlockCreditBlockSource.Manual)]
    public void Validation_Works(BlockCreditBlockSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockCreditBlockSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockCreditBlockSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockCreditBlockSource.Allocation)]
    [InlineData(BlockCreditBlockSource.TopUp)]
    [InlineData(BlockCreditBlockSource.Manual)]
    public void SerializationRoundtrip_Works(BlockCreditBlockSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockCreditBlockSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockCreditBlockSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockCreditBlockSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockCreditBlockSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

public class BlockCreditAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        bool expectedAllowsRollover = true;
        string expectedCurrency = "currency";
        Models::CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = Models::CustomExpirationDurationUnit.Day,
        };
        string expectedItemID = "item_id";
        List<BlockCreditAllocationFilter> expectedFilters =
        [
            new()
            {
                Field = BlockCreditAllocationFilterField.PriceID,
                Operator = BlockCreditAllocationFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedLicenseTypeID = "license_type_id";

        Assert.Equal(expectedAllowsRollover, model.AllowsRollover);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomExpiration, model.CustomExpiration);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedLicenseTypeID, model.LicenseTypeID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockCreditAllocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockCreditAllocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAllowsRollover = true;
        string expectedCurrency = "currency";
        Models::CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = Models::CustomExpirationDurationUnit.Day,
        };
        string expectedItemID = "item_id";
        List<BlockCreditAllocationFilter> expectedFilters =
        [
            new()
            {
                Field = BlockCreditAllocationFilterField.PriceID,
                Operator = BlockCreditAllocationFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedLicenseTypeID = "license_type_id";

        Assert.Equal(expectedAllowsRollover, deserialized.AllowsRollover);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomExpiration, deserialized.CustomExpiration);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedLicenseTypeID, deserialized.LicenseTypeID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
        };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",

            // Null should be interpreted as omitted for these properties
            Filters = null,
        };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",

            // Null should be interpreted as omitted for these properties
            Filters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
        };

        Assert.Null(model.LicenseTypeID);
        Assert.False(model.RawData.ContainsKey("license_type_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],

            LicenseTypeID = null,
        };

        Assert.Null(model.LicenseTypeID);
        Assert.True(model.RawData.ContainsKey("license_type_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],

            LicenseTypeID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BlockCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = BlockCreditAllocationFilterField.PriceID,
                    Operator = BlockCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        BlockCreditAllocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockCreditAllocationFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BlockCreditAllocationFilter
        {
            Field = BlockCreditAllocationFilterField.PriceID,
            Operator = BlockCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, BlockCreditAllocationFilterField> expectedField =
            BlockCreditAllocationFilterField.PriceID;
        ApiEnum<string, BlockCreditAllocationFilterOperator> expectedOperator =
            BlockCreditAllocationFilterOperator.Includes;
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
        var model = new BlockCreditAllocationFilter
        {
            Field = BlockCreditAllocationFilterField.PriceID,
            Operator = BlockCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockCreditAllocationFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BlockCreditAllocationFilter
        {
            Field = BlockCreditAllocationFilterField.PriceID,
            Operator = BlockCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BlockCreditAllocationFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BlockCreditAllocationFilterField> expectedField =
            BlockCreditAllocationFilterField.PriceID;
        ApiEnum<string, BlockCreditAllocationFilterOperator> expectedOperator =
            BlockCreditAllocationFilterOperator.Includes;
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
        var model = new BlockCreditAllocationFilter
        {
            Field = BlockCreditAllocationFilterField.PriceID,
            Operator = BlockCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BlockCreditAllocationFilter
        {
            Field = BlockCreditAllocationFilterField.PriceID,
            Operator = BlockCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        BlockCreditAllocationFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockCreditAllocationFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(BlockCreditAllocationFilterField.PriceID)]
    [InlineData(BlockCreditAllocationFilterField.ItemID)]
    [InlineData(BlockCreditAllocationFilterField.PriceType)]
    [InlineData(BlockCreditAllocationFilterField.Currency)]
    [InlineData(BlockCreditAllocationFilterField.PricingUnitID)]
    public void Validation_Works(BlockCreditAllocationFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockCreditAllocationFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockCreditAllocationFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockCreditAllocationFilterField.PriceID)]
    [InlineData(BlockCreditAllocationFilterField.ItemID)]
    [InlineData(BlockCreditAllocationFilterField.PriceType)]
    [InlineData(BlockCreditAllocationFilterField.Currency)]
    [InlineData(BlockCreditAllocationFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(BlockCreditAllocationFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockCreditAllocationFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BlockCreditAllocationFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockCreditAllocationFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BlockCreditAllocationFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BlockCreditAllocationFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(BlockCreditAllocationFilterOperator.Includes)]
    [InlineData(BlockCreditAllocationFilterOperator.Excludes)]
    public void Validation_Works(BlockCreditAllocationFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockCreditAllocationFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BlockCreditAllocationFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockCreditAllocationFilterOperator.Includes)]
    [InlineData(BlockCreditAllocationFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(BlockCreditAllocationFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockCreditAllocationFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BlockCreditAllocationFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BlockCreditAllocationFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BlockCreditAllocationFilterOperator>
        >(json, ModelBase.SerializerOptions);

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
