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
/// This endpoint can be used to cancel an existing subscription. It returns the serialized
/// subscription object with an `end_date` parameter that signifies when the subscription
/// will transition to an ended state.
///
/// <para>The body parameter `cancel_option` determines the cancellation behavior.
/// Orb supports three cancellation options: - `end_of_subscription_term`: stops
/// the subscription from auto-renewing. Subscriptions that have been cancelled with
///   this option can still incur charges for the remainder of their term:     - Issuing
/// this cancellation request for a monthly subscription will keep the subscription
/// active until the start       of the subsequent month, and potentially issue an
/// invoice for any usage charges incurred in the intervening       period.     -
/// Issuing this cancellation request for a quarterly subscription will keep the subscription
/// active until the end       of the quarter and potentially issue an invoice for
/// any usage charges incurred in the intervening period.     - Issuing this cancellation
/// request for a yearly subscription will keep the subscription active for the full
///       year. For example, a yearly subscription starting on 2021-11-01 and cancelled
/// on 2021-12-08 will remain active       until 2022-11-01 and potentially issue
/// charges in the intervening months for any recurring monthly usage       charges
/// in its plan.     - **Note**: If a subscription's plan contains prices with difference
/// cadences, the end of term date will be       determined by the largest cadence
/// value. For example, cancelling end of term for a subscription with a       quarterly
/// fixed fee with a monthly usage fee will result in the subscription ending at the
/// end of the quarter.</para>
///
/// <para>- `immediate`: ends the subscription immediately, setting the `end_date`
/// to the current time:     - Subscriptions that have been cancelled with this option
/// will be invoiced immediately. This invoice will       include any usage fees incurred
/// in the billing period up to the cancellation, along with any prorated       recurring
/// fees for the billing period, if applicable.     - **Note**: If the subscription
/// has a recurring fee that was paid in-advance, the prorated amount for the
///    remaining time period will be added to the [customer's balance](list-balance-transactions)
/// upon immediate       cancellation. However, if the customer is ineligible to
/// use the customer balance, the subscription cannot be       cancelled immediately.</para>
///
/// <para>- `requested_date`: ends the subscription on a specified date, which requires
/// a `cancellation_date` to be passed in.   If no timezone is provided, the customer's
/// timezone is used.  For example, a subscription starting on January 1st   with
/// a monthly price can be set to be cancelled on the first of any month after January
/// 1st (e.g. March 1st, April   1st, May 1st). A subscription with multiple prices
/// with different cadences defines the "term" to be the highest   cadence of the prices.</para>
///
/// <para>Upcoming subscriptions are only eligible for immediate cancellation, which
/// will set the `end_date` equal to the `start_date` upon cancellation.</para>
///
/// <para>## Backdated cancellations Orb allows you to cancel a subscription in the
/// past as long as there are no paid invoices between the `requested_date` and the
/// current time. If the cancellation is after the latest issued invoice, Orb will
/// generate a balance refund for the current period. If the cancellation is before
/// the most recently issued invoice, Orb will void the intervening invoice and generate
/// a new one based on the new dates for the subscription. See the section on [cancellation behaviors](/product-catalog/creating-subscriptions#cancellation-behaviors).</para>
/// </summary>
public sealed record class SubscriptionCancelParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string SubscriptionID { get; init; }

    /// <summary>
    /// Determines the timing of subscription cancellation
    /// </summary>
    public required ApiEnum<string, CancelOption> CancelOption
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("cancel_option", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cancel_option' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cancel_option",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, CancelOption>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["cancel_option"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
                !this._bodyProperties.TryGetValue(
                    "allow_invoice_credit_or_void",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["allow_invoice_credit_or_void"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The date that the cancellation should take effect. This parameter can only
    /// be passed if the `cancel_option` is `requested_date`.
    /// </summary>
    public System::DateTimeOffset? CancellationDate
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("cancellation_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["cancellation_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionCancelParams() { }

    public SubscriptionCancelParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCancelParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static SubscriptionCancelParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/cancel", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Determines the timing of subscription cancellation
/// </summary>
[JsonConverter(typeof(CancelOptionConverter))]
public enum CancelOption
{
    EndOfSubscriptionTerm,
    Immediate,
    RequestedDate,
}

sealed class CancelOptionConverter : JsonConverter<CancelOption>
{
    public override CancelOption Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "end_of_subscription_term" => CancelOption.EndOfSubscriptionTerm,
            "immediate" => CancelOption.Immediate,
            "requested_date" => CancelOption.RequestedDate,
            _ => (CancelOption)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancelOption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancelOption.EndOfSubscriptionTerm => "end_of_subscription_term",
                CancelOption.Immediate => "immediate",
                CancelOption.RequestedDate => "requested_date",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
