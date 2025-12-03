using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Coupons;
using Coupons = Orb.Services.Coupons;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class CouponService : ICouponService
{
    /// <inheritdoc/>
    public ICouponService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CouponService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public CouponService(IOrbClient client)
    {
        _client = client;
        _subscriptions = new(() => new Coupons::SubscriptionService(client));
    }

    readonly Lazy<Coupons::ISubscriptionService> _subscriptions;
    public Coupons::ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<Coupon> Archive(
        CouponArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CouponID == null)
        {
            throw new OrbInvalidDataException("'parameters.CouponID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<Coupon> Archive(
        string couponID,
        CouponArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Archive(parameters with { CouponID = couponID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Coupon> Fetch(
        CouponFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CouponID == null)
        {
            throw new OrbInvalidDataException("'parameters.CouponID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<Coupon> Fetch(
        string couponID,
        CouponFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(parameters with { CouponID = couponID }, cancellationToken);
    }
}
