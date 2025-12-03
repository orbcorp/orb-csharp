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
    /// <inheritdoc/>
    public IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public EventService(IOrbClient client)
    {
        _client = client;
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
        if (parameters.EventID == null)
        {
            throw new OrbInvalidDataException("'parameters.EventID' cannot be null");
        }

        HttpRequest<EventUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<EventUpdateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<EventUpdateResponse> Update(
        string eventID,
        EventUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Update(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventDeprecateResponse> Deprecate(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<EventDeprecateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<EventDeprecateResponse> Deprecate(
        string eventID,
        EventDeprecateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Deprecate(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventIngestResponse> Ingest(
        EventIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EventIngestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<EventIngestResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<EventSearchResponse> Search(
        EventSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EventSearchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<EventSearchResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
