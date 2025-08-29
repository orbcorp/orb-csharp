using System.Threading.Tasks;
using Orb.Models.InvoiceLineItems;

namespace Orb.Services.InvoiceLineItems;

public interface IInvoiceLineItemService
{
    /// <summary>
    /// This creates a one-off fixed fee invoice line item on an Invoice. This can
    /// only be done for invoices that are in a `draft` status.
    /// </summary>
    Task<InvoiceLineItemCreateResponse> Create(InvoiceLineItemCreateParams parameters);
}
