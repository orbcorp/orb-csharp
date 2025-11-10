using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Credits;
using Orb.Services.Customers.Credits;

namespace Orb.Services.Customers;

public sealed class CreditService : ICreditService
{
    public ICreditService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public CreditService(IOrbClient client)
    {
        _client = client;
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

    public async Task<CreditListPageResponse> List(
        CreditListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<CreditListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<CreditListByExternalIDPageResponse> ListByExternalID(
        CreditListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditListByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<CreditListByExternalIDPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
