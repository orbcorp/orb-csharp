using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Services.Customers;

public sealed class BalanceTransactionService : IBalanceTransactionService
{
    public IBalanceTransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BalanceTransactionService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public BalanceTransactionService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<BalanceTransactionCreateResponse> Create(
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BalanceTransactionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var balanceTransaction = await response
            .Deserialize<BalanceTransactionCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            balanceTransaction.Validate();
        }
        return balanceTransaction;
    }

    public async Task<BalanceTransactionListPageResponse> List(
        BalanceTransactionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BalanceTransactionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<BalanceTransactionListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
