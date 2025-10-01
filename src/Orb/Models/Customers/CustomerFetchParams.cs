using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Customers;

/// <summary>
/// This endpoint is used to fetch customer details given an identifier. If the `Customer`
/// is in the process of being deleted, only the properties `id` and `deleted: true`
/// will be returned.
///
/// See the [Customer resource](/core-concepts#customer) for a full discussion of
/// the Customer model.
/// </summary>
public sealed record class CustomerFetchParams : ParamsBase
{
    public required string CustomerID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}", this.CustomerID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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
