using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.SubscriptionChanges;
using Orb.Models.Subscriptions;

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
        SubscriptionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubscriptionCreateParams> request = new()
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

    public async Task<Subscription> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscription = await response
            .Deserialize<Subscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<SubscriptionsModel> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<SubscriptionsModel>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<MutatedSubscription> Cancel(
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionCancelParams> request = new()
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

    public async Task<Subscription> Fetch(
        SubscriptionFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscription = await response
            .Deserialize<Subscription>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscription.Validate();
        }
        return subscription;
    }

    public async Task<SubscriptionFetchCostsResponse> FetchCosts(
        SubscriptionFetchCostsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionFetchCostsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SubscriptionFetchCostsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<SubscriptionFetchSchedulePageResponse> FetchSchedule(
        SubscriptionFetchScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionFetchScheduleParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<SubscriptionFetchSchedulePageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<SubscriptionUsage> FetchUsage(
        SubscriptionFetchUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionFetchUsageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscriptionUsage = await response
            .Deserialize<SubscriptionUsage>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscriptionUsage.Validate();
        }
        return subscriptionUsage;
    }

    public async Task<MutatedSubscription> PriceIntervals(
        SubscriptionPriceIntervalsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionPriceIntervalsParams> request = new()
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
        SubscriptionRedeemCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionRedeemCouponParams> request = new()
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
        SubscriptionSchedulePlanChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionSchedulePlanChangeParams> request = new()
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
        SubscriptionTriggerPhaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionTriggerPhaseParams> request = new()
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
        SubscriptionUnscheduleCancellationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionUnscheduleCancellationParams> request = new()
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
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionUnscheduleFixedFeeQuantityUpdatesParams> request = new()
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

    public async Task<MutatedSubscription> UnschedulePendingPlanChanges(
        SubscriptionUnschedulePendingPlanChangesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionUnschedulePendingPlanChangesParams> request = new()
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
        SubscriptionUpdateFixedFeeQuantityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionUpdateFixedFeeQuantityParams> request = new()
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
        SubscriptionUpdateTrialParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionUpdateTrialParams> request = new()
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
