using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.DimensionalPriceGroups;

/// <summary>
/// Fetch dimensional price group
/// </summary>
public sealed record class DimensionalPriceGroupRetrieveParams : Orb::ParamsBase
{
    public required string DimensionalPriceGroupID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/dimensional_price_groups/{0}", this.DimensionalPriceGroupID)
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
