using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Models.Customers.BalanceTransactions;

public class BalanceTransactionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceTransactionCreateParams
        {
            CustomerID = "customer_id",
            Amount = "amount",
            Type = Type.Increment,
            Description = "description",
        };

        string expectedCustomerID = "customer_id";
        string expectedAmount = "amount";
        ApiEnum<string, Type> expectedType = Type.Increment;
        string expectedDescription = "description";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceTransactionCreateParams
        {
            CustomerID = "customer_id",
            Amount = "amount",
            Type = Type.Increment,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BalanceTransactionCreateParams
        {
            CustomerID = "customer_id",
            Amount = "amount",
            Type = Type.Increment,

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Increment)]
    [InlineData(Type.Decrement)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Increment)]
    [InlineData(Type.Decrement)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
