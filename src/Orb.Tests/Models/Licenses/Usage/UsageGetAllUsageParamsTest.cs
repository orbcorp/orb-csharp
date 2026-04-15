using System;
using System.Collections.Generic;
using Orb.Models.Licenses.Usage;

namespace Orb.Tests.Models.Licenses.Usage;

public class UsageGetAllUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageGetAllUsageParams
        {
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = ["string"],
            Limit = 1,
            StartDate = "2019-12-27",
        };

        string expectedLicenseTypeID = "license_type_id";
        string expectedSubscriptionID = "subscription_id";
        string expectedCursor = "cursor";
        string expectedEndDate = "2019-12-27";
        List<string> expectedGroupBy = ["string"];
        long expectedLimit = 1;
        string expectedStartDate = "2019-12-27";

        Assert.Equal(expectedLicenseTypeID, parameters.LicenseTypeID);
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.NotNull(parameters.GroupBy);
        Assert.Equal(expectedGroupBy.Count, parameters.GroupBy.Count);
        for (int i = 0; i < expectedGroupBy.Count; i++)
        {
            Assert.Equal(expectedGroupBy[i], parameters.GroupBy[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStartDate, parameters.StartDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageGetAllUsageParams
        {
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = ["string"],
            StartDate = "2019-12-27",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UsageGetAllUsageParams
        {
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = ["string"],
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
        var parameters = new UsageGetAllUsageParams
        {
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
        var parameters = new UsageGetAllUsageParams
        {
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
        UsageGetAllUsageParams parameters = new()
        {
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = ["string"],
            Limit = 1,
            StartDate = "2019-12-27",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.withorb.com/v1/licenses/usage?license_type_id=license_type_id&subscription_id=subscription_id&cursor=cursor&end_date=2019-12-27&group_by%5b%5d=string&limit=1&start_date=2019-12-27"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageGetAllUsageParams
        {
            LicenseTypeID = "license_type_id",
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            EndDate = "2019-12-27",
            GroupBy = ["string"],
            Limit = 1,
            StartDate = "2019-12-27",
        };

        UsageGetAllUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
