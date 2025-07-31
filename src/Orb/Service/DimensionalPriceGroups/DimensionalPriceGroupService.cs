using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.DimensionalPriceGroups;
using ExternalDimensionalPriceGroupID = Orb.Service.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Service.DimensionalPriceGroups;

public sealed class DimensionalPriceGroupService : IDimensionalPriceGroupService
{
    readonly IOrbClient _client;

    public DimensionalPriceGroupService(IOrbClient client)
    {
        _client = client;
        _externalDimensionalPriceGroupID = new(() =>
            new ExternalDimensionalPriceGroupID::ExternalDimensionalPriceGroupIDService(client)
        );
    }

    readonly Lazy<ExternalDimensionalPriceGroupID::IExternalDimensionalPriceGroupIDService> _externalDimensionalPriceGroupID;
    public ExternalDimensionalPriceGroupID::IExternalDimensionalPriceGroupIDService ExternalDimensionalPriceGroupID
    {
        get { return _externalDimensionalPriceGroupID.Value; }
    }

    public async Task<DimensionalPriceGroup> Create(DimensionalPriceGroupCreateParams @params)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<DimensionalPriceGroup>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<DimensionalPriceGroup> Retrieve(DimensionalPriceGroupRetrieveParams @params)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<DimensionalPriceGroup>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<DimensionalPriceGroup> Update(DimensionalPriceGroupUpdateParams @params)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Put, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<DimensionalPriceGroup>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<DimensionalPriceGroups> List(DimensionalPriceGroupListParams @params)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<DimensionalPriceGroups>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
