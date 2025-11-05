using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Ledger = Orb.Models.Customers.Credits.Ledger;

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

    public async Task<Ledger::LedgerListPageResponse> List(Ledger::LedgerListParams parameters)
    {
        HttpRequest<Ledger::LedgerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<Ledger::LedgerListPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Ledger::LedgerCreateEntryResponse> CreateEntry(
        Ledger::LedgerCreateEntryParams parameters
    )
    {
        HttpRequest<Ledger::LedgerCreateEntryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Ledger::LedgerCreateEntryResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Ledger::LedgerCreateEntryByExternalIDResponse> CreateEntryByExternalID(
        Ledger::LedgerCreateEntryByExternalIDParams parameters
    )
    {
        HttpRequest<Ledger::LedgerCreateEntryByExternalIDParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Ledger::LedgerCreateEntryByExternalIDResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Ledger::LedgerListByExternalIDPageResponse> ListByExternalID(
        Ledger::LedgerListByExternalIDParams parameters
    )
    {
        HttpRequest<Ledger::LedgerListByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<Ledger::LedgerListByExternalIDPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
