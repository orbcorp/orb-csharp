using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.SubscriptionChanges;
using Orb.Models.Subscriptions;

namespace Orb.Services.Subscriptions;

public sealed class SubscriptionService : ISubscriptionService
{
    readonly IOrbClient _client;

    public SubscriptionService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<MutatedSubscription> Create(SubscriptionCreateParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<SubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<Subscription> Update(SubscriptionUpdateParams parameters)
    {
        HttpRequest<SubscriptionUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Subscription>().ConfigureAwait(false);
    }

    public async Task<SubscriptionsModel> List(SubscriptionListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionsModel>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> Cancel(SubscriptionCancelParams parameters)
    {
        HttpRequest<SubscriptionCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<Subscription> Fetch(SubscriptionFetchParams parameters)
    {
        HttpRequest<SubscriptionFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Subscription>().ConfigureAwait(false);
    }

    public async Task<SubscriptionFetchCostsResponse> FetchCosts(
        SubscriptionFetchCostsParams parameters
    )
    {
        HttpRequest<SubscriptionFetchCostsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionFetchCostsResponse>().ConfigureAwait(false);
    }

    public async Task<SubscriptionFetchSchedulePageResponse> FetchSchedule(
        SubscriptionFetchScheduleParams parameters
    )
    {
        HttpRequest<SubscriptionFetchScheduleParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<SubscriptionFetchSchedulePageResponse>()
            .ConfigureAwait(false);
    }

    public async Task<SubscriptionUsage> FetchUsage(SubscriptionFetchUsageParams parameters)
    {
        HttpRequest<SubscriptionFetchUsageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<SubscriptionUsage>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> PriceIntervals(
        SubscriptionPriceIntervalsParams parameters
    )
    {
        HttpRequest<SubscriptionPriceIntervalsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> RedeemCoupon(SubscriptionRedeemCouponParams parameters)
    {
        HttpRequest<SubscriptionRedeemCouponParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> SchedulePlanChange(
        SubscriptionSchedulePlanChangeParams parameters
    )
    {
        HttpRequest<SubscriptionSchedulePlanChangeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> TriggerPhase(SubscriptionTriggerPhaseParams parameters)
    {
        HttpRequest<SubscriptionTriggerPhaseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> UnscheduleCancellation(
        SubscriptionUnscheduleCancellationParams parameters
    )
    {
        HttpRequest<SubscriptionUnscheduleCancellationParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> UnscheduleFixedFeeQuantityUpdates(
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters
    )
    {
        HttpRequest<SubscriptionUnscheduleFixedFeeQuantityUpdatesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> UnschedulePendingPlanChanges(
        SubscriptionUnschedulePendingPlanChangesParams parameters
    )
    {
        HttpRequest<SubscriptionUnschedulePendingPlanChangesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> UpdateFixedFeeQuantity(
        SubscriptionUpdateFixedFeeQuantityParams parameters
    )
    {
        HttpRequest<SubscriptionUpdateFixedFeeQuantityParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }

    public async Task<MutatedSubscription> UpdateTrial(SubscriptionUpdateTrialParams parameters)
    {
        HttpRequest<SubscriptionUpdateTrialParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MutatedSubscription>().ConfigureAwait(false);
    }
}
