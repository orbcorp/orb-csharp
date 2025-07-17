using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.TopLevel;

/// <summary>
/// This endpoint allows you to test your connection to the Orb API and check the
/// validity of your API key, passed in the Authorization header. This is particularly
/// useful for checking that your environment is set up properly, and is a great choice
/// for connectors and integrations.
///
/// This API does not have any side-effects or return any Orb resources.
/// </summary>
public sealed record class TopLevelPingParams : Orb::ParamsBase
{
    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/ping")
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
