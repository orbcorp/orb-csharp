using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Customers.BalanceTransactions;

/// <summary>
/// ## The customer balance
///
/// <para>The customer balance is an amount in the customer's currency, which Orb
/// automatically applies to subsequent invoices. This balance can be adjusted manually
/// via Orb's webapp on the customer details page. You can use this balance to provide
/// a fixed mid-period credit to the customer. Commonly, this is done due to system
/// downtime/SLA violation, or an adhoc adjustment discussed with the customer.</para>
///
/// <para>If the balance is a positive value at the time of invoicing, it represents
/// that the customer has credit that should be used to offset the amount due on the
/// next issued invoice. In this case, Orb will automatically reduce the next invoice
/// by the balance amount, and roll over any remaining balance if the invoice is fully discounted.</para>
///
/// <para>If the balance is a negative value at the time of invoicing, Orb will increase
/// the invoice's amount due with a positive adjustment, and reset the balance to 0.</para>
///
/// <para>This endpoint retrieves all customer balance transactions in reverse chronological
/// order for a single customer, providing a complete audit trail of all adjustments
/// and invoice applications.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BalanceTransactionListParams : ParamsBase
{
    public string? CustomerID { get; init; }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init { this._rawQueryData.Set("cursor", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public DateTimeOffset? OperationTimeGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("operation_time[gt]");
        }
        init { this._rawQueryData.Set("operation_time[gt]", value); }
    }

    public DateTimeOffset? OperationTimeGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("operation_time[gte]");
        }
        init { this._rawQueryData.Set("operation_time[gte]", value); }
    }

    public DateTimeOffset? OperationTimeLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("operation_time[lt]");
        }
        init { this._rawQueryData.Set("operation_time[lt]", value); }
    }

    public DateTimeOffset? OperationTimeLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("operation_time[lte]");
        }
        init { this._rawQueryData.Set("operation_time[lte]", value); }
    }

    public BalanceTransactionListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceTransactionListParams(BalanceTransactionListParams balanceTransactionListParams)
        : base(balanceTransactionListParams)
    {
        this.CustomerID = balanceTransactionListParams.CustomerID;
    }
#pragma warning restore CS8618

    public BalanceTransactionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static BalanceTransactionListParams FromRawUnchecked(
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
                ["CustomerID"] = this.CustomerID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BalanceTransactionListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CustomerID?.Equals(other.CustomerID) ?? other.CustomerID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/balance_transactions", this.CustomerID)
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
