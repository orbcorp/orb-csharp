using System;
using Orb.Models.LicenseTypes;

namespace Orb.Tests.Models.LicenseTypes;

public class LicenseTypeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseTypeListParams { Cursor = "cursor", Limit = 1 };

        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseTypeListParams { Cursor = "cursor" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LicenseTypeListParams
        {
            Cursor = "cursor",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseTypeListParams { Limit = 1 };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LicenseTypeListParams
        {
            Limit = 1,

            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        LicenseTypeListParams parameters = new() { Cursor = "cursor", Limit = 1 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.withorb.com/v1/license_types?cursor=cursor&limit=1"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseTypeListParams { Cursor = "cursor", Limit = 1 };

        LicenseTypeListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
