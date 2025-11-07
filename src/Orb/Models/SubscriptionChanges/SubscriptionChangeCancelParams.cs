using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// Cancel a subscription change. The change can no longer be applied. A subscription
/// can only have one "pending" change at a time - use this endpoint to cancel an
/// existing change before creating a new one.
/// </summary>
public sealed record class SubscriptionChangeCancelParams : ParamsBase
{
    public required string SubscriptionChangeID { get; init; }

    public SubscriptionChangeCancelParams() { }

    public SubscriptionChangeCancelParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeCancelParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }
#pragma warning restore CS8618

    public static SubscriptionChangeCancelParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscription_changes/{0}/cancel", this.SubscriptionChangeID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
