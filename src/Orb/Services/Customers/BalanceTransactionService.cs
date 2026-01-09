using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Services.Customers;

/// <inheritdoc/>
public sealed class BalanceTransactionService : IBalanceTransactionService
{
    readonly Lazy<IBalanceTransactionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBalanceTransactionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IBalanceTransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BalanceTransactionService(this._client.WithOptions(modifier));
    }

    public BalanceTransactionService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new BalanceTransactionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BalanceTransactionCreateResponse> Create(
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BalanceTransactionCreateResponse> Create(
        string customerID,
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BalanceTransactionListPage> List(
        BalanceTransactionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BalanceTransactionListPage> List(
        string customerID,
        BalanceTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BalanceTransactionServiceWithRawResponse
    : IBalanceTransactionServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBalanceTransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BalanceTransactionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BalanceTransactionServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceTransactionCreateResponse>> Create(
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<BalanceTransactionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var balanceTransaction = await response
                    .Deserialize<BalanceTransactionCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    balanceTransaction.Validate();
                }
                return balanceTransaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BalanceTransactionCreateResponse>> Create(
        string customerID,
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceTransactionListPage>> List(
        BalanceTransactionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<BalanceTransactionListParams> request = new()
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
                    .Deserialize<BalanceTransactionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BalanceTransactionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BalanceTransactionListPage>> List(
        string customerID,
        BalanceTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }
}
