using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using SubscriptionPriceIntervalsParamsProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties;
using System = System;
using Text = System.Text;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint is used to add and edit subscription [price intervals](/api-reference/price-interval/add-or-edit-price-intervals).
/// By making modifications to a subscription’s price intervals, you can [flexibly
/// and atomically control the billing behavior of a subscription](/product-catalog/modifying-subscriptions).
///
/// ## Adding price intervals
///
/// Prices can be added as price intervals to a subscription by specifying them in
/// the `add` array. A `price_id` or `external_price_id` from an add-on price or previously
/// removed plan price can be specified to reuse an existing price definition (however,
/// please note that prices from other plans cannot be added to the subscription).
/// Additionally, a new price can be specified using the `price` field — this price
/// will be created automatically.
///
/// A `start_date` must be specified for the price interval. This is the date when
/// the price will start billing on the subscription, so this will notably result
/// in an immediate charge at this time for any billed in advance fixed fees. The
/// `end_date` will default to null, resulting in a price interval that will bill
/// on a continually recurring basis. Both of these dates can be set in the past or
/// the future and Orb will generate or modify invoices to ensure the subscription’s
/// invoicing behavior is correct.
///
/// Additionally, a discount, minimum, or maximum can be specified on the price interval.
/// This will only apply to this price interval, not any other price intervals on
/// the subscription.
///
/// ## Adjustment intervals
///
/// An adjustment interval represents the time period that a particular adjustment
/// (a discount, minimum, or maximum) applies to the prices on a subscription. Adjustment
/// intervals can be added to a subscription by specifying them in the `add_adjustments`
/// array, or modified via the `edit_adjustments` array. When creating an adjustment
/// interval, you'll need to provide the definition of the new adjustment (the type
/// of adjustment, and which prices it applies to), as well as the start and end dates
/// for the adjustment interval. The start and end dates of an existing adjustment
/// interval can be edited via the `edit_adjustments` field (just like price intervals).
/// (To "change" the amount of a discount, minimum, or maximum, then, you'll need
/// to end the existing interval, and create a new adjustment interval with the new
/// amount and a start date that matches the end date of the previous interval.)
///
/// ## Editing price intervals
///
/// Price intervals can be adjusted by specifying edits to make in the `edit` array.
/// A `price_interval_id` to edit must be specified — this can be retrieved from
/// the `price_intervals` field on the subscription.
///
/// A new `start_date` or `end_date` can be specified to change the range of the price
/// interval, which will modify past or future invoices to ensure correctness. If
/// either of these dates are unspecified, they will default to the existing date
/// on the price interval. To remove a price interval entirely from a subscription,
/// set the `end_date` to be equivalent to the `start_date`.
///
/// ## Fixed fee quantity transitions The fixed fee quantity transitions for a fixed
/// fee price interval can also be specified when adding or editing by passing an
/// array for `fixed_fee_quantity_transitions`. A fixed fee quantity transition must
/// have a `quantity` and an `effective_date`, which is the date after which the
/// new quantity will be used for billing. If a fixed fee quantity transition is
/// scheduled at a billing period boundary, the full quantity will be billed on an
/// invoice with the other prices on the subscription. If the fixed fee quantity transition
/// is scheduled mid-billing period, the difference between the existing quantity
/// and quantity specified in the transition will be prorated for the rest of the
/// billing period and billed immediately, which will generate a new invoice.
///
/// Notably, the list of fixed fee quantity transitions passed will overwrite the
/// existing fixed fee quantity transitions on the price interval, so the entire list
/// of transitions must be specified to add additional transitions. The existing list
/// of transitions can be retrieved using the `fixed_fee_quantity_transitions` property
/// on a subscription’s serialized price intervals.
/// </summary>
public sealed record class SubscriptionPriceIntervalsParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// A list of price intervals to add to the subscription.
    /// </summary>
    public Generic::List<SubscriptionPriceIntervalsParamsProperties::Add>? Add
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("add", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<SubscriptionPriceIntervalsParamsProperties::Add>?>(
                element
            );
        }
        set { this.BodyProperties["add"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of adjustments to add to the subscription.
    /// </summary>
    public Generic::List<SubscriptionPriceIntervalsParamsProperties::AddAdjustment>? AddAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("add_adjustments", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<SubscriptionPriceIntervalsParamsProperties::AddAdjustment>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["add_adjustments"] = Json::JsonSerializer.SerializeToElement(value);
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
    /// A list of price intervals to edit on the subscription.
    /// </summary>
    public Generic::List<SubscriptionPriceIntervalsParamsProperties::Edit>? Edit
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("edit", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<SubscriptionPriceIntervalsParamsProperties::Edit>?>(
                element
            );
        }
        set { this.BodyProperties["edit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of adjustments to edit on the subscription.
    /// </summary>
    public Generic::List<SubscriptionPriceIntervalsParamsProperties::EditAdjustment>? EditAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("edit_adjustments", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<SubscriptionPriceIntervalsParamsProperties::EditAdjustment>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["edit_adjustments"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/price_intervals", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new Http::StringContent(
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
