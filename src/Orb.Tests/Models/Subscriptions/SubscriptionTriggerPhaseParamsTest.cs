using System;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionTriggerPhaseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionTriggerPhaseParams
        {
            SubscriptionID = "subscription_id",
            AllowInvoiceCreditOrVoid = true,
            EffectiveDate = "2019-12-27",
        };

        string expectedSubscriptionID = "subscription_id";
        bool expectedAllowInvoiceCreditOrVoid = true;
        string expectedEffectiveDate = "2019-12-27";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedAllowInvoiceCreditOrVoid, parameters.AllowInvoiceCreditOrVoid);
        Assert.Equal(expectedEffectiveDate, parameters.EffectiveDate);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionTriggerPhaseParams { SubscriptionID = "subscription_id" };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.EffectiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionTriggerPhaseParams
        {
            SubscriptionID = "subscription_id",

            AllowInvoiceCreditOrVoid = null,
            EffectiveDate = null,
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.EffectiveDate);
        Assert.True(parameters.RawBodyData.ContainsKey("effective_date"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionTriggerPhaseParams parameters = new() { SubscriptionID = "subscription_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/subscriptions/subscription_id/trigger_phase"),
            url
        );
    }
}
