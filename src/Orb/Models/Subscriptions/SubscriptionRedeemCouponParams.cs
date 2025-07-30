using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using SubscriptionRedeemCouponParamsProperties = Orb.Models.Subscriptions.SubscriptionRedeemCouponParamsProperties;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// Redeem a coupon effective at a given time.
/// </summary>
public sealed record class SubscriptionRedeemCouponParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    public required SubscriptionRedeemCouponParamsProperties::ChangeOption ChangeOption
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("change_option", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "change_option",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<SubscriptionRedeemCouponParamsProperties::ChangeOption>(
                    element
                ) ?? throw new System::ArgumentNullException("change_option");
        }
        set { this.BodyProperties["change_option"] = JsonSerializer.SerializeToElement(value); }
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
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["allow_invoice_credit_or_void"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The date that the coupon discount should take effect. This parameter can only
    /// be passed if the `change_option` is `requested_date`.
    /// </summary>
    public System::DateTime? ChangeDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("change_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.BodyProperties["change_date"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Coupon ID to be redeemed for this subscription.
    /// </summary>
    public string? CouponID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("coupon_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["coupon_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Redemption code of the coupon to be redeemed for this subscription.
    /// </summary>
    public string? CouponRedemptionCode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("coupon_redemption_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["coupon_redemption_code"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/redeem_coupon", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
