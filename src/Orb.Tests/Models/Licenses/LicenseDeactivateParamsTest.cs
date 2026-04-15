using System;
using Orb.Models.Licenses;

namespace Orb.Tests.Models.Licenses;

public class LicenseDeactivateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseDeactivateParams
        {
            LicenseID = "license_id",
            EndDate = "2026-01-27",
        };

        string expectedLicenseID = "license_id";
        string expectedEndDate = "2026-01-27";

        Assert.Equal(expectedLicenseID, parameters.LicenseID);
        Assert.Equal(expectedEndDate, parameters.EndDate);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseDeactivateParams { LicenseID = "license_id" };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("end_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LicenseDeactivateParams
        {
            LicenseID = "license_id",

            EndDate = null,
        };

        Assert.Null(parameters.EndDate);
        Assert.True(parameters.RawBodyData.ContainsKey("end_date"));
    }

    [Fact]
    public void Url_Works()
    {
        LicenseDeactivateParams parameters = new() { LicenseID = "license_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.withorb.com/v1/licenses/license_id/deactivate"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseDeactivateParams
        {
            LicenseID = "license_id",
            EndDate = "2026-01-27",
        };

        LicenseDeactivateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
