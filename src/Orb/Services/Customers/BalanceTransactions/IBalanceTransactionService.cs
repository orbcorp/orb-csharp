using System.Threading.Tasks;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Services.Customers.BalanceTransactions;

public interface IBalanceTransactionService
{
    /// <summary>
    /// Creates an immutable balance transaction that updates the customer's balance
    /// and returns back the newly created transaction.
    /// </summary>
    Task<BalanceTransactionCreateResponse> Create(BalanceTransactionCreateParams parameters);

    /// <summary>
    /// ## The customer balance
    ///
    /// The customer balance is an amount in the customer's currency, which Orb automatically
    /// applies to subsequent invoices. This balance can be adjusted manually via
    /// Orb's webapp on the customer details page. You can use this balance to provide
    /// a fixed mid-period credit to the customer. Commonly, this is done due to
    /// system downtime/SLA violation, or an adhoc adjustment discussed with the customer.
    ///
    /// If the balance is a positive value at the time of invoicing, it represents
    /// that the customer has credit that should be used to offset the amount due
    /// on the next issued invoice. In this case, Orb will automatically reduce the
    /// next invoice by the balance amount, and roll over any remaining balance if
    /// the invoice is fully discounted.
    ///
    /// If the balance is a negative value at the time of invoicing, Orb will increase
    /// the invoice's amount due with a positive adjustment, and reset the balance
    /// to 0.
    ///
    /// This endpoint retrieves all customer balance transactions in reverse chronological
    /// order for a single customer, providing a complete audit trail of all adjustments
    /// and invoice applications.
    /// </summary>
    Task<BalanceTransactionListPageResponse> List(BalanceTransactionListParams parameters);
}
