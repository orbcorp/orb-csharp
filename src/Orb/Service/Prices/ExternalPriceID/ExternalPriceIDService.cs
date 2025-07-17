using ExternalPriceID = Orb.Models.Prices.ExternalPriceID;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Prices.ExternalPriceID;

public sealed class ExternalPriceIDService : IExternalPriceIDService
{
    readonly Orb::IOrbClient _client;

    public ExternalPriceIDService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<Models::Price> Update(
        ExternalPriceID::ExternalPriceIDUpdateParams @params
    )
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
        return Json::JsonSerializer.Deserialize<Models::Price>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Models::Price> Fetch(
        ExternalPriceID::ExternalPriceIDFetchParams @params
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
        return Json::JsonSerializer.Deserialize<Models::Price>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
