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
/// <para>If multiple plans are found to contain the specified external_plan_id,
/// the active plans will take priority over archived ones, and among those, the endpoint
/// will return the most recently created plan.</para>
///
/// <para>## Serialized prices Orb supports a few different pricing models out of
/// the box. Each of these models is serialized differently in a given [Price](/core-concepts#plan-and-price)
/// object. The `model_type` field determines the key for the configuration object
/// that is present. A detailed explanation of price types can be found in the [Price
/// schema](/core-concepts#plan-and-price). "</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalPlanIDFetchParams : ParamsBase
{
    public string? ExternalPlanID { get; init; }

    public ExternalPlanIDFetchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalPlanIDFetchParams(ExternalPlanIDFetchParams externalPlanIDFetchParams)
        : base(externalPlanIDFetchParams)
    {
        this.ExternalPlanID = externalPlanIDFetchParams.ExternalPlanID;
    }
#pragma warning restore CS8618

    public ExternalPlanIDFetchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalPlanIDFetchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ExternalPlanIDFetchParams FromRawUnchecked(
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
                ["ExternalPlanID"] = this.ExternalPlanID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExternalPlanIDFetchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ExternalPlanID?.Equals(other.ExternalPlanID) ?? other.ExternalPlanID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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
