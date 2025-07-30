using CouponCreateParamsProperties = Orb.Models.Coupons.CouponCreateParamsProperties;
using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Coupons;

/// <summary>
/// This endpoint allows the creation of coupons, which can then be redeemed at subscription
/// creation or plan change.
/// </summary>
public sealed record class CouponCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required CouponCreateParamsProperties::Discount Discount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CouponCreateParamsProperties::Discount>(element)
                ?? throw new System::ArgumentNullException("discount");
        }
        set { this.BodyProperties["discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// This string can be used to redeem this coupon for a given subscription.
    /// </summary>
    public required string RedemptionCode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("redemption_code", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "redemption_code",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("redemption_code");
        }
        set
        {
            this.BodyProperties["redemption_code"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// This allows for a coupon's discount to apply for a limited time (determined
    /// in months); a `null` value here means "unlimited time".
    /// </summary>
    public long? DurationInMonths
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "duration_in_months",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.BodyProperties["duration_in_months"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The maximum number of redemptions allowed for this coupon before it is exhausted;`null`
    /// here means "unlimited".
    /// </summary>
    public long? MaxRedemptions
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("max_redemptions", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.BodyProperties["max_redemptions"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/coupons")
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
