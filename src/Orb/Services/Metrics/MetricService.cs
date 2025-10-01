using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Metrics;

namespace Orb.Services.Metrics;

public sealed class MetricService : IMetricService
{
    readonly IOrbClient _client;

    public MetricService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<BillableMetric> Create(MetricCreateParams parameters)
    {
        HttpRequest<MetricCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BillableMetric>().ConfigureAwait(false);
    }

    public async Task<BillableMetric> Update(MetricUpdateParams parameters)
    {
        HttpRequest<MetricUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BillableMetric>().ConfigureAwait(false);
    }

    public async Task<MetricListPageResponse> List(MetricListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<MetricListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MetricListPageResponse>().ConfigureAwait(false);
    }

    public async Task<BillableMetric> Fetch(MetricFetchParams parameters)
    {
        HttpRequest<MetricFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BillableMetric>().ConfigureAwait(false);
    }
}
