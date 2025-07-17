using InvoiceLineItems = Orb.Models.InvoiceLineItems;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.InvoiceLineItems;

public interface IInvoiceLineItemService
{
    /// <summary>
    /// This creates a one-off fixed fee invoice line item on an Invoice. This can only
    /// be done for invoices that are in a `draft` status.
    /// </summary>
    Tasks::Task<InvoiceLineItems::InvoiceLineItemCreateResponse> Create(
        InvoiceLineItems::InvoiceLineItemCreateParams @params
    );
}
