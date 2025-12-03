using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The credits ledger provides _auditing_ functionality over Orb's credits system
/// with a list of actions that have taken place to modify a customer's credit balance.
/// This [paginated endpoint](/api-reference/pagination) lists these entries, starting
/// from the most recent ledger entry.
///
/// <para>More details on using Orb's real-time credit feature are [here](/product-catalog/prepurchase).</para>
///
/// <para>There are four major types of modifications to credit balance, detailed below.</para>
///
/// <para>## Increment Credits (which optionally expire on a future date) can be
/// added via the API ([Add Ledger Entry](create-ledger-entry)). The ledger entry
/// for such an action will always contain the total eligible starting and ending
/// balance for the customer at the time the entry was added to the ledger.</para>
///
/// <para>## Decrement Deductions can occur as a result of an API call to create
/// a ledger entry (see [Add Ledger Entry](create-ledger-entry)), or automatically
/// as a result of incurring usage. Both ledger entries present the `decrement` entry type.</para>
///
/// <para>As usage for a customer is reported into Orb, credits may be deducted according
/// to the customer's plan configuration. An automated deduction of this type will
/// result in a ledger entry, also with a starting and ending balance. In order to
/// provide better tracing capabilities for automatic deductions, Orb always associates
/// each automatic deduction with the `event_id` at the time of ingestion, used to
/// pinpoint _why_ credit deduction took place and to ensure that credits are never
/// deducted without an associated usage event.</para>
///
/// <para>By default, Orb uses an algorithm that automatically deducts from the *soonest
/// expiring credit block* first in order to ensure that all credits are utilized
/// appropriately. As an example, if trial credits with an expiration date of 2 weeks
/// from now are present for a customer, they will be used before any deductions take
/// place from a non-expiring credit block.</para>
///
/// <para>If there are multiple blocks with the same expiration date, Orb will deduct
/// from the block with the *lower cost basis* first (e.g. trial credits with a \$0
/// cost basis before paid credits with a \$5.00 cost basis).</para>
///
/// <para>It's also possible for a single usage event's deduction to _span_ credit
/// blocks. In this case, Orb will deduct from the next block, ending at the credit
/// block which consists of unexpiring credits. Each of these deductions will lead
/// to a _separate_ ledger entry, one per credit block that is deducted from. By default,
/// the customer's total credit balance in Orb can be negative as a result of a decrement.</para>
///
/// <para>## Expiration change The expiry of credits can be changed as a result of
/// the API (See [Add Ledger Entry](create-ledger-entry)). This will create a ledger
/// entry that specifies the balance as well as the initial and target expiry dates.</para>
///
/// <para>Note that for this entry type, `starting_balance` will equal `ending_balance`,
/// and the `amount` represents the balance transferred. The credit block linked to
/// the ledger entry is the source credit block from which there was an expiration change.</para>
///
/// <para>## Credits expiry When a set of credits expire on pre-set expiration date,
/// the customer's balance automatically reflects this change and adds an entry to
/// the ledger indicating this event. Note that credit expiry should always happen
/// close to a date boundary in the customer's timezone.</para>
///
/// <para>## Void initiated Credit blocks can be voided via the API. The `amount`
/// on this entry corresponds to the number of credits that were remaining in the
/// block at time of void. `void_reason` will be populated if the void is created
/// with a reason.</para>
///
/// <para>## Void When a set of credits is voided, the customer's balance automatically
/// reflects this change and adds an entry to the ledger indicating this event.</para>
///
/// <para>## Amendment When credits are added to a customer's balance as a result
/// of a correction, this entry will be added to the ledger to indicate the adjustment
/// of credits.</para>
/// </summary>
public sealed record class LedgerListByExternalIDParams : ParamsBase
{
    public string? ExternalCustomerID { get; init; }

    public System::DateTimeOffset? CreatedAtGt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "created_at[gt]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[gt]", value); }
    }

    public System::DateTimeOffset? CreatedAtGte
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "created_at[gte]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[gte]", value); }
    }

    public System::DateTimeOffset? CreatedAtLt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "created_at[lt]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[lt]", value); }
    }

    public System::DateTimeOffset? CreatedAtLte
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "created_at[lte]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[lte]", value); }
    }

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

    public ApiEnum<string, LedgerListByExternalIDParamsEntryStatus>? EntryStatus
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, LedgerListByExternalIDParamsEntryStatus>
            >(this.RawQueryData, "entry_status");
        }
        init { ModelBase.Set(this._rawQueryData, "entry_status", value); }
    }

    public ApiEnum<string, LedgerListByExternalIDParamsEntryType>? EntryType
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, LedgerListByExternalIDParamsEntryType>
            >(this.RawQueryData, "entry_type");
        }
        init { ModelBase.Set(this._rawQueryData, "entry_type", value); }
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

    public string? MinimumAmount
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "minimum_amount"); }
        init { ModelBase.Set(this._rawQueryData, "minimum_amount", value); }
    }

    public LedgerListByExternalIDParams() { }

    public LedgerListByExternalIDParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerListByExternalIDParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static LedgerListByExternalIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/credits/ledger",
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

[JsonConverter(typeof(LedgerListByExternalIDParamsEntryStatusConverter))]
public enum LedgerListByExternalIDParamsEntryStatus
{
    Committed,
    Pending,
}

sealed class LedgerListByExternalIDParamsEntryStatusConverter
    : JsonConverter<LedgerListByExternalIDParamsEntryStatus>
{
    public override LedgerListByExternalIDParamsEntryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => LedgerListByExternalIDParamsEntryStatus.Committed,
            "pending" => LedgerListByExternalIDParamsEntryStatus.Pending,
            _ => (LedgerListByExternalIDParamsEntryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerListByExternalIDParamsEntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LedgerListByExternalIDParamsEntryStatus.Committed => "committed",
                LedgerListByExternalIDParamsEntryStatus.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(LedgerListByExternalIDParamsEntryTypeConverter))]
public enum LedgerListByExternalIDParamsEntryType
{
    Increment,
    Decrement,
    ExpirationChange,
    CreditBlockExpiry,
    Void,
    VoidInitiated,
    Amendment,
}

sealed class LedgerListByExternalIDParamsEntryTypeConverter
    : JsonConverter<LedgerListByExternalIDParamsEntryType>
{
    public override LedgerListByExternalIDParamsEntryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => LedgerListByExternalIDParamsEntryType.Increment,
            "decrement" => LedgerListByExternalIDParamsEntryType.Decrement,
            "expiration_change" => LedgerListByExternalIDParamsEntryType.ExpirationChange,
            "credit_block_expiry" => LedgerListByExternalIDParamsEntryType.CreditBlockExpiry,
            "void" => LedgerListByExternalIDParamsEntryType.Void,
            "void_initiated" => LedgerListByExternalIDParamsEntryType.VoidInitiated,
            "amendment" => LedgerListByExternalIDParamsEntryType.Amendment,
            _ => (LedgerListByExternalIDParamsEntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerListByExternalIDParamsEntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LedgerListByExternalIDParamsEntryType.Increment => "increment",
                LedgerListByExternalIDParamsEntryType.Decrement => "decrement",
                LedgerListByExternalIDParamsEntryType.ExpirationChange => "expiration_change",
                LedgerListByExternalIDParamsEntryType.CreditBlockExpiry => "credit_block_expiry",
                LedgerListByExternalIDParamsEntryType.Void => "void",
                LedgerListByExternalIDParamsEntryType.VoidInitiated => "void_initiated",
                LedgerListByExternalIDParamsEntryType.Amendment => "amendment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
