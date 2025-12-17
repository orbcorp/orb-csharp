using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

/// <summary>
/// This endpoint can be used to update the `external_dimensional_price_group_id`
/// and `metadata` of an existing dimensional price group. Other fields on a dimensional
/// price group are currently immutable.
/// </summary>
public sealed record class ExternalDimensionalPriceGroupIDUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ExternalDimensionalPriceGroupID { get; init; }

    /// <summary>
    /// An optional user-defined ID for this dimensional price group resource, used
    /// throughout the system as an alias for this dimensional price group. Use this
    /// field to identify a dimensional price group by an existing identifier in
    /// your system.
    /// </summary>
    public string? ExternalDimensionalPriceGroupIDValue
    {
        get
        {
            return JsonModel.GetNullableClass<string>(
                this.RawBodyData,
                "external_dimensional_price_group_id"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "external_dimensional_price_group_id", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "metadata", value); }
    }

    public ExternalDimensionalPriceGroupIDUpdateParams() { }

    public ExternalDimensionalPriceGroupIDUpdateParams(
        ExternalDimensionalPriceGroupIDUpdateParams externalDimensionalPriceGroupIDUpdateParams
    )
        : base(externalDimensionalPriceGroupIDUpdateParams)
    {
        this._rawBodyData = [.. externalDimensionalPriceGroupIDUpdateParams._rawBodyData];
    }

    public ExternalDimensionalPriceGroupIDUpdateParams(
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
    ExternalDimensionalPriceGroupIDUpdateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ExternalDimensionalPriceGroupIDUpdateParams FromRawUnchecked(
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
                + string.Format(
                    "/dimensional_price_groups/external_dimensional_price_group_id/{0}",
                    this.ExternalDimensionalPriceGroupID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
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
