using System;
using System.Net.Http;

namespace Orb.Models.Customers.Credits.TopUps;

/// <summary>
/// This deactivates the top-up and voids any invoices associated with pending credit
/// blocks purchased through the top-up.
/// </summary>
public sealed record class TopUpDeleteParams : ParamsBase
{
    public required string CustomerID;

    public required string TopUpID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/credits/top_ups/{1}", this.CustomerID, this.TopUpID)
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
