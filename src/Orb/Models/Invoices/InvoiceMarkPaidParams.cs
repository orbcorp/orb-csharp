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
/// This endpoint allows an invoice's status to be set to the `paid` status. This
/// can only be done to invoices that are in the `issued` or `synced` status.
/// </summary>
public sealed record class InvoiceMarkPaidParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InvoiceID { get; init; }

    /// <summary>
    /// A date string to specify the date of the payment.
    /// </summary>
    public required
#if NET
    DateOnly
#else
    DateTimeOffset
#endif
    PaymentReceivedDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            >(this.RawBodyData, "payment_received_date");
        }
        init { ModelBase.Set(this._rawBodyData, "payment_received_date", value); }
    }

    /// <summary>
    /// An optional external ID to associate with the payment.
    /// </summary>
    public string? ExternalID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "external_id"); }
        init { ModelBase.Set(this._rawBodyData, "external_id", value); }
    }

    /// <summary>
    /// An optional note to associate with the payment.
    /// </summary>
    public string? Notes
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "notes"); }
        init { ModelBase.Set(this._rawBodyData, "notes", value); }
    }

    public InvoiceMarkPaidParams() { }

    public InvoiceMarkPaidParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceMarkPaidParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static InvoiceMarkPaidParams FromRawUnchecked(
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
                + string.Format("/invoices/{0}/mark_paid", this.InvoiceID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
