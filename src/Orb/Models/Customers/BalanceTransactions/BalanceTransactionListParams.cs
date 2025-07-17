using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;

namespace Orb.Models.Customers.BalanceTransactions;

/// <summary>
/// ## The customer balance
///
/// The customer balance is an amount in the customer's currency, which Orb automatically
/// applies to subsequent invoices. This balance can be adjusted manually via Orb's
/// webapp on the customer details page. You can use this balance to provide a fixed
/// mid-period credit to the customer. Commonly, this is done due to system downtime/SLA
/// violation, or an adhoc adjustment discussed with the customer.
///
/// If the balance is a positive value at the time of invoicing, it represents that
/// the customer has credit that should be used to offset the amount due on the next
/// issued invoice. In this case, Orb will automatically reduce the next invoice
/// by the balance amount, and roll over any remaining balance if the invoice is
/// fully discounted.
///
/// If the balance is a negative value at the time of invoicing, Orb will increase
/// the invoice's amount due with a positive adjustment, and reset the balance to 0.
///
/// This endpoint retrieves all customer balance transactions in reverse chronological
/// order for a single customer, providing a complete audit trail of all adjustments
/// and invoice applications.
/// </summary>
public sealed record class BalanceTransactionListParams : Orb::ParamsBase
{
    public required string CustomerID;

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

    public System::DateTime? OperationTimeGt
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue(
                    "operation_time[gt]",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["operation_time[gt]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? OperationTimeGte
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue(
                    "operation_time[gte]",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["operation_time[gte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? OperationTimeLt
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue(
                    "operation_time[lt]",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["operation_time[lt]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? OperationTimeLte
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue(
                    "operation_time[lte]",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["operation_time[lte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/balance_transactions", this.CustomerID)
        )
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
