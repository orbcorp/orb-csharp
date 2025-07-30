using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Service.Customers.Credits.TopUps;

public sealed class TopUpService : ITopUpService
{
    readonly IOrbClient _client;

    public TopUpService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<TopUpCreateResponse> Create(TopUpCreateParams @params)
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
        return JsonSerializer.Deserialize<TopUpCreateResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task<TopUpListPageResponse> List(TopUpListParams @params)
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
        return JsonSerializer.Deserialize<TopUpListPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task Delete(TopUpDeleteParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Delete, @params.Url(this._client));
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
    }

    public async Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
        TopUpCreateByExternalIDParams @params
    )
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
        return JsonSerializer.Deserialize<TopUpCreateByExternalIDResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task DeleteByExternalID(TopUpDeleteByExternalIDParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Delete, @params.Url(this._client));
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
    }

    public async Task<TopUpListByExternalIDPageResponse> ListByExternalID(
        TopUpListByExternalIDParams @params
    )
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
        return JsonSerializer.Deserialize<TopUpListByExternalIDPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }
}
