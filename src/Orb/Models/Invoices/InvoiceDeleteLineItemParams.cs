using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint deletes an invoice line item from a draft invoice.
///
/// <para>This endpoint only allows deletion of one-off line items (not subscription-based
/// line items). The invoice must be in a draft status for this operation to succeed.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoiceDeleteLineItemParams : ParamsBase
{
    public required string InvoiceID { get; init; }

    public string? LineItemID { get; init; }

    public InvoiceDeleteLineItemParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceDeleteLineItemParams(InvoiceDeleteLineItemParams invoiceDeleteLineItemParams)
        : base(invoiceDeleteLineItemParams)
    {
        this.InvoiceID = invoiceDeleteLineItemParams.InvoiceID;
        this.LineItemID = invoiceDeleteLineItemParams.LineItemID;
    }
#pragma warning restore CS8618

    public InvoiceDeleteLineItemParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceDeleteLineItemParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static InvoiceDeleteLineItemParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["InvoiceID"] = this.InvoiceID,
                ["LineItemID"] = this.LineItemID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InvoiceDeleteLineItemParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.InvoiceID.Equals(other.InvoiceID)
            && (this.LineItemID?.Equals(other.LineItemID) ?? other.LineItemID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/invoices/{0}/invoice_line_items/{1}",
                    this.InvoiceID,
                    this.LineItemID
                )
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

    public override int GetHashCode()
    {
        return 0;
    }
}
