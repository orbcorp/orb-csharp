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
}
