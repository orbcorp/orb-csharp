using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.CreditNotes;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class CreditNoteService : ICreditNoteService
{
    readonly Lazy<ICreditNoteServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICreditNoteServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ICreditNoteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditNoteService(this._client.WithOptions(modifier));
    }

    public CreditNoteService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CreditNoteServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SharedCreditNote> Create(
        CreditNoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditNoteListPage> List(
        CreditNoteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SharedCreditNote> Fetch(
        CreditNoteFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SharedCreditNote> Fetch(
        string creditNoteID,
        CreditNoteFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { CreditNoteID = creditNoteID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CreditNoteServiceWithRawResponse : ICreditNoteServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICreditNoteServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CreditNoteServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CreditNoteServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SharedCreditNote>> Create(
        CreditNoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditNoteCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var creditNote = await response
                    .Deserialize<SharedCreditNote>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditNote.Validate();
                }
                return creditNote;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditNoteListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<CreditNoteListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CreditNoteListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SharedCreditNote>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var creditNote = await response
                    .Deserialize<SharedCreditNote>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditNote.Validate();
                }
                return creditNote;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SharedCreditNote>> Fetch(
        string creditNoteID,
        CreditNoteFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { CreditNoteID = creditNoteID }, cancellationToken);
    }
}
