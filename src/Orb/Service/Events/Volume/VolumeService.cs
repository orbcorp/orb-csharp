using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.Events.Volume;

namespace Orb.Service.Events.Volume;

public sealed class VolumeService : IVolumeService
{
    readonly IOrbClient _client;

    public VolumeService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<EventVolumes> List(VolumeListParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<EventVolumes>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }
}
