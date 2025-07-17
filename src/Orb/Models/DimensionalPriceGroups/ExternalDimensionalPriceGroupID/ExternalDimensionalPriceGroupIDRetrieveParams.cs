using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

/// <summary>
/// Fetch dimensional price group by external ID
/// </summary>
public sealed record class ExternalDimensionalPriceGroupIDRetrieveParams : Orb::ParamsBase
{
    public required string ExternalDimensionalPriceGroupID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/dimensional_price_groups/external_dimensional_price_group_id/{0}",
                    this.ExternalDimensionalPriceGroupID
                )
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
