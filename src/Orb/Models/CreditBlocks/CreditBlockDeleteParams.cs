using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.CreditBlocks;

/// <summary>
/// This endpoint deletes a credit block by its ID.
///
/// <para>When a credit block is deleted: - The block is removed from the customer's
/// credit ledger. - Any usage of the credit block is reversed, and the ledger is
/// replayed as if the block never existed. - If invoices were generated from the
/// purchase of the credit block, they will be deleted if in draft status,   voided
/// if issued, or a credit note will be issued if the invoice is paid.</para>
///
/// <para><Note> Issued invoices that had credits applied from this block will not
/// be regenerated, but the ledger will reflect the state as if credits from the
/// deleted block were never applied. </Note></para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditBlockDeleteParams : ParamsBase
{
    public string? BlockID { get; init; }

    public CreditBlockDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditBlockDeleteParams(CreditBlockDeleteParams creditBlockDeleteParams)
        : base(creditBlockDeleteParams)
    {
        this.BlockID = creditBlockDeleteParams.BlockID;
    }
#pragma warning restore CS8618

    public CreditBlockDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBlockDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CreditBlockDeleteParams FromRawUnchecked(
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
                ["BlockID"] = this.BlockID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CreditBlockDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.BlockID?.Equals(other.BlockID) ?? other.BlockID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/credit_blocks/{0}", this.BlockID)
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
