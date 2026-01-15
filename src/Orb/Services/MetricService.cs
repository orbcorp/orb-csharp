using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Metrics;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class MetricService : IMetricService
{
    readonly Lazy<IMetricServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMetricServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IMetricService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetricService(this._client.WithOptions(modifier));
    }

    public MetricService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MetricServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BillableMetric> Create(
        MetricCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BillableMetric> Update(
        MetricUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BillableMetric> Update(
        string metricID,
        MetricUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { MetricID = metricID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MetricListPage> List(
        MetricListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BillableMetric> Fetch(
        MetricFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BillableMetric> Fetch(
        string metricID,
        MetricFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { MetricID = metricID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MetricServiceWithRawResponse : IMetricServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMetricServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetricServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MetricServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillableMetric>> Create(
        MetricCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MetricCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var billableMetric = await response
                    .Deserialize<BillableMetric>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    billableMetric.Validate();
                }
                return billableMetric;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillableMetric>> Update(
        MetricUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MetricID == null)
        {
            throw new OrbInvalidDataException("'parameters.MetricID' cannot be null");
        }

        HttpRequest<MetricUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var billableMetric = await response
                    .Deserialize<BillableMetric>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    billableMetric.Validate();
                }
                return billableMetric;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BillableMetric>> Update(
        string metricID,
        MetricUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { MetricID = metricID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MetricListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<MetricListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new MetricListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillableMetric>> Fetch(
        MetricFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MetricID == null)
        {
            throw new OrbInvalidDataException("'parameters.MetricID' cannot be null");
        }

        HttpRequest<MetricFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var billableMetric = await response
                    .Deserialize<BillableMetric>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    billableMetric.Validate();
                }
                return billableMetric;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BillableMetric>> Fetch(
        string metricID,
        MetricFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { MetricID = metricID }, cancellationToken);
    }
}
