using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Services.Customers.Credits.Ledger;

public sealed class LedgerService : ILedgerService
{
    readonly IOrbClient _client;

    public LedgerService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<LedgerListPageResponse> List(LedgerListParams parameters)
    {
        HttpRequest<LedgerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LedgerListPageResponse>().ConfigureAwait(false);
    }

    public async Task<LedgerCreateEntryResponse> CreateEntry(LedgerCreateEntryParams parameters)
    {
        HttpRequest<LedgerCreateEntryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<LedgerCreateEntryResponse>().ConfigureAwait(false);
    }

    public async Task<LedgerCreateEntryByExternalIDResponse> CreateEntryByExternalID(
        LedgerCreateEntryByExternalIDParams parameters
    )
    {
        HttpRequest<LedgerCreateEntryByExternalIDParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<LedgerCreateEntryByExternalIDResponse>()
            .ConfigureAwait(false);
    }

    public async Task<LedgerListByExternalIDPageResponse> ListByExternalID(
        LedgerListByExternalIDParams parameters
    )
    {
        HttpRequest<LedgerListByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<LedgerListByExternalIDPageResponse>()
            .ConfigureAwait(false);
    }
}
