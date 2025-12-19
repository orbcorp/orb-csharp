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
    /// <inheritdoc/>
    public global::Orb.Services.Coupons.ISubscriptionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Orb.Services.Coupons.SubscriptionService(
            this._client.WithOptions(modifier)
        );
    }

    readonly IOrbClient _client;

    public SubscriptionService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListPage> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<Subscriptions::SubscriptionSubscriptions>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new SubscriptionListPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListPage> List(
        string couponID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { CouponID = couponID }, cancellationToken);
    }
}
