using Http = System.Net.Http;
using Json = System.Text.Json;
using LedgerListParamsProperties = Orb.Models.Customers.Credits.Ledger.LedgerListParamsProperties;
using Orb = Orb;
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
/// to the ledger entry is the source credit block from which there was an expiration change
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
public sealed record class LedgerListParams : Orb::ParamsBase
{
    public required string CustomerID;

    public System::DateTime? CreatedAtGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["created_at[gt]"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public System::DateTime? CreatedAtGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gte]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["created_at[gte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? CreatedAtLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["created_at[lt]"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public System::DateTime? CreatedAtLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lte]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["created_at[lte]"] = Json::JsonSerializer.SerializeToElement(
                value
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
            if (!this.QueryProperties.TryGetValue("currency", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["cursor"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public LedgerListParamsProperties::EntryStatus? EntryStatus
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("entry_status", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<LedgerListParamsProperties::EntryStatus?>(
                element
            );
        }
        set
        {
            this.QueryProperties["entry_status"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public LedgerListParamsProperties::EntryType? EntryType
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("entry_type", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<LedgerListParamsProperties::EntryType?>(
                element
            );
        }
        set { this.QueryProperties["entry_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? MinimumAmount
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("minimum_amount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.QueryProperties["minimum_amount"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/credits/ledger", this.CustomerID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
