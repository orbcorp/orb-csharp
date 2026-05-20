using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class AccountingProviderConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderConfigProviderType.Quickbooks,
        };

        string expectedExternalProviderID = "external_provider_id";
        ApiEnum<string, AccountingProviderConfigProviderType> expectedProviderType =
            AccountingProviderConfigProviderType.Quickbooks;

        Assert.Equal(expectedExternalProviderID, model.ExternalProviderID);
        Assert.Equal(expectedProviderType, model.ProviderType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderConfigProviderType.Quickbooks,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountingProviderConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderConfigProviderType.Quickbooks,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountingProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExternalProviderID = "external_provider_id";
        ApiEnum<string, AccountingProviderConfigProviderType> expectedProviderType =
            AccountingProviderConfigProviderType.Quickbooks;

        Assert.Equal(expectedExternalProviderID, deserialized.ExternalProviderID);
        Assert.Equal(expectedProviderType, deserialized.ProviderType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderConfigProviderType.Quickbooks,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountingProviderConfig
        {
            ExternalProviderID = "external_provider_id",
            ProviderType = AccountingProviderConfigProviderType.Quickbooks,
        };

        AccountingProviderConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountingProviderConfigProviderTypeTest : TestBase
{
    [Theory]
    [InlineData(AccountingProviderConfigProviderType.Quickbooks)]
    [InlineData(AccountingProviderConfigProviderType.Netsuite)]
    public void Validation_Works(AccountingProviderConfigProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountingProviderConfigProviderType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountingProviderConfigProviderType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountingProviderConfigProviderType.Quickbooks)]
    [InlineData(AccountingProviderConfigProviderType.Netsuite)]
    public void SerializationRoundtrip_Works(AccountingProviderConfigProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountingProviderConfigProviderType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountingProviderConfigProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountingProviderConfigProviderType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountingProviderConfigProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
