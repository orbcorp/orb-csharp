using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using InvoiceListParamsProperties = Orb.Models.Invoices.InvoiceListParamsProperties;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint returns a list of all [`Invoice`](/core-concepts#invoice)s for
/// an account in a list format.
///
/// The list of invoices is ordered starting from the most recently issued invoice
/// date. The response also includes [`pagination_metadata`](/api-reference/pagination),
/// which lets the caller retrieve the next page of results if they exist.
///
/// By default, this only returns invoices that are `issued`, `paid`, or `synced`.
///
/// When fetching any `draft` invoices, this returns the last-computed invoice values
/// for each draft invoice, which may not always be up-to-date since Orb regularly
/// refreshes invoices asynchronously.
/// </summary>
public sealed record class InvoiceListParams : Orb::ParamsBase
{
    public string? Amount
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("amount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? AmountGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("amount[gt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["amount[gt]"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? AmountLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("amount[lt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["amount[lt]"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["cursor"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? CustomerID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("customer_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.QueryProperties["customer_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public InvoiceListParamsProperties::DateType? DateType
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("date_type", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<InvoiceListParamsProperties::DateType?>(
                element
            );
        }
        set { this.QueryProperties["date_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public System::DateOnly? DueDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("due_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set { this.QueryProperties["due_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Filters invoices by their due dates within a specific time range in the past.
    /// Specify the range as a number followed by 'd' (days) or 'm' (months). For example,
    /// '7d' filters invoices due in the last 7 days, and '2m' filters those due in
    /// the last 2 months.
    /// </summary>
    public string? DueDateWindow
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("due_date_window", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.QueryProperties["due_date_window"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateOnly? DueDateGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("due_date[gt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set
        {
            this.QueryProperties["due_date[gt]"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public System::DateOnly? DueDateLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("due_date[lt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set
        {
            this.QueryProperties["due_date[lt]"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public string? ExternalCustomerID
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue(
                    "external_customer_id",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.QueryProperties["external_customer_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? InvoiceDateGt
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue("invoice_date[gt]", out Json::JsonElement element)
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["invoice_date[gt]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? InvoiceDateGte
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue(
                    "invoice_date[gte]",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["invoice_date[gte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? InvoiceDateLt
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue("invoice_date[lt]", out Json::JsonElement element)
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["invoice_date[lt]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? InvoiceDateLte
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue(
                    "invoice_date[lte]",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["invoice_date[lte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public bool? IsRecurring
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("is_recurring", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.QueryProperties["is_recurring"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Generic::List<InvoiceListParamsProperties::Status>? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<InvoiceListParamsProperties::Status>?>(
                element
            );
        }
        set { this.QueryProperties["status"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? SubscriptionID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("subscription_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.QueryProperties["subscription_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/invoices")
        {
            Query = this.QueryString(client),
        }.Uri;
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
