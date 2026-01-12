using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.InvoiceLineItems;

/// <summary>
/// This creates a one-off fixed fee invoice line item on an Invoice. This can only
/// be done for invoices that are in a `draft` status.
///
/// <para>The behavior depends on which parameters are provided: - If `item_id` is
/// provided without `name`: The item is looked up by ID, and the item's name   is
/// used for the line item. - If `name` is provided without `item_id`: An item with
/// the given name is searched for in the account.   If found, that item is used.
/// If not found, a new item is created with that name.   The new item's name is used
/// for the line item. - If both `item_id` and `name` are provided: The item is looked
/// up by ID for association,   but the provided `name` is used for the line item
/// (not the item's name).</para>
/// </summary>
public sealed record class InvoiceLineItemCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The total amount in the invoice's currency to add to the line item.
    /// </summary>
    public required string Amount
    {
        get { return this._rawBodyData.GetNotNullClass<string>("amount"); }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// A date string to specify the line item's end date in the customer's timezone.
    /// </summary>
    public required string EndDate
    {
        get { return this._rawBodyData.GetNotNullClass<string>("end_date"); }
        init { this._rawBodyData.Set("end_date", value); }
    }

    /// <summary>
    /// The id of the Invoice to add this line item.
    /// </summary>
    public required string InvoiceID
    {
        get { return this._rawBodyData.GetNotNullClass<string>("invoice_id"); }
        init { this._rawBodyData.Set("invoice_id", value); }
    }

    /// <summary>
    /// The number of units on the line item
    /// </summary>
    public required double Quantity
    {
        get { return this._rawBodyData.GetNotNullStruct<double>("quantity"); }
        init { this._rawBodyData.Set("quantity", value); }
    }

    /// <summary>
    /// A date string to specify the line item's start date in the customer's timezone.
    /// </summary>
    public required string StartDate
    {
        get { return this._rawBodyData.GetNotNullClass<string>("start_date"); }
        init { this._rawBodyData.Set("start_date", value); }
    }

    /// <summary>
    /// The id of the item to associate with this line item. If provided without
    /// `name`, the item's name will be used for the price/line item. If provided
    /// with `name`, the item will be associated but `name` will be used for the line
    /// item. At least one of `name` or `item_id` must be provided.
    /// </summary>
    public string? ItemID
    {
        get { return this._rawBodyData.GetNullableClass<string>("item_id"); }
        init { this._rawBodyData.Set("item_id", value); }
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
        get { return this._rawBodyData.GetNullableClass<string>("name"); }
        init { this._rawBodyData.Set("name", value); }
    }

    public InvoiceLineItemCreateParams() { }

    public InvoiceLineItemCreateParams(InvoiceLineItemCreateParams invoiceLineItemCreateParams)
        : base(invoiceLineItemCreateParams)
    {
        this._rawBodyData = new(invoiceLineItemCreateParams._rawBodyData);
    }

    public InvoiceLineItemCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceLineItemCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static InvoiceLineItemCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/invoice_line_items")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
