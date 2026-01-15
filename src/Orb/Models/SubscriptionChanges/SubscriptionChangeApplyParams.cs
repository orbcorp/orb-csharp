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
    readonly JsonDictionary _rawBodyData = new();
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
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Mark all pending invoices that are payable as paid. If amount is also provided,
    /// mark as paid and credit the difference to the customer's balance.
    /// </summary>
    public bool? MarkAsPaid
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("mark_as_paid");
        }
        init { this._rawBodyData.Set("mark_as_paid", value); }
    }

    /// <summary>
    /// An optional external ID to associate with the payment. Only applicable when
    /// mark_as_paid is true.
    /// </summary>
    public string? PaymentExternalID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payment_external_id");
        }
        init { this._rawBodyData.Set("payment_external_id", value); }
    }

    /// <summary>
    /// Optional notes about the payment. Only applicable when mark_as_paid is true.
    /// </summary>
    public string? PaymentNotes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payment_notes");
        }
        init { this._rawBodyData.Set("payment_notes", value); }
    }

    /// <summary>
    /// A date string to specify the date the payment was received. Only applicable
    /// when mark_as_paid is true. If not provided, defaults to the current date.
    /// </summary>
    public string? PaymentReceivedDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payment_received_date");
        }
        init { this._rawBodyData.Set("payment_received_date", value); }
    }

    /// <summary>
    /// Amount already collected to apply to the customer's balance. If mark_as_paid
    /// is also provided, credit the difference to the customer's balance.
    /// </summary>
    public string? PreviouslyCollectedAmount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("previously_collected_amount");
        }
        init { this._rawBodyData.Set("previously_collected_amount", value); }
    }

    public SubscriptionChangeApplyParams() { }

    public SubscriptionChangeApplyParams(
        SubscriptionChangeApplyParams subscriptionChangeApplyParams
    )
        : base(subscriptionChangeApplyParams)
    {
        this.SubscriptionChangeID = subscriptionChangeApplyParams.SubscriptionChangeID;

        this._rawBodyData = new(subscriptionChangeApplyParams._rawBodyData);
    }

    public SubscriptionChangeApplyParams(
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
    SubscriptionChangeApplyParams(
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
