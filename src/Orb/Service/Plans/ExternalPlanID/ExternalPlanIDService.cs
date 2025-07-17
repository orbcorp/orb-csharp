using ExternalPlanID = Orb.Models.Plans.ExternalPlanID;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using Plans = Orb.Models.Plans;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Plans.ExternalPlanID;

public sealed class ExternalPlanIDService : IExternalPlanIDService
{
    readonly Orb::IOrbClient _client;

    public ExternalPlanIDService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<Plans::Plan> Update(ExternalPlanID::ExternalPlanIDUpdateParams @params)
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
        return Json::JsonSerializer.Deserialize<Plans::Plan>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Plans::Plan> Fetch(ExternalPlanID::ExternalPlanIDFetchParams @params)
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
        return Json::JsonSerializer.Deserialize<Plans::Plan>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
