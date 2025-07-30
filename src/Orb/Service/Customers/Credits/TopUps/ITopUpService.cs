using System.Threading.Tasks;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Service.Customers.Credits.TopUps;

public interface ITopUpService
{
    /// <summary>
    /// This endpoint allows you to create a new top-up for a specified customer's
    /// balance. While this top-up is active, the customer's balance will added in
    /// increments of the specified amount whenever the balance reaches the specified threshold.
    ///
    /// If a top-up already exists for this customer in the same currency, the existing
    /// top-up will be replaced.
    /// </summary>
    Task<TopUpCreateResponse> Create(TopUpCreateParams @params);

    /// <summary>
    /// List top-ups
    /// </summary>
    Task<TopUpListPageResponse> List(TopUpListParams @params);

    /// <summary>
    /// This deactivates the top-up and voids any invoices associated with pending
    /// credit blocks purchased through the top-up.
    /// </summary>
    Task Delete(TopUpDeleteParams @params);

    /// <summary>
    /// This endpoint allows you to create a new top-up for a specified customer's
    /// balance. While this top-up is active, the customer's balance will added in
    /// increments of the specified amount whenever the balance reaches the specified threshold.
    ///
    /// If a top-up already exists for this customer in the same currency, the existing
    /// top-up will be replaced.
    /// </summary>
    Task<TopUpCreateByExternalIDResponse> CreateByExternalID(TopUpCreateByExternalIDParams @params);

    /// <summary>
    /// This deactivates the top-up and voids any invoices associated with pending
    /// credit blocks purchased through the top-up.
    /// </summary>
    Task DeleteByExternalID(TopUpDeleteByExternalIDParams @params);

    /// <summary>
    /// List top-ups by external ID
    /// </summary>
    Task<TopUpListByExternalIDPageResponse> ListByExternalID(TopUpListByExternalIDParams @params);
}
