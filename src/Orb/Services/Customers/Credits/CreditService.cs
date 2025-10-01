using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Credits;
using Orb.Services.Customers.Credits.Ledger;
using Orb.Services.Customers.Credits.TopUps;

namespace Orb.Services.Customers.Credits;

public sealed class CreditService : ICreditService
{
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

    public async Task<CreditListPageResponse> List(CreditListParams parameters)
    {
        HttpRequest<CreditListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<CreditListPageResponse>().ConfigureAwait(false);
    }

    public async Task<CreditListByExternalIDPageResponse> ListByExternalID(
        CreditListByExternalIDParams parameters
    )
    {
        HttpRequest<CreditListByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<CreditListByExternalIDPageResponse>()
            .ConfigureAwait(false);
    }
}
