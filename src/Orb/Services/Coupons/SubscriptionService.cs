using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Coupons.Subscriptions;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Services.Coupons;

/// <inheritdoc/>
public sealed class SubscriptionService : global::Orb.Services.Coupons.ISubscriptionService
{
    readonly Lazy<global::Orb.Services.Coupons.ISubscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public global::Orb.Services.Coupons.ISubscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public global::Orb.Services.Coupons.ISubscriptionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Orb.Services.Coupons.SubscriptionService(
            this._client.WithOptions(modifier)
        );
    }

    public SubscriptionService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new global::Orb.Services.Coupons.SubscriptionServiceWithRawResponse(
                client.WithRawResponse
            )
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListPage> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionListPage> List(
        string couponID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CouponID = couponID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SubscriptionServiceWithRawResponse
    : global::Orb.Services.Coupons.ISubscriptionServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public global::Orb.Services.Coupons.ISubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Orb.Services.Coupons.SubscriptionServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public SubscriptionServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionListPage>> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CouponID == null)
        {
            throw new OrbInvalidDataException("'parameters.CouponID' cannot be null");
        }

        HttpRequest<SubscriptionListParams> request = new()
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
                    .Deserialize<Subscriptions::SubscriptionSubscriptions>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SubscriptionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionListPage>> List(
        string couponID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CouponID = couponID }, cancellationToken);
    }
}
