using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Events.Backfills;

namespace Orb.Services.Events;

public sealed class BackfillService : IBackfillService
{
    public IBackfillService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BackfillService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public BackfillService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<BackfillCreateResponse> Create(
        BackfillCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BackfillCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var backfill = await response
            .Deserialize<BackfillCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            backfill.Validate();
        }
        return backfill;
    }

    public async Task<BackfillListPageResponse> List(
        BackfillListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BackfillListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<BackfillListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<BackfillCloseResponse> Close(
        BackfillCloseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BackfillID == null)
        {
            throw new OrbInvalidDataException("'parameters.BackfillID' cannot be null");
        }

        HttpRequest<BackfillCloseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BackfillCloseResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BackfillCloseResponse> Close(
        string backfillID,
        BackfillCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Close(parameters with { BackfillID = backfillID }, cancellationToken);
    }

    public async Task<BackfillFetchResponse> Fetch(
        BackfillFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BackfillID == null)
        {
            throw new OrbInvalidDataException("'parameters.BackfillID' cannot be null");
        }

        HttpRequest<BackfillFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BackfillFetchResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BackfillFetchResponse> Fetch(
        string backfillID,
        BackfillFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(parameters with { BackfillID = backfillID }, cancellationToken);
    }

    public async Task<BackfillRevertResponse> Revert(
        BackfillRevertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BackfillID == null)
        {
            throw new OrbInvalidDataException("'parameters.BackfillID' cannot be null");
        }

        HttpRequest<BackfillRevertParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BackfillRevertResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BackfillRevertResponse> Revert(
        string backfillID,
        BackfillRevertParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Revert(parameters with { BackfillID = backfillID }, cancellationToken);
    }
}
