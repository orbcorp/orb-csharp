using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.CreditNotes;
using Models = Orb.Models;

namespace Orb.Services.CreditNotes;

public sealed class CreditNoteService : ICreditNoteService
{
    public ICreditNoteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditNoteService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public CreditNoteService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Models::CreditNoteModel> Create(CreditNoteCreateParams parameters)
    {
        HttpRequest<CreditNoteCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var creditNote = await response
            .Deserialize<Models::CreditNoteModel>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            creditNote.Validate();
        }
        return creditNote;
    }

    public async Task<CreditNoteListPageResponse> List(CreditNoteListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<CreditNoteListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<CreditNoteListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Models::CreditNoteModel> Fetch(CreditNoteFetchParams parameters)
    {
        HttpRequest<CreditNoteFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var creditNote = await response
            .Deserialize<Models::CreditNoteModel>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            creditNote.Validate();
        }
        return creditNote;
    }
}
