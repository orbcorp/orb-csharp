using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.InvoiceLineItems;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvoiceLineItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvoiceLineItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceLineItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This creates a one-off fixed fee invoice line item on an Invoice. This can
    /// only be done for invoices that are in a `draft` status.
    ///
    /// <para>The behavior depends on which parameters are provided: - If `item_id`
    /// is provided without `name`: The item is looked up by ID, and the item's name
    ///   is used for the line item. - If `name` is provided without `item_id`: An
    /// item with the given name is searched for in the account.   If found, that
    /// item is used. If not found, a new item is created with that name.   The new
    /// item's name is used for the line item. - If both `item_id` and `name` are
    /// provided: The item is looked up by ID for association,   but the provided
    /// `name` is used for the line item (not the item's name).</para>
    /// </summary>
    Task<InvoiceLineItemCreateResponse> Create(
        InvoiceLineItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvoiceLineItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvoiceLineItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceLineItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /invoice_line_items`, but is otherwise the
    /// same as <see cref="IInvoiceLineItemService.Create(InvoiceLineItemCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceLineItemCreateResponse>> Create(
        InvoiceLineItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
