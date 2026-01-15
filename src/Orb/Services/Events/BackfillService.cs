using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Events.Backfills;

namespace Orb.Services.Events;

/// <inheritdoc/>
public sealed class BackfillService : IBackfillService
{
    readonly Lazy<IBackfillServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBackfillServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IBackfillService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BackfillService(this._client.WithOptions(modifier));
    }

    public BackfillService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BackfillServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BackfillCreateResponse> Create(
        BackfillCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BackfillListPage> List(
        BackfillListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BackfillCloseResponse> Close(
        BackfillCloseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Close(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BackfillCloseResponse> Close(
        string backfillID,
        BackfillCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Close(parameters with { BackfillID = backfillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BackfillFetchResponse> Fetch(
        BackfillFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BackfillFetchResponse> Fetch(
        string backfillID,
        BackfillFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { BackfillID = backfillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BackfillRevertResponse> Revert(
        BackfillRevertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Revert(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BackfillRevertResponse> Revert(
        string backfillID,
        BackfillRevertParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Revert(parameters with { BackfillID = backfillID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BackfillServiceWithRawResponse : IBackfillServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBackfillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BackfillServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BackfillServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BackfillCreateResponse>> Create(
        BackfillCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BackfillCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var backfill = await response
                    .Deserialize<BackfillCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    backfill.Validate();
                }
                return backfill;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BackfillListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<BackfillListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BackfillListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BackfillCloseResponse>> Close(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<BackfillCloseResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BackfillCloseResponse>> Close(
        string backfillID,
        BackfillCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Close(parameters with { BackfillID = backfillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BackfillFetchResponse>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<BackfillFetchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BackfillFetchResponse>> Fetch(
        string backfillID,
        BackfillFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { BackfillID = backfillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BackfillRevertResponse>> Revert(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<BackfillRevertResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BackfillRevertResponse>> Revert(
        string backfillID,
        BackfillRevertParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Revert(parameters with { BackfillID = backfillID }, cancellationToken);
    }
}
