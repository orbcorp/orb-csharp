using System;
using Orb.Models.LicenseTypes;

namespace Orb.Tests.Models.LicenseTypes;

public class LicenseTypeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseTypeCreateParams
        {
            GroupingKey = "grouping_key",
            Name = "name",
        };

        string expectedGroupingKey = "grouping_key";
        string expectedName = "name";

        Assert.Equal(expectedGroupingKey, parameters.GroupingKey);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        LicenseTypeCreateParams parameters = new() { GroupingKey = "grouping_key", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/license_types"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseTypeCreateParams
        {
            GroupingKey = "grouping_key",
            Name = "name",
        };

        LicenseTypeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
