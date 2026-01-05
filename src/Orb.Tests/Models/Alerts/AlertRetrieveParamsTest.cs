using System;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlertRetrieveParams { AlertID = "alert_id" };

        string expectedAlertID = "alert_id";

        Assert.Equal(expectedAlertID, parameters.AlertID);
    }

    [Fact]
    public void Url_Works()
    {
        AlertRetrieveParams parameters = new() { AlertID = "alert_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/alerts/alert_id"), url);
    }
}
