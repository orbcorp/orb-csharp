using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using SubscriptionChanges = Orb.Models.SubscriptionChanges;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.SubscriptionChanges;

public sealed class SubscriptionChangeService : ISubscriptionChangeService
{
    readonly Orb::IOrbClient _client;

    public SubscriptionChangeService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<SubscriptionChanges::SubscriptionChangeRetrieveResponse> Retrieve(
        SubscriptionChanges::SubscriptionChangeRetrieveParams @params
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
        return Json::JsonSerializer.Deserialize<SubscriptionChanges::SubscriptionChangeRetrieveResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<SubscriptionChanges::SubscriptionChangeApplyResponse> Apply(
        SubscriptionChanges::SubscriptionChangeApplyParams @params
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
        return Json::JsonSerializer.Deserialize<SubscriptionChanges::SubscriptionChangeApplyResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<SubscriptionChanges::SubscriptionChangeCancelResponse> Cancel(
        SubscriptionChanges::SubscriptionChangeCancelParams @params
    )
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Post, @params.Url(this._client));
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
        return Json::JsonSerializer.Deserialize<SubscriptionChanges::SubscriptionChangeCancelResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
