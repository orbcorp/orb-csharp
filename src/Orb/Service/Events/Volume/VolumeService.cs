using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;
using Volume = Orb.Models.Events.Volume;

namespace Orb.Service.Events.Volume;

public sealed class VolumeService : IVolumeService
{
    readonly Orb::IOrbClient _client;

    public VolumeService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<Volume::EventVolumes> List(Volume::VolumeListParams @params)
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Get, @params.Url(this._client));
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
        return Json::JsonSerializer.Deserialize<Volume::EventVolumes>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
