using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.SubscriptionChanges;
using Orb.Models.Subscriptions;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class SubscriptionService : ISubscriptionService
{
    readonly Lazy<ISubscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    public SubscriptionService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SubscriptionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> Create(
        SubscriptionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Subscription> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Subscription> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListPage> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> Cancel(
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> Cancel(
        string subscriptionID,
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Cancel(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Subscription> Fetch(
        SubscriptionFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Subscription> Fetch(
        string subscriptionID,
        SubscriptionFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionFetchCostsResponse> FetchCosts(
        SubscriptionFetchCostsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FetchCosts(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionFetchCostsResponse> FetchCosts(
        string subscriptionID,
        SubscriptionFetchCostsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchCosts(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionFetchSchedulePage> FetchSchedule(
        SubscriptionFetchScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FetchSchedule(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionFetchSchedulePage> FetchSchedule(
        string subscriptionID,
        SubscriptionFetchScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchSchedule(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionUsage> FetchUsage(
        SubscriptionFetchUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FetchUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionUsage> FetchUsage(
        string subscriptionID,
        SubscriptionFetchUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchUsage(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> PriceIntervals(
        SubscriptionPriceIntervalsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.PriceIntervals(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> PriceIntervals(
        string subscriptionID,
        SubscriptionPriceIntervalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PriceIntervals(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> RedeemCoupon(
        SubscriptionRedeemCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RedeemCoupon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> RedeemCoupon(
        string subscriptionID,
        SubscriptionRedeemCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RedeemCoupon(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> SchedulePlanChange(
        SubscriptionSchedulePlanChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SchedulePlanChange(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> SchedulePlanChange(
        string subscriptionID,
        SubscriptionSchedulePlanChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SchedulePlanChange(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> TriggerPhase(
        SubscriptionTriggerPhaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TriggerPhase(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> TriggerPhase(
        string subscriptionID,
        SubscriptionTriggerPhaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TriggerPhase(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> UnscheduleCancellation(
        SubscriptionUnscheduleCancellationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UnscheduleCancellation(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> UnscheduleCancellation(
        string subscriptionID,
        SubscriptionUnscheduleCancellationParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UnscheduleCancellation(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> UnscheduleFixedFeeQuantityUpdates(
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UnscheduleFixedFeeQuantityUpdates(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> UnscheduleFixedFeeQuantityUpdates(
        string subscriptionID,
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UnscheduleFixedFeeQuantityUpdates(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> UnschedulePendingPlanChanges(
        SubscriptionUnschedulePendingPlanChangesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UnschedulePendingPlanChanges(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> UnschedulePendingPlanChanges(
        string subscriptionID,
        SubscriptionUnschedulePendingPlanChangesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UnschedulePendingPlanChanges(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> UpdateFixedFeeQuantity(
        SubscriptionUpdateFixedFeeQuantityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateFixedFeeQuantity(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> UpdateFixedFeeQuantity(
        string subscriptionID,
        SubscriptionUpdateFixedFeeQuantityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateFixedFeeQuantity(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MutatedSubscription> UpdateTrial(
        SubscriptionUpdateTrialParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateTrial(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MutatedSubscription> UpdateTrial(
        string subscriptionID,
        SubscriptionUpdateTrialParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateTrial(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class SubscriptionServiceWithRawResponse : ISubscriptionServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubscriptionServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> Create(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Subscription>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<Subscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Subscription>> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SubscriptionSubscriptions>(token)
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
    public async Task<HttpResponse<MutatedSubscription>> Cancel(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> Cancel(
        string subscriptionID,
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Cancel(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Subscription>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<Subscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Subscription>> Fetch(
        string subscriptionID,
        SubscriptionFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { SubscriptionID = subscriptionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionFetchCostsResponse>> FetchCosts(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SubscriptionFetchCostsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionFetchCostsResponse>> FetchCosts(
        string subscriptionID,
        SubscriptionFetchCostsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchCosts(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionFetchSchedulePage>> FetchSchedule(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SubscriptionFetchSchedulePageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SubscriptionFetchSchedulePage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionFetchSchedulePage>> FetchSchedule(
        string subscriptionID,
        SubscriptionFetchScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchSchedule(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionUsage>> FetchUsage(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscriptionUsage = await response
                    .Deserialize<SubscriptionUsage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscriptionUsage.Validate();
                }
                return subscriptionUsage;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionUsage>> FetchUsage(
        string subscriptionID,
        SubscriptionFetchUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchUsage(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> PriceIntervals(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> PriceIntervals(
        string subscriptionID,
        SubscriptionPriceIntervalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PriceIntervals(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> RedeemCoupon(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> RedeemCoupon(
        string subscriptionID,
        SubscriptionRedeemCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RedeemCoupon(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> SchedulePlanChange(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> SchedulePlanChange(
        string subscriptionID,
        SubscriptionSchedulePlanChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SchedulePlanChange(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> TriggerPhase(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> TriggerPhase(
        string subscriptionID,
        SubscriptionTriggerPhaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TriggerPhase(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> UnscheduleCancellation(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> UnscheduleCancellation(
        string subscriptionID,
        SubscriptionUnscheduleCancellationParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UnscheduleCancellation(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> UnscheduleFixedFeeQuantityUpdates(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> UnscheduleFixedFeeQuantityUpdates(
        string subscriptionID,
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UnscheduleFixedFeeQuantityUpdates(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> UnschedulePendingPlanChanges(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> UnschedulePendingPlanChanges(
        string subscriptionID,
        SubscriptionUnschedulePendingPlanChangesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UnschedulePendingPlanChanges(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> UpdateFixedFeeQuantity(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> UpdateFixedFeeQuantity(
        string subscriptionID,
        SubscriptionUpdateFixedFeeQuantityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateFixedFeeQuantity(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MutatedSubscription>> UpdateTrial(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mutatedSubscription = await response
                    .Deserialize<MutatedSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mutatedSubscription.Validate();
                }
                return mutatedSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MutatedSubscription>> UpdateTrial(
        string subscriptionID,
        SubscriptionUpdateTrialParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateTrial(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }
}
