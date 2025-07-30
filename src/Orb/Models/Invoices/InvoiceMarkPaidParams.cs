using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint allows an invoice's status to be set the `paid` status. This can
/// only be done to invoices that are in the `issued` status.
/// </summary>
public sealed record class InvoiceMarkPaidParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string InvoiceID;

    /// <summary>
    /// A date string to specify the date of the payment.
    /// </summary>
    public required System::DateOnly PaymentReceivedDate
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "payment_received_date",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "payment_received_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateOnly>(element);
        }
        set
        {
            this.BodyProperties["payment_received_date"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// An optional external ID to associate with the payment.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["external_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional note to associate with the payment.
    /// </summary>
    public string? Notes
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("notes", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["notes"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/{0}/mark_paid", this.InvoiceID)
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
