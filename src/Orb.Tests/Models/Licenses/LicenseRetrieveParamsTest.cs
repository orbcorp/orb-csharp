using System;
using Orb.Models.Licenses;

namespace Orb.Tests.Models.Licenses;

public class LicenseRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseRetrieveParams { LicenseID = "license_id" };

        string expectedLicenseID = "license_id";

        Assert.Equal(expectedLicenseID, parameters.LicenseID);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseRetrieveParams parameters = new() { LicenseID = "license_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/licenses/license_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseRetrieveParams { LicenseID = "license_id" };

        LicenseRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
