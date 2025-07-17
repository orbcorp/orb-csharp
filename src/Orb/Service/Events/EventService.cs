using Backfills = Orb.Service.Events.Backfills;
using Events = Orb.Models.Events;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;
using Volume = Orb.Service.Events.Volume;

namespace Orb.Service.Events;

public sealed class EventService : IEventService
{
    readonly Orb::IOrbClient _client;

    public EventService(Orb::IOrbClient client)
    {
        _client = client;
        _backfills = new(() => new Backfills::BackfillService(client));
        _volume = new(() => new Volume::VolumeService(client));
    }

    readonly System::Lazy<Backfills::IBackfillService> _backfills;
    public Backfills::IBackfillService Backfills
    {
        get { return _backfills.Value; }
    }

    readonly System::Lazy<Volume::IVolumeService> _volume;
    public Volume::IVolumeService Volume
    {
        get { return _volume.Value; }
    }

    public async Tasks::Task<Events::EventUpdateResponse> Update(Events::EventUpdateParams @params)
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Put, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Events::EventUpdateResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Events::EventDeprecateResponse> Deprecate(
        Events::EventDeprecateParams @params
    )
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Put, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Events::EventDeprecateResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Events::EventIngestResponse> Ingest(Events::EventIngestParams @params)
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Events::EventIngestResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Events::EventSearchResponse> Search(Events::EventSearchParams @params)
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Events::EventSearchResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
