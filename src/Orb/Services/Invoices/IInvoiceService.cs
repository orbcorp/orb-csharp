using System;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Invoices;

namespace Orb.Services.Invoices;

public interface IInvoiceService
{
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint is used to create a one-off invoice for a customer.
    /// </summary>
    Task<Invoice> Create(InvoiceCreateParams parameters);

    /// <summary>
    /// This endpoint allows you to update the `metadata`, `net_terms`, `due_date`,
    /// and `invoice_date` properties on an invoice. If you pass null for the metadata
    /// value, it will clear any existing metadata for that invoice.
    ///
    /// `metadata` can be modified regardless of invoice state. `net_terms`, `due_date`,
    /// and `invoice_date` can only be modified if the invoice is in a `draft` state.
    /// `invoice_date` can only be modified for non-subscription invoices.
    /// </summary>
    Task<Invoice> Update(InvoiceUpdateParams parameters);

    /// <summary>
    /// This endpoint returns a list of all [`Invoice`](/core-concepts#invoice)s for
    /// an account in a list format.
    ///
    /// The list of invoices is ordered starting from the most recently issued invoice
    /// date. The response also includes [`pagination_metadata`](/api-reference/pagination),
    /// which lets the caller retrieve the next page of results if they exist.
    ///
    /// By default, this only returns invoices that are `issued`, `paid`, or `synced`.
    ///
    /// When fetching any `draft` invoices, this returns the last-computed invoice
    /// values for each draft invoice, which may not always be up-to-date since Orb
    /// regularly refreshes invoices asynchronously.
    /// </summary>
    Task<InvoiceListPageResponse> List(InvoiceListParams? parameters = null);

    /// <summary>
    /// This endpoint is used to fetch an [`Invoice`](/core-concepts#invoice) given
    /// an identifier.
    /// </summary>
    Task<Invoice> Fetch(InvoiceFetchParams parameters);

    /// <summary>
    /// This endpoint can be used to fetch the upcoming [invoice](/core-concepts#invoice)
    /// for the current billing period given a subscription.
    /// </summary>
    Task<InvoiceFetchUpcomingResponse> FetchUpcoming(InvoiceFetchUpcomingParams parameters);

    /// <summary>
    /// This endpoint allows an eligible invoice to be issued manually. This is only
    /// possible with invoices where status is `draft`, `will_auto_issue` is false,
    /// and an `eligible_to_issue_at` is a time in the past. Issuing an invoice could
    /// possibly trigger side effects, some of which could be customer-visible (e.g.
    /// sending emails, auto-collecting payment, syncing the invoice to external providers, etc).
    /// </summary>
    Task<Invoice> Issue(InvoiceIssueParams parameters);

    /// <summary>
    /// This endpoint allows an invoice's status to be set to the `paid` status.
    /// This can only be done to invoices that are in the `issued` or `synced` status.
    /// </summary>
    Task<Invoice> MarkPaid(InvoiceMarkPaidParams parameters);

    /// <summary>
    /// This endpoint collects payment for an invoice using the customer's default
    /// payment method. This action can only be taken on invoices with status "issued".
    /// </summary>
    Task<Invoice> Pay(InvoicePayParams parameters);

    /// <summary>
    /// This endpoint allows an invoice's status to be set to the `void` status.
    /// This can only be done to invoices that are in the `issued` status.
    ///
    /// If the associated invoice has used the customer balance to change the amount
    /// due, the customer balance operation will be reverted. For example, if the
    /// invoice used \$10 of customer balance, that amount will be added back to the
    /// customer balance upon voiding.
    ///
    /// If the invoice was used to purchase a credit block, but the invoice is not
    /// yet paid, the credit block will be voided. If the invoice was created due
    /// to a top-up, the top-up will be disabled.
    /// </summary>
    Task<Invoice> Void(InvoiceVoidParams parameters);
}
