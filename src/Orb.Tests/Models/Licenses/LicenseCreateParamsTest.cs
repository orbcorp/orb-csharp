using System;
using Orb.Models.Licenses;

namespace Orb.Tests.Models.Licenses;

public class LicenseCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseCreateParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            EndDate = "2026-01-27",
            StartDate = "2026-01-27",
        };

        string expectedExternalLicenseID = "external_license_id";
        string expectedLicenseTypeID = "license_type_id";
        string expectedSubscriptionID = "subscription_id";
        string expectedEndDate = "2026-01-27";
        string expectedStartDate = "2026-01-27";

        Assert.Equal(expectedExternalLicenseID, parameters.ExternalLicenseID);
        Assert.Equal(expectedLicenseTypeID, parameters.LicenseTypeID);
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedStartDate, parameters.StartDate);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseCreateParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
        };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("end_date"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LicenseCreateParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",

            EndDate = null,
            StartDate = null,
        };

        Assert.Null(parameters.EndDate);
        Assert.True(parameters.RawBodyData.ContainsKey("end_date"));
        Assert.Null(parameters.StartDate);
        Assert.True(parameters.RawBodyData.ContainsKey("start_date"));
    }

    [Fact]
    public void Url_Works()
    {
        LicenseCreateParams parameters = new()
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.withorb.com/v1/licenses"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseCreateParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            EndDate = "2026-01-27",
            StartDate = "2026-01-27",
        };

        LicenseCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
