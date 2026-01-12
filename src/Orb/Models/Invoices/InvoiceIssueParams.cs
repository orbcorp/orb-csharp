using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint allows an eligible invoice to be issued manually. This is only possible
/// with invoices where status is `draft`, `will_auto_issue` is false, and an `eligible_to_issue_at`
/// is a time in the past. Issuing an invoice could possibly trigger side effects,
/// some of which could be customer-visible (e.g. sending emails, auto-collecting
/// payment, syncing the invoice to external providers, etc).
/// </summary>
public sealed record class InvoiceIssueParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InvoiceID { get; init; }

    /// <summary>
    /// If true, the invoice will be issued synchronously. If false, the invoice
    /// will be issued asynchronously. The synchronous option is only available for
    /// invoices that have no usage fees. If the invoice is configured to sync to
    /// an external provider, a successful response from this endpoint guarantees
    /// the invoice is present in the provider.
    /// </summary>
    public bool? Synchronous
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("synchronous");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("synchronous", value);
        }
    }

    public InvoiceIssueParams() { }

    public InvoiceIssueParams(InvoiceIssueParams invoiceIssueParams)
        : base(invoiceIssueParams)
    {
        this.InvoiceID = invoiceIssueParams.InvoiceID;

        this._rawBodyData = new(invoiceIssueParams._rawBodyData);
    }

    public InvoiceIssueParams(
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
    InvoiceIssueParams(
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
    public static InvoiceIssueParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/{0}/issue", this.InvoiceID)
        )
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
