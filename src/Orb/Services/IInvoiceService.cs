using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Invoices;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint is used to create a one-off invoice for a customer.
    /// </summary>
    Task<Invoice> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to update the `metadata`, `net_terms`, `due_date`,
    /// and `invoice_date` properties on an invoice. If you pass null for the metadata
    /// value, it will clear any existing metadata for that invoice.
    ///
    /// <para>`metadata` can be modified regardless of invoice state. `net_terms`,
    /// `due_date`, and `invoice_date` can only be modified if the invoice is in a
    /// `draft` state. `invoice_date` can only be modified for non-subscription invoices.</para>
    /// </summary>
    Task<Invoice> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(InvoiceUpdateParams, CancellationToken)"/>
    Task<Invoice> Update(
        string invoiceID,
        InvoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all [`Invoice`](/core-concepts#invoice)s
    /// for an account in a list format.
    ///
    /// <para>The list of invoices is ordered starting from the most recently issued
    /// invoice date. The response also includes [`pagination_metadata`](/api-reference/pagination),
    /// which lets the caller retrieve the next page of results if they exist.</para>
    ///
    /// <para>By default, this only returns invoices that are `issued`, `paid`, or `synced`.</para>
    ///
    /// <para>When fetching any `draft` invoices, this returns the last-computed invoice
    /// values for each draft invoice, which may not always be up-to-date since Orb
    /// regularly refreshes invoices asynchronously.</para>
    /// </summary>
    Task<InvoiceListPage> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint deletes an invoice line item from a draft invoice.
    ///
    /// <para>This endpoint only allows deletion of one-off line items (not subscription-based
    /// line items). The invoice must be in a draft status for this operation to succeed.</para>
    /// </summary>
    Task DeleteLineItem(
        InvoiceDeleteLineItemParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteLineItem(InvoiceDeleteLineItemParams, CancellationToken)"/>
    Task DeleteLineItem(
        string lineItemID,
        InvoiceDeleteLineItemParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch an [`Invoice`](/core-concepts#invoice) given
    /// an identifier.
    /// </summary>
    Task<Invoice> Fetch(
        InvoiceFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(InvoiceFetchParams, CancellationToken)"/>
    Task<Invoice> Fetch(
        string invoiceID,
        InvoiceFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to fetch the upcoming [invoice](/core-concepts#invoice)
    /// for the current billing period given a subscription.
    /// </summary>
    Task<InvoiceFetchUpcomingResponse> FetchUpcoming(
        InvoiceFetchUpcomingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows an eligible invoice to be issued manually. This is only
    /// possible with invoices where status is `draft`, `will_auto_issue` is false,
    /// and an `eligible_to_issue_at` is a time in the past. Issuing an invoice could
    /// possibly trigger side effects, some of which could be customer-visible (e.g.
    /// sending emails, auto-collecting payment, syncing the invoice to external
    /// providers, etc).
    /// </summary>
    Task<Invoice> Issue(
        InvoiceIssueParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Issue(InvoiceIssueParams, CancellationToken)"/>
    Task<Invoice> Issue(
        string invoiceID,
        InvoiceIssueParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This is a lighter-weight endpoint that returns a list of all [`Invoice`](/core-concepts#invoice)
    /// summaries for an account in a list format.
    ///
    /// <para>These invoice summaries do not include line item details, minimums,
    /// maximums, and discounts, making this endpoint more efficient.</para>
    ///
    /// <para>The list of invoices is ordered starting from the most recently issued
    /// invoice date. The response also includes [`pagination_metadata`](/api-reference/pagination),
    /// which lets the caller retrieve the next page of results if they exist.</para>
    ///
    /// <para>By default, this only returns invoices that are `issued`, `paid`, or `synced`.</para>
    ///
    /// <para>When fetching any `draft` invoices, this returns the last-computed invoice
    /// values for each draft invoice, which may not always be up-to-date since Orb
    /// regularly refreshes invoices asynchronously.</para>
    /// </summary>
    Task<InvoiceListSummaryPage> ListSummary(
        InvoiceListSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows an invoice's status to be set to the `paid` status. This
    /// can only be done to invoices that are in the `issued` or `synced` status.
    /// </summary>
    Task<Invoice> MarkPaid(
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MarkPaid(InvoiceMarkPaidParams, CancellationToken)"/>
    Task<Invoice> MarkPaid(
        string invoiceID,
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint collects payment for an invoice using the customer's default
    /// payment method. This action can only be taken on invoices with status "issued".
    /// </summary>
    Task<Invoice> Pay(InvoicePayParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Pay(InvoicePayParams, CancellationToken)"/>
    Task<Invoice> Pay(
        string invoiceID,
        InvoicePayParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows an invoice's status to be set to the `void` status. This
    /// can only be done to invoices that are in the `issued` status.
    ///
    /// <para>If the associated invoice has used the customer balance to change the
    /// amount due, the customer balance operation will be reverted. For example,
    /// if the invoice used \$10 of customer balance, that amount will be added back
    /// to the customer balance upon voiding.</para>
    ///
    /// <para>If the invoice was used to purchase a credit block, but the invoice
    /// is not yet paid, the credit block will be voided. If the invoice was created
    /// due to a top-up, the top-up will be disabled.</para>
    /// </summary>
    Task<Invoice> Void(InvoiceVoidParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Void(InvoiceVoidParams, CancellationToken)"/>
    Task<Invoice> Void(
        string invoiceID,
        InvoiceVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /invoices`, but is otherwise the
    /// same as <see cref="IInvoiceService.Create(InvoiceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /invoices/{invoice_id}`, but is otherwise the
    /// same as <see cref="IInvoiceService.Update(InvoiceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(InvoiceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Update(
        string invoiceID,
        InvoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /invoices`, but is otherwise the
    /// same as <see cref="IInvoiceService.List(InvoiceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceListPage>> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /invoices/{invoice_id}/invoice_line_items/{line_item_id}`, but is otherwise the
    /// same as <see cref="IInvoiceService.DeleteLineItem(InvoiceDeleteLineItemParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DeleteLineItem(
        InvoiceDeleteLineItemParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteLineItem(InvoiceDeleteLineItemParams, CancellationToken)"/>
    Task<HttpResponse> DeleteLineItem(
        string lineItemID,
        InvoiceDeleteLineItemParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /invoices/{invoice_id}`, but is otherwise the
    /// same as <see cref="IInvoiceService.Fetch(InvoiceFetchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Fetch(
        InvoiceFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(InvoiceFetchParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Fetch(
        string invoiceID,
        InvoiceFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /invoices/upcoming`, but is otherwise the
    /// same as <see cref="IInvoiceService.FetchUpcoming(InvoiceFetchUpcomingParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceFetchUpcomingResponse>> FetchUpcoming(
        InvoiceFetchUpcomingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /invoices/{invoice_id}/issue`, but is otherwise the
    /// same as <see cref="IInvoiceService.Issue(InvoiceIssueParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Issue(
        InvoiceIssueParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Issue(InvoiceIssueParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Issue(
        string invoiceID,
        InvoiceIssueParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /invoices/summary`, but is otherwise the
    /// same as <see cref="IInvoiceService.ListSummary(InvoiceListSummaryParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceListSummaryPage>> ListSummary(
        InvoiceListSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /invoices/{invoice_id}/mark_paid`, but is otherwise the
    /// same as <see cref="IInvoiceService.MarkPaid(InvoiceMarkPaidParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> MarkPaid(
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MarkPaid(InvoiceMarkPaidParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> MarkPaid(
        string invoiceID,
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /invoices/{invoice_id}/pay`, but is otherwise the
    /// same as <see cref="IInvoiceService.Pay(InvoicePayParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Pay(
        InvoicePayParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Pay(InvoicePayParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Pay(
        string invoiceID,
        InvoicePayParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /invoices/{invoice_id}/void`, but is otherwise the
    /// same as <see cref="IInvoiceService.Void(InvoiceVoidParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invoice>> Void(
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Void(InvoiceVoidParams, CancellationToken)"/>
    Task<HttpResponse<Invoice>> Void(
        string invoiceID,
        InvoiceVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
