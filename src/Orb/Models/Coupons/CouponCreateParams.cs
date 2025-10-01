using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using CouponCreateParamsProperties = Orb.Models.Coupons.CouponCreateParamsProperties;

namespace Orb.Models.Coupons;

/// <summary>
/// This endpoint allows the creation of coupons, which can then be redeemed at subscription
/// creation or plan change.
/// </summary>
public sealed record class CouponCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required CouponCreateParamsProperties::Discount Discount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new ArgumentOutOfRangeException("discount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CouponCreateParamsProperties::Discount>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new ArgumentNullException("discount")
                );
        }
        set
        {
            this.BodyProperties["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This string can be used to redeem this coupon for a given subscription.
    /// </summary>
    public required string RedemptionCode
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("redemption_code", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'redemption_code' cannot be null",
                    new ArgumentOutOfRangeException("redemption_code", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'redemption_code' cannot be null",
                    new ArgumentNullException("redemption_code")
                );
        }
        set
        {
            this.BodyProperties["redemption_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.BodyProperties.TryGetValue("duration_in_months", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["duration_in_months"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.BodyProperties.TryGetValue("max_redemptions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["max_redemptions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/coupons")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
