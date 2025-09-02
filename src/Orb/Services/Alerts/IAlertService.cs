using System.Threading.Tasks;
using Orb.Models.Alerts;

namespace Orb.Services.Alerts;

public interface IAlertService
{
    /// <summary>
    /// This endpoint retrieves an alert by its ID.
    /// </summary>
    Task<Alert> Retrieve(AlertRetrieveParams parameters);

    /// <summary>
    /// This endpoint updates the thresholds of an alert.
    /// </summary>
    Task<Alert> Update(AlertUpdateParams parameters);

    /// <summary>
    /// This endpoint returns a list of alerts within Orb.
    ///
    /// The request must specify one of `customer_id`, `external_customer_id`, or `subscription_id`.
    ///
    /// If querying by subscription_id, the endpoint will return the subscription
    /// level alerts as well as the plan level alerts associated with the subscription.
    ///
    /// The list of alerts is ordered starting from the most recently created alert.
    /// This endpoint follows Orb's [standardized pagination format](/api-reference/pagination).
    /// </summary>
    Task<AlertListPageResponse> List(AlertListParams? parameters = null);

    /// <summary>
    ///  This endpoint creates a new alert to monitor a customer's credit balance.
    /// There are three types of alerts that can be scoped to  customers: `credit_balance_depleted`,
    /// `credit_balance_dropped`, and `credit_balance_recovered`. Customers can have
    /// a maximum  of one of each type of alert per [credit balance currency](/product-catalog/prepurchase).
    /// `credit_balance_dropped` alerts require a list of thresholds to be provided
    /// while `credit_balance_depleted`  and `credit_balance_recovered` alerts do
    /// not require thresholds.
    /// </summary>
    Task<Alert> CreateForCustomer(AlertCreateForCustomerParams parameters);

    /// <summary>
    ///  This endpoint creates a new alert to monitor a customer's credit balance.
    /// There are three types of alerts that can be scoped to  customers: `credit_balance_depleted`,
    /// `credit_balance_dropped`, and `credit_balance_recovered`. Customers can have
    /// a maximum  of one of each type of alert per [credit balance currency](/product-catalog/prepurchase).
    /// `credit_balance_dropped` alerts require a list of thresholds to be provided
    /// while `credit_balance_depleted`  and `credit_balance_recovered` alerts do
    /// not require thresholds.
    /// </summary>
    Task<Alert> CreateForExternalCustomer(AlertCreateForExternalCustomerParams parameters);

    /// <summary>
    /// This endpoint is used to create alerts at the subscription level.
    ///
    /// Subscription level alerts can be one of two types: `usage_exceeded` or `cost_exceeded`.
    /// A `usage_exceeded` alert is scoped to a particular metric and is triggered
    /// when the usage of that metric exceeds predefined thresholds during the current
    /// billing cycle. A `cost_exceeded` alert is triggered when the total amount
    /// due during the current billing cycle surpasses predefined thresholds. `cost_exceeded`
    /// alerts do not include burndown of pre-purchase credits. Each subscription
    /// can have one `cost_exceeded` alert and one `usage_exceeded` alert per metric
    /// that is a part of the subscription. Alerts are triggered based on usage or
    /// cost conditions met during the current billing cycle.
    /// </summary>
    Task<Alert> CreateForSubscription(AlertCreateForSubscriptionParams parameters);

    /// <summary>
    /// This endpoint allows you to disable an alert. To disable a plan-level alert
    /// for a specific subscription, you must include the `subscription_id`. The
    /// `subscription_id` is not required for customer or subscription level alerts.
    /// </summary>
    Task<Alert> Disable(AlertDisableParams parameters);

    /// <summary>
    /// This endpoint allows you to enable an alert. To enable a plan-level alert
    /// for a specific subscription, you must include the `subscription_id`. The
    /// `subscription_id` is not required for customer or subscription level alerts.
    /// </summary>
    Task<Alert> Enable(AlertEnableParams parameters);
}
