using System;
using System.Net.Http;

namespace Orb.Models.Customers;

/// <summary>
/// This performs a deletion of this customer, its subscriptions, and its invoices,
/// provided the customer does not have any issued invoices. Customers with issued
/// invoices cannot be deleted. This operation is irreversible. Note that this is
/// a _soft_ deletion, but the data will be inaccessible through the API and Orb dashboard.
///
/// For a hard-deletion, please reach out to the Orb team directly.
///
/// **Note**: This operation happens asynchronously and can be expected to take a
/// few minutes to propagate to related resources. However, querying for the customer
/// on subsequent GET requests while deletion is in process will reflect its deletion.
/// </summary>
public sealed record class CustomerDeleteParams : ParamsBase
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

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
