using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.Beta;
using Orb.Models.Plans;
using ExternalPlanID = Orb.Service.Beta.ExternalPlanID;

namespace Orb.Service.Beta;

public sealed class BetaService : IBetaService
{
    readonly IOrbClient _client;

    public BetaService(IOrbClient client)
    {
        _client = client;
        _externalPlanID = new(() => new ExternalPlanID::ExternalPlanIDService(client));
    }

    readonly Lazy<ExternalPlanID::IExternalPlanIDService> _externalPlanID;
    public ExternalPlanID::IExternalPlanIDService ExternalPlanID
    {
        get { return _externalPlanID.Value; }
    }

    public async Task<PlanVersion> CreatePlanVersion(BetaCreatePlanVersionParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client))
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
        return JsonSerializer.Deserialize<PlanVersion>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task<PlanVersion> FetchPlanVersion(BetaFetchPlanVersionParams @params)
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
        return JsonSerializer.Deserialize<PlanVersion>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task<Plan> SetDefaultPlanVersion(BetaSetDefaultPlanVersionParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client))
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
}
