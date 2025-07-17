using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Prices;

/// <summary>
/// This endpoint returns a price given an identifier.
/// </summary>
public sealed record class PriceFetchParams : Orb::ParamsBase
{
    public required string PriceID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/prices/{0}", this.PriceID)
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
