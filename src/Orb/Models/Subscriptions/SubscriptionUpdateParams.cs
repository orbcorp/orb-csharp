using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to update the `metadata`, `net terms`, `auto_collection`,
/// `invoicing_threshold`, and `default_invoice_memo` properties on a subscription.
/// </summary>
public sealed record class SubscriptionUpdateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// Determines whether issued invoices for this subscription will automatically
    /// be charged with the saved payment method on the due date. This property defaults
    /// to the plan's behavior.
    /// </summary>
    public bool? AutoCollection
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("auto_collection", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["auto_collection"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Determines the default memo on this subscription's invoices. Note that if this
    /// is not provided, it is determined by the plan configuration.
    /// </summary>
    public string? DefaultInvoiceMemo
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "default_invoice_memo",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["default_invoice_memo"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// When this subscription's accrued usage reaches this threshold, an invoice will
    /// be issued for the subscription. If not specified, invoices will only be issued
    /// at the end of the billing period.
    /// </summary>
    public string? InvoicingThreshold
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "invoicing_threshold",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["invoicing_threshold"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Generic::Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string?>?>(element);
        }
        set { this.BodyProperties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Determines the difference between the invoice issue date for subscription invoices
    /// as the date that they are due. A value of `0` here represents that the invoice
    /// is due on issue, whereas a value of `30` represents that the customer has a
    /// month to pay the invoice.
    /// </summary>
    public long? NetTerms
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("net_terms", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.BodyProperties["net_terms"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
