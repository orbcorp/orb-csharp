using System;
using System.Net.Http;
using System.Text.Json;

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
public sealed record class BalanceTransactionListParams : ParamsBase
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
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTime? OperationTimeGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("operation_time[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["operation_time[gt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTime? OperationTimeGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("operation_time[gte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["operation_time[gte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTime? OperationTimeLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("operation_time[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["operation_time[lt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTime? OperationTimeLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("operation_time[lte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["operation_time[lte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/balance_transactions", this.CustomerID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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
