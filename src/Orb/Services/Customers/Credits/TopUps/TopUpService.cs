using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Services.Customers.Credits.TopUps;

public sealed class TopUpService : ITopUpService
{
    readonly IOrbClient _client;

    public TopUpService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<TopUpCreateResponse> Create(TopUpCreateParams parameters)
    {
        HttpRequest<TopUpCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<TopUpCreateResponse>().ConfigureAwait(false);
    }

    public async Task<TopUpListPageResponse> List(TopUpListParams parameters)
    {
        HttpRequest<TopUpListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<TopUpListPageResponse>().ConfigureAwait(false);
    }

    public async Task Delete(TopUpDeleteParams parameters)
    {
        HttpRequest<TopUpDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
        TopUpCreateByExternalIDParams parameters
    )
    {
        HttpRequest<TopUpCreateByExternalIDParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<TopUpCreateByExternalIDResponse>().ConfigureAwait(false);
    }

    public async Task DeleteByExternalID(TopUpDeleteByExternalIDParams parameters)
    {
        HttpRequest<TopUpDeleteByExternalIDParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<TopUpListByExternalIDPageResponse> ListByExternalID(
        TopUpListByExternalIDParams parameters
    )
    {
        HttpRequest<TopUpListByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<TopUpListByExternalIDPageResponse>()
            .ConfigureAwait(false);
    }
}
