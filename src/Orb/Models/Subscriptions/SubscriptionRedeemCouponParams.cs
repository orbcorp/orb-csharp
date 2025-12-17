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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    public required ApiEnum<string, ChangeOption> ChangeOption
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, ChangeOption>>(
                this.RawBodyData,
                "change_option"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "change_option", value); }
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
            return JsonModel.GetNullableStruct<bool>(
                this.RawBodyData,
                "allow_invoice_credit_or_void"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "allow_invoice_credit_or_void", value); }
    }

    /// <summary>
    /// The date that the coupon discount should take effect. This parameter can
    /// only be passed if the `change_option` is `requested_date`.
    /// </summary>
    public System::DateTimeOffset? ChangeDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawBodyData,
                "change_date"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "change_date", value); }
    }

    /// <summary>
    /// Coupon ID to be redeemed for this subscription.
    /// </summary>
    public string? CouponID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "coupon_id"); }
        init { JsonModel.Set(this._rawBodyData, "coupon_id", value); }
    }

    /// <summary>
    /// Redemption code of the coupon to be redeemed for this subscription.
    /// </summary>
    public string? CouponRedemptionCode
    {
        get
        {
            return JsonModel.GetNullableClass<string>(this.RawBodyData, "coupon_redemption_code");
        }
        init { JsonModel.Set(this._rawBodyData, "coupon_redemption_code", value); }
    }

    public SubscriptionRedeemCouponParams() { }

    public SubscriptionRedeemCouponParams(
        SubscriptionRedeemCouponParams subscriptionRedeemCouponParams
    )
        : base(subscriptionRedeemCouponParams)
    {
        this._rawBodyData = [.. subscriptionRedeemCouponParams._rawBodyData];
    }

    public SubscriptionRedeemCouponParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRedeemCouponParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
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
            JsonSerializer.Serialize(this.RawBodyData),
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
