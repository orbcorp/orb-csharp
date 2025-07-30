using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.Plans;
using Orb.Models.Plans.ExternalPlanID;

namespace Orb.Service.Plans.ExternalPlanID;

public sealed class ExternalPlanIDService : IExternalPlanIDService
{
    readonly IOrbClient _client;

    public ExternalPlanIDService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Plan> Update(ExternalPlanIDUpdateParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Put, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
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
        return JsonSerializer.Deserialize<Plan>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task<Plan> Fetch(ExternalPlanIDFetchParams @params)
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
        return JsonSerializer.Deserialize<Plan>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }
}
