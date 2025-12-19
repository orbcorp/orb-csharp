using System.Collections.Generic;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscription_id",
            AutoCollection = true,
            DefaultInvoiceMemo = "default_invoice_memo",
            InvoicingThreshold = "10.00",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            NetTerms = 0,
        };

        string expectedSubscriptionID = "subscription_id";
        bool expectedAutoCollection = true;
        string expectedDefaultInvoiceMemo = "default_invoice_memo";
        string expectedInvoicingThreshold = "10.00";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        long expectedNetTerms = 0;

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedAutoCollection, parameters.AutoCollection);
        Assert.Equal(expectedDefaultInvoiceMemo, parameters.DefaultInvoiceMemo);
        Assert.Equal(expectedInvoicingThreshold, parameters.InvoicingThreshold);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedNetTerms, parameters.NetTerms);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateParams { SubscriptionID = "subscription_id" };

        Assert.Null(parameters.AutoCollection);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_collection"));
        Assert.Null(parameters.DefaultInvoiceMemo);
        Assert.False(parameters.RawBodyData.ContainsKey("default_invoice_memo"));
        Assert.Null(parameters.InvoicingThreshold);
        Assert.False(parameters.RawBodyData.ContainsKey("invoicing_threshold"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NetTerms);
        Assert.False(parameters.RawBodyData.ContainsKey("net_terms"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscription_id",

            AutoCollection = null,
            DefaultInvoiceMemo = null,
            InvoicingThreshold = null,
            Metadata = null,
            NetTerms = null,
        };

        Assert.Null(parameters.AutoCollection);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_collection"));
        Assert.Null(parameters.DefaultInvoiceMemo);
        Assert.False(parameters.RawBodyData.ContainsKey("default_invoice_memo"));
        Assert.Null(parameters.InvoicingThreshold);
        Assert.False(parameters.RawBodyData.ContainsKey("invoicing_threshold"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.NetTerms);
        Assert.False(parameters.RawBodyData.ContainsKey("net_terms"));
    }
}
