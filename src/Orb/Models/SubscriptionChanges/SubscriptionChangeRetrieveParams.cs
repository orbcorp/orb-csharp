using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// This endpoint returns a subscription change given an identifier.
///
/// <para>A subscription change is created by including `Create-Pending-Subscription-Change:
/// True` in the header of a subscription mutation API call (e.g. [create subscription
/// endpoint](/api-reference/subscription/create-subscription), [schedule plan change
/// endpoint](/api-reference/subscription/schedule-plan-change), ...). The subscription
/// change will be referenced by the `pending_subscription_change` field in the response.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionChangeRetrieveParams : ParamsBase
{
    public string? SubscriptionChangeID { get; init; }

    public SubscriptionChangeRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionChangeRetrieveParams(
        SubscriptionChangeRetrieveParams subscriptionChangeRetrieveParams
    )
        : base(subscriptionChangeRetrieveParams)
    {
        this.SubscriptionChangeID = subscriptionChangeRetrieveParams.SubscriptionChangeID;
    }
#pragma warning restore CS8618

    public SubscriptionChangeRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionChangeRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["SubscriptionChangeID"] = this.SubscriptionChangeID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SubscriptionChangeRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.SubscriptionChangeID?.Equals(other.SubscriptionChangeID)
                ?? other.SubscriptionChangeID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscription_changes/{0}", this.SubscriptionChangeID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
