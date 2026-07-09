using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class TaxAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxAmount
        {
            Amount = "amount",
            TaxRateDescription = "tax_rate_description",
            TaxRatePercentage = "tax_rate_percentage",
        };

        string expectedAmount = "amount";
        string expectedTaxRateDescription = "tax_rate_description";
        string expectedTaxRatePercentage = "tax_rate_percentage";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedTaxRateDescription, model.TaxRateDescription);
        Assert.Equal(expectedTaxRatePercentage, model.TaxRatePercentage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TaxAmount
        {
            Amount = "amount",
            TaxRateDescription = "tax_rate_description",
            TaxRatePercentage = "tax_rate_percentage",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxAmount>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TaxAmount
        {
            Amount = "amount",
            TaxRateDescription = "tax_rate_description",
            TaxRatePercentage = "tax_rate_percentage",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "amount";
        string expectedTaxRateDescription = "tax_rate_description";
        string expectedTaxRatePercentage = "tax_rate_percentage";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedTaxRateDescription, deserialized.TaxRateDescription);
        Assert.Equal(expectedTaxRatePercentage, deserialized.TaxRatePercentage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TaxAmount
        {
            Amount = "amount",
            TaxRateDescription = "tax_rate_description",
            TaxRatePercentage = "tax_rate_percentage",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TaxAmount
        {
            Amount = "amount",
            TaxRateDescription = "tax_rate_description",
            TaxRatePercentage = "tax_rate_percentage",
        };

        TaxAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}
