using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using SubscriptionCancelParamsProperties = Orb.Models.Subscriptions.SubscriptionCancelParamsProperties;
using System = System;
using Text = System.Text;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to cancel an existing subscription. It returns the
/// serialized subscription object with an `end_date` parameter that signifies when
/// the subscription will transition to an ended state.
///
/// The body parameter `cancel_option` determines the cancellation behavior. Orb
/// supports three cancellation options: - `end_of_subscription_term`: stops the
/// subscription from auto-renewing. Subscriptions that have been cancelled with
///  this option can still incur charges for the remainder of their term:     - Issuing
/// this cancellation request for a monthly subscription will keep the subscription
/// active until the start       of the subsequent month, and potentially issue an
/// invoice for any usage charges incurred in the intervening       period.     -
/// Issuing this cancellation request for a quarterly subscription will keep the
/// subscription active until the end       of the quarter and potentially issue an
/// invoice for any usage charges incurred in the intervening period.     - Issuing
/// this cancellation request for a yearly subscription will keep the subscription
/// active for the full       year. For example, a yearly subscription starting on
/// 2021-11-01 and cancelled on 2021-12-08 will remain active       until 2022-11-01
/// and potentially issue charges in the intervening months for any recurring monthly
/// usage       charges in its plan.     - **Note**: If a subscription's plan contains
/// prices with difference cadences, the end of term date will be       determined
/// by the largest cadence value. For example, cancelling end of term for a subscription
/// with a       quarterly fixed fee with a monthly usage fee will result in the subscription
/// ending at the end of the quarter.
///
/// - `immediate`: ends the subscription immediately, setting the `end_date` to the
/// current time:     - Subscriptions that have been cancelled with this option will
/// be invoiced immediately. This invoice will       include any usage fees incurred
/// in the billing period up to the cancellation, along with any prorated       recurring
/// fees for the billing period, if applicable.     - **Note**: If the subscription
/// has a recurring fee that was paid in-advance, the prorated amount for the
///   remaining time period will be added to the [customer's balance](list-balance-transactions)
/// upon immediate       cancellation. However, if the customer is ineligible to use
/// the customer balance, the subscription cannot be       cancelled immediately.
///
/// - `requested_date`: ends the subscription on a specified date, which requires
/// a `cancellation_date` to be passed in.   If no timezone is provided, the customer's
/// timezone is used.  For example, a subscription starting on January 1st   with
/// a monthly price can be set to be cancelled on the first of any month after January
/// 1st (e.g. March 1st, April   1st, May 1st). A subscription with multiple prices
/// with different cadences defines the "term" to be the highest   cadence of the prices.
///
/// Upcoming subscriptions are only eligible for immediate cancellation, which will
/// set the `end_date` equal to the `start_date` upon cancellation.
///
/// ## Backdated cancellations Orb allows you to cancel a subscription in the past
/// as long as there are no paid invoices between the `requested_date` and the current
/// time. If the cancellation is after the latest issued invoice, Orb will generate
/// a balance refund for the current period. If the cancellation is before the most
/// recently issued invoice, Orb will void the intervening invoice and generate a
/// new one based on the new dates for the subscription. See the section on [cancellation behaviors](/product-catalog/creating-subscriptions#cancellation-behaviors).
/// </summary>
public sealed record class SubscriptionCancelParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// Determines the timing of subscription cancellation
    /// </summary>
    public required SubscriptionCancelParamsProperties::CancelOption CancelOption
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("cancel_option", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "cancel_option",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<SubscriptionCancelParamsProperties::CancelOption>(
                    element
                ) ?? throw new System::ArgumentNullException("cancel_option");
        }
        set
        {
            this.BodyProperties["cancel_option"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// If false, this request will fail if it would void an issued invoice or create
    /// a credit note. Consider using this as a safety mechanism if you do not expect
    /// existing invoices to be changed.
    /// </summary>
    public bool? AllowInvoiceCreditOrVoid
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "allow_invoice_credit_or_void",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["allow_invoice_credit_or_void"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The date that the cancellation should take effect. This parameter can only be
    /// passed if the `cancel_option` is `requested_date`.
    /// </summary>
    public System::DateTime? CancellationDate
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("cancellation_date", out Json::JsonElement element)
            )
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.BodyProperties["cancellation_date"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/cancel", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
