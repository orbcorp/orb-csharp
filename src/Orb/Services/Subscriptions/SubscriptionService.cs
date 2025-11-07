using System;
using System.Net.Http;
using System.Threading;
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
        Subscriptions::SubscriptionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Subscriptions::SubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<Subscriptions::Subscription> Update(
        Subscriptions::SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscription = await response
            .Deserialize<Subscriptions::Subscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<Subscriptions::SubscriptionsModel> List(
        Subscriptions::SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Subscriptions::SubscriptionListParams> request = new()
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

    public async Task<MutatedSubscription> Cancel(
        Subscriptions::SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<Subscriptions::Subscription> Fetch(
        Subscriptions::SubscriptionFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscription = await response
            .Deserialize<Subscriptions::Subscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<Subscriptions::SubscriptionFetchCostsResponse> FetchCosts(
        Subscriptions::SubscriptionFetchCostsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionFetchCostsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Subscriptions::SubscriptionFetchCostsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Subscriptions::SubscriptionFetchSchedulePageResponse> FetchSchedule(
        Subscriptions::SubscriptionFetchScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionFetchScheduleParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<Subscriptions::SubscriptionFetchSchedulePageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Subscriptions::SubscriptionUsage> FetchUsage(
        Subscriptions::SubscriptionFetchUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionFetchUsageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscriptionUsage = await response
            .Deserialize<Subscriptions::SubscriptionUsage>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscriptionUsage.Validate();
        }
        return subscriptionUsage;
    }

    public async Task<MutatedSubscription> PriceIntervals(
        Subscriptions::SubscriptionPriceIntervalsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionPriceIntervalsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> RedeemCoupon(
        Subscriptions::SubscriptionRedeemCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionRedeemCouponParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> SchedulePlanChange(
        Subscriptions::SubscriptionSchedulePlanChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionSchedulePlanChangeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> TriggerPhase(
        Subscriptions::SubscriptionTriggerPhaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionTriggerPhaseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UnscheduleCancellation(
        Subscriptions::SubscriptionUnscheduleCancellationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionUnscheduleCancellationParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UnscheduleFixedFeeQuantityUpdates(
        Subscriptions::SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionUnscheduleFixedFeeQuantityUpdatesParams> request =
            new() { Method = HttpMethod.Post, Params = parameters };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UnschedulePendingPlanChanges(
        Subscriptions::SubscriptionUnschedulePendingPlanChangesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionUnschedulePendingPlanChangesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UpdateFixedFeeQuantity(
        Subscriptions::SubscriptionUpdateFixedFeeQuantityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionUpdateFixedFeeQuantityParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }

    public async Task<MutatedSubscription> UpdateTrial(
        Subscriptions::SubscriptionUpdateTrialParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Subscriptions::SubscriptionUpdateTrialParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var mutatedSubscription = await response
            .Deserialize<MutatedSubscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            mutatedSubscription.Validate();
        }
        return mutatedSubscription;
    }
}
