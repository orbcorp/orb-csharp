using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Coupons.Subscriptions;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Services.Coupons;

public sealed class SubscriptionService : global::Orb.Services.Coupons.ISubscriptionService
{
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

    public async Task<Subscriptions::SubscriptionsModel> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<Subscriptions::SubscriptionsModel>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
