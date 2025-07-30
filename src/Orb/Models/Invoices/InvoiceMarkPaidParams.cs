using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint allows an invoice's status to be set the `paid` status. This can
/// only be done to invoices that are in the `issued` status.
/// </summary>
public sealed record class InvoiceMarkPaidParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string InvoiceID;

    /// <summary>
    /// A date string to specify the date of the payment.
    /// </summary>
    public required System::DateOnly PaymentReceivedDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("payment_received_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "payment_received_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateOnly>(element);
        }
        set
        {
            this.BodyProperties["payment_received_date"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// An optional external ID to associate with the payment.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["external_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional note to associate with the payment.
    /// </summary>
    public string? Notes
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("notes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["notes"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/{0}/mark_paid", this.InvoiceID)
        )
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
