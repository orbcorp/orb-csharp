using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class TopUpListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUpListResponse
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
            ExpiresAfterUnit = TopUpListResponseExpiresAfterUnit.Day,
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
        ApiEnum<string, TopUpListResponseExpiresAfterUnit> expectedExpiresAfterUnit =
            TopUpListResponseExpiresAfterUnit.Day;

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
        var model = new TopUpListResponse
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
            ExpiresAfterUnit = TopUpListResponseExpiresAfterUnit.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUpListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUpListResponse
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
            ExpiresAfterUnit = TopUpListResponseExpiresAfterUnit.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUpListResponse>(
            element,
            ModelBase.SerializerOptions
        );
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
        ApiEnum<string, TopUpListResponseExpiresAfterUnit> expectedExpiresAfterUnit =
            TopUpListResponseExpiresAfterUnit.Day;

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
        var model = new TopUpListResponse
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
            ExpiresAfterUnit = TopUpListResponseExpiresAfterUnit.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopUpListResponse
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
        var model = new TopUpListResponse
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
        var model = new TopUpListResponse
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
        var model = new TopUpListResponse
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopUpListResponse
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
            ExpiresAfterUnit = TopUpListResponseExpiresAfterUnit.Day,
        };

        TopUpListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopUpListResponseExpiresAfterUnitTest : TestBase
{
    [Theory]
    [InlineData(TopUpListResponseExpiresAfterUnit.Day)]
    [InlineData(TopUpListResponseExpiresAfterUnit.Month)]
    public void Validation_Works(TopUpListResponseExpiresAfterUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TopUpListResponseExpiresAfterUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TopUpListResponseExpiresAfterUnit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TopUpListResponseExpiresAfterUnit.Day)]
    [InlineData(TopUpListResponseExpiresAfterUnit.Month)]
    public void SerializationRoundtrip_Works(TopUpListResponseExpiresAfterUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TopUpListResponseExpiresAfterUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TopUpListResponseExpiresAfterUnit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TopUpListResponseExpiresAfterUnit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TopUpListResponseExpiresAfterUnit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
