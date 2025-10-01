using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// This endpoint allows you to create a new ledger entry for a specified customer's
/// balance. This can be used to increment balance, deduct credits, and change the
/// expiry date of existing credits.
///
/// ## Effects of adding a ledger entry 1. After calling this endpoint, [Fetch Credit
/// Balance](fetch-customer-credits) will return a credit block that   represents
/// the changes (i.e. balance changes or transfers). 2. A ledger entry will be added
/// to the credits ledger for this customer, and therefore returned in the   [View
/// Credits Ledger](fetch-customer-credits-ledger) response as well as serialized
/// in the response to this request. In   the case of deductions without a specified
/// block, multiple ledger entries may be created if the deduction spans   credit
/// blocks. 3. If `invoice_settings` is specified, an invoice will be created that
/// reflects the cost of the credits (based on   `amount` and `per_unit_cost_basis`).
///
/// ## Adding credits   Adding credits is done by creating an entry of type `increment`.
/// This requires the caller to specify a number of   credits as well as an optional
/// expiry date in `YYYY-MM-DD` format. Orb also recommends specifying a description
///   to assist with auditing. When adding credits, the caller can also specify a
/// cost basis per-credit, to indicate   how much in USD a customer paid for a single
/// credit in a block. This can later be used for revenue recognition.
///
/// The following snippet illustrates a sample request body to increment credits
/// which will expire in January of 2022.
///
/// ```json {   "entry_type": "increment",   "amount": 100,   "expiry_date": "2022-12-28",
///   "per_unit_cost_basis": "0.20",   "description": "Purchased 100 credits" } ```
///
/// Note that by default, Orb will always first increment any _negative_ balance in
/// existing blocks before adding the remaining amount to the desired credit block.
///
/// ### Invoicing for credits By default, Orb manipulates the credit ledger but does
/// not charge for credits. However, if you pass `invoice_settings` in the body of
/// this request, Orb will also generate a one-off invoice for the customer for the
/// credits pre-purchase. Note that you _must_ provide the `per_unit_cost_basis`,
/// since the total charges on the invoice are calculated by multiplying the cost
/// basis with the number of credit units added.
///
/// ## Deducting Credits Orb allows you to deduct credits from a customer by creating
/// an entry of type `decrement`. Orb matches the algorithm for automatic deductions
/// for determining which credit blocks to decrement from. In the case that the deduction
/// leads to multiple ledger entries, the response from this endpoint will be the
/// final deduction. Orb also optionally allows specifying a description to assist
/// with auditing.
///
/// The following snippet illustrates a sample request body to decrement credits.
///
/// ```json {   "entry_type": "decrement",   "amount": 20,   "description": "Removing
/// excess credits" } ```
///
/// ## Changing credits expiry If you'd like to change when existing credits expire,
/// you should create a ledger entry of type `expiration_change`. For this entry,
/// the required parameter `expiry_date` identifies the _originating_ block, and the
/// required parameter `target_expiry_date` identifies when the transferred credits
/// should now expire. A new credit block will be created with expiry date `target_expiry_date`,
/// with the same cost basis data as the original credit block, if present.
///
/// Note that the balance of the block with the given `expiry_date` must be at least
/// equal to the desired transfer amount determined by the `amount` parameter.
///
/// The following snippet illustrates a sample request body to extend the expiration
/// date of credits by one year:
///
/// ```json {   "entry_type": "expiration_change",   "amount": 10,   "expiry_date":
/// "2022-12-28",   "block_id": "UiUhFWeLHPrBY4Ad",   "target_expiry_date": "2023-12-28",
///   "description": "Extending credit validity" } ```
///
/// ## Voiding credits
///
/// If you'd like to void a credit block, create a ledger entry of type `void`. For
/// this entry, `block_id` is required to identify the block, and `amount` indicates
/// how many credits to void, up to the block's initial balance. Pass in a `void_reason`
/// of `refund` if the void is due to a refund.
///
/// ## Amendment
///
/// If you'd like to undo a decrement on a credit block, create a ledger entry of
/// type `amendment`. For this entry, `block_id` is required to identify the block
/// that was originally decremented from, and `amount` indicates how many credits
/// to return to the customer, up to the block's initial balance.
/// </summary>
public sealed record class LedgerCreateEntryParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string CustomerID;

    public required Body Body
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("body", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'body' cannot be null",
                    new ArgumentOutOfRangeException("body", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'body' cannot be null",
                    new ArgumentNullException("body")
                );
        }
        set
        {
            this.BodyProperties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/credits/ledger_entry", this.CustomerID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
