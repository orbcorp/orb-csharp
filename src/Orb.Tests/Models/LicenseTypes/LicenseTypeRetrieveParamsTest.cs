using System;
using Orb.Models.LicenseTypes;

namespace Orb.Tests.Models.LicenseTypes;

public class LicenseTypeRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseTypeRetrieveParams { LicenseTypeID = "license_type_id" };

        string expectedLicenseTypeID = "license_type_id";

        Assert.Equal(expectedLicenseTypeID, parameters.LicenseTypeID);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseTypeRetrieveParams parameters = new() { LicenseTypeID = "license_type_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/license_types/license_type_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseTypeRetrieveParams { LicenseTypeID = "license_type_id" };

        LicenseTypeRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
