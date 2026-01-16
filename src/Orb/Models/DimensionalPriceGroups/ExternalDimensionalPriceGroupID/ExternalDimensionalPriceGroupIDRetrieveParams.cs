using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

/// <summary>
/// Fetch dimensional price group by external ID
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalDimensionalPriceGroupIDRetrieveParams : ParamsBase
{
    public string? ExternalDimensionalPriceGroupID { get; init; }

    public ExternalDimensionalPriceGroupIDRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalDimensionalPriceGroupIDRetrieveParams(
        ExternalDimensionalPriceGroupIDRetrieveParams externalDimensionalPriceGroupIDRetrieveParams
    )
        : base(externalDimensionalPriceGroupIDRetrieveParams)
    {
        this.ExternalDimensionalPriceGroupID =
            externalDimensionalPriceGroupIDRetrieveParams.ExternalDimensionalPriceGroupID;
    }
#pragma warning restore CS8618

    public ExternalDimensionalPriceGroupIDRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalDimensionalPriceGroupIDRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ExternalDimensionalPriceGroupIDRetrieveParams FromRawUnchecked(
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
                ["ExternalDimensionalPriceGroupID"] = this.ExternalDimensionalPriceGroupID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExternalDimensionalPriceGroupIDRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.ExternalDimensionalPriceGroupID?.Equals(other.ExternalDimensionalPriceGroupID)
                ?? other.ExternalDimensionalPriceGroupID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/dimensional_price_groups/external_dimensional_price_group_id/{0}",
                    this.ExternalDimensionalPriceGroupID
                )
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
