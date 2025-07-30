using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.InvoiceLineItems;

/// <summary>
/// This creates a one-off fixed fee invoice line item on an Invoice. This can only
/// be done for invoices that are in a `draft` status.
/// </summary>
public sealed record class InvoiceLineItemCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The total amount in the invoice's currency to add to the line item.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.BodyProperties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify the line item's end date in the customer's timezone.
    /// </summary>
    public required System::DateOnly EndDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("end_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateOnly>(element);
        }
        set { this.BodyProperties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the Invoice to add this line item.
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("invoice_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoice_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("invoice_id");
        }
        set { this.BodyProperties["invoice_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The item name associated with this line item. If an item with the same name
    /// exists in Orb, that item will be associated with the line item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.BodyProperties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of units on the line item
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.BodyProperties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify the line item's start date in the customer's timezone.
    /// </summary>
    public required System::DateOnly StartDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("start_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateOnly>(element);
        }
        set { this.BodyProperties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/invoice_line_items"
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
