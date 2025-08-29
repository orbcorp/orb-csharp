using System;
using System.Net.Http;

namespace Orb.Models.Customers;

/// <summary>
/// This endpoint is used to fetch customer details given an `external_customer_id`
/// (see [Customer ID Aliases](/events-and-metrics/customer-aliases)).
///
/// Note that the resource and semantics of this endpoint exactly mirror [Get Customer](fetch-customer).
/// </summary>
public sealed record class CustomerFetchByExternalIDParams : ParamsBase
{
    public required string ExternalCustomerID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/external_customer_id/{0}", this.ExternalCustomerID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
