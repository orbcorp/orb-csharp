using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// Apply a subscription change to perform the intended action. If a positive amount
/// is passed with a request to this endpoint, any eligible invoices that were created
/// will be issued immediately if they only contain in-advance fees.
/// </summary>
public sealed record class SubscriptionChangeApplyParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionChangeID { get; init; }

    /// <summary>
    /// Description to apply to the balance transaction representing this credit.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { ModelBase.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// Mark all pending invoices that are payable as paid. If amount is also provided,
    /// mark as paid and credit the difference to the customer's balance.
    /// </summary>
    public bool? MarkAsPaid
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "mark_as_paid"); }
        init { ModelBase.Set(this._rawBodyData, "mark_as_paid", value); }
    }

    /// <summary>
    /// An optional external ID to associate with the payment. Only applicable when
    /// mark_as_paid is true.
    /// </summary>
    public string? PaymentExternalID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "payment_external_id"); }
        init { ModelBase.Set(this._rawBodyData, "payment_external_id", value); }
    }

    /// <summary>
    /// Optional notes about the payment. Only applicable when mark_as_paid is true.
    /// </summary>
    public string? PaymentNotes
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "payment_notes"); }
        init { ModelBase.Set(this._rawBodyData, "payment_notes", value); }
    }

    /// <summary>
    /// A date string to specify the date the payment was received. Only applicable
    /// when mark_as_paid is true. If not provided, defaults to the current date.
    /// </summary>
    public
#if NET
    DateOnly
#else
    DateTimeOffset
#endif
    ? PaymentReceivedDate
    {
        get
        {
            return ModelBase.GetNullableStruct<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            >(this.RawBodyData, "payment_received_date");
        }
        init { ModelBase.Set(this._rawBodyData, "payment_received_date", value); }
    }

    /// <summary>
    /// Amount already collected to apply to the customer's balance. If mark_as_paid
    /// is also provided, credit the difference to the customer's balance.
    /// </summary>
    public string? PreviouslyCollectedAmount
    {
        get
        {
            return ModelBase.GetNullableClass<string>(
                this.RawBodyData,
                "previously_collected_amount"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "previously_collected_amount", value); }
    }

    public SubscriptionChangeApplyParams() { }

    public SubscriptionChangeApplyParams(
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
    SubscriptionChangeApplyParams(
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

    public static SubscriptionChangeApplyParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscription_changes/{0}/apply", this.SubscriptionChangeID)
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
