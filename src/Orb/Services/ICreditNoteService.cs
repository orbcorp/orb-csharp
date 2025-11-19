using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.CreditNotes;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICreditNoteService
{
    ICreditNoteService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint is used to create a single [`Credit Note`](/invoicing/credit-notes).
    ///
    /// <para>The credit note service period configuration supports two explicit modes:</para>
    ///
    /// <para>1. Global service periods: Specify start_date and end_date at the credit
    /// note level.    These dates will be applied to all line items uniformly.</para>
    ///
    /// <para>2. Individual service periods: Specify start_date and end_date for each
    /// line item.    When using this mode, ALL line items must have individual periods specified.</para>
    ///
    /// <para>3. Default behavior: If no service periods are specified (neither global
    /// nor individual),    the original invoice line item service periods will be used.</para>
    ///
    /// <para>Note: Mixing global and individual service periods in the same request
    /// is not allowed to prevent confusion.</para>
    ///
    /// <para>Service period dates are normalized to the start of the day in the customer's
    /// timezone to ensure consistent handling across different timezones.</para>
    ///
    /// <para>Date Format: Use start_date and end_date with format "YYYY-MM-DD" (e.g.,
    /// "2023-09-22") to match other Orb APIs like /v1/invoice_line_items.</para>
    ///
    /// <para>Note: Both start_date and end_date are inclusive - the service period
    /// will cover both the start date and end date completely (from start of start_date
    /// to end of end_date).</para>
    /// </summary>
    Task<SharedCreditNote> Create(
        CreditNoteCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of CreditNotes. Users can also filter by customer_id,
    /// subscription_id, or external_customer_id. The credit notes will be returned
    /// in reverse chronological order by `creation_time`.
    /// </summary>
    Task<CreditNoteListPageResponse> List(
        CreditNoteListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a single [`Credit Note`](/invoicing/credit-notes)
    /// given an identifier.
    /// </summary>
    Task<SharedCreditNote> Fetch(
        CreditNoteFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a single [`Credit Note`](/invoicing/credit-notes)
    /// given an identifier.
    /// </summary>
    Task<SharedCreditNote> Fetch(
        string creditNoteID,
        CreditNoteFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
