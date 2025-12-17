using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint allows an invoice's status to be set to the `void` status. This
/// can only be done to invoices that are in the `issued` status.
///
/// <para>If the associated invoice has used the customer balance to change the amount
/// due, the customer balance operation will be reverted. For example, if the invoice
/// used \$10 of customer balance, that amount will be added back to the customer
/// balance upon voiding.</para>
///
/// <para>If the invoice was used to purchase a credit block, but the invoice is
/// not yet paid, the credit block will be voided. If the invoice was created due
/// to a top-up, the top-up will be disabled.</para>
/// </summary>
public sealed record class InvoiceVoidParams : ParamsBase
{
    public string? InvoiceID { get; init; }

    public InvoiceVoidParams() { }

    public InvoiceVoidParams(InvoiceVoidParams invoiceVoidParams)
        : base(invoiceVoidParams) { }

    public InvoiceVoidParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceVoidParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static InvoiceVoidParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/{0}/void", this.InvoiceID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
