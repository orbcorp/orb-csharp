using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Items;

/// <summary>
/// This endpoint returns an item identified by its item_id.
/// </summary>
public sealed record class ItemFetchParams : Orb::ParamsBase
{
    public required string ItemID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/items/{0}", this.ItemID)
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
