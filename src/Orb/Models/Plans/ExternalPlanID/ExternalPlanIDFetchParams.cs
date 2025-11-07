using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Plans.ExternalPlanID;

/// <summary>
/// This endpoint is used to fetch [plan](/core-concepts##plan-and-price) details
/// given an external_plan_id identifier. It returns information about the prices
/// included in the plan and their configuration, as well as the product that the
/// plan is attached to.
///
/// If multiple plans are found to contain the specified external_plan_id, the active
/// plans will take priority over archived ones, and among those, the endpoint will
/// return the most recently created plan.
///
/// ## Serialized prices Orb supports a few different pricing models out of the box.
/// Each of these models is serialized differently in a given [Price](/core-concepts#plan-and-price)
/// object. The `model_type` field determines the key for the configuration object
/// that is present. A detailed explanation of price types can be found in the [Price
/// schema](/core-concepts#plan-and-price). "
/// </summary>
public sealed record class ExternalPlanIDFetchParams : ParamsBase
{
    public required string ExternalPlanID { get; init; }

    public ExternalPlanIDFetchParams() { }

    public ExternalPlanIDFetchParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalPlanIDFetchParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }
#pragma warning restore CS8618

    public static ExternalPlanIDFetchParams FromRawUnchecked(
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
                + string.Format("/plans/external_plan_id/{0}", this.ExternalPlanID)
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
