using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Coupons;
using Orb.Services.Coupons.Subscriptions;

namespace Orb.Services.Coupons;

public sealed class CouponService : ICouponService
{
    public ICouponService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CouponService(this._client.WithOptions(modifier));
    }

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

    public async Task<Coupon> Create(
        CouponCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CouponCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var coupon = await response.Deserialize<Coupon>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            coupon.Validate();
        }
        return coupon;
    }

    public async Task<CouponListPageResponse> List(
        CouponListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CouponListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<CouponListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Coupon> Archive(
        CouponArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CouponArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var coupon = await response.Deserialize<Coupon>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            coupon.Validate();
        }
        return coupon;
    }

    public async Task<Coupon> Fetch(
        CouponFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CouponFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var coupon = await response.Deserialize<Coupon>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            coupon.Validate();
        }
        return coupon;
    }
}
