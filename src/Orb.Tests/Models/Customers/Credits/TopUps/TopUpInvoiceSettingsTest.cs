using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class TopUpInvoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUpInvoiceSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUpInvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUpInvoiceSettings>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
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
        var model = new TopUpInvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            RequireSuccessfulPayment = true,

            Memo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopUpInvoiceSettings
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };

        TopUpInvoiceSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}
