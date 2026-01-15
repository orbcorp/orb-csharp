using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits;
using Orb.Services.Customers.Credits;

namespace Orb.Services.Customers;

/// <inheritdoc/>
public sealed class CreditService : ICreditService
{
    readonly Lazy<ICreditServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICreditServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ICreditService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditService(this._client.WithOptions(modifier));
    }

    public CreditService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CreditServiceWithRawResponse(client.WithRawResponse));
        _ledger = new(() => new LedgerService(client));
        _topUps = new(() => new TopUpService(client));
    }

    readonly Lazy<ILedgerService> _ledger;
    public ILedgerService Ledger
    {
        get { return _ledger.Value; }
    }

    readonly Lazy<ITopUpService> _topUps;
    public ITopUpService TopUps
    {
        get { return _topUps.Value; }
    }

    /// <inheritdoc/>
    public async Task<CreditListPage> List(
        CreditListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CreditListPage> List(
        string customerID,
        CreditListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CreditListByExternalIDPage> ListByExternalID(
        CreditListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CreditListByExternalIDPage> ListByExternalID(
        string externalCustomerID,
        CreditListByExternalIDParams? parameters = null,
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
public sealed class CreditServiceWithRawResponse : ICreditServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICreditServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CreditServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _ledger = new(() => new LedgerServiceWithRawResponse(client));
        _topUps = new(() => new TopUpServiceWithRawResponse(client));
    }

    readonly Lazy<ILedgerServiceWithRawResponse> _ledger;
    public ILedgerServiceWithRawResponse Ledger
    {
        get { return _ledger.Value; }
    }

    readonly Lazy<ITopUpServiceWithRawResponse> _topUps;
    public ITopUpServiceWithRawResponse TopUps
    {
        get { return _topUps.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditListPage>> List(
        CreditListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<CreditListParams> request = new()
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
                    .Deserialize<CreditListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CreditListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CreditListPage>> List(
        string customerID,
        CreditListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditListByExternalIDPage>> ListByExternalID(
        CreditListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<CreditListByExternalIDParams> request = new()
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
                    .Deserialize<CreditListByExternalIDPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CreditListByExternalIDPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CreditListByExternalIDPage>> ListByExternalID(
        string externalCustomerID,
        CreditListByExternalIDParams? parameters = null,
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
