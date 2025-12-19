using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class TopUpCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopUpCreateParams
        {
            CustomerID = "customer_id",
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
            ActiveFrom = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAfter = 0,
            ExpiresAfterUnit = ExpiresAfterUnit.Day,
        };

        string expectedCustomerID = "customer_id";
        string expectedAmount = "amount";
        string expectedCurrency = "currency";
        InvoiceSettings expectedInvoiceSettings = new()
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        string expectedThreshold = "threshold";
        DateTimeOffset expectedActiveFrom = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedExpiresAfter = 0;
        ApiEnum<string, ExpiresAfterUnit> expectedExpiresAfterUnit = ExpiresAfterUnit.Day;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedInvoiceSettings, parameters.InvoiceSettings);
        Assert.Equal(expectedPerUnitCostBasis, parameters.PerUnitCostBasis);
        Assert.Equal(expectedThreshold, parameters.Threshold);
        Assert.Equal(expectedActiveFrom, parameters.ActiveFrom);
        Assert.Equal(expectedExpiresAfter, parameters.ExpiresAfter);
        Assert.Equal(expectedExpiresAfterUnit, parameters.ExpiresAfterUnit);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TopUpCreateParams
        {
            CustomerID = "customer_id",
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

        Assert.Null(parameters.ActiveFrom);
        Assert.False(parameters.RawBodyData.ContainsKey("active_from"));
        Assert.Null(parameters.ExpiresAfter);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_after"));
        Assert.Null(parameters.ExpiresAfterUnit);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_after_unit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TopUpCreateParams
        {
            CustomerID = "customer_id",
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

            ActiveFrom = null,
            ExpiresAfter = null,
            ExpiresAfterUnit = null,
        };

        Assert.Null(parameters.ActiveFrom);
        Assert.False(parameters.RawBodyData.ContainsKey("active_from"));
        Assert.Null(parameters.ExpiresAfter);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_after"));
        Assert.Null(parameters.ExpiresAfterUnit);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_after_unit"));
    }
}

public class InvoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };

        bool expectedAutoCollection = true;
        long expectedNetTerms = 0;
        string expectedMemo = "memo";
        bool expectedRequireSuccessfulPayment = true;

        Assert.Equal(expectedAutoCollection, model.AutoCollection);
        Assert.Equal(expectedNetTerms, model.NetTerms);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedRequireSuccessfulPayment, model.RequireSuccessfulPayment);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InvoiceSettings>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InvoiceSettings>(element);
        Assert.NotNull(deserialized);

        bool expectedAutoCollection = true;
        long expectedNetTerms = 0;
        string expectedMemo = "memo";
        bool expectedRequireSuccessfulPayment = true;

        Assert.Equal(expectedAutoCollection, deserialized.AutoCollection);
        Assert.Equal(expectedNetTerms, deserialized.NetTerms);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedRequireSuccessfulPayment, deserialized.RequireSuccessfulPayment);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
        };

        Assert.Null(model.RequireSuccessfulPayment);
        Assert.False(model.RawData.ContainsKey("require_successful_payment"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",

            // Null should be interpreted as omitted for these properties
            RequireSuccessfulPayment = null,
        };

        Assert.Null(model.RequireSuccessfulPayment);
        Assert.False(model.RawData.ContainsKey("require_successful_payment"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",

            // Null should be interpreted as omitted for these properties
            RequireSuccessfulPayment = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            RequireSuccessfulPayment = true,
        };

        Assert.Null(model.Memo);
        Assert.False(model.RawData.ContainsKey("memo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            RequireSuccessfulPayment = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            RequireSuccessfulPayment = true,

            Memo = null,
        };

        Assert.Null(model.Memo);
        Assert.True(model.RawData.ContainsKey("memo"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            RequireSuccessfulPayment = true,

            Memo = null,
        };

        model.Validate();
    }
}

public class ExpiresAfterUnitTest : TestBase
{
    [Theory]
    [InlineData(ExpiresAfterUnit.Day)]
    [InlineData(ExpiresAfterUnit.Month)]
    public void Validation_Works(ExpiresAfterUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExpiresAfterUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExpiresAfterUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExpiresAfterUnit.Day)]
    [InlineData(ExpiresAfterUnit.Month)]
    public void SerializationRoundtrip_Works(ExpiresAfterUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExpiresAfterUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExpiresAfterUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExpiresAfterUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExpiresAfterUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
