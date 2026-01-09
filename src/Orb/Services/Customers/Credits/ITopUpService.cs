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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITopUpServiceWithRawResponse WithRawResponse { get; }

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
    Task<TopUpListPage> List(
        TopUpListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TopUpListParams, CancellationToken)"/>
    Task<TopUpListPage> List(
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
    Task<TopUpListByExternalIDPage> ListByExternalID(
        TopUpListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByExternalID(TopUpListByExternalIDParams, CancellationToken)"/>
    Task<TopUpListByExternalIDPage> ListByExternalID(
        string externalCustomerID,
        TopUpListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITopUpService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITopUpServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITopUpServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /customers/{customer_id}/credits/top_ups`, but is otherwise the
    /// same as <see cref="ITopUpService.Create(TopUpCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TopUpCreateResponse>> Create(
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TopUpCreateParams, CancellationToken)"/>
    Task<HttpResponse<TopUpCreateResponse>> Create(
        string customerID,
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/{customer_id}/credits/top_ups`, but is otherwise the
    /// same as <see cref="ITopUpService.List(TopUpListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TopUpListPage>> List(
        TopUpListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TopUpListParams, CancellationToken)"/>
    Task<HttpResponse<TopUpListPage>> List(
        string customerID,
        TopUpListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /customers/{customer_id}/credits/top_ups/{top_up_id}`, but is otherwise the
    /// same as <see cref="ITopUpService.Delete(TopUpDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TopUpDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TopUpDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string topUpID,
        TopUpDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /customers/external_customer_id/{external_customer_id}/credits/top_ups`, but is otherwise the
    /// same as <see cref="ITopUpService.CreateByExternalID(TopUpCreateByExternalIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TopUpCreateByExternalIDResponse>> CreateByExternalID(
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateByExternalID(TopUpCreateByExternalIDParams, CancellationToken)"/>
    Task<HttpResponse<TopUpCreateByExternalIDResponse>> CreateByExternalID(
        string externalCustomerID,
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /customers/external_customer_id/{external_customer_id}/credits/top_ups/{top_up_id}`, but is otherwise the
    /// same as <see cref="ITopUpService.DeleteByExternalID(TopUpDeleteByExternalIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DeleteByExternalID(
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteByExternalID(TopUpDeleteByExternalIDParams, CancellationToken)"/>
    Task<HttpResponse> DeleteByExternalID(
        string topUpID,
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/external_customer_id/{external_customer_id}/credits/top_ups`, but is otherwise the
    /// same as <see cref="ITopUpService.ListByExternalID(TopUpListByExternalIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TopUpListByExternalIDPage>> ListByExternalID(
        TopUpListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByExternalID(TopUpListByExternalIDParams, CancellationToken)"/>
    Task<HttpResponse<TopUpListByExternalIDPage>> ListByExternalID(
        string externalCustomerID,
        TopUpListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
