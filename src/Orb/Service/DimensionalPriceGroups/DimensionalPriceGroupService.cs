using DimensionalPriceGroups = Orb.Models.DimensionalPriceGroups;
using ExternalDimensionalPriceGroupID = Orb.Service.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.DimensionalPriceGroups;

public sealed class DimensionalPriceGroupService : IDimensionalPriceGroupService
{
    readonly Orb::IOrbClient _client;

    public DimensionalPriceGroupService(Orb::IOrbClient client)
    {
        _client = client;
        _externalDimensionalPriceGroupID = new(() =>
            new ExternalDimensionalPriceGroupID::ExternalDimensionalPriceGroupIDService(client)
        );
    }

    readonly System::Lazy<ExternalDimensionalPriceGroupID::IExternalDimensionalPriceGroupIDService> _externalDimensionalPriceGroupID;
    public ExternalDimensionalPriceGroupID::IExternalDimensionalPriceGroupIDService ExternalDimensionalPriceGroupID
    {
        get { return _externalDimensionalPriceGroupID.Value; }
    }

    public async Tasks::Task<DimensionalPriceGroups::DimensionalPriceGroup> Create(
        DimensionalPriceGroups::DimensionalPriceGroupCreateParams @params
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
        return Json::JsonSerializer.Deserialize<DimensionalPriceGroups::DimensionalPriceGroup>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<DimensionalPriceGroups::DimensionalPriceGroup> Retrieve(
        DimensionalPriceGroups::DimensionalPriceGroupRetrieveParams @params
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

    public async Tasks::Task<DimensionalPriceGroups::DimensionalPriceGroups> List(
        DimensionalPriceGroups::DimensionalPriceGroupListParams @params
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
        return Json::JsonSerializer.Deserialize<DimensionalPriceGroups::DimensionalPriceGroups>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
