using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Services.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBalanceTransactionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBalanceTransactionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceTransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates an immutable balance transaction that updates the customer's balance
    /// and returns back the newly created transaction.
    /// </summary>
    Task<BalanceTransactionCreateResponse> Create(
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(BalanceTransactionCreateParams, CancellationToken)"/>
    Task<BalanceTransactionCreateResponse> Create(
        string customerID,
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// ## The customer balance
    ///
    /// <para>The customer balance is an amount in the customer's currency, which
    /// Orb automatically applies to subsequent invoices. This balance can be adjusted
    /// manually via Orb's webapp on the customer details page. You can use this balance
    /// to provide a fixed mid-period credit to the customer. Commonly, this is done
    /// due to system downtime/SLA violation, or an adhoc adjustment discussed with
    /// the customer.</para>
    ///
    /// <para>If the balance is a positive value at the time of invoicing, it represents
    /// that the customer has credit that should be used to offset the amount due
    /// on the next issued invoice. In this case, Orb will automatically reduce the
    /// next invoice by the balance amount, and roll over any remaining balance if
    /// the invoice is fully discounted.</para>
    ///
    /// <para>If the balance is a negative value at the time of invoicing, Orb will
    /// increase the invoice's amount due with a positive adjustment, and reset the
    /// balance to 0.</para>
    ///
    /// <para>This endpoint retrieves all customer balance transactions in reverse
    /// chronological order for a single customer, providing a complete audit trail
    /// of all adjustments and invoice applications.</para>
    /// </summary>
    Task<BalanceTransactionListPage> List(
        BalanceTransactionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(BalanceTransactionListParams, CancellationToken)"/>
    Task<BalanceTransactionListPage> List(
        string customerID,
        BalanceTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBalanceTransactionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBalanceTransactionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceTransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /customers/{customer_id}/balance_transactions`, but is otherwise the
    /// same as <see cref="IBalanceTransactionService.Create(BalanceTransactionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BalanceTransactionCreateResponse>> Create(
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(BalanceTransactionCreateParams, CancellationToken)"/>
    Task<HttpResponse<BalanceTransactionCreateResponse>> Create(
        string customerID,
        BalanceTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/{customer_id}/balance_transactions`, but is otherwise the
    /// same as <see cref="IBalanceTransactionService.List(BalanceTransactionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BalanceTransactionListPage>> List(
        BalanceTransactionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(BalanceTransactionListParams, CancellationToken)"/>
    Task<HttpResponse<BalanceTransactionListPage>> List(
        string customerID,
        BalanceTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
