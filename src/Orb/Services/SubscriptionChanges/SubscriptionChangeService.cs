using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.SubscriptionChanges;

namespace Orb.Services.SubscriptionChanges;

public sealed class SubscriptionChangeService : ISubscriptionChangeService
{
    readonly IOrbClient _client;

    public SubscriptionChangeService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<SubscriptionChangeRetrieveResponse> Retrieve(
        SubscriptionChangeRetrieveParams parameters
    )
    {
        HttpRequest<SubscriptionChangeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<SubscriptionChangeRetrieveResponse>()
            .ConfigureAwait(false);
    }

    public async Task<SubscriptionChangeApplyResponse> Apply(
        SubscriptionChangeApplyParams parameters
    )
    {
        HttpRequest<SubscriptionChangeApplyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionChangeApplyResponse>().ConfigureAwait(false);
    }

    public async Task<SubscriptionChangeCancelResponse> Cancel(
        SubscriptionChangeCancelParams parameters
    )
    {
        HttpRequest<SubscriptionChangeCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionChangeCancelResponse>().ConfigureAwait(false);
    }
}
