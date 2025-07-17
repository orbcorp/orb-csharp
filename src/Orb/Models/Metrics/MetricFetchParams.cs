using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Metrics;

/// <summary>
/// This endpoint is used to list [metrics](/core-concepts#metric). It returns information
/// about the metrics including its name, description, and item.
/// </summary>
public sealed record class MetricFetchParams : Orb::ParamsBase
{
    public required string MetricID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/metrics/{0}", this.MetricID)
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
