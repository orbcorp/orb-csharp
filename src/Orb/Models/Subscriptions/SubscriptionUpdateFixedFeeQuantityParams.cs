using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using SubscriptionUpdateFixedFeeQuantityParamsProperties = Orb.Models.Subscriptions.SubscriptionUpdateFixedFeeQuantityParamsProperties;
using System = System;
using Text = System.Text;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to update the quantity for a fixed fee.
///
/// To be eligible, the subscription must currently be active and the price specified
/// must be a fixed fee (not usage-based). This operation will immediately update
/// the quantity for the fee, or if a `effective_date` is passed in, will update
/// the quantity on the requested date at midnight in the customer's timezone.
///
/// In order to change the fixed fee quantity as of the next draft invoice for this
/// subscription, pass `change_option=upcoming_invoice` without an `effective_date` specified.
///
/// If the fee is an in-advance fixed fee, it will also issue an immediate invoice
/// for the difference for the remainder of the billing period.
/// </summary>
public sealed record class SubscriptionUpdateFixedFeeQuantityParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// Price for which the quantity should be updated. Must be a fixed fee.
    /// </summary>
    public required string PriceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("price_id");
        }
        set { this.BodyProperties["price_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double Quantity
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.BodyProperties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
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
    /// Determines when the change takes effect. Note that if `effective_date` is specified,
    /// this defaults to `effective_date`. Otherwise, this defaults to `immediate`
    /// unless it's explicitly set to `upcoming_invoice`.
    /// </summary>
    public SubscriptionUpdateFixedFeeQuantityParamsProperties::ChangeOption? ChangeOption
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("change_option", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<SubscriptionUpdateFixedFeeQuantityParamsProperties::ChangeOption?>(
                element
            );
        }
        set
        {
            this.BodyProperties["change_option"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The date that the quantity change should take effect, localized to the customer's
    /// timezone. If this parameter is not passed in, the quantity change is effective
    /// according to `change_option`.
    /// </summary>
    public System::DateOnly? EffectiveDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("effective_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set
        {
            this.BodyProperties["effective_date"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/update_fixed_fee_quantity", this.SubscriptionID)
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
