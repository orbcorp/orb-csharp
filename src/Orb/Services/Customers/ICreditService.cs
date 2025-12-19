using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Credits;
using Orb.Services.Customers.Credits;

namespace Orb.Services.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICreditService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILedgerService Ledger { get; }

    ITopUpService TopUps { get; }

    /// <summary>
    /// Returns a paginated list of unexpired, non-zero credit blocks for a customer.
    ///
    /// <para>If `include_all_blocks` is set to `true`, all credit blocks (including
    /// expired and depleted blocks) will be included in the response.</para>
    ///
    /// <para>Note that `currency` defaults to credits if not specified. To use a
    /// real world currency, set `currency` to an ISO 4217 string.</para>
    /// </summary>
    Task<CreditListPage> List(
        CreditListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CreditListParams, CancellationToken)"/>
    Task<CreditListPage> List(
        string customerID,
        CreditListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a paginated list of unexpired, non-zero credit blocks for a customer.
    ///
    /// <para>If `include_all_blocks` is set to `true`, all credit blocks (including
    /// expired and depleted blocks) will be included in the response.</para>
    ///
    /// <para>Note that `currency` defaults to credits if not specified. To use a
    /// real world currency, set `currency` to an ISO 4217 string.</para>
    /// </summary>
    Task<CreditListByExternalIDPage> ListByExternalID(
        CreditListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByExternalID(CreditListByExternalIDParams, CancellationToken)"/>
    Task<CreditListByExternalIDPage> ListByExternalID(
        string externalCustomerID,
        CreditListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
