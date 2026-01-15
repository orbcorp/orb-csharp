using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// Redeem a coupon effective at a given time.
/// </summary>
public sealed record class SubscriptionRedeemCouponParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    public required ApiEnum<string, ChangeOption> ChangeOption
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ChangeOption>>(
                "change_option"
            );
        }
        init { this._rawBodyData.Set("change_option", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("allow_invoice_credit_or_void");
        }
        init { this._rawBodyData.Set("allow_invoice_credit_or_void", value); }
    }

    /// <summary>
    /// The date that the coupon discount should take effect. This parameter can
    /// only be passed if the `change_option` is `requested_date`.
    /// </summary>
    public System::DateTimeOffset? ChangeDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("change_date");
        }
        init { this._rawBodyData.Set("change_date", value); }
    }

    /// <summary>
    /// Coupon ID to be redeemed for this subscription.
    /// </summary>
    public string? CouponID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("coupon_id");
        }
        init { this._rawBodyData.Set("coupon_id", value); }
    }

    /// <summary>
    /// Redemption code of the coupon to be redeemed for this subscription.
    /// </summary>
    public string? CouponRedemptionCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("coupon_redemption_code");
        }
        init { this._rawBodyData.Set("coupon_redemption_code", value); }
    }

    public SubscriptionRedeemCouponParams() { }

    public SubscriptionRedeemCouponParams(
        SubscriptionRedeemCouponParams subscriptionRedeemCouponParams
    )
        : base(subscriptionRedeemCouponParams)
    {
        this.SubscriptionID = subscriptionRedeemCouponParams.SubscriptionID;

        this._rawBodyData = new(subscriptionRedeemCouponParams._rawBodyData);
    }

    public SubscriptionRedeemCouponParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRedeemCouponParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionRedeemCouponParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/redeem_coupon", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ChangeOptionConverter))]
public enum ChangeOption
{
    RequestedDate,
    EndOfSubscriptionTerm,
    Immediate,
}

sealed class ChangeOptionConverter : JsonConverter<ChangeOption>
{
    public override ChangeOption Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "requested_date" => ChangeOption.RequestedDate,
            "end_of_subscription_term" => ChangeOption.EndOfSubscriptionTerm,
            "immediate" => ChangeOption.Immediate,
            _ => (ChangeOption)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChangeOption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChangeOption.RequestedDate => "requested_date",
                ChangeOption.EndOfSubscriptionTerm => "end_of_subscription_term",
                ChangeOption.Immediate => "immediate",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
