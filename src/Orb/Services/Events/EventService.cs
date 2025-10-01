using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Events;
using Orb.Services.Events.Backfills;
using Orb.Services.Events.Volume;

namespace Orb.Services.Events;

public sealed class EventService : IEventService
{
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

    public async Task<EventUpdateResponse> Update(EventUpdateParams parameters)
    {
        HttpRequest<EventUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<EventUpdateResponse>().ConfigureAwait(false);
    }

    public async Task<EventDeprecateResponse> Deprecate(EventDeprecateParams parameters)
    {
        HttpRequest<EventDeprecateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<EventDeprecateResponse>().ConfigureAwait(false);
    }

    public async Task<EventIngestResponse> Ingest(EventIngestParams parameters)
    {
        HttpRequest<EventIngestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<EventIngestResponse>().ConfigureAwait(false);
    }

    public async Task<EventSearchResponse> Search(EventSearchParams parameters)
    {
        HttpRequest<EventSearchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<EventSearchResponse>().ConfigureAwait(false);
    }
}
