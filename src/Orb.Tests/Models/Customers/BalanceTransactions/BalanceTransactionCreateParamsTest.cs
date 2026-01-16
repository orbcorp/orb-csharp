using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using BalanceTransactions = Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Models.Customers.BalanceTransactions;

public class BalanceTransactionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceTransactions::BalanceTransactionCreateParams
        {
            CustomerID = "customer_id",
            Amount = "amount",
            Type = BalanceTransactions::Type.Increment,
            Description = "description",
        };

        string expectedCustomerID = "customer_id";
        string expectedAmount = "amount";
        ApiEnum<string, BalanceTransactions::Type> expectedType =
            BalanceTransactions::Type.Increment;
        string expectedDescription = "description";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceTransactions::BalanceTransactionCreateParams
        {
            CustomerID = "customer_id",
            Amount = "amount",
            Type = BalanceTransactions::Type.Increment,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BalanceTransactions::BalanceTransactionCreateParams
        {
            CustomerID = "customer_id",
            Amount = "amount",
            Type = BalanceTransactions::Type.Increment,

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        BalanceTransactions::BalanceTransactionCreateParams parameters = new()
        {
            CustomerID = "customer_id",
            Amount = "amount",
            Type = BalanceTransactions::Type.Increment,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/customers/customer_id/balance_transactions"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BalanceTransactions::BalanceTransactionCreateParams
        {
            CustomerID = "customer_id",
            Amount = "amount",
            Type = BalanceTransactions::Type.Increment,
            Description = "description",
        };

        BalanceTransactions::BalanceTransactionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(BalanceTransactions::Type.Increment)]
    [InlineData(BalanceTransactions::Type.Decrement)]
    public void Validation_Works(BalanceTransactions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BalanceTransactions::Type.Increment)]
    [InlineData(BalanceTransactions::Type.Decrement)]
    public void SerializationRoundtrip_Works(BalanceTransactions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceTransactions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceTransactions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
