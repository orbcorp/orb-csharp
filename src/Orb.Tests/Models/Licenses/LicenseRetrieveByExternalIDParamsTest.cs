using System;
using Orb.Models.Licenses;

namespace Orb.Tests.Models.Licenses;

public class LicenseRetrieveByExternalIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseRetrieveByExternalIDParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
        };

        string expectedExternalLicenseID = "external_license_id";
        string expectedLicenseTypeID = "license_type_id";
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedExternalLicenseID, parameters.ExternalLicenseID);
        Assert.Equal(expectedLicenseTypeID, parameters.LicenseTypeID);
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseRetrieveByExternalIDParams parameters = new()
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/licenses/external_license_id/external_license_id?license_type_id=license_type_id&subscription_id=subscription_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseRetrieveByExternalIDParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
        };

        LicenseRetrieveByExternalIDParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
