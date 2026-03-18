using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.CreditBlocks;

/// <summary>
/// This endpoint returns the credit block and its associated purchasing invoices.
///
/// <para>If a credit block was purchased (as opposed to being manually added or allocated
/// from a subscription), this endpoint returns the invoices that were created to
/// charge the customer for the credit block. For credit blocks with payment schedules
/// spanning multiple periods (e.g., monthly payments over 12 months), multiple invoices
/// will be returned.</para>
///
/// <para>If the credit block was not purchased (e.g., manual increment, allocation),
/// an empty invoices list is returned.</para>
///
/// <para>**Note: This endpoint is currently experimental and its interface may change
/// in future releases. Please contact support before building production integrations
/// against this endpoint.**</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditBlockListInvoicesParams : ParamsBase
{
    public string? BlockID { get; init; }

    public CreditBlockListInvoicesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditBlockListInvoicesParams(
        CreditBlockListInvoicesParams creditBlockListInvoicesParams
    )
        : base(creditBlockListInvoicesParams)
    {
        this.BlockID = creditBlockListInvoicesParams.BlockID;
    }
#pragma warning restore CS8618

    public CreditBlockListInvoicesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBlockListInvoicesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string blockID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.BlockID = blockID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CreditBlockListInvoicesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string blockID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            blockID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BlockID"] = JsonSerializer.SerializeToElement(this.BlockID),
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

    public virtual bool Equals(CreditBlockListInvoicesParams? other)
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
                + string.Format("/credit_blocks/{0}/invoices", this.BlockID)
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
