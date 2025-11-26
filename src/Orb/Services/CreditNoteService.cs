using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.CreditNotes;

namespace Orb.Services;

/// <inheritdoc />
public sealed class CreditNoteService : ICreditNoteService
{
    /// <inheritdoc/>
    public ICreditNoteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditNoteService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public CreditNoteService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SharedCreditNote> Create(
        CreditNoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditNoteCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var creditNote = await response
            .Deserialize<SharedCreditNote>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            creditNote.Validate();
        }
        return creditNote;
    }

    /// <inheritdoc/>
    public async Task<CreditNoteListPageResponse> List(
        CreditNoteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CreditNoteListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<CreditNoteListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<SharedCreditNote> Fetch(
        CreditNoteFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CreditNoteID == null)
        {
            throw new OrbInvalidDataException("'parameters.CreditNoteID' cannot be null");
        }

        HttpRequest<CreditNoteFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var creditNote = await response
            .Deserialize<SharedCreditNote>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            creditNote.Validate();
        }
        return creditNote;
    }

    /// <inheritdoc/>
    public async Task<SharedCreditNote> Fetch(
        string creditNoteID,
        CreditNoteFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(parameters with { CreditNoteID = creditNoteID }, cancellationToken);
    }
}
