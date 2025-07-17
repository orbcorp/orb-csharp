using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Customers.Credits.TopUps;

/// <summary>
/// This deactivates the top-up and voids any invoices associated with pending credit
/// blocks purchased through the top-up.
/// </summary>
public sealed record class TopUpDeleteParams : Orb::ParamsBase
{
    public required string CustomerID;

    public required string TopUpID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/credits/top_ups/{1}", this.CustomerID, this.TopUpID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
