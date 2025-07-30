using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using Subscriptions = Orb.Models.Coupons.Subscriptions;
using Subscriptions1 = Orb.Models.Subscriptions;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Coupons.Subscriptions;

public sealed class SubscriptionService : ISubscriptionService
{
    readonly Orb::IOrbClient _client;

    public SubscriptionService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<Subscriptions1::Subscriptions> List(
        Subscriptions::SubscriptionListParams @params
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
        return Json::JsonSerializer.Deserialize<Subscriptions1::Subscriptions>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
