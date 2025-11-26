using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Services.Customers.Credits;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITopUpService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITopUpService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows you to create a new top-up for a specified customer's
    /// balance. While this top-up is active, the customer's balance will added in
    /// increments of the specified amount whenever the balance reaches the specified threshold.
    ///
    /// <para>If a top-up already exists for this customer in the same currency,
    /// the existing top-up will be replaced.</para>
    /// </summary>
    Task<TopUpCreateResponse> Create(
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TopUpCreateParams, CancellationToken)"/>
    Task<TopUpCreateResponse> Create(
        string customerID,
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List top-ups
    /// </summary>
    Task<TopUpListPageResponse> List(
        TopUpListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TopUpListParams, CancellationToken)"/>
    Task<TopUpListPageResponse> List(
        string customerID,
        TopUpListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This deactivates the top-up and voids any invoices associated with pending
    /// credit blocks purchased through the top-up.
    /// </summary>
    Task Delete(TopUpDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TopUpDeleteParams, CancellationToken)"/>
    Task Delete(
        string topUpID,
        TopUpDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to create a new top-up for a specified customer's
    /// balance. While this top-up is active, the customer's balance will added in
    /// increments of the specified amount whenever the balance reaches the specified threshold.
    ///
    /// <para>If a top-up already exists for this customer in the same currency,
    /// the existing top-up will be replaced.</para>
    /// </summary>
    Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateByExternalID(TopUpCreateByExternalIDParams, CancellationToken)"/>
    Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
        string externalCustomerID,
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This deactivates the top-up and voids any invoices associated with pending
    /// credit blocks purchased through the top-up.
    /// </summary>
    Task DeleteByExternalID(
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteByExternalID(TopUpDeleteByExternalIDParams, CancellationToken)"/>
    Task DeleteByExternalID(
        string topUpID,
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List top-ups by external ID
    /// </summary>
    Task<TopUpListByExternalIDPageResponse> ListByExternalID(
        TopUpListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByExternalID(TopUpListByExternalIDParams, CancellationToken)"/>
    Task<TopUpListByExternalIDPageResponse> ListByExternalID(
        string externalCustomerID,
        TopUpListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
