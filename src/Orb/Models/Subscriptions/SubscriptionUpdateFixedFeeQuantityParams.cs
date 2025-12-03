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
/// This endpoint can be used to update the quantity for a fixed fee.
///
/// <para>To be eligible, the subscription must currently be active and the price
/// specified must be a fixed fee (not usage-based). This operation will immediately
/// update the quantity for the fee, or if a `effective_date` is passed in, will
/// update the quantity on the requested date at midnight in the customer's timezone.</para>
///
/// <para>In order to change the fixed fee quantity as of the next draft invoice
/// for this subscription, pass `change_option=upcoming_invoice` without an `effective_date` specified.</para>
///
/// <para>If the fee is an in-advance fixed fee, it will also issue an immediate
/// invoice for the difference for the remainder of the billing period.</para>
/// </summary>
public sealed record class SubscriptionUpdateFixedFeeQuantityParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// Price for which the quantity should be updated. Must be a fixed fee.
    /// </summary>
    public required string PriceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "price_id"); }
        init { ModelBase.Set(this._rawBodyData, "price_id", value); }
    }

    public required double Quantity
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawBodyData, "quantity"); }
        init { ModelBase.Set(this._rawBodyData, "quantity", value); }
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
            return ModelBase.GetNullableStruct<bool>(
                this.RawBodyData,
                "allow_invoice_credit_or_void"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "allow_invoice_credit_or_void", value); }
    }

    /// <summary>
    /// Determines when the change takes effect. Note that if `effective_date` is
    /// specified, this defaults to `effective_date`. Otherwise, this defaults to
    /// `immediate` unless it's explicitly set to `upcoming_invoice`.
    /// </summary>
    public ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption>? ChangeOption
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption>
            >(this.RawBodyData, "change_option");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "change_option", value);
        }
    }

    /// <summary>
    /// The date that the quantity change should take effect, localized to the customer's
    /// timezone. If this parameter is not passed in, the quantity change is effective
    /// according to `change_option`.
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? EffectiveDate
    {
        get
        {
            return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawBodyData, "effective_date");
        }
        init { ModelBase.Set(this._rawBodyData, "effective_date", value); }
    }

    public SubscriptionUpdateFixedFeeQuantityParams() { }

    public SubscriptionUpdateFixedFeeQuantityParams(
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
    SubscriptionUpdateFixedFeeQuantityParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static SubscriptionUpdateFixedFeeQuantityParams FromRawUnchecked(
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
                + string.Format("/subscriptions/{0}/update_fixed_fee_quantity", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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

/// <summary>
/// Determines when the change takes effect. Note that if `effective_date` is specified,
/// this defaults to `effective_date`. Otherwise, this defaults to `immediate` unless
/// it's explicitly set to `upcoming_invoice`.
/// </summary>
[JsonConverter(typeof(SubscriptionUpdateFixedFeeQuantityParamsChangeOptionConverter))]
public enum SubscriptionUpdateFixedFeeQuantityParamsChangeOption
{
    Immediate,
    UpcomingInvoice,
    EffectiveDate,
}

sealed class SubscriptionUpdateFixedFeeQuantityParamsChangeOptionConverter
    : JsonConverter<SubscriptionUpdateFixedFeeQuantityParamsChangeOption>
{
    public override SubscriptionUpdateFixedFeeQuantityParamsChangeOption Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediate" => SubscriptionUpdateFixedFeeQuantityParamsChangeOption.Immediate,
            "upcoming_invoice" =>
                SubscriptionUpdateFixedFeeQuantityParamsChangeOption.UpcomingInvoice,
            "effective_date" => SubscriptionUpdateFixedFeeQuantityParamsChangeOption.EffectiveDate,
            _ => (SubscriptionUpdateFixedFeeQuantityParamsChangeOption)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionUpdateFixedFeeQuantityParamsChangeOption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionUpdateFixedFeeQuantityParamsChangeOption.Immediate => "immediate",
                SubscriptionUpdateFixedFeeQuantityParamsChangeOption.UpcomingInvoice =>
                    "upcoming_invoice",
                SubscriptionUpdateFixedFeeQuantityParamsChangeOption.EffectiveDate =>
                    "effective_date",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
