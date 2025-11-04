using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Services.Customers.BalanceTransactions;

public sealed class BalanceTransactionService : IBalanceTransactionService
{
    readonly IOrbClient _client;

    public BalanceTransactionService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<BalanceTransactionCreateResponse> Create(
        BalanceTransactionCreateParams parameters
    )
    {
        HttpRequest<BalanceTransactionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var balanceTransaction = await response
            .Deserialize<BalanceTransactionCreateResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            balanceTransaction.Validate();
        }
        return balanceTransaction;
    }

    public async Task<BalanceTransactionListPageResponse> List(
        BalanceTransactionListParams parameters
    )
    {
        HttpRequest<BalanceTransactionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<BalanceTransactionListPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
