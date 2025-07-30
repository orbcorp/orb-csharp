using System.Net.Http;
using System = System;

namespace Orb.Models.Prices;

/// <summary>
/// This endpoint returns a price given an identifier.
/// </summary>
public sealed record class PriceFetchParams : ParamsBase
{
    public required string PriceID;

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/prices/{0}", this.PriceID)
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
