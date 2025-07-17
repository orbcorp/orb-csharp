using CreditNotes = Orb.Models.CreditNotes;
using Models = Orb.Models;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.CreditNotes;

public interface ICreditNoteService
{
    /// <summary>
    /// This endpoint is used to create a single [`Credit Note`](/invoicing/credit-notes).
    ///
    /// The credit note service period configuration supports two explicit modes:
    ///
    /// 1. Global service periods: Specify start_date and end_date at the credit note
    /// level.    These dates will be applied to all line items uniformly.
    ///
    /// 2. Individual service periods: Specify start_date and end_date for each line
    /// item.    When using this mode, ALL line items must have individual periods specified.
    ///
    /// 3. Default behavior: If no service periods are specified (neither global nor
    /// individual),    the original invoice line item service periods will be used.
    ///
    /// Note: Mixing global and individual service periods in the same request is not
    /// allowed to prevent confusion.
    ///
    /// Service period dates are normalized to the start of the day in the customer's
    /// timezone to ensure consistent handling across different timezones.
    ///
    /// Date Format: Use start_date and end_date with format "YYYY-MM-DD" (e.g., "2023-09-22")
    /// to match other Orb APIs like /v1/invoice_line_items.
    ///
    /// Note: Both start_date and end_date are inclusive - the service period will cover
    /// both the start date and end date completely (from start of start_date to end
    /// of end_date).
    /// </summary>
    Tasks::Task<Models::CreditNote> Create(CreditNotes::CreditNoteCreateParams @params);

    /// <summary>
    /// Get a paginated list of CreditNotes. Users can also filter by customer_id, subscription_id,
    /// or external_customer_id. The credit notes will be returned in reverse chronological
    /// order by `creation_time`.
    /// </summary>
    Tasks::Task<CreditNotes::CreditNoteListPageResponse> List(
        CreditNotes::CreditNoteListParams @params
    );

    /// <summary>
    /// This endpoint is used to fetch a single [`Credit Note`](/invoicing/credit-notes)
    /// given an identifier.
    /// </summary>
    Tasks::Task<Models::CreditNote> Fetch(CreditNotes::CreditNoteFetchParams @params);
}
