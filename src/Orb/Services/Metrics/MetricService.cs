using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Metrics;

namespace Orb.Services.Metrics;

public sealed class MetricService : IMetricService
{
    public IMetricService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetricService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public MetricService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<BillableMetric> Create(
        MetricCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MetricCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var billableMetric = await response
            .Deserialize<BillableMetric>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            billableMetric.Validate();
        }
        return billableMetric;
    }

    public async Task<BillableMetric> Update(
        MetricUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MetricUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var billableMetric = await response
            .Deserialize<BillableMetric>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            billableMetric.Validate();
        }
        return billableMetric;
    }

    public async Task<MetricListPageResponse> List(
        MetricListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MetricListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<MetricListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<BillableMetric> Fetch(
        MetricFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MetricFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var billableMetric = await response
            .Deserialize<BillableMetric>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            billableMetric.Validate();
        }
        return billableMetric;
    }
}
