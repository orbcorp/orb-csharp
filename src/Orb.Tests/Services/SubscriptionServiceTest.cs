using System;
using System.Threading.Tasks;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Services;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var subscription = await this.client.Subscriptions.Update(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Subscriptions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.Cancel(
            "subscription_id",
            new() { CancelOption = CancelOption.EndOfSubscriptionTerm },
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var subscription = await this.client.Subscriptions.Fetch(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact]
    public async Task FetchCosts_Works()
    {
        var response = await this.client.Subscriptions.FetchCosts(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task FetchSchedule_Works()
    {
        var page = await this.client.Subscriptions.FetchSchedule(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Incorrect example breaks Prism")]
    public async Task FetchUsage_Works()
    {
        var subscriptionUsage = await this.client.Subscriptions.FetchUsage(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        subscriptionUsage.Validate();
    }

    [Fact(Skip = "Incorrect example breaks Prism")]
    public async Task PriceIntervals_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.PriceIntervals(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task RedeemCoupon_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.RedeemCoupon(
            "subscription_id",
            new() { ChangeOption = ChangeOption.RequestedDate },
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task SchedulePlanChange_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.SchedulePlanChange(
            "subscription_id",
            new() { ChangeOption = SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate },
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task TriggerPhase_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.TriggerPhase(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnscheduleCancellation_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnscheduleCancellation(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnscheduleFixedFeeQuantityUpdates_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnscheduleFixedFeeQuantityUpdates(
            "subscription_id",
            new() { PriceID = "price_id" },
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnschedulePendingPlanChanges_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnschedulePendingPlanChanges(
            "subscription_id",
            new(),
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UpdateFixedFeeQuantity_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UpdateFixedFeeQuantity(
            "subscription_id",
            new() { PriceID = "price_id", Quantity = 0 },
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UpdateTrial_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UpdateTrial(
            "subscription_id",
            new() { TrialEndDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z") },
            TestContext.Current.CancellationToken
        );
        mutatedSubscription.Validate();
    }
}
