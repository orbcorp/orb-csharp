using System;
using Orb.Models.Licenses.ExternalLicenses;

namespace Orb.Tests.Models.Licenses.ExternalLicenses;

public class ExternalLicenseGetUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalLicenseGetUsageParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = "group_by",
            Limit = 1,
            StartDate = "2019-12-27",
        };

        string expectedExternalLicenseID = "external_license_id";
        string expectedLicenseTypeID = "license_type_id";
        string expectedSubscriptionID = "subscription_id";
        string expectedCursor = "cursor";
        string expectedEndDate = "2019-12-27";
        string expectedGroupBy = "group_by";
        long expectedLimit = 1;
        string expectedStartDate = "2019-12-27";

        Assert.Equal(expectedExternalLicenseID, parameters.ExternalLicenseID);
        Assert.Equal(expectedLicenseTypeID, parameters.LicenseTypeID);
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedGroupBy, parameters.GroupBy);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStartDate, parameters.StartDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalLicenseGetUsageParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = "group_by",
            StartDate = "2019-12-27",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalLicenseGetUsageParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = "group_by",
            StartDate = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalLicenseGetUsageParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Limit = 1,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalLicenseGetUsageParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Limit = 1,

            Cursor = null,
            EndDate = null,
            GroupBy = null,
            StartDate = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EndDate);
        Assert.True(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.GroupBy);
        Assert.True(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.StartDate);
        Assert.True(parameters.RawQueryData.ContainsKey("start_date"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalLicenseGetUsageParams parameters = new()
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = "group_by",
            Limit = 1,
            StartDate = "2019-12-27",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.withorb.com/v1/licenses/external_licenses/external_license_id/usage?license_type_id=license_type_id&subscription_id=subscription_id&cursor=cursor&end_date=2019-12-27&group_by=group_by&limit=1&start_date=2019-12-27"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalLicenseGetUsageParams
        {
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = "group_by",
            Limit = 1,
            StartDate = "2019-12-27",
        };

        ExternalLicenseGetUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
