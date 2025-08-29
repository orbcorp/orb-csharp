using System;
using System.Threading.Tasks;
using Orb.Models.Subscriptions.SubscriptionCancelParamsProperties;
using Orb.Models.Subscriptions.SubscriptionRedeemCouponParamsProperties;
using SubscriptionSchedulePlanChangeParamsProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

namespace Orb.Tests.Services.Subscriptions;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.Create();
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var subscription = await this.client.Subscriptions.Update(
            new() { SubscriptionID = "subscription_id" }
        );
        subscription.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Subscriptions.List();
        page.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.Cancel(
            new()
            {
                SubscriptionID = "subscription_id",
                CancelOption = CancelOption.EndOfSubscriptionTerm,
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var subscription = await this.client.Subscriptions.Fetch(
            new() { SubscriptionID = "subscription_id" }
        );
        subscription.Validate();
    }

    [Fact]
    public async Task FetchCosts_Works()
    {
        var response = await this.client.Subscriptions.FetchCosts(
            new() { SubscriptionID = "subscription_id" }
        );
        response.Validate();
    }

    [Fact]
    public async Task FetchSchedule_Works()
    {
        var page = await this.client.Subscriptions.FetchSchedule(
            new() { SubscriptionID = "subscription_id" }
        );
        page.Validate();
    }

    [Fact(Skip = "Incorrect example breaks Prism")]
    public async Task FetchUsage_Works()
    {
        var subscriptionUsage = await this.client.Subscriptions.FetchUsage(
            new() { SubscriptionID = "subscription_id" }
        );
        subscriptionUsage.Validate();
    }

    [Fact(Skip = "Incorrect example breaks Prism")]
    public async Task PriceIntervals_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.PriceIntervals(
            new() { SubscriptionID = "subscription_id" }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task RedeemCoupon_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.RedeemCoupon(
            new() { SubscriptionID = "subscription_id", ChangeOption = ChangeOption.RequestedDate }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task SchedulePlanChange_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.SchedulePlanChange(
            new()
            {
                SubscriptionID = "subscription_id",
                ChangeOption =
                    SubscriptionSchedulePlanChangeParamsProperties::ChangeOption.RequestedDate,
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task TriggerPhase_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.TriggerPhase(
            new() { SubscriptionID = "subscription_id" }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnscheduleCancellation_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnscheduleCancellation(
            new() { SubscriptionID = "subscription_id" }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnscheduleFixedFeeQuantityUpdates_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnscheduleFixedFeeQuantityUpdates(
            new() { SubscriptionID = "subscription_id", PriceID = "price_id" }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnschedulePendingPlanChanges_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnschedulePendingPlanChanges(
            new() { SubscriptionID = "subscription_id" }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UpdateFixedFeeQuantity_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UpdateFixedFeeQuantity(
            new()
            {
                SubscriptionID = "subscription_id",
                PriceID = "price_id",
                Quantity = 0,
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UpdateTrial_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UpdateTrial(
            new()
            {
                SubscriptionID = "subscription_id",
                TrialEndDate = DateTime.Parse("2017-07-21T17:32:28Z"),
            }
        );
        mutatedSubscription.Validate();
    }
}
