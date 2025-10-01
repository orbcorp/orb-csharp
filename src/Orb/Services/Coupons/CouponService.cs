using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Coupons;
using Orb.Services.Coupons.Subscriptions;

namespace Orb.Services.Coupons;

public sealed class CouponService : ICouponService
{
    readonly IOrbClient _client;

    public CouponService(IOrbClient client)
    {
        _client = client;
        _subscriptions = new(() => new SubscriptionService(client));
    }

    readonly Lazy<ISubscriptionService> _subscriptions;
    public ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    public async Task<Coupon> Create(CouponCreateParams parameters)
    {
        HttpRequest<CouponCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Coupon>().ConfigureAwait(false);
    }

    public async Task<CouponListPageResponse> List(CouponListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<CouponListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<CouponListPageResponse>().ConfigureAwait(false);
    }

    public async Task<Coupon> Archive(CouponArchiveParams parameters)
    {
        HttpRequest<CouponArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Coupon>().ConfigureAwait(false);
    }

    public async Task<Coupon> Fetch(CouponFetchParams parameters)
    {
        HttpRequest<CouponFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Coupon>().ConfigureAwait(false);
    }
}
