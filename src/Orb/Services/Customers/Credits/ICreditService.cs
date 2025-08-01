using System.Threading.Tasks;
using Orb.Models.Customers.Credits;
using Ledger = Orb.Services.Customers.Credits.Ledger;
using TopUps = Orb.Services.Customers.Credits.TopUps;

namespace Orb.Services.Customers.Credits;

public interface ICreditService
{
    Ledger::ILedgerService Ledger { get; }

    TopUps::ITopUpService TopUps { get; }

    /// <summary>
    /// Returns a paginated list of unexpired, non-zero credit blocks for a customer.
    ///
    /// If `include_all_blocks` is set to `true`, all credit blocks (including expired
    /// and depleted blocks) will be included in the response.
    ///
    /// Note that `currency` defaults to credits if not specified. To use a real
    /// world currency, set `currency` to an ISO 4217 string.
    /// </summary>
    Task<CreditListPageResponse> List(CreditListParams @params);

    /// <summary>
    /// Returns a paginated list of unexpired, non-zero credit blocks for a customer.
    ///
    /// If `include_all_blocks` is set to `true`, all credit blocks (including expired
    /// and depleted blocks) will be included in the response.
    ///
    /// Note that `currency` defaults to credits if not specified. To use a real
    /// world currency, set `currency` to an ISO 4217 string.
    /// </summary>
    Task<CreditListByExternalIDPageResponse> ListByExternalID(CreditListByExternalIDParams @params);
}
