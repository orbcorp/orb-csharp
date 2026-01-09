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
    readonly Lazy<ICouponServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICouponServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ICouponService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CouponService(this._client.WithOptions(modifier));
    }

    public CouponService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CouponServiceWithRawResponse(client.WithRawResponse));
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
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CouponListPage> List(
        CouponListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Coupon> Archive(
        CouponArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Coupon> Archive(
        string couponID,
        CouponArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { CouponID = couponID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Coupon> Fetch(
        CouponFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Coupon> Fetch(
        string couponID,
        CouponFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { CouponID = couponID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CouponServiceWithRawResponse : ICouponServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICouponServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CouponServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CouponServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _subscriptions = new(() => new Coupons::SubscriptionServiceWithRawResponse(client));
    }

    readonly Lazy<Coupons::ISubscriptionServiceWithRawResponse> _subscriptions;
    public Coupons::ISubscriptionServiceWithRawResponse Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Coupon>> Create(
        CouponCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CouponCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var coupon = await response.Deserialize<Coupon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    coupon.Validate();
                }
                return coupon;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CouponListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<CouponListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CouponListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Coupon>> Archive(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var coupon = await response.Deserialize<Coupon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    coupon.Validate();
                }
                return coupon;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Coupon>> Archive(
        string couponID,
        CouponArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { CouponID = couponID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Coupon>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var coupon = await response.Deserialize<Coupon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    coupon.Validate();
                }
                return coupon;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Coupon>> Fetch(
        string couponID,
        CouponFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { CouponID = couponID }, cancellationToken);
    }
}
