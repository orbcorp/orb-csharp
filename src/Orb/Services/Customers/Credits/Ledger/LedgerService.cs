using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Services.Customers.Credits.Ledger;

public sealed class LedgerService : ILedgerService
{
    public ILedgerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LedgerService(this._client.WithOptions(modifier));
    }

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
        var page = await response.Deserialize<LedgerListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<LedgerCreateEntryResponse> CreateEntry(LedgerCreateEntryParams parameters)
    {
        HttpRequest<LedgerCreateEntryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<LedgerCreateEntryResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
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
        var deserializedResponse = await response
            .Deserialize<LedgerCreateEntryByExternalIDResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
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
        var page = await response
            .Deserialize<LedgerListByExternalIDPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
