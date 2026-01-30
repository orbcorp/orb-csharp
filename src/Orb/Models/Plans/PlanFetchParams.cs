using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Plans;

/// <summary>
/// This endpoint is used to fetch [plan](/core-concepts#plan-and-price) details
/// given a plan identifier. It returns information about the prices included in
/// the plan and their configuration, as well as the product that the plan is attached to.
///
/// <para>## Serialized prices Orb supports a few different pricing models out of
/// the box. Each of these models is serialized differently in a given [Price](/core-concepts#plan-and-price)
/// object. The `model_type` field determines the key for the configuration object
/// that is present. A detailed explanation of price types can be found in the [Price schema](/core-concepts#plan-and-price).</para>
///
/// <para>## Phases Orb supports plan phases, also known as contract ramps. For plans
/// with phases, the serialized prices refer to all prices across all phases.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlanFetchParams : ParamsBase
{
    public string? PlanID { get; init; }

    public PlanFetchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanFetchParams(PlanFetchParams planFetchParams)
        : base(planFetchParams)
    {
        this.PlanID = planFetchParams.PlanID;
    }
#pragma warning restore CS8618

    public PlanFetchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanFetchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PlanFetchParams FromRawUnchecked(
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
                ["PlanID"] = this.PlanID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PlanFetchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PlanID?.Equals(other.PlanID) ?? other.PlanID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/plans/{0}", this.PlanID)
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
