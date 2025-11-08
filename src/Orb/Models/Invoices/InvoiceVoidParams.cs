using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;
using System = System;

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
    public required string InvoiceID { get; init; }

    public InvoiceVoidParams() { }

    public InvoiceVoidParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceVoidParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }
#pragma warning restore CS8618

    public static InvoiceVoidParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
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
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
