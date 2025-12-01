using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.CreditNotes;

/// <summary>
/// Get a paginated list of CreditNotes. Users can also filter by customer_id, subscription_id,
/// or external_customer_id. The credit notes will be returned in reverse chronological
/// order by `creation_time`.
/// </summary>
public sealed record class CreditNoteListParams : ParamsBase
{
    public DateTimeOffset? CreatedAtGt
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "created_at[gt]");
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[gt]", value); }
    }

    public DateTimeOffset? CreatedAtGte
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(
                this.RawQueryData,
                "created_at[gte]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[gte]", value); }
    }

    public DateTimeOffset? CreatedAtLt
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawQueryData, "created_at[lt]");
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[lt]", value); }
    }

    public DateTimeOffset? CreatedAtLte
    {
        get
        {
            return ModelBase.GetNullableStruct<DateTimeOffset>(
                this.RawQueryData,
                "created_at[lte]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[lte]", value); }
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

    public CreditNoteListParams() { }

    public CreditNoteListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNoteListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static CreditNoteListParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/credit_notes")
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
