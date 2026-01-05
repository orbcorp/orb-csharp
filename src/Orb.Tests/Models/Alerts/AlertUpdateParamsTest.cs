using System;
using System.Collections.Generic;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlertUpdateParams
        {
            AlertConfigurationID = "alert_configuration_id",
            Thresholds = [new(0)],
        };

        string expectedAlertConfigurationID = "alert_configuration_id";
        List<Threshold> expectedThresholds = [new(0)];

        Assert.Equal(expectedAlertConfigurationID, parameters.AlertConfigurationID);
        Assert.Equal(expectedThresholds.Count, parameters.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], parameters.Thresholds[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        AlertUpdateParams parameters = new()
        {
            AlertConfigurationID = "alert_configuration_id",
            Thresholds = [new(0)],
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/alerts/alert_configuration_id"), url);
    }
}
