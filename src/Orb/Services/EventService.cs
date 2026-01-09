using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Events;
using Orb.Services.Events;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class EventService : IEventService
{
    readonly Lazy<IEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventService(this._client.WithOptions(modifier));
    }

    public EventService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EventServiceWithRawResponse(client.WithRawResponse));
        _backfills = new(() => new BackfillService(client));
        _volume = new(() => new VolumeService(client));
    }

    readonly Lazy<IBackfillService> _backfills;
    public IBackfillService Backfills
    {
        get { return _backfills.Value; }
    }

    readonly Lazy<IVolumeService> _volume;
    public IVolumeService Volume
    {
        get { return _volume.Value; }
    }

    /// <inheritdoc/>
    public async Task<EventUpdateResponse> Update(
        EventUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventUpdateResponse> Update(
        string eventID,
        EventUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventDeprecateResponse> Deprecate(
        EventDeprecateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deprecate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventDeprecateResponse> Deprecate(
        string eventID,
        EventDeprecateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deprecate(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventIngestResponse> Ingest(
        EventIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Ingest(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EventSearchResponse> Search(
        EventSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EventServiceWithRawResponse : IEventServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _backfills = new(() => new BackfillServiceWithRawResponse(client));
        _volume = new(() => new VolumeServiceWithRawResponse(client));
    }

    readonly Lazy<IBackfillServiceWithRawResponse> _backfills;
    public IBackfillServiceWithRawResponse Backfills
    {
        get { return _backfills.Value; }
    }

    readonly Lazy<IVolumeServiceWithRawResponse> _volume;
    public IVolumeServiceWithRawResponse Volume
    {
        get { return _volume.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventUpdateResponse>> Update(
        EventUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new OrbInvalidDataException("'parameters.EventID' cannot be null");
        }

        HttpRequest<EventUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<EventUpdateResponse>(token)
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
    public Task<HttpResponse<EventUpdateResponse>> Update(
        string eventID,
        EventUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventDeprecateResponse>> Deprecate(
        EventDeprecateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new OrbInvalidDataException("'parameters.EventID' cannot be null");
        }

        HttpRequest<EventDeprecateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<EventDeprecateResponse>(token)
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
    public Task<HttpResponse<EventDeprecateResponse>> Deprecate(
        string eventID,
        EventDeprecateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deprecate(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventIngestResponse>> Ingest(
        EventIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EventIngestParams> request = new()
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
                    .Deserialize<EventIngestResponse>(token)
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
    public async Task<HttpResponse<EventSearchResponse>> Search(
        EventSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EventSearchParams> request = new()
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
                    .Deserialize<EventSearchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
