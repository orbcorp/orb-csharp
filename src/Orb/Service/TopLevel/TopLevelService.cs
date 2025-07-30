using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.TopLevel;

namespace Orb.Service.TopLevel;

public sealed class TopLevelService : ITopLevelService
{
    readonly IOrbClient _client;

    public TopLevelService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<TopLevelPingResponse> Ping(TopLevelPingParams @params)
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
        return JsonSerializer.Deserialize<TopLevelPingResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }
}
