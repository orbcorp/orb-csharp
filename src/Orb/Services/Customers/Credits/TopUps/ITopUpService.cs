using System;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Services.Customers.Credits.TopUps;

public interface ITopUpService
{
    ITopUpService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows you to create a new top-up for a specified customer's
    /// balance. While this top-up is active, the customer's balance will added in
    /// increments of the specified amount whenever the balance reaches the specified threshold.
    ///
    /// If a top-up already exists for this customer in the same currency, the existing
    /// top-up will be replaced.
    /// </summary>
    Task<TopUpCreateResponse> Create(TopUpCreateParams parameters);

    /// <summary>
    /// List top-ups
    /// </summary>
    Task<TopUpListPageResponse> List(TopUpListParams parameters);

    /// <summary>
    /// This deactivates the top-up and voids any invoices associated with pending
    /// credit blocks purchased through the top-up.
    /// </summary>
    Task Delete(TopUpDeleteParams parameters);

    /// <summary>
    /// This endpoint allows you to create a new top-up for a specified customer's
    /// balance. While this top-up is active, the customer's balance will added in
    /// increments of the specified amount whenever the balance reaches the specified threshold.
    ///
    /// If a top-up already exists for this customer in the same currency, the existing
    /// top-up will be replaced.
    /// </summary>
    Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
        TopUpCreateByExternalIDParams parameters
    );

    /// <summary>
    /// This deactivates the top-up and voids any invoices associated with pending
    /// credit blocks purchased through the top-up.
    /// </summary>
    Task DeleteByExternalID(TopUpDeleteByExternalIDParams parameters);

    /// <summary>
    /// List top-ups by external ID
    /// </summary>
    Task<TopUpListByExternalIDPageResponse> ListByExternalID(
        TopUpListByExternalIDParams parameters
    );
}
