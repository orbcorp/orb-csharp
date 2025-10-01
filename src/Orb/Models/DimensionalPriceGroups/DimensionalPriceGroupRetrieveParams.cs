using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.DimensionalPriceGroups;

/// <summary>
/// Fetch dimensional price group
/// </summary>
public sealed record class DimensionalPriceGroupRetrieveParams : ParamsBase
{
    public required string DimensionalPriceGroupID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/dimensional_price_groups/{0}", this.DimensionalPriceGroupID)
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
