using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to unschedule any pending cancellations for a subscription.
///
/// <para>To be eligible, the subscription must currently be active and have a future
/// cancellation. This operation will turn on auto-renew, ensuring that the subscription
/// does not end at the currently scheduled cancellation time.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionUnscheduleCancellationParams : ParamsBase
{
    public string? SubscriptionID { get; init; }

    public SubscriptionUnscheduleCancellationParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionUnscheduleCancellationParams(
        SubscriptionUnscheduleCancellationParams subscriptionUnscheduleCancellationParams
    )
        : base(subscriptionUnscheduleCancellationParams)
    {
        this.SubscriptionID = subscriptionUnscheduleCancellationParams.SubscriptionID;
    }
#pragma warning restore CS8618

    public SubscriptionUnscheduleCancellationParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionUnscheduleCancellationParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string subscriptionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.SubscriptionID = subscriptionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubscriptionUnscheduleCancellationParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string subscriptionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            subscriptionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SubscriptionID"] = JsonSerializer.SerializeToElement(this.SubscriptionID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SubscriptionUnscheduleCancellationParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SubscriptionID?.Equals(other.SubscriptionID) ?? other.SubscriptionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/unschedule_cancellation", this.SubscriptionID)
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
