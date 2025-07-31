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
        using HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<EventVolumes>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
