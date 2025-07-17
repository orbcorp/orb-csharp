using Invoices = Orb.Models.Invoices;
using Models = Orb.Models;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Invoices;

public interface IInvoiceService
{
    /// <summary>
    /// This endpoint is used to create a one-off invoice for a customer.
    /// </summary>
    Tasks::Task<Models::Invoice> Create(Invoices::InvoiceCreateParams @params);

    /// <summary>
    /// This endpoint allows you to update the `metadata` property on an invoice. If
    /// you pass null for the metadata value, it will clear any existing metadata for
    /// that invoice.
    ///
    /// `metadata` can be modified regardless of invoice state.
    /// </summary>
    Tasks::Task<Models::Invoice> Update(Invoices::InvoiceUpdateParams @params);

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
    /// When fetching any `draft` invoices, this returns the last-computed invoice values
    /// for each draft invoice, which may not always be up-to-date since Orb regularly
    /// refreshes invoices asynchronously.
    /// </summary>
    Tasks::Task<Invoices::InvoiceListPageResponse> List(Invoices::InvoiceListParams @params);

    /// <summary>
    /// This endpoint is used to fetch an [`Invoice`](/core-concepts#invoice) given
    /// an identifier.
    /// </summary>
    Tasks::Task<Models::Invoice> Fetch(Invoices::InvoiceFetchParams @params);

    /// <summary>
    /// This endpoint can be used to fetch the upcoming [invoice](/core-concepts#invoice)
    /// for the current billing period given a subscription.
    /// </summary>
    Tasks::Task<Invoices::InvoiceFetchUpcomingResponse> FetchUpcoming(
        Invoices::InvoiceFetchUpcomingParams @params
    );

    /// <summary>
    /// This endpoint allows an eligible invoice to be issued manually. This is only
    /// possible with invoices where status is `draft`, `will_auto_issue` is false,
    /// and an `eligible_to_issue_at` is a time in the past. Issuing an invoice could
    /// possibly trigger side effects, some of which could be customer-visible (e.g.
    /// sending emails, auto-collecting payment, syncing the invoice to external providers, etc).
    /// </summary>
    Tasks::Task<Models::Invoice> Issue(Invoices::InvoiceIssueParams @params);

    /// <summary>
    /// This endpoint allows an invoice's status to be set the `paid` status. This
    /// can only be done to invoices that are in the `issued` status.
    /// </summary>
    Tasks::Task<Models::Invoice> MarkPaid(Invoices::InvoiceMarkPaidParams @params);

    /// <summary>
    /// This endpoint collects payment for an invoice using the customer's default
    /// payment method. This action can only be taken on invoices with status "issued".
    /// </summary>
    Tasks::Task<Models::Invoice> Pay(Invoices::InvoicePayParams @params);

    /// <summary>
    /// This endpoint allows an invoice's status to be set the `void` status. This
    /// can only be done to invoices that are in the `issued` status.
    ///
    /// If the associated invoice has used the customer balance to change the amount
    /// due, the customer balance operation will be reverted. For example, if the invoice
    /// used \$10 of customer balance, that amount will be added back to the customer
    /// balance upon voiding.
    ///
    /// If the invoice was used to purchase a credit block, but the invoice is not
    /// yet paid, the credit block will be voided. If the invoice was created due to
    /// a top-up, the top-up will be disabled.
    /// </summary>
    Tasks::Task<Models::Invoice> Void(Invoices::InvoiceVoidParams @params);
}
