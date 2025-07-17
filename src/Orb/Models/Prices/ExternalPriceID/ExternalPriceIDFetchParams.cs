using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Prices.ExternalPriceID;

/// <summary>
/// This endpoint returns a price given an external price id. See the [price creation
/// API](/api-reference/price/create-price) for more information about external price aliases.
/// </summary>
public sealed record class ExternalPriceIDFetchParams : Orb::ParamsBase
{
    public required string ExternalPriceID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/prices/external_price_id/{0}", this.ExternalPriceID)
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
