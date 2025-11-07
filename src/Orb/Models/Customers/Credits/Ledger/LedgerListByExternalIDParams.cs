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
/// More details on using Orb's real-time credit feature are [here](/product-catalog/prepurchase).
///
/// There are four major types of modifications to credit balance, detailed below.
///
/// ## Increment Credits (which optionally expire on a future date) can be added
/// via the API ([Add Ledger Entry](create-ledger-entry)). The ledger entry for such
/// an action will always contain the total eligible starting and ending balance for
/// the customer at the time the entry was added to the ledger.
///
/// ## Decrement Deductions can occur as a result of an API call to create a ledger
/// entry (see [Add Ledger Entry](create-ledger-entry)), or automatically as a result
/// of incurring usage. Both ledger entries present the `decrement` entry type.
///
/// As usage for a customer is reported into Orb, credits may be deducted according
/// to the customer's plan configuration. An automated deduction of this type will
/// result in a ledger entry, also with a starting and ending balance. In order to
/// provide better tracing capabilities for automatic deductions, Orb always associates
/// each automatic deduction with the `event_id` at the time of ingestion, used to
/// pinpoint _why_ credit deduction took place and to ensure that credits are never
/// deducted without an associated usage event.
///
/// By default, Orb uses an algorithm that automatically deducts from the *soonest
/// expiring credit block* first in order to ensure that all credits are utilized
/// appropriately. As an example, if trial credits with an expiration date of 2 weeks
/// from now are present for a customer, they will be used before any deductions
/// take place from a non-expiring credit block.
///
/// If there are multiple blocks with the same expiration date, Orb will deduct from
/// the block with the *lower cost basis* first (e.g. trial credits with a \$0 cost
/// basis before paid credits with a \$5.00 cost basis).
///
/// It's also possible for a single usage event's deduction to _span_ credit blocks.
/// In this case, Orb will deduct from the next block, ending at the credit block
/// which consists of unexpiring credits. Each of these deductions will lead to a
/// _separate_ ledger entry, one per credit block that is deducted from. By default,
/// the customer's total credit balance in Orb can be negative as a result of a decrement.
///
/// ## Expiration change The expiry of credits can be changed as a result of the
/// API (See [Add Ledger Entry](create-ledger-entry)). This will create a ledger
/// entry that specifies the balance as well as the initial and target expiry dates.
///
/// Note that for this entry type, `starting_balance` will equal `ending_balance`,
/// and the `amount` represents the balance transferred. The credit block linked
/// to the ledger entry is the source credit block from which there was an expiration change.
///
/// ## Credits expiry When a set of credits expire on pre-set expiration date, the
/// customer's balance automatically reflects this change and adds an entry to the
/// ledger indicating this event. Note that credit expiry should always happen close
/// to a date boundary in the customer's timezone.
///
/// ## Void initiated Credit blocks can be voided via the API. The `amount` on this
/// entry corresponds to the number of credits that were remaining in the block at
/// time of void. `void_reason` will be populated if the void is created with a reason.
///
/// ## Void When a set of credits is voided, the customer's balance automatically
/// reflects this change and adds an entry to the ledger indicating this event.
///
/// ## Amendment When credits are added to a customer's balance as a result of a
/// correction, this entry will be added to the ledger to indicate the adjustment
/// of credits.
/// </summary>
public sealed record class LedgerListByExternalIDParams : ParamsBase
{
    public required string ExternalCustomerID { get; init; }

    public System::DateTime? CreatedAtGt
    {
        get
        {
            if (!this._queryProperties.TryGetValue("created_at[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["created_at[gt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? CreatedAtGte
    {
        get
        {
            if (!this._queryProperties.TryGetValue("created_at[gte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["created_at[gte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? CreatedAtLt
    {
        get
        {
            if (!this._queryProperties.TryGetValue("created_at[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["created_at[lt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? CreatedAtLte
    {
        get
        {
            if (!this._queryProperties.TryGetValue("created_at[lte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["created_at[lte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ledger currency or custom pricing unit to use.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._queryProperties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._queryProperties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this._queryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._queryProperties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, EntryStatusModel>? EntryStatus
    {
        get
        {
            if (!this._queryProperties.TryGetValue("entry_status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, EntryStatusModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["entry_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, EntryType10>? EntryType
    {
        get
        {
            if (!this._queryProperties.TryGetValue("entry_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, EntryType10>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._queryProperties["entry_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this._queryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._queryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? MinimumAmount
    {
        get
        {
            if (!this._queryProperties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._queryProperties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public LedgerListByExternalIDParams() { }

    public LedgerListByExternalIDParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerListByExternalIDParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }
#pragma warning restore CS8618

    public static LedgerListByExternalIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties)
        );
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/credits/ledger",
                    this.ExternalCustomerID
                )
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(EntryStatusModelConverter))]
public enum EntryStatusModel
{
    Committed,
    Pending,
}

sealed class EntryStatusModelConverter : JsonConverter<EntryStatusModel>
{
    public override EntryStatusModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => EntryStatusModel.Committed,
            "pending" => EntryStatusModel.Pending,
            _ => (EntryStatusModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryStatusModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryStatusModel.Committed => "committed",
                EntryStatusModel.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntryType10Converter))]
public enum EntryType10
{
    Increment,
    Decrement,
    ExpirationChange,
    CreditBlockExpiry,
    Void,
    VoidInitiated,
    Amendment,
}

sealed class EntryType10Converter : JsonConverter<EntryType10>
{
    public override EntryType10 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => EntryType10.Increment,
            "decrement" => EntryType10.Decrement,
            "expiration_change" => EntryType10.ExpirationChange,
            "credit_block_expiry" => EntryType10.CreditBlockExpiry,
            "void" => EntryType10.Void,
            "void_initiated" => EntryType10.VoidInitiated,
            "amendment" => EntryType10.Amendment,
            _ => (EntryType10)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryType10 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryType10.Increment => "increment",
                EntryType10.Decrement => "decrement",
                EntryType10.ExpirationChange => "expiration_change",
                EntryType10.CreditBlockExpiry => "credit_block_expiry",
                EntryType10.Void => "void",
                EntryType10.VoidInitiated => "void_initiated",
                EntryType10.Amendment => "amendment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
