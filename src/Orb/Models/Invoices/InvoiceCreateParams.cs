using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using InvoiceCreateParamsProperties = Orb.Models.Invoices.InvoiceCreateParamsProperties;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint is used to create a one-off invoice for a customer.
/// </summary>
public sealed record class InvoiceCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// An ISO 4217 currency string. Must be the same as the customer's currency if
    /// it is set.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.BodyProperties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional invoice date to set. Must be in the past, if not set, `invoice_date`
    /// is set to the current time in the customer's timezone.
    /// </summary>
    public required System::DateTime InvoiceDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("invoice_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoice_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set
        {
            this.BodyProperties["invoice_date"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required Generic::List<InvoiceCreateParamsProperties::LineItem> LineItems
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("line_items", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "line_items",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<InvoiceCreateParamsProperties::LineItem>>(
                    element
                ) ?? throw new System::ArgumentNullException("line_items");
        }
        set { this.BodyProperties["line_items"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the `Customer` to create this invoice for. One of `customer_id` and
    /// `external_customer_id` are required.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customer_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["customer_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional discount to attach to the invoice.
    /// </summary>
    public Models::Discount? Discount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Models::Discount?>(element);
        }
        set { this.BodyProperties["discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The `external_customer_id` of the `Customer` to create this invoice for. One
    /// of `customer_id` and `external_customer_id` are required.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "external_customer_id",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["external_customer_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// An optional memo to attach to the invoice.
    /// </summary>
    public string? Memo
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("memo", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["memo"] = Json::JsonSerializer.SerializeToElement(value); }
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
    /// as the date that they are due. A value of '0' here represents that the invoice
    /// is due on issue, whereas a value of 30 represents that the customer has 30 days
    /// to pay the invoice.
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

    /// <summary>
    /// When true, this invoice will be submitted for issuance upon creation. When false,
    /// the resulting invoice will require manual review to issue. Defaulted to false.
    /// </summary>
    public bool? WillAutoIssue
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("will_auto_issue", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["will_auto_issue"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/invoices")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new Http::StringContent(
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
