using Beta = Orb.Models.Beta;
using ExternalPlanID = Orb.Service.Beta.ExternalPlanID;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using Plans = Orb.Models.Plans;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Beta;

public sealed class BetaService : IBetaService
{
    readonly Orb::IOrbClient _client;

    public BetaService(Orb::IOrbClient client)
    {
        _client = client;
        _externalPlanID = new(() => new ExternalPlanID::ExternalPlanIDService(client));
    }

    readonly System::Lazy<ExternalPlanID::IExternalPlanIDService> _externalPlanID;
    public ExternalPlanID::IExternalPlanIDService ExternalPlanID
    {
        get { return _externalPlanID.Value; }
    }

    public async Tasks::Task<Beta::PlanVersion> CreatePlanVersion(
        Beta::BetaCreatePlanVersionParams @params
    )
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
        return Json::JsonSerializer.Deserialize<Beta::PlanVersion>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Beta::PlanVersion> FetchPlanVersion(
        Beta::BetaFetchPlanVersionParams @params
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
        return Json::JsonSerializer.Deserialize<Beta::PlanVersion>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Plans::Plan> SetDefaultPlanVersion(
        Beta::BetaSetDefaultPlanVersionParams @params
    )
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
        return Json::JsonSerializer.Deserialize<Plans::Plan>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
