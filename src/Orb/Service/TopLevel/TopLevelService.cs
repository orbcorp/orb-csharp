using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;
using TopLevel = Orb.Models.TopLevel;

namespace Orb.Service.TopLevel;

public sealed class TopLevelService : ITopLevelService
{
    readonly Orb::IOrbClient _client;

    public TopLevelService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<TopLevel::TopLevelPingResponse> Ping(
        TopLevel::TopLevelPingParams @params
    )
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
        return Json::JsonSerializer.Deserialize<TopLevel::TopLevelPingResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
