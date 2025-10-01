using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.TopLevel;

/// <summary>
/// This endpoint allows you to test your connection to the Orb API and check the
/// validity of your API key, passed in the Authorization header. This is particularly
/// useful for checking that your environment is set up properly, and is a great choice
/// for connectors and integrations.
///
/// This API does not have any side-effects or return any Orb resources.
/// </summary>
public sealed record class TopLevelPingParams : ParamsBase
{
    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/ping")
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
