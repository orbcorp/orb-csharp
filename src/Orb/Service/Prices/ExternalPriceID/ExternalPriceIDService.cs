using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Service.Prices.ExternalPriceID;

public sealed class ExternalPriceIDService : IExternalPriceIDService
{
    readonly IOrbClient _client;

    public ExternalPriceIDService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Price> Update(ExternalPriceIDUpdateParams @params)
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
        return JsonSerializer.Deserialize<Price>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<Price> Fetch(ExternalPriceIDFetchParams @params)
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
        return JsonSerializer.Deserialize<Price>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
