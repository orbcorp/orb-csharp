using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Customers;

/// <summary>
/// This performs a deletion of this customer, its subscriptions, and its invoices,
/// provided the customer does not have any issued invoices. Customers with issued
/// invoices cannot be deleted. This operation is irreversible. Note that this is
/// a _soft_ deletion, but the data will be inaccessible through the API and Orb dashboard.
///
/// <para>For a hard-deletion, please reach out to the Orb team directly.</para>
///
/// <para>**Note**: This operation happens asynchronously and can be expected to
/// take a few minutes to propagate to related resources. However, querying for the
/// customer on subsequent GET requests while deletion is in process will reflect
/// its deletion.</para>
/// </summary>
public sealed record class CustomerDeleteParams : ParamsBase
{
    public string? CustomerID { get; init; }

    public CustomerDeleteParams() { }

    public CustomerDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static CustomerDeleteParams FromRawUnchecked(
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
                + string.Format("/customers/{0}", this.CustomerID)
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
