using System;
using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventDeprecateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventDeprecateParams { EventID = "event_id" };

        string expectedEventID = "event_id";

        Assert.Equal(expectedEventID, parameters.EventID);
    }

    [Fact]
    public void Url_Works()
    {
        EventDeprecateParams parameters = new() { EventID = "event_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/events/event_id/deprecate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventDeprecateParams { EventID = "event_id" };

        EventDeprecateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
