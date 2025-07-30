using System;
using System.Net.Http;

namespace Orb.Models.Metrics;

/// <summary>
/// This endpoint is used to list [metrics](/core-concepts#metric). It returns information
/// about the metrics including its name, description, and item.
/// </summary>
public sealed record class MetricFetchParams : ParamsBase
{
    public required string MetricID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/metrics/{0}", this.MetricID)
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
