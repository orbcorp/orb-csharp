using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Invoices = Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Invoices::InvoiceCreateParams
        {
            Currency = "USD",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    EndDate = "2023-09-22",
                    ItemID = "4khy3nwzktxv7",
                    ModelType = Invoices::ModelType.Unit,
                    Name = "Line Item Name",
                    Quantity = 1,
                    StartDate = "2023-09-22",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                },
            ],
            CustomerID = "4khy3nwzktxv7",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            DueDate = "2023-09-22",
            ExternalCustomerID = "external-customer-id",
            Memo = "An optional memo for my invoice.",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            NetTerms = 0,
            WillAutoIssue = false,
        };

        string expectedCurrency = "USD";
        DateTimeOffset expectedInvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Invoices::LineItem> expectedLineItems =
        [
            new()
            {
                EndDate = "2023-09-22",
                ItemID = "4khy3nwzktxv7",
                ModelType = Invoices::ModelType.Unit,
                Name = "Line Item Name",
                Quantity = 1,
                StartDate = "2023-09-22",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            },
        ];
        string expectedCustomerID = "4khy3nwzktxv7";
        SharedDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        Invoices::DueDate expectedDueDate = "2023-09-22";
        string expectedExternalCustomerID = "external-customer-id";
        string expectedMemo = "An optional memo for my invoice.";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        long expectedNetTerms = 0;
        bool expectedWillAutoIssue = false;

        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedInvoiceDate, parameters.InvoiceDate);
        Assert.Equal(expectedLineItems.Count, parameters.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], parameters.LineItems[i]);
        }
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedDiscount, parameters.Discount);
        Assert.Equal(expectedDueDate, parameters.DueDate);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedMemo, parameters.Memo);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedNetTerms, parameters.NetTerms);
        Assert.Equal(expectedWillAutoIssue, parameters.WillAutoIssue);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Invoices::InvoiceCreateParams
        {
            Currency = "USD",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    EndDate = "2023-09-22",
                    ItemID = "4khy3nwzktxv7",
                    ModelType = Invoices::ModelType.Unit,
                    Name = "Line Item Name",
                    Quantity = 1,
                    StartDate = "2023-09-22",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                },
            ],
            CustomerID = "4khy3nwzktxv7",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            DueDate = "2023-09-22",
            ExternalCustomerID = "external-customer-id",
            Memo = "An optional memo for my invoice.",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            NetTerms = 0,
        };

        Assert.Null(parameters.WillAutoIssue);
        Assert.False(parameters.RawBodyData.ContainsKey("will_auto_issue"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Invoices::InvoiceCreateParams
        {
            Currency = "USD",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    EndDate = "2023-09-22",
                    ItemID = "4khy3nwzktxv7",
                    ModelType = Invoices::ModelType.Unit,
                    Name = "Line Item Name",
                    Quantity = 1,
                    StartDate = "2023-09-22",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                },
            ],
            CustomerID = "4khy3nwzktxv7",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            DueDate = "2023-09-22",
            ExternalCustomerID = "external-customer-id",
            Memo = "An optional memo for my invoice.",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            NetTerms = 0,

            // Null should be interpreted as omitted for these properties
            WillAutoIssue = null,
        };

        Assert.Null(parameters.WillAutoIssue);
        Assert.False(parameters.RawBodyData.ContainsKey("will_auto_issue"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Invoices::InvoiceCreateParams
        {
            Currency = "USD",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    EndDate = "2023-09-22",
                    ItemID = "4khy3nwzktxv7",
                    ModelType = Invoices::ModelType.Unit,
                    Name = "Line Item Name",
                    Quantity = 1,
                    StartDate = "2023-09-22",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                },
            ],
            WillAutoIssue = false,
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.Discount);
        Assert.False(parameters.RawBodyData.ContainsKey("discount"));
        Assert.Null(parameters.DueDate);
        Assert.False(parameters.RawBodyData.ContainsKey("due_date"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NetTerms);
        Assert.False(parameters.RawBodyData.ContainsKey("net_terms"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Invoices::InvoiceCreateParams
        {
            Currency = "USD",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    EndDate = "2023-09-22",
                    ItemID = "4khy3nwzktxv7",
                    ModelType = Invoices::ModelType.Unit,
                    Name = "Line Item Name",
                    Quantity = 1,
                    StartDate = "2023-09-22",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                },
            ],
            WillAutoIssue = false,

            CustomerID = null,
            Discount = null,
            DueDate = null,
            ExternalCustomerID = null,
            Memo = null,
            Metadata = null,
            NetTerms = null,
        };

        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.Discount);
        Assert.True(parameters.RawBodyData.ContainsKey("discount"));
        Assert.Null(parameters.DueDate);
        Assert.True(parameters.RawBodyData.ContainsKey("due_date"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.Memo);
        Assert.True(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NetTerms);
        Assert.True(parameters.RawBodyData.ContainsKey("net_terms"));
    }

    [Fact]
    public void Url_Works()
    {
        Invoices::InvoiceCreateParams parameters = new()
        {
            Currency = "USD",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    EndDate = "2023-09-22",
                    ItemID = "4khy3nwzktxv7",
                    ModelType = Invoices::ModelType.Unit,
                    Name = "Line Item Name",
                    Quantity = 1,
                    StartDate = "2023-09-22",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/invoices"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Invoices::InvoiceCreateParams
        {
            Currency = "USD",
            InvoiceDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    EndDate = "2023-09-22",
                    ItemID = "4khy3nwzktxv7",
                    ModelType = Invoices::ModelType.Unit,
                    Name = "Line Item Name",
                    Quantity = 1,
                    StartDate = "2023-09-22",
                    UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                },
            ],
            CustomerID = "4khy3nwzktxv7",
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            },
            DueDate = "2023-09-22",
            ExternalCustomerID = "external-customer-id",
            Memo = "An optional memo for my invoice.",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            NetTerms = 0,
            WillAutoIssue = false,
        };

        Invoices::InvoiceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class LineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::LineItem
        {
            EndDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            ModelType = Invoices::ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate = "2023-09-22",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        string expectedEndDate = "2023-09-22";
        string expectedItemID = "4khy3nwzktxv7";
        ApiEnum<string, Invoices::ModelType> expectedModelType = Invoices::ModelType.Unit;
        string expectedName = "Line Item Name";
        double expectedQuantity = 1;
        string expectedStartDate = "2023-09-22";
        UnitConfig expectedUnitConfig = new() { UnitAmount = "unit_amount", Prorated = true };

        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedUnitConfig, model.UnitConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::LineItem
        {
            EndDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            ModelType = Invoices::ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate = "2023-09-22",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::LineItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::LineItem
        {
            EndDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            ModelType = Invoices::ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate = "2023-09-22",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::LineItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEndDate = "2023-09-22";
        string expectedItemID = "4khy3nwzktxv7";
        ApiEnum<string, Invoices::ModelType> expectedModelType = Invoices::ModelType.Unit;
        string expectedName = "Line Item Name";
        double expectedQuantity = 1;
        string expectedStartDate = "2023-09-22";
        UnitConfig expectedUnitConfig = new() { UnitAmount = "unit_amount", Prorated = true };

        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedModelType, deserialized.ModelType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedUnitConfig, deserialized.UnitConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::LineItem
        {
            EndDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            ModelType = Invoices::ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate = "2023-09-22",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        model.Validate();
    }
}

public class ModelTypeTest : TestBase
{
    [Theory]
    [InlineData(Invoices::ModelType.Unit)]
    public void Validation_Works(Invoices::ModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::ModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::ModelType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::ModelType.Unit)]
    public void SerializationRoundtrip_Works(Invoices::ModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::ModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::ModelType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::ModelType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::ModelType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DueDateTest : TestBase
{
    [Fact]
    public void DateValidationWorks()
    {
        Invoices::DueDate value = "2019-12-27";
        value.Validate();
    }

    [Fact]
    public void DateTimeValidationWorks()
    {
        Invoices::DueDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DateSerializationRoundtripWorks()
    {
        Invoices::DueDate value = "2019-12-27";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::DueDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Invoices::DueDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::DueDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
