using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.SubscriptionChanges;
using Orb.Models.Subscriptions;

namespace Orb.Services;

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
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<Subscription> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<SubscriptionSubscriptions> List(
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
            .Deserialize<SubscriptionSubscriptions>(cancellationToken)
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
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> Cancel(
        string subscriptionID,
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Cancel(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<Subscription> Fetch(
        SubscriptionFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<Subscription> Fetch(
        string subscriptionID,
        SubscriptionFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<SubscriptionFetchCostsResponse> FetchCosts(
        SubscriptionFetchCostsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<SubscriptionFetchCostsResponse> FetchCosts(
        string subscriptionID,
        SubscriptionFetchCostsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.FetchCosts(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<SubscriptionFetchSchedulePageResponse> FetchSchedule(
        SubscriptionFetchScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<SubscriptionFetchSchedulePageResponse> FetchSchedule(
        string subscriptionID,
        SubscriptionFetchScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.FetchSchedule(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<SubscriptionUsage> FetchUsage(
        SubscriptionFetchUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<SubscriptionUsage> FetchUsage(
        string subscriptionID,
        SubscriptionFetchUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.FetchUsage(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> PriceIntervals(
        SubscriptionPriceIntervalsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> PriceIntervals(
        string subscriptionID,
        SubscriptionPriceIntervalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.PriceIntervals(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> RedeemCoupon(
        SubscriptionRedeemCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> RedeemCoupon(
        string subscriptionID,
        SubscriptionRedeemCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.RedeemCoupon(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> SchedulePlanChange(
        SubscriptionSchedulePlanChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> SchedulePlanChange(
        string subscriptionID,
        SubscriptionSchedulePlanChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.SchedulePlanChange(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> TriggerPhase(
        SubscriptionTriggerPhaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> TriggerPhase(
        string subscriptionID,
        SubscriptionTriggerPhaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.TriggerPhase(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> UnscheduleCancellation(
        SubscriptionUnscheduleCancellationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> UnscheduleCancellation(
        string subscriptionID,
        SubscriptionUnscheduleCancellationParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.UnscheduleCancellation(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> UnscheduleFixedFeeQuantityUpdates(
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> UnscheduleFixedFeeQuantityUpdates(
        string subscriptionID,
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.UnscheduleFixedFeeQuantityUpdates(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> UnschedulePendingPlanChanges(
        SubscriptionUnschedulePendingPlanChangesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> UnschedulePendingPlanChanges(
        string subscriptionID,
        SubscriptionUnschedulePendingPlanChangesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.UnschedulePendingPlanChanges(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> UpdateFixedFeeQuantity(
        SubscriptionUpdateFixedFeeQuantityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> UpdateFixedFeeQuantity(
        string subscriptionID,
        SubscriptionUpdateFixedFeeQuantityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.UpdateFixedFeeQuantity(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    public async Task<MutatedSubscription> UpdateTrial(
        SubscriptionUpdateTrialParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

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

    public async Task<MutatedSubscription> UpdateTrial(
        string subscriptionID,
        SubscriptionUpdateTrialParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.UpdateTrial(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }
}
