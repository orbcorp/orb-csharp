using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Coupons.Subscriptions;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Services.Coupons.Subscriptions;

public sealed class SubscriptionService : ISubscriptionService
{
    readonly IOrbClient _client;

    public SubscriptionService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Subscriptions::SubscriptionsModel> List(SubscriptionListParams parameters)
    {
        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<Subscriptions::SubscriptionsModel>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
