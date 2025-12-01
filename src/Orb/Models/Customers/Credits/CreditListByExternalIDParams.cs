using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Customers.Credits;

/// <summary>
/// Returns a paginated list of unexpired, non-zero credit blocks for a customer.
///
/// <para>If `include_all_blocks` is set to `true`, all credit blocks (including
/// expired and depleted blocks) will be included in the response.</para>
///
/// <para>Note that `currency` defaults to credits if not specified. To use a real
/// world currency, set `currency` to an ISO 4217 string.</para>
/// </summary>
public sealed record class CreditListByExternalIDParams : ParamsBase
{
    public string? ExternalCustomerID { get; init; }

    /// <summary>
    /// The ledger currency or custom pricing unit to use.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "currency"); }
        init { ModelBase.Set(this._rawQueryData, "currency", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { ModelBase.Set(this._rawQueryData, "cursor", value); }
    }

    /// <summary>
    /// If set to True, all expired and depleted blocks, as well as active block
    /// will be returned.
    /// </summary>
    public bool? IncludeAllBlocks
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawQueryData, "include_all_blocks"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "include_all_blocks", value);
        }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "limit", value);
        }
    }

    public CreditListByExternalIDParams() { }

    public CreditListByExternalIDParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static CreditListByExternalIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/credits",
                    this.ExternalCustomerID
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
}
