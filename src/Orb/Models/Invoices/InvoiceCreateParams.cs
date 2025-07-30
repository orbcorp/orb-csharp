using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using InvoiceCreateParamsProperties = Orb.Models.Invoices.InvoiceCreateParamsProperties;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint is used to create a one-off invoice for a customer.
/// </summary>
public sealed record class InvoiceCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// An ISO 4217 currency string. Must be the same as the customer's currency if
    /// it is set.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.BodyProperties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional invoice date to set. Must be in the past, if not set, `invoice_date`
    /// is set to the current time in the customer's timezone.
    /// </summary>
    public required System::DateTime InvoiceDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("invoice_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoice_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.BodyProperties["invoice_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public required List<InvoiceCreateParamsProperties::LineItem> LineItems
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("line_items", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "line_items",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<InvoiceCreateParamsProperties::LineItem>>(
                    element
                ) ?? throw new System::ArgumentNullException("line_items");
        }
        set { this.BodyProperties["line_items"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the `Customer` to create this invoice for. One of `customer_id` and
    /// `external_customer_id` are required.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["customer_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional discount to attach to the invoice.
    /// </summary>
    public Discount2? Discount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Discount2?>(element);
        }
        set { this.BodyProperties["discount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The `external_customer_id` of the `Customer` to create this invoice for. One
    /// of `customer_id` and `external_customer_id` are required.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["external_customer_id"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// An optional memo to attach to the invoice.
    /// </summary>
    public string? Memo
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["memo"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(element);
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
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
            if (!this.BodyProperties.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.BodyProperties["net_terms"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// When true, this invoice will be submitted for issuance upon creation. When false,
    /// the resulting invoice will require manual review to issue. Defaulted to false.
    /// </summary>
    public bool? WillAutoIssue
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("will_auto_issue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.BodyProperties["will_auto_issue"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/invoices")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
