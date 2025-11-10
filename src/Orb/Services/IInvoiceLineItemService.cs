using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.InvoiceLineItems;

namespace Orb.Services;

public interface IInvoiceLineItemService
{
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
