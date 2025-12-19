using System.Collections.Generic;
using Orb.Models.Items;

namespace Orb.Tests.Models.Items;

public class ItemCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemCreateParams
        {
            Name = "API requests",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedName = "API requests";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ItemCreateParams { Name = "API requests" };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ItemCreateParams
        {
            Name = "API requests",

            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }
}
