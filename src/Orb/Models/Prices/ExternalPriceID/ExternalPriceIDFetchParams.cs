using System;
using System.Net.Http;

namespace Orb.Models.Prices.ExternalPriceID;

/// <summary>
/// This endpoint returns a price given an external price id. See the [price creation
/// API](/api-reference/price/create-price) for more information about external price aliases.
/// </summary>
public sealed record class ExternalPriceIDFetchParams : ParamsBase
{
    public required string ExternalPriceID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/prices/external_price_id/{0}", this.ExternalPriceID)
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
