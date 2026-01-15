using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Costs;

namespace Orb.Services.Customers;

/// <inheritdoc/>
public sealed class CostService : ICostService
{
    readonly Lazy<ICostServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICostServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ICostService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CostService(this._client.WithOptions(modifier));
    }

    public CostService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CostServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CostListResponse> List(
        CostListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CostListResponse> List(
        string customerID,
        CostListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CostListByExternalIDResponse> ListByExternalID(
        CostListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CostListByExternalIDResponse> ListByExternalID(
        string externalCustomerID,
        CostListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class CostServiceWithRawResponse : ICostServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICostServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CostServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CostServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CostListResponse>> List(
        CostListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<CostListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var costs = await response
                    .Deserialize<CostListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    costs.Validate();
                }
                return costs;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CostListResponse>> List(
        string customerID,
        CostListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CostListByExternalIDResponse>> ListByExternalID(
        CostListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<CostListByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<CostListByExternalIDResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CostListByExternalIDResponse>> ListByExternalID(
        string externalCustomerID,
        CostListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }
}
