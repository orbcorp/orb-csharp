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
}
