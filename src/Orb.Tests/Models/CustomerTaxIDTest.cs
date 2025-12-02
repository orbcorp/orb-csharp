using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class CustomerTaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerTaxID
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        ApiEnum<string, Country> expectedCountry = Country.Ad;
        ApiEnum<string, CustomerTaxIDType> expectedType = CustomerTaxIDType.AdNrt;
        string expectedValue = "value";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerTaxID
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerTaxID>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerTaxID
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerTaxID>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Country> expectedCountry = Country.Ad;
        ApiEnum<string, CustomerTaxIDType> expectedType = CustomerTaxIDType.AdNrt;
        string expectedValue = "value";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerTaxID
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        model.Validate();
    }
}
