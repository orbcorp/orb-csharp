using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceListParams
        {
            Amount = "amount",
            AmountGt = "amount[gt]",
            AmountLt = "amount[lt]",
            Cursor = "cursor",
            CustomerID = "customer_id",
            DateType = DateType.DueDate,
            DueDate = "2019-12-27",
            DueDateWindow = "due_date_window",
            DueDateGt = "2019-12-27",
            DueDateLt = "2019-12-27",
            ExternalCustomerID = "external_customer_id",
            InvoiceDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsRecurring = true,
            Limit = 1,
            Status = [Status.Draft],
            SubscriptionID = "subscription_id",
        };

        string expectedAmount = "amount";
        string expectedAmountGt = "amount[gt]";
        string expectedAmountLt = "amount[lt]";
        string expectedCursor = "cursor";
        string expectedCustomerID = "customer_id";
        ApiEnum<string, DateType> expectedDateType = DateType.DueDate;
        string expectedDueDate = "2019-12-27";
        string expectedDueDateWindow = "due_date_window";
        string expectedDueDateGt = "2019-12-27";
        string expectedDueDateLt = "2019-12-27";
        string expectedExternalCustomerID = "external_customer_id";
        DateTimeOffset expectedInvoiceDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedInvoiceDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedInvoiceDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedInvoiceDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsRecurring = true;
        long expectedLimit = 1;
        List<ApiEnum<string, Status>> expectedStatus = [Status.Draft];
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedAmountGt, parameters.AmountGt);
        Assert.Equal(expectedAmountLt, parameters.AmountLt);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedDateType, parameters.DateType);
        Assert.Equal(expectedDueDate, parameters.DueDate);
        Assert.Equal(expectedDueDateWindow, parameters.DueDateWindow);
        Assert.Equal(expectedDueDateGt, parameters.DueDateGt);
        Assert.Equal(expectedDueDateLt, parameters.DueDateLt);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedInvoiceDateGt, parameters.InvoiceDateGt);
        Assert.Equal(expectedInvoiceDateGte, parameters.InvoiceDateGte);
        Assert.Equal(expectedInvoiceDateLt, parameters.InvoiceDateLt);
        Assert.Equal(expectedInvoiceDateLte, parameters.InvoiceDateLte);
        Assert.Equal(expectedIsRecurring, parameters.IsRecurring);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceListParams
        {
            Amount = "amount",
            AmountGt = "amount[gt]",
            AmountLt = "amount[lt]",
            Cursor = "cursor",
            CustomerID = "customer_id",
            DateType = DateType.DueDate,
            DueDate = "2019-12-27",
            DueDateWindow = "due_date_window",
            DueDateGt = "2019-12-27",
            DueDateLt = "2019-12-27",
            ExternalCustomerID = "external_customer_id",
            InvoiceDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsRecurring = true,
            Status = [Status.Draft],
            SubscriptionID = "subscription_id",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvoiceListParams
        {
            Amount = "amount",
            AmountGt = "amount[gt]",
            AmountLt = "amount[lt]",
            Cursor = "cursor",
            CustomerID = "customer_id",
            DateType = DateType.DueDate,
            DueDate = "2019-12-27",
            DueDateWindow = "due_date_window",
            DueDateGt = "2019-12-27",
            DueDateLt = "2019-12-27",
            ExternalCustomerID = "external_customer_id",
            InvoiceDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsRecurring = true,
            Status = [Status.Draft],
            SubscriptionID = "subscription_id",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceListParams { Limit = 1 };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawQueryData.ContainsKey("amount"));
        Assert.Null(parameters.AmountGt);
        Assert.False(parameters.RawQueryData.ContainsKey("amount[gt]"));
        Assert.Null(parameters.AmountLt);
        Assert.False(parameters.RawQueryData.ContainsKey("amount[lt]"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.DateType);
        Assert.False(parameters.RawQueryData.ContainsKey("date_type"));
        Assert.Null(parameters.DueDate);
        Assert.False(parameters.RawQueryData.ContainsKey("due_date"));
        Assert.Null(parameters.DueDateWindow);
        Assert.False(parameters.RawQueryData.ContainsKey("due_date_window"));
        Assert.Null(parameters.DueDateGt);
        Assert.False(parameters.RawQueryData.ContainsKey("due_date[gt]"));
        Assert.Null(parameters.DueDateLt);
        Assert.False(parameters.RawQueryData.ContainsKey("due_date[lt]"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.InvoiceDateGt);
        Assert.False(parameters.RawQueryData.ContainsKey("invoice_date[gt]"));
        Assert.Null(parameters.InvoiceDateGte);
        Assert.False(parameters.RawQueryData.ContainsKey("invoice_date[gte]"));
        Assert.Null(parameters.InvoiceDateLt);
        Assert.False(parameters.RawQueryData.ContainsKey("invoice_date[lt]"));
        Assert.Null(parameters.InvoiceDateLte);
        Assert.False(parameters.RawQueryData.ContainsKey("invoice_date[lte]"));
        Assert.Null(parameters.IsRecurring);
        Assert.False(parameters.RawQueryData.ContainsKey("is_recurring"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.SubscriptionID);
        Assert.False(parameters.RawQueryData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvoiceListParams
        {
            Limit = 1,

            Amount = null,
            AmountGt = null,
            AmountLt = null,
            Cursor = null,
            CustomerID = null,
            DateType = null,
            DueDate = null,
            DueDateWindow = null,
            DueDateGt = null,
            DueDateLt = null,
            ExternalCustomerID = null,
            InvoiceDateGt = null,
            InvoiceDateGte = null,
            InvoiceDateLt = null,
            InvoiceDateLte = null,
            IsRecurring = null,
            Status = null,
            SubscriptionID = null,
        };

        Assert.Null(parameters.Amount);
        Assert.True(parameters.RawQueryData.ContainsKey("amount"));
        Assert.Null(parameters.AmountGt);
        Assert.True(parameters.RawQueryData.ContainsKey("amount[gt]"));
        Assert.Null(parameters.AmountLt);
        Assert.True(parameters.RawQueryData.ContainsKey("amount[lt]"));
        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawQueryData.ContainsKey("customer_id"));
        Assert.Null(parameters.DateType);
        Assert.True(parameters.RawQueryData.ContainsKey("date_type"));
        Assert.Null(parameters.DueDate);
        Assert.True(parameters.RawQueryData.ContainsKey("due_date"));
        Assert.Null(parameters.DueDateWindow);
        Assert.True(parameters.RawQueryData.ContainsKey("due_date_window"));
        Assert.Null(parameters.DueDateGt);
        Assert.True(parameters.RawQueryData.ContainsKey("due_date[gt]"));
        Assert.Null(parameters.DueDateLt);
        Assert.True(parameters.RawQueryData.ContainsKey("due_date[lt]"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawQueryData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.InvoiceDateGt);
        Assert.True(parameters.RawQueryData.ContainsKey("invoice_date[gt]"));
        Assert.Null(parameters.InvoiceDateGte);
        Assert.True(parameters.RawQueryData.ContainsKey("invoice_date[gte]"));
        Assert.Null(parameters.InvoiceDateLt);
        Assert.True(parameters.RawQueryData.ContainsKey("invoice_date[lt]"));
        Assert.Null(parameters.InvoiceDateLte);
        Assert.True(parameters.RawQueryData.ContainsKey("invoice_date[lte]"));
        Assert.Null(parameters.IsRecurring);
        Assert.True(parameters.RawQueryData.ContainsKey("is_recurring"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.SubscriptionID);
        Assert.True(parameters.RawQueryData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceListParams parameters = new()
        {
            Amount = "amount",
            AmountGt = "amount[gt]",
            AmountLt = "amount[lt]",
            Cursor = "cursor",
            CustomerID = "customer_id",
            DateType = DateType.DueDate,
            DueDate = "2019-12-27",
            DueDateWindow = "due_date_window",
            DueDateGt = "2019-12-27",
            DueDateLt = "2019-12-27",
            ExternalCustomerID = "external_customer_id",
            InvoiceDateGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceDateLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsRecurring = true,
            Limit = 1,
            Status = [Status.Draft],
            SubscriptionID = "subscription_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/invoices?amount=amount&amount%5bgt%5d=amount%5bgt%5d&amount%5blt%5d=amount%5blt%5d&cursor=cursor&customer_id=customer_id&date_type=due_date&due_date=2019-12-27&due_date_window=due_date_window&due_date%5bgt%5d=2019-12-27&due_date%5blt%5d=2019-12-27&external_customer_id=external_customer_id&invoice_date%5bgt%5d=2019-12-27T18%3a11%3a19.117Z&invoice_date%5bgte%5d=2019-12-27T18%3a11%3a19.117Z&invoice_date%5blt%5d=2019-12-27T18%3a11%3a19.117Z&invoice_date%5blte%5d=2019-12-27T18%3a11%3a19.117Z&is_recurring=true&limit=1&status%5b%5d=draft&subscription_id=subscription_id"
            ),
            url
        );
    }
}

public class DateTypeTest : TestBase
{
    [Theory]
    [InlineData(DateType.DueDate)]
    [InlineData(DateType.InvoiceDate)]
    public void Validation_Works(DateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DateType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DateType.DueDate)]
    [InlineData(DateType.InvoiceDate)]
    public void SerializationRoundtrip_Works(DateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DateType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DateType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DateType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Issued)]
    [InlineData(Status.Paid)]
    [InlineData(Status.Synced)]
    [InlineData(Status.Void)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Issued)]
    [InlineData(Status.Paid)]
    [InlineData(Status.Synced)]
    [InlineData(Status.Void)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
