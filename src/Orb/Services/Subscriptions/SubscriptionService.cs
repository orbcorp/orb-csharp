using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.SubscriptionChanges;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Services.Subscriptions;

public sealed class SubscriptionService : ISubscriptionService
{
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public SubscriptionService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<MutatedSubscription> Create(
        Subscriptions::SubscriptionCreateParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<Subscriptions::SubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<Subscriptions::Subscription> Update(
        Subscriptions::SubscriptionUpdateParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var subscription = await response
            .Deserialize<Subscriptions::Subscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<Subscriptions::SubscriptionsModel> List(
        Subscriptions::SubscriptionListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<Subscriptions::SubscriptionListParams> request = new()
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

    public async Task<MutatedSubscription> Cancel(
        Subscriptions::SubscriptionCancelParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<Subscriptions::Subscription> Fetch(
        Subscriptions::SubscriptionFetchParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var subscription = await response
            .Deserialize<Subscriptions::Subscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<Subscriptions::SubscriptionFetchCostsResponse> FetchCosts(
        Subscriptions::SubscriptionFetchCostsParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionFetchCostsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Subscriptions::SubscriptionFetchCostsResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Subscriptions::SubscriptionFetchSchedulePageResponse> FetchSchedule(
        Subscriptions::SubscriptionFetchScheduleParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionFetchScheduleParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<Subscriptions::SubscriptionFetchSchedulePageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Subscriptions::SubscriptionUsage> FetchUsage(
        Subscriptions::SubscriptionFetchUsageParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionFetchUsageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var subscriptionUsage = await response
            .Deserialize<Subscriptions::SubscriptionUsage>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscriptionUsage.Validate();
        }
        return subscriptionUsage;
    }

    public async Task<MutatedSubscription> PriceIntervals(
        Subscriptions::SubscriptionPriceIntervalsParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionPriceIntervalsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> RedeemCoupon(
        Subscriptions::SubscriptionRedeemCouponParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionRedeemCouponParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> SchedulePlanChange(
        Subscriptions::SubscriptionSchedulePlanChangeParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionSchedulePlanChangeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> TriggerPhase(
        Subscriptions::SubscriptionTriggerPhaseParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionTriggerPhaseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UnscheduleCancellation(
        Subscriptions::SubscriptionUnscheduleCancellationParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionUnscheduleCancellationParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UnscheduleFixedFeeQuantityUpdates(
        Subscriptions::SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionUnscheduleFixedFeeQuantityUpdatesParams> request =
            new() { Method = HttpMethod.Post, Params = parameters };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UnschedulePendingPlanChanges(
        Subscriptions::SubscriptionUnschedulePendingPlanChangesParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionUnschedulePendingPlanChangesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UpdateFixedFeeQuantity(
        Subscriptions::SubscriptionUpdateFixedFeeQuantityParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionUpdateFixedFeeQuantityParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UpdateTrial(
        Subscriptions::SubscriptionUpdateTrialParams parameters
    )
    {
        HttpRequest<Subscriptions::SubscriptionUpdateTrialParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }
}
