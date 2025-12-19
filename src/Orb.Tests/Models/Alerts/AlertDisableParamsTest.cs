using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertDisableParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlertDisableParams
        {
            AlertConfigurationID = "alert_configuration_id",
            SubscriptionID = "subscription_id",
        };

        string expectedAlertConfigurationID = "alert_configuration_id";
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedAlertConfigurationID, parameters.AlertConfigurationID);
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AlertDisableParams { AlertConfigurationID = "alert_configuration_id" };

        Assert.Null(parameters.SubscriptionID);
        Assert.False(parameters.RawQueryData.ContainsKey("subscription_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AlertDisableParams
        {
            AlertConfigurationID = "alert_configuration_id",

            SubscriptionID = null,
        };

        Assert.Null(parameters.SubscriptionID);
        Assert.False(parameters.RawQueryData.ContainsKey("subscription_id"));
    }
}
