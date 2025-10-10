using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.InvoiceLineItems;

/// <summary>
/// This creates a one-off fixed fee invoice line item on an Invoice. This can only
/// be done for invoices that are in a `draft` status.
///
/// The behavior depends on which parameters are provided: - If `item_id` is provided
/// without `name`: The item is looked up by ID, and the item's name   is used for
/// the line item. - If `name` is provided without `item_id`: An item with the given
/// name is searched for in the account.   If found, that item is used. If not found,
/// a new item is created with that name.   The new item's name is used for the line
/// item. - If both `item_id` and `name` are provided: The item is looked up by ID
/// for association,   but the provided `name` is used for the line item (not the
/// item's name).
/// </summary>
public sealed record class InvoiceLineItemCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The total amount in the invoice's currency to add to the line item.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentNullException("amount")
                );
        }
        set
        {
            this.BodyProperties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A date string to specify the line item's end date in the customer's timezone.
    /// </summary>
    public required DateOnly EndDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("end_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'end_date' cannot be null",
                    new ArgumentOutOfRangeException("end_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateOnly>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the Invoice to add this line item.
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("invoice_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_id' cannot be null",
                    new ArgumentOutOfRangeException("invoice_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'invoice_id' cannot be null",
                    new ArgumentNullException("invoice_id")
                );
        }
        set
        {
            this.BodyProperties["invoice_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of units on the line item
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A date string to specify the line item's start date in the customer's timezone.
    /// </summary>
    public required DateOnly StartDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new ArgumentOutOfRangeException("start_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateOnly>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item to associate with this line item. If provided without `name`,
    /// the item's name will be used for the price/line item. If provided with `name`,
    /// the item will be associated but `name` will be used for the line item. At
    /// least one of `name` or `item_id` must be provided.
    /// </summary>
    public string? ItemID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("item_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name to use for the line item. If `item_id` is not provided, Orb will
    /// search for an item with this name. If found, that item will be associated
    /// with the line item. If not found, a new item will be created with this name.
    /// If `item_id` is provided, this name will be used for the line item, but the
    /// item association will be based on `item_id`. At least one of `name` or `item_id`
    /// must be provided.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/invoice_line_items")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
