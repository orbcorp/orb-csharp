using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Service.Customers.Credits.Ledger;

public sealed class LedgerService : ILedgerService
{
    readonly IOrbClient _client;

    public LedgerService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<LedgerListPageResponse> List(LedgerListParams @params)
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
        return JsonSerializer.Deserialize<LedgerListPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task<LedgerCreateEntryResponse> CreateEntry(LedgerCreateEntryParams @params)
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
        return JsonSerializer.Deserialize<LedgerCreateEntryResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task<LedgerCreateEntryByExternalIDResponse> CreateEntryByExternalID(
        LedgerCreateEntryByExternalIDParams @params
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
        return JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task<LedgerListByExternalIDPageResponse> ListByExternalID(
        LedgerListByExternalIDParams @params
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
        return JsonSerializer.Deserialize<LedgerListByExternalIDPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }
}
