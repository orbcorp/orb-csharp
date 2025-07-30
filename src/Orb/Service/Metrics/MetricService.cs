using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.Metrics;

namespace Orb.Service.Metrics;

public sealed class MetricService : IMetricService
{
    readonly IOrbClient _client;

    public MetricService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<BillableMetric> Create(MetricCreateParams @params)
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
        return JsonSerializer.Deserialize<BillableMetric>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task<BillableMetric> Update(MetricUpdateParams @params)
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
        return JsonSerializer.Deserialize<BillableMetric>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task<MetricListPageResponse> List(MetricListParams @params)
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
        return JsonSerializer.Deserialize<MetricListPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task<BillableMetric> Fetch(MetricFetchParams @params)
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
        return JsonSerializer.Deserialize<BillableMetric>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }
}
