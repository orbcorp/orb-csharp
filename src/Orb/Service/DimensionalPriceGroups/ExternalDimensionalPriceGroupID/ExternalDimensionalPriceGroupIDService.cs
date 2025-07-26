using DimensionalPriceGroups = Orb.Models.DimensionalPriceGroups;
using ExternalDimensionalPriceGroupID = Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public sealed class ExternalDimensionalPriceGroupIDService : IExternalDimensionalPriceGroupIDService
{
    readonly Orb::IOrbClient _client;

    public ExternalDimensionalPriceGroupIDService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<DimensionalPriceGroups::DimensionalPriceGroup> Retrieve(
        ExternalDimensionalPriceGroupID::ExternalDimensionalPriceGroupIDRetrieveParams @params
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
        return Json::JsonSerializer.Deserialize<DimensionalPriceGroups::DimensionalPriceGroup>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<DimensionalPriceGroups::DimensionalPriceGroup> Update(
        ExternalDimensionalPriceGroupID::ExternalDimensionalPriceGroupIDUpdateParams @params
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
        return Json::JsonSerializer.Deserialize<DimensionalPriceGroups::DimensionalPriceGroup>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
