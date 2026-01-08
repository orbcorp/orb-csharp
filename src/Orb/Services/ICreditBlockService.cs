using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.CreditBlocks;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICreditBlockService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditBlockService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint returns a credit block identified by its block_id.
    /// </summary>
    Task<CreditBlockRetrieveResponse> Retrieve(
        CreditBlockRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CreditBlockRetrieveParams, CancellationToken)"/>
    Task<CreditBlockRetrieveResponse> Retrieve(
        string blockID,
        CreditBlockRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint deletes a credit block by its ID.
    ///
    /// <para>When a credit block is deleted: - The block is removed from the customer's
    /// credit ledger. - Any usage of the credit block is reversed, and the ledger
    /// is replayed as if the block never existed. - If invoices were generated from
    /// the purchase of the credit block, they will be deleted if in draft status,
    ///   voided if issued, or a credit note will be issued if the invoice is paid.</para>
    ///
    /// <para><Note> Issued invoices that had credits applied from this block will
    /// not be regenerated, but the ledger will reflect the state as if credits from
    /// the deleted block were never applied. </Note></para>
    /// </summary>
    Task Delete(CreditBlockDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CreditBlockDeleteParams, CancellationToken)"/>
    Task Delete(
        string blockID,
        CreditBlockDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
