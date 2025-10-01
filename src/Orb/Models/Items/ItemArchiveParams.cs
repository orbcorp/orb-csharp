using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Items;

/// <summary>
/// Archive item
/// </summary>
public sealed record class ItemArchiveParams : ParamsBase
{
    public required string ItemID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/items/{0}/archive", this.ItemID)
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
