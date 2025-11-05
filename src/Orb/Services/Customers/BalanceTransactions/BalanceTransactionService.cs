using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using BalanceTransactions = Orb.Models.Customers.BalanceTransactions;

namespace Orb.Services.Customers.BalanceTransactions;

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

    public async Task<BalanceTransactions::BalanceTransactionCreateResponse> Create(
        BalanceTransactions::BalanceTransactionCreateParams parameters
    )
    {
        HttpRequest<BalanceTransactions::BalanceTransactionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var balanceTransaction = await response
            .Deserialize<BalanceTransactions::BalanceTransactionCreateResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            balanceTransaction.Validate();
        }
        return balanceTransaction;
    }

    public async Task<BalanceTransactions::BalanceTransactionListPageResponse> List(
        BalanceTransactions::BalanceTransactionListParams parameters
    )
    {
        HttpRequest<BalanceTransactions::BalanceTransactionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<BalanceTransactions::BalanceTransactionListPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
