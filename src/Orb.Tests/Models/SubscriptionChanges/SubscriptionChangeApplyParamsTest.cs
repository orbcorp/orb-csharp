using System;
using Orb.Models.SubscriptionChanges;

namespace Orb.Tests.Models.SubscriptionChanges;

public class SubscriptionChangeApplyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionChangeApplyParams
        {
            SubscriptionChangeID = "subscription_change_id",
            Description = "description",
            MarkAsPaid = true,
            PaymentExternalID = "payment_external_id",
            PaymentNotes = "payment_notes",
            PaymentReceivedDate = "2019-12-27",
            PreviouslyCollectedAmount = "previously_collected_amount",
        };

        string expectedSubscriptionChangeID = "subscription_change_id";
        string expectedDescription = "description";
        bool expectedMarkAsPaid = true;
        string expectedPaymentExternalID = "payment_external_id";
        string expectedPaymentNotes = "payment_notes";
        string expectedPaymentReceivedDate = "2019-12-27";
        string expectedPreviouslyCollectedAmount = "previously_collected_amount";

        Assert.Equal(expectedSubscriptionChangeID, parameters.SubscriptionChangeID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedMarkAsPaid, parameters.MarkAsPaid);
        Assert.Equal(expectedPaymentExternalID, parameters.PaymentExternalID);
        Assert.Equal(expectedPaymentNotes, parameters.PaymentNotes);
        Assert.Equal(expectedPaymentReceivedDate, parameters.PaymentReceivedDate);
        Assert.Equal(expectedPreviouslyCollectedAmount, parameters.PreviouslyCollectedAmount);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionChangeApplyParams
        {
            SubscriptionChangeID = "subscription_change_id",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MarkAsPaid);
        Assert.False(parameters.RawBodyData.ContainsKey("mark_as_paid"));
        Assert.Null(parameters.PaymentExternalID);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_external_id"));
        Assert.Null(parameters.PaymentNotes);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_notes"));
        Assert.Null(parameters.PaymentReceivedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("payment_received_date"));
        Assert.Null(parameters.PreviouslyCollectedAmount);
        Assert.False(parameters.RawBodyData.ContainsKey("previously_collected_amount"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionChangeApplyParams
        {
            SubscriptionChangeID = "subscription_change_id",

            Description = null,
            MarkAsPaid = null,
            PaymentExternalID = null,
            PaymentNotes = null,
            PaymentReceivedDate = null,
            PreviouslyCollectedAmount = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MarkAsPaid);
        Assert.True(parameters.RawBodyData.ContainsKey("mark_as_paid"));
        Assert.Null(parameters.PaymentExternalID);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_external_id"));
        Assert.Null(parameters.PaymentNotes);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_notes"));
        Assert.Null(parameters.PaymentReceivedDate);
        Assert.True(parameters.RawBodyData.ContainsKey("payment_received_date"));
        Assert.Null(parameters.PreviouslyCollectedAmount);
        Assert.True(parameters.RawBodyData.ContainsKey("previously_collected_amount"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionChangeApplyParams parameters = new()
        {
            SubscriptionChangeID = "subscription_change_id",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/subscription_changes/subscription_change_id/apply"),
            url
        );
    }
}
