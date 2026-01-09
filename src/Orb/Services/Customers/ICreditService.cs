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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICreditServiceWithRawResponse WithRawResponse { get; }

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

/// <summary>
/// A view of <see cref="ICreditService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICreditServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILedgerServiceWithRawResponse Ledger { get; }

    ITopUpServiceWithRawResponse TopUps { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/{customer_id}/credits`, but is otherwise the
    /// same as <see cref="ICreditService.List(CreditListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditListPage>> List(
        CreditListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CreditListParams, CancellationToken)"/>
    Task<HttpResponse<CreditListPage>> List(
        string customerID,
        CreditListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/external_customer_id/{external_customer_id}/credits`, but is otherwise the
    /// same as <see cref="ICreditService.ListByExternalID(CreditListByExternalIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditListByExternalIDPage>> ListByExternalID(
        CreditListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByExternalID(CreditListByExternalIDParams, CancellationToken)"/>
    Task<HttpResponse<CreditListByExternalIDPage>> ListByExternalID(
        string externalCustomerID,
        CreditListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
